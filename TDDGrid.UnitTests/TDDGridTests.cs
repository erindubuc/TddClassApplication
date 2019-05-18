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

        [SetUp]
        public void TestFixtureSetup()
        {
            _gameBoard = new GameBoard();
            _gameBoard.SetInitialBoardState();
        }

        [Test]
        public void InsertCharIntoOneCellOfBoard()
        {
            int row = 1;
            int col = 1;

            var expected = 'x';
            var actual = _gameBoard.InsertCharIntoChosenCell(row, col);

            Assert.AreEqual(expected, actual);
        }

        public void ChooseOneCell_ReturnEmptyBoard()
        {

        }
    }
}
