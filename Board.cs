using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        public int size;
        public Cell[,] theGrid;

        public Board(int size) //constructor
        {
            this.size = size;

            theGrid = new Cell[size, size];
        }

    }
}
