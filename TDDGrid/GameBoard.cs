using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDGrid
{
    public class GameBoard
    {
        public char[,] boardState = new char[5, 5];

        public void DrawBoard()
        {
            for (int row = 0; row < boardState.GetLength(1); row++)
            {
                string row1 = "| ";
                string row2 = "";

                for (int col = 0; col < boardState.GetLength(0); col++)
                {
                    row1 = row1 + boardState[row, col] + " | ";
                    row2 += "+---";
                }
                Console.WriteLine(row1);
                Console.WriteLine(row2 + "+");
            }
        }

        public void SetInitialBoardState()
        {
            for (int row = 0; row < boardState.GetLength(1); row++)
            {
                for (int col = 0; col < boardState.GetLength(0); col++)
                {
                    boardState[row, col] = 'x';
                }
            }
        }


        public char InsertCharIntoChosenCell(int row, int col)
        {
            return (boardState[row,col] = 'x');
        }

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
    }
}
