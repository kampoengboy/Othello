using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tes_othello
{
    class ButtonX : Button //Inheritance
    {
        public char button;
        public ButtonX(int x,int y)
        {
            button = 'X';
            coordinateX = x;
            coordinateY = y;
        }
    }
}
