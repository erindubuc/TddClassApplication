using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDGrid
{
    public class GameBoard 
    {
        public const int Rows = 15;
        public const int Columns = 15;
        public bool[,] boardState = new bool[Rows,Columns];
        public bool isCellChecked = false;
        public int neighborCount = 0;
        private int _lastColumn = Columns - 1;
        private int _lastRow = Rows - 1;
        private string falseColor = "gray";
        private string trueColor = "yellow";

        public GameBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    boardState[row, col] = isCellChecked;

                }
            }
        }

        public bool GetStateOfCell(int row, int col)
        {
            return boardState[row,col];
        }

        public bool SwitchStateOfCell(int row, int col)
        {
            if (boardState[row, col] == isCellChecked)
                boardState[row,col] = true;
            else
                boardState[row,col] = isCellChecked;
            return boardState[row, col];
        }

        public string GetColorOfCell(int row, int col)
        {
            string color = "";
            if (GetStateOfCell(row, col) == false)
                color = falseColor;
            else
                color = trueColor;

            return color;
        }

        public int CountHorizontalNeighborsOfCell(int row, int col)
        {
            int horizontalNeighborCount = 0;
            
            if (col == 0)
            {
                if (boardState[row, col + 1] == true)
                    horizontalNeighborCount++;
            }
            else if(col == _lastColumn)
            {
                if (boardState[row, col - 1] == true)
                    horizontalNeighborCount++;
            }
            else
            {
                if (boardState[row, col - 1] == true)
                    horizontalNeighborCount++;
                if (boardState[row, col + 1] == true)
                    horizontalNeighborCount++;
            }
            
            return horizontalNeighborCount;
        }

        public int CountVerticalNeighborsOfCell(int row, int col)
        {
            int verticalNeighborCount = 0;
            
            if (row == 0)
            {
                if (boardState[row + 1, col] == true)
                    verticalNeighborCount++;
            }
            else if (row == _lastRow)
            {
                if (boardState[row - 1, col] == true)
                    verticalNeighborCount++;
            }
            else
            {
                if (boardState[row - 1, col] == true)
                    verticalNeighborCount++;
                if (boardState[row + 1, col] == true)
                    verticalNeighborCount++;
            }
            
            return verticalNeighborCount;
        }

        public int CountDiagonalNeighborsOfCell(int row, int col)
        {
            int diagonalNeighborCount = 0;
            int lastColumn = _lastColumn;
            int lastRow = _lastRow;
            
            if (col == 0)
            {
                if (row == 0)
                {
                    if (boardState[row + 1, col + 1] == true)
                        diagonalNeighborCount++;
                }
                else if (row == _lastRow)
                {
                    if (boardState[row - 1, col + 1] == true)
                        diagonalNeighborCount++;
                }
                else
                {
                    if (boardState[row - 1, col + 1] == true)
                        diagonalNeighborCount++;
                    if (boardState[row + 1, col + 1] == true)
                        diagonalNeighborCount++;
                }
            }
            else if (col == _lastColumn)
            {
                if (row == 0)
                {
                    if (boardState[row + 1, col - 1])
                        diagonalNeighborCount++;
                }
                else if (row == _lastRow)
                {
                    if (boardState[row - 1, col - 1] == true)
                        diagonalNeighborCount++;
                }
                else
                {
                    if (boardState[row - 1, col - 1] == true)
                        diagonalNeighborCount++;
                    if (boardState[row + 1, col - 1] == true)
                        diagonalNeighborCount++;
                }
            }
            else if (row == 0)
            {

                if (boardState[row + 1, col + 1] == true)
                    diagonalNeighborCount++;
                if (boardState[row + 1, col - 1] == true)
                    diagonalNeighborCount++;
            }
            else if (row == _lastRow)
            {
                if (boardState[row - 1, col - 1] == true)
                    diagonalNeighborCount++;
                if (boardState[row - 1, col + 1] == true)
                    diagonalNeighborCount++;
            }
            else
            {
                // diag left
                if (boardState[row - 1, col - 1] == true)
                    diagonalNeighborCount++;
                if (boardState[row + 1, col + 1] == true)
                    diagonalNeighborCount++;
                // diag right
                if (boardState[row - 1, col + 1] == true)
                    diagonalNeighborCount++;
                if (boardState[row + 1, col - 1] == true)
                    diagonalNeighborCount++;
            }

            return diagonalNeighborCount;
        }

            public int CountActiveNeighborsOfCell(int row, int col)
            {
                int vertical = CountVerticalNeighborsOfCell(row, col);
                int horizontal = CountHorizontalNeighborsOfCell(row, col);
                int diagonal = CountDiagonalNeighborsOfCell(row, col);

                neighborCount = vertical + horizontal + diagonal;

                return neighborCount;
            }

            public bool DetermineNextStateOfCell(int row, int col)
            {
                int neighbors = CountActiveNeighborsOfCell(row, col);

                if (boardState[row, col] == true)
                {
                    // each cell with one or no neighbors dies, as if by solitude.
                    if (neighbors <= 1)
                    {
                        if (boardState[row, col] == true)
                            SwitchStateOfCell(row, col);
                    }

                    // each cell with four or more neighbors dies, as if by overpopulation.
                    if (neighbors >= 4)
                    {
                        if (boardState[row, col] == true)
                            SwitchStateOfCell(row, col);
                    }

                    // each cell with two or three neighbors survives.
                    if (neighbors == 2 || neighbors == 3)
                    {
                        if (boardState[row, col] == false)
                            SwitchStateOfCell(row, col);
                    }
                }
                else if (boardState[row, col] == false)
                {
                    if (neighbors == 3)
                        SwitchStateOfCell(row, col);
                }

                return GetStateOfCell(row, col);
            }

            public void DrawBoard()
            {
                for (int row = 0; row < Rows; row++)
                {
                    string row1 = "| ";
                    string row2 = "";

                    for (int col = 0; col < Columns; col++)
                    {
                        row1 = row1 + boardState[row, col] + " | ";
                        row2 += "+---";
                    }
                    Console.WriteLine(row1);
                    Console.WriteLine(row2 + "+");
                }
            }

        /*
        public void DisplayBoard()
        {
            for (int row = 0; row < boardState.GetLength(1); row++)
            {
                for (int col = 0; col < boardState.GetLength(0); col++)
                {
                    Console.WriteLine(boardState[row, col]);
                }
            }
        }
        */

    }
}
