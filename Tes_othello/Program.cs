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
                Console.Clear();
                othello.PrintBoard();
                othello.Oturn();
                othello.hasQuery = false;
                Console.Clear();
                othello.PrintBoard();
                othello.Xturn();
            }
            othello.PrintBoard();
            Console.ReadKey();
        }
    }
}
