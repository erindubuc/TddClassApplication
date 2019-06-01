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
        //public List<int> activeCells = new List<int>(); 

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

        public bool GetStateOfSpecificCell(int row, int col)
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

        public int CountAllHorizontalNeighborsOfActiveCell(int row, int col)
        {
            int horizontalNeighborCount = 0;
            if (boardState[row, col] == true)
            {
                if (col == 0)
                {
                    // horz
                    if (boardState[row, col + 1] == true)
                        horizontalNeighborCount++;
                }
                else if(col == GameBoard.Columns - 1)
                {
                    // horz
                    if (boardState[row, col - 1] == true)
                        horizontalNeighborCount++;
                }
                else
                {
                    // horz
                    if (boardState[row, col - 1] == true)
                        horizontalNeighborCount++;
                    if (boardState[row, col + 1] == true)
                        horizontalNeighborCount++;
                }
            }
            return horizontalNeighborCount;
        }

        public int CountAllVerticalNeighborsOfActiveCell(int row, int col)
        {
            int verticalNeighborCount = 0;
            if (boardState[row, col] == true)
            {
                if (row == 0)
                {
                    if (boardState[row + 1, col] == true)
                        neighborCount++;
                }
                else if (row == GameBoard.Rows - 1)
                {
                    if (boardState[row - 1, col] == true)
                        verticalNeighborCount++;
                }
                else
                {
                    // vert
                    if (boardState[row - 1, col] == true)
                        verticalNeighborCount++;
                    if (boardState[row + 1, col] == true)
                        verticalNeighborCount++;

                }
            }
            return verticalNeighborCount;
        }

        public int CountAllDiagonalNeighborsOfActiveCell(int row, int col)
        {
            int diagonalNeighborCount = 0;
            if (boardState[row, col] == true)
            {
                if (col == 0)
                {
                    if (row == 0)
                    {
                        if (boardState[row + 1, col + 1] == true)
                            diagonalNeighborCount++;
                    }

                    if (row == GameBoard.Rows - 1)
                    {
                        if (boardState[row - 1, col + 1] == true)
                            diagonalNeighborCount++;
                    }

                    if (boardState[row + 1, col + 1] == true)
                        diagonalNeighborCount++;

                    if (boardState[row - 1, col + 1] == true)
                        diagonalNeighborCount++;

                }
                else if (col == GameBoard.Columns - 1)
                {
                    if (row == 0)
                    {
                        if (boardState[row + 1, col - 1] == true)
                            diagonalNeighborCount++;
                    }
                    if (row == GameBoard.Rows - 1)
                    {
                        if (boardState[row - 1, col - 1] == true)
                            diagonalNeighborCount++;
                    }

                    if (boardState[row + 1, col - 1] == true)
                        diagonalNeighborCount++;

                    if (boardState[row - 1, col - 1] == true)
                        diagonalNeighborCount++;
                }
                /*
                else if (row == 0)
                {
                    if ()
                }
                else if (row == GameBoard.Rows - 1)
                {
                }
                */
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
        public int CountActiveNeighborsOfActiveCell(int row, int col)
        {
            int neighborCount = 0;
            if (boardState[row, col] == true)
            {
                if (col == 0)
                {
                    // vert
                    if (boardState[row - 1, col] == true)
                        neighborCount++;
                    if (boardState[row + 1, col] == true)
                        neighborCount++;
                    // horz
                    if (boardState[row, col + 1] == true)
                        neighborCount++;
                    // diag left
                    if (boardState[row + 1, col + 1] == true)
                        neighborCount++;
                    // diag right
                    if (boardState[row - 1, col + 1] == true)
                        neighborCount++;




                }
                else
                {
                    // vert
                    if (boardState[row - 1, col] == true)
                        neighborCount++;
                    if (boardState[row + 1, col] == true)
                        neighborCount++;
                    // horz
                    if (boardState[row, col - 1] == true)
                        neighborCount++;
                    if (boardState[row, col + 1] == true)
                        neighborCount++;
                    // diag left
                    if (boardState[row - 1, col - 1] == true)
                        neighborCount++;
                    if (boardState[row + 1, col + 1] == true)
                        neighborCount++;
                    // diag right
                    if (boardState[row - 1, col + 1] == true)
                        neighborCount++;
                    if (boardState[row + 1, col - 1] == true)
                        neighborCount++;
                }
                
            }
            return neighborCount;
        }
        /*
        public List<int> GetAllActiveCellsInBoard()
        {
            for (int row = 0; row < GameBoard.Rows; row++)
            {
                for (int col = 0; col < GameBoard.Columns; col++)
                {
                    if (GetStateOfSpecificCell(row,col) == true)
                    {
                        activeCells.Add(row);
                        activeCells.Add(col);
                    }
                }
            }
            return activeCells;
        }
        */
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
