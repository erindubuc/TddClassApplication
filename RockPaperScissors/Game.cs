using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class Game 
    {
        public static Gesture DetermineWhoWins(Gesture player1, Gesture player2)
        {
            if (player1 == Gesture.Rock && player2 == Gesture.Paper || player2 == Gesture.Rock && player1 == Gesture.Paper)
                return Gesture.Paper;
            if (player1 == Gesture.Rock && player2 == Gesture.Scissor || player2 == Gesture.Rock && player1 == Gesture.Scissor)
                return Gesture.Rock;
            if (player1 == Gesture.Scissor && player2 == Gesture.Paper || player2 == Gesture.Scissor && player1 == Gesture.Paper)
                return Gesture.Scissor;
            return Gesture.Draw;
        }
    }
}
