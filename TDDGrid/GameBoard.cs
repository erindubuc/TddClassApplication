using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDGrid
{
    public class GameBoard : Coordinates
    {
        public bool[,] boardState = new bool[8, 8];
        public Dictionary<Coordinates, bool> boardCoords = new Dictionary<Coordinates, bool>();


        public Dictionary<Coordinates, bool> SetAllBoardCoordinatesAndStateAsFalse()
        {
            for (int row = 0; row < boardState.GetLength(1); row++)
            {
                for (int col = 0; col < boardState.GetLength(0); col++)
                {
                    var coords = new Coordinates(row, col);
                    boardState[row, col] = coords.State;
                    boardCoords.Add(coords, coords.State);
                }
            }
            return boardCoords;
        }

        public bool GetStateOfParticularCellCoordinates(Coordinates coords)
        {
            return coords.State;
        }

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


        public bool TurnStateOfCellToTrue(Coordinates coords)
        {
            // add if statement for if it is already true
            return coords.State = true;
        }

        public bool SwitchAllTrueStatesToFalseStates(Coordinates coords)
        {
            return coords.State = false;
        }
        
        public void DisplayCoordintatesAndState()
        {
            foreach (var item in boardCoords)
            {
                Console.WriteLine("[{0}, {1}] : {2}", item.Key.Row, item.Key.Column, item.Value);
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
