using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tes_othello
{
    class Othello
    {
        public int y = Console.WindowHeight / 2 -5;
        public int x = Console.WindowWidth / 2 - 20;
       public void Arena()
        {
            for (int k = 0; k < 8; k++)
            {
                y = Console.WindowHeight / 2 - 5;
                for (int i = 0; i <= 8; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("*****");
                    if (i != 8)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            y++;
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine("*   *");
                        }

                    }
                    y++;
                }
                x += 4;
            }     
           
        }
       public void tampilAwal()
       {
           Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + 9);
           Console.Write("x");
           Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 9);
           Console.Write("o");
           Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + 13);
           Console.Write("o");
           Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 + 13);
           Console.Write("x");
       }
    }
}
