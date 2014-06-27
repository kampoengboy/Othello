using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tes_othello
{
    abstract class MainItem
    {
        public struct data
        {
            public int r, c;
        }
        public int idx;
        public int tmpy;
        public int scoreO, scoreX;
        public bool hasQueryO = false;
        public bool hasQueryX = false;
        public List<data> query = new List<data>();
        public Queue<data> coordinate = new Queue<data>();
        public Button[] col;
        public List<Button[]> row = new List<Button[]>(); //Polymorphism
        public int y = Console.WindowHeight / 2 - 5;
        public int x = Console.WindowWidth / 2 - 20;
    }
}
