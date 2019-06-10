using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Challenge_Winner_Validity.Models
{
    public class Board
    {
        public State[,] board = new State[6, 7];

        public Board(int rows, int columns)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = State.blank;
                }
            }

        }

        public enum State
        {
            X,
            O,
            blank
        }

        public static bool CheckForHorizontalWinner(State[,] board)
        {
            int xCounter = 0;
            int oCounter = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == State.X)
                        xCounter++;

                    if (board[row, col] == State.O)
                        oCounter++;

                    if (xCounter >= 1 && board[row, col] == State.O)
                    {
                        xCounter = 0;
                        oCounter = 1;
                    }
                    else if (oCounter >= 1 && board[row, col] == State.X)
                    {
                        xCounter = 1;
                        oCounter = 0;
                    }
                    else if (xCounter >= 1 && board[row, col] == State.blank || oCounter >= 1 && board[row, col] == State.blank)
                    {
                        xCounter = 0;
                        oCounter = 0;
                    }
                    if (xCounter == 4 || oCounter == 4)
                    {
                        return true;
                    }

                }
            }

            return false;
        }

        public static bool CheckForVerticalWinner(State[,] board)
        {
            int xCounter = 0;
            int oCounter = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {

                    if (board[row, col] == State.X && board[row + 1, col] == State.X)
                    {
                        xCounter++;
                        int nextRow = 1;
                        while (board[row + nextRow, col] == State.X)
                        {
                            xCounter++;
                            nextRow++;

                            if (xCounter == 4)
                                return true;
                        }
                        xCounter = 0;

                    }

                    if (board[row, col] == State.O && board[row + 1, col] == State.O)
                    {
                        oCounter++;
                        int nextRow = 1;
                        while (board[row + nextRow, col] == State.O)
                        {
                            oCounter++;
                            nextRow++;

                            if (oCounter == 4)
                                return true;
                        }
                        oCounter = 0;

                    }
                }
            }
            return false;
        }

        public static bool CheckForDiagonalWinner(State[,] board)
        {
            int xCounter = 0;
            int oCounter = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == State.X && board[row + 1, col - 1] == State.X)
                    {
                        xCounter++;
                        int nextRow = 1;
                        int nextCol = 1;
                        while (board[row + nextRow, col - nextCol] == State.X)
                        {
                            xCounter++;
                            nextRow++;
                            nextCol++;

                            if (xCounter == 4)
                                return true;
                        }
                        xCounter = 0;
                    }

                    if (board[row, col] == State.X && board[row + 1, col + 1] == State.X)
                    {
                        xCounter++;
                        int nextRow = 1;
                        int nextCol = 1;
                        while (board[row + nextRow, col + nextCol] == State.X)
                        {
                            xCounter++;
                            nextRow++;
                            nextCol++;

                            if (xCounter == 4)
                                return true;
                        }
                        xCounter = 0;
                    }

                    if (board[row, col] == State.O && board[row + 1, col - 1] == State.O)
                    {
                        oCounter++;
                        int nextRow = 1;
                        int nextCol = 1;
                        while (board[row + nextRow, col - nextCol] == State.O)
                        {
                            oCounter++;
                            nextRow++;
                            nextCol++;

                            if (oCounter == 4)
                                return true;
                        }
                        oCounter = 0;
                    }

                    if (board[row, col] == State.O && board[row + 1, col + 1] == State.O)
                    {
                        oCounter++;
                        int nextRow = 1;
                        int nextCol = 1;
                        while (board[row + nextRow, col + nextCol] == State.O)
                        {
                            oCounter++;
                            nextRow++;
                            nextCol++;

                            if (oCounter == 4)
                                return true;
                        }
                        oCounter = 0;
                    }
                }
            }
            return false;
        }
        /*
        for (int row = 5; row >= 0; row--)
            {
                for (int column = 6; column >= 0; column--)
                {
                    State currentCell = board[row, column];
                    if (currentCell == State.X || currentCell == State.O)
                    {
                        if (column >= 3 && currentCell == board[row, column - 1] && currentCell == board[row, column - 2] && currentCell == board[row, column - 3])
                            return true;

                        if (row >= 3 && currentCell == board[row - 1, column] && currentCell == board[row - 2, column] && currentCell == board[row - 3, column])
                            return true;

                        if (column >= 3 && row >= 3 && currentCell == board[row - 1, column - 1] && currentCell == board[row - 2, column - 2] && currentCell == board[row - 3, column - 3])
                            return true;

                        if (column <= 3 && row >= 3 && currentCell == board[row - 1, column + 1] && currentCell == board[row - 2, column + 2] && currentCell == board[row - 3, column + 3])
                            return true;
                    }
                }
            }
            return false;
        
    */
    }
}