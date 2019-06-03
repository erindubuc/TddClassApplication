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
        }

        [Test]
        public void EnterRowAndColumnOfUncheckedCell_ReturnFalse()
        {
            bool expected = false;
            bool actual = _gameBoard.GetStateOfCell(2, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EnterRowAndColumnOfCheckedCell_ReturnTrue()
        {
            _gameBoard.SwitchStateOfCell(14, 4);

            bool expected = true;
            bool actual = _gameBoard.GetStateOfCell(14, 4);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EnterRowAndCol_ReturnStateOfCell()
        {
            var expected = false;
            var actual = _gameBoard.GetStateOfCell(2, 4);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfStateOfCellIsFalse_SwitchToTrue()
        {
            var expected = true;
            var actual = _gameBoard.SwitchStateOfCell(2, 4);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void IfStateOfCellIsTrue_SwitchToFalse()
        {
            row = 5;
            col = 7;
            _gameBoard.boardState[row, col] = true;

            var expected = false;
            var actual = _gameBoard.SwitchStateOfCell(5, 7);

            Assert.AreEqual(expected, actual);
        }

        /*  For a space that is 'populated':
                Each cell with one or no neighbors dies, as if by solitude.
                Each cell with four or more neighbors dies, as if by overpopulation.
                Each cell with two or three neighbors survives.
            For a space that is 'empty' or 'unpopulated'
                Each cell with three neighbors becomes populated.
        */
      

        [Test]
        public void CheckCellForHorizontalNeighbors_ReturnCountOfHorizontalNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 6);
            _gameBoard.SwitchStateOfCell(3, 4);

            var expected = 2;
            var actual = _gameBoard.CountHorizontalNeighborsOfCell(3, 5);
            Assert.AreEqual(expected, actual);
        }

        
        [Test]
        public void CheckUpperEdgeCellForActiveNeighbors()
        {
            _gameBoard.SwitchStateOfCell(0, 6);
            _gameBoard.SwitchStateOfCell(1, 6);
            _gameBoard.SwitchStateOfCell(0, 8);
            _gameBoard.SwitchStateOfCell(1, 7);
            _gameBoard.SwitchStateOfCell(1, 8);

            int expected = 5;
            int actual = _gameBoard.CountActiveNeighborsOfCell(0, 7);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckLowerEdgeCellForActiveNeighbors()
        {
            _gameBoard.SwitchStateOfCell(13, 8);
            _gameBoard.SwitchStateOfCell(14, 7);

            int expected = 2;
            int actual = _gameBoard.CountActiveNeighborsOfCell(14, 8);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckRightEdgeCellForActiveNeighbors()
        {
            _gameBoard.SwitchStateOfCell(7, 13);
            _gameBoard.SwitchStateOfCell(8, 13);
            _gameBoard.SwitchStateOfCell(8, 14);

            int expected = 3;
            int actual = _gameBoard.CountActiveNeighborsOfCell(7, 14);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckLeftEdgeCellForActiveNeighbors()
        {
            _gameBoard.SwitchStateOfCell(9, 1);
            _gameBoard.SwitchStateOfCell(10, 1);

            int expected = 2;
            int actual = _gameBoard.CountActiveNeighborsOfCell(9, 0);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckCellForVerticalNeighbors_ReturnCountOfVerticalNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            _gameBoard.SwitchStateOfCell(2, 5);
            _gameBoard.SwitchStateOfCell(4, 5);

            int expected = 2;
            int actual = _gameBoard.CountVerticalNeighborsOfCell(3, 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckCellForDiagonalNeighbors_ReturnCountOfDiagonalNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            _gameBoard.SwitchStateOfCell(2, 4);
            _gameBoard.SwitchStateOfCell(4, 6);

            int expected = 2;
            int actual = _gameBoard.CountDiagonalNeighborsOfCell(3, 5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetCountOfActiveNeighborsOfCell_ReturnCountOfNeighbors_TestCaseOf4Neighbors()
        {
            _gameBoard.SwitchStateOfCell(2, 7);
            _gameBoard.SwitchStateOfCell(3, 7);
            _gameBoard.SwitchStateOfCell(4, 7);
            _gameBoard.SwitchStateOfCell(3, 5);

            int expected = 4;
            int actual = _gameBoard.CountActiveNeighborsOfCell(3, 6);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void GetCountOfActiveNeighborsOfCell_ReturnCountOfNeighbors_TestCaseOf8Neighbors()
        {
            _gameBoard.SwitchStateOfCell(5, 4);
            _gameBoard.SwitchStateOfCell(5, 5);
            _gameBoard.SwitchStateOfCell(5, 6);
            _gameBoard.SwitchStateOfCell(6, 4);
            _gameBoard.SwitchStateOfCell(6, 6);
            _gameBoard.SwitchStateOfCell(7, 4);
            _gameBoard.SwitchStateOfCell(7, 5);
            _gameBoard.SwitchStateOfCell(7, 6);

            int expected = 8;
            int actual = _gameBoard.CountActiveNeighborsOfCell(6, 5);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void IfCellIsTrueAndHasOneNeighbor_CellDiesAndTurnsFalse()
        {
            _gameBoard.SwitchStateOfCell(7, 4);
            _gameBoard.SwitchStateOfCell(7, 5);


            bool expected = false;
            bool actual = _gameBoard.DetermineNextStateOfCell(7, 4);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void IfCellIsTrueAndHas4Neighbors_CellDiesAndTurnsFalse()
        {
            _gameBoard.SwitchStateOfCell(3, 6);

            _gameBoard.SwitchStateOfCell(2, 7);
            _gameBoard.SwitchStateOfCell(3, 7);
            _gameBoard.SwitchStateOfCell(4, 7);
            _gameBoard.SwitchStateOfCell(3, 5);

            bool expected = false;
            bool actual = _gameBoard.DetermineNextStateOfCell(3, 6);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfCellIsTrueAndHas3Neighbors_CellStateRemainsTrue()
        {
            _gameBoard.SwitchStateOfCell(3, 6);

            _gameBoard.SwitchStateOfCell(2, 7);
            _gameBoard.SwitchStateOfCell(4, 7);
            _gameBoard.SwitchStateOfCell(3, 5);

            bool expected = true;
            bool actual = _gameBoard.DetermineNextStateOfCell(3, 6);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfCellIsFalseAndHas3Neighbors_CellBecomesPopulatedAndTurnsTrue()
        {
            _gameBoard.SwitchStateOfCell(2, 7);
            _gameBoard.SwitchStateOfCell(4, 7);
            _gameBoard.SwitchStateOfCell(3, 5);

            bool expected = true;
            bool actual = _gameBoard.DetermineNextStateOfCell(3, 6);

            Assert.AreEqual(expected, actual);
        }

        //[Test]
        //public void CheckBoardForActiveCells_ReturnListOfActiveCells()
        //{
        //    _gameBoard.SwitchStateOfCell(6, 5);
        //    _gameBoard.SwitchStateOfCell(2, 10);
        //    _gameBoard.SwitchStateOfCell(13, 7);

        //    List<int> returnedBoard = new List<int> { 6, 5, 2, 10, 13, 7 };

        //    var expected = returnedBoard;
        //    var actual = _gameBoard.GetAllActiveCellsInBoard();
        //    Assert.AreEqual(expected, actual);

        //}


        //    [Test]
        //    public void CheckBoardForOneActiveCell_ReturnIndexOfActiveCell()
        //    {
        //        _gameBoard.SwitchStateOfCell(3, 5);

        //        List<int> returnedBoard = new List<int> { 3, 5};

        //        var expected = returnedBoard;
        //        var actual = _gameBoard.GetAllActiveCellsInBoard();
        //        Assert.AreEqual(expected, actual);

        //    }

    }
}

    