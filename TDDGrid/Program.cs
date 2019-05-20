using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDGrid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameBoard game = new GameBoard();
            game.SetAllBoardCoordinatesAndStateAsFalse();
            game.DrawBoard();
            //game.DisplayBoard();

            game.DisplayCoordintatesAndState();
            Console.ReadLine();
        }
    }
}
