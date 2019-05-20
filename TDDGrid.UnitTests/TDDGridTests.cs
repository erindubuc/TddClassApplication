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
        private Coordinates _coords;
        public int row;
        public int col;

        [SetUp]
        public void TestFixtureSetup()
        {
            _gameBoard = new GameBoard();
            //_coords = new Coordinates();
            //_gameBoard.SetInitialBoardState();
        }

        [Test]
        public void EnterOneRowAndCol_ReturnStateOfCoordinateObject()
        {
            _coords = new Coordinates(1, 5);
            var expected = false;
            var actual = _gameBoard.GetStateOfParticularCellCoordinates(_coords);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChooseOneCellAndReturnStateAsTrue()
        {
            _coords = new Coordinates(4, 7);
            var expected = true;
            var actual = _gameBoard.TurnStateOfCellToTrue(_coords);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IfStateOfCellCoordsIsTrue_SwitchToFalse()
        {
            _coords = new Coordinates(2, 5);
            _coords.State = true;
            var expected = false;
            var actual = _gameBoard.SwitchAllTrueStatesToFalseStates(_coords);

            Assert.AreEqual(expected, actual);
        }
        /*
        [Test]
        public void GetDictionaryOfCoordinates()
        {
            var expected = _gameBoard.SetAllBoardCoordinatesAndStateAsFalse();
            var actual = 
        }

        /*
        [Test]
        public void ChooseSetOfCoords_ReturnStateAsTrue()
        {
           
        }
        
       

        public void ChooseACellAndReturnCoordinates()
        {
            int row = 1;
            int col = 2;

        }
        */
    }
}
