using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tes_othello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100,53);

            Board othello = new Board();
            while(!othello.Allfilled())
            {
                othello.Oturn();
                if (othello.hasQueryO)
                {
                    othello.hasQueryO = false;
                    othello.Xturn();
                    if (othello.hasQueryX)
                        othello.hasQueryX = false;
                    else
                        break;
                }
                else
                {
                    othello.Xturn();
                    if (othello.hasQueryX)
                        othello.hasQueryX = false;
                    else
                        break;
                }
            }
            othello.PrintBoard();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight - 5);
            if (othello.scoreO > othello.scoreX)
                Console.Write("O WIN");
            else if (othello.scoreO < othello.scoreX)
                Console.Write("X WIN");
            else
                Console.Write("DRAW");
            Console.ReadKey();
        }
    }
}
