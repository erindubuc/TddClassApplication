using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDGrid
{
    public class Coordinates
    {
        private int _row;
        private int _column;
        private bool _state = false;
        public int Row { get => _row; set => _row = value; }
        public int Column { get => _column; set => _column = value; }
        public bool State { get => _state; set => _state = value; }

        public Coordinates()
        {
        }

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;  
        }

     
        public bool SwitchStateOfCell()
        {
            var setState = (State == false) ? State = true : State = false;
            return setState;
        }

        



    }
}
