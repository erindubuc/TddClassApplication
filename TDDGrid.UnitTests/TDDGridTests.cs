using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDGrid.UnitTests
{
    [TestFixture]
    public class TDDGridTests
    {
        private GameBoard _gameBoard;
        public int row;
        public int col;

        [SetUp]
        public void TestFixtureSetup()
        {
            _gameBoard = new GameBoard();
            //_gameBoard.SetAllBoardCellStatesToFalse();
        }

        [Test]
        public void EnterRowAndCol_ReturnStateOfCell()
        {
            row = 2;
            col = 4;
            var expected = false;
            var actual = _gameBoard.GetStateOfSpecificCell(row, col);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void IfStateOfCellIsFalse_SwitchToTrue()
        {
            row = 2;
            col = 4;
            var expected = true;
            var actual = _gameBoard.SwitchStateOfCell(row, col);

            Assert.AreEqual(expected, actual);
        }

        
        [Test]
        public void IfStateOfCellIsTrue_SwitchToFalse()
        {
            row = 5;
            col = 7;
            _gameBoard.boardState[row, col] = true;

            var expected = false;
            var actual = _gameBoard.SwitchStateOfCell(row, col);

            Assert.AreEqual(expected, actual);
        }
    }
}
