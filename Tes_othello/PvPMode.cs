using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Tes_othello
{
    class PvPMode:Function
    {
        public void newBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                Button[] col = new Button[8];
                for (int j = 0; j < 8; j++)
                {
                    if ((i == 3 && j == 3) || (i == 4 && j == 4))
                        col[j] = new ButtonX(i, j);
                    else if ((i == 3 && j == 4) || (i == 4 && j == 3))
                        col[j] = new ButtonO(i, j);
                }
                row.Add(col);
            }
        }
    }
}
