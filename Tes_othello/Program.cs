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
            Othello othello = new Othello();
            othello.Arena();
            othello.tampilAwal();

            // index mengeset x & o
            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + 9);
            Console.ReadKey();
        }
    }
}
