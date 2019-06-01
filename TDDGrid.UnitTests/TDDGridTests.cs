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

        /*  For a space that is 'populated':
                Each cell with one or no neighbors dies, as if by solitude.
                Each cell with four or more neighbors dies, as if by overpopulation.
                Each cell with two or three neighbors survives.
            For a space that is 'empty' or 'unpopulated'
                Each cell with three neighbors becomes populated.
        */
      

        [Test]
        public void CheckActiveCellForHorizontalNeighbors_ReturnHorizontalCountOfNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            _gameBoard.SwitchStateOfCell(3, 6);
            _gameBoard.SwitchStateOfCell(3, 4);
            var expected = 2;
            var actual = _gameBoard.CountAllHorizontalNeighborsOfActiveCell(3, 5);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CheckActiveCellForVerticalNeighbors_ReturnVerticalCountOfNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            _gameBoard.SwitchStateOfCell(2, 5);
            var expected = 1;
            var actual = _gameBoard.CountAllVerticalNeighborsOfActiveCell(3, 5);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckActiveCellForLeftDiagonalNeighbors_ReturnCountOfNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            _gameBoard.SwitchStateOfCell(2, 4);
            _gameBoard.SwitchStateOfCell(4, 6);
            var expected = 2;
            var actual = _gameBoard.CountAllDiagonalNeighborsOfActiveCell(3, 5);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CheckActiveCellForRightDiagonalNeighbors_ReturnCountOfNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            _gameBoard.SwitchStateOfCell(2, 6);
            _gameBoard.SwitchStateOfCell(4, 4);
            var expected = 2;
            var actual = _gameBoard.CountAllDiagonalNeighborsOfActiveCell(3, 5);
            Assert.AreEqual(expected, actual);
        }
        /*
        [Test]
        public void CheckActiveCellForAnyActiveNeighbors_ReturnCountOfNeighbors()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            _gameBoard.SwitchStateOfCell(2, 6);
            _gameBoard.SwitchStateOfCell(4, 4);
            _gameBoard.SwitchStateOfCell(2, 4);
            _gameBoard.SwitchStateOfCell(4, 6);
            _gameBoard.SwitchStateOfCell(3, 6);
            _gameBoard.SwitchStateOfCell(3, 4);
            _gameBoard.SwitchStateOfCell(2, 5);
            var expected = 7;
            var actual = _gameBoard.CountActiveNeighborsOfActiveCell(3, 5);
            Assert.AreEqual(expected, actual);
        }




        [Test]
        public void GetCountOfActiveNeighborsOfActiveCellOnEdgeOfBoard_ReturnCount()
        {
            _gameBoard.SwitchStateOfCell(6, 0);
            _gameBoard.SwitchStateOfCell(5, 1);
            
            var expected = 1;
            var actual = _gameBoard.CountActiveNeighborsOfActiveCell(6, 0);
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CheckBoardForOneActiveCell_ReturnIndexOfActiveCell()
        {
            _gameBoard.SwitchStateOfCell(3, 5);
            
            List<int> returnedBoard = new List<int> { 3, 5 };

            var expected = returnedBoard;
            var actual = _gameBoard.GetAllActiveCellsInBoard();
            Assert.AreEqual(expected, actual);

        }

        
        [Test]
        public void CheckBoardForActiveCells_ReturnArrayOfActiveCells()
        {
            _gameBoard.SwitchStateOfCell(6, 5);
            _gameBoard.SwitchStateOfCell(2, 10);
            _gameBoard.SwitchStateOfCell(13, 7);


            List<int> returnedBoard = new List<int>();

            var expected = returnedBoard;
            var actual = _gameBoard.GetAllActiveCellsInBoard();
            Assert.AreEqual(expected, actual);

        }
        */


    }
}
