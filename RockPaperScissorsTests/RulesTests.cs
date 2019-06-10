using NUnit.Framework;
using RockPaperScissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsTests
{
    [TestFixture]
    public class RulesTests
    {
        Gesture Rock = Gesture.Rock;
        Gesture Paper = Gesture.Paper;
        Gesture Scissor = Gesture.Scissor;
        Gesture Draw = Gesture.Draw;

        Gesture player1;
        Gesture player2;
        
        [Test]
        public void IfRockAndScissors_RockBeatsScissors()
        {
            player1 = Rock;
            player2 = Scissor;

            var expected = Rock;
            var actual = Game.DetermineWhoWins(player1, player2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfScissorsAndPaper_ScissorsBeatsPaper()
        {
            player1 = Paper;
            player2 = Scissor;

            var expected = Scissor;
            var actual = Game.DetermineWhoWins(player1, player2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfPaperAndRock_PaperBeatsRock()
        {
            player1 = Paper;
            player2 = Rock;

            var expected = Paper;
            var actual = Game.DetermineWhoWins(player1, player2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfSameGesture_ReturnDraw()
        {
            player1 = Paper;
            player2 = Paper;

            var expected = Draw;
            var actual = Game.DetermineWhoWins(player1, player2);

            Assert.AreEqual(expected, actual);
        }

    }
}
