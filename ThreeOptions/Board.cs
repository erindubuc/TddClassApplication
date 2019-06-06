using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeOptions
{
    class Board
    {
        public int Rows = 5;
        public int Columns = 5;
        public Colors[,] board = new Colors[5, 5];
        public Board()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    board[row, col] = Colors.Gray;
                }
            }
        }
        public void DisplayBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Console.WriteLine(board[row, col]);
                }
            }
        }
    }

}
}
