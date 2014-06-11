using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tes_othello
{
    class ButtonO : Button //Inheritance
    {
        public char button;
        public ButtonO(int x,int y)
        {
            button = 'O';
            coordinateX = x;
            coordinateY = y;
        }
    }
}
