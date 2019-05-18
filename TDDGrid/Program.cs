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
            game.SetInitialBoardState();
            game.DrawBoard();
            //game.DisplayBoard();
            Console.ReadLine();
        }
    }
}
