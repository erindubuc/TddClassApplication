using NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Challenge_Winner_Validity.Models;
using static Challenge_Winner_Validity.Models.Board;

namespace Challenge_Winner_Validity.Tests
{
    [TestFixture]
    
    public class ConnectFourTests
    {
        public State[,] board = new State[6, 7];
        State player1 = State.X;
        State player2 = State.O;

        [Test]
        public void ReturnEmptyBoard()
        {
            State[,] input = new State[,] {
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank }
            };
            bool actual = Board.CheckForWinner(input);
            bool expected = false;
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourXInARowHorizontally()
        {
            State[,] input = new State[,] {
                { player1, player1, player1, player1, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourOInARowHorizontally()
        {
            State[,] input = new State[,] {
                { State.blank, player1, player1, player1, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, player2, player2, player2, player2 },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourXInARowVertically()
        {
            State[,] input = new State[,] {
                { State.blank, player1, player1, player1, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, player1, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, player1, State.blank, player2, player2, player2, player2 },
                { State.blank, player1, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, player1, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourOInARowVertically()
        {
            State[,] input = new State[,] {
                { State.blank, player1, player1, player2, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, player2, State.blank, State.blank, State.blank },
                { State.blank, player1, State.blank, player2, State.blank, State.blank, State.blank },
                { State.blank, player1, State.blank, player2, player2, player2, player2 },
                { State.blank, player1, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, player2, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourXInARowDiagonally_LowerLeftToUpperRight()
        {
            State[,] input = new State[,] {
                { State.blank, player1, player1, player2, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, player2, player1, State.blank, State.blank },
                { State.blank, player1, State.blank, player1, State.blank, State.blank, State.blank },
                { State.blank, player1, player1, player2, player2, player2, player2 },
                { State.blank, player1, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, player2, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourXInARowDiagonally_UpperLeftToLowerRight()
        {
            State[,] input = new State[,] {
                { State.blank, player1, player1, player2, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, player1, player1, State.blank, State.blank },
                { State.blank, player1, State.blank, State.blank, player1, State.blank, State.blank },
                { State.blank, player1, player1, player2, player2, player1, player2 },
                { State.blank, player1, State.blank, State.blank, State.blank, State.blank, State.blank },
                { State.blank, player2, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourOInARowDiagonally_LowerLeftToUpperRight()
        {
            State[,] input = new State[,] {
                { State.blank, player1, player1, player2, State.blank, State.blank, State.blank },
                { State.blank, State.blank, State.blank, player2, player1, State.blank, State.blank },
                { State.blank, player1, State.blank, player1, player2, State.blank, State.blank },
                { State.blank, player1, player1, player2, player2, State.blank, player2 },
                { State.blank, player1, player2, State.blank, State.blank, State.blank, State.blank },
                { State.blank, player2, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTrueIfFourOInARowDiagonally_UpperLeftToLowerRight()
        {
            State[,] input = new State[,] {
                { player1, player1, player1, player2, State.blank, State.blank, State.blank },
                { State.blank, player2, State.blank, player1, player1, State.blank, State.blank },
                { State.blank, player1, player2, State.blank, player1, State.blank, State.blank },
                { State.blank, player1, player1, player2, player2, player1, player2 },
                { State.blank, player1, State.blank, State.blank, player2, State.blank, State.blank },
                { State.blank, player2, State.blank, State.blank, State.blank, State.blank, State.blank }
            };

            bool actual = Board.CheckForWinner(input);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

    }
}
    

