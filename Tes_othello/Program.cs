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
            Board othello = new Board();
            while(!othello.Allfilled())
            {
                Console.Clear();
                othello.PrintBoard();
                othello.Oturn();
                Console.Clear();
                othello.PrintBoard();
                othello.Xturn();
            }
            Console.ReadKey();
        }
    }
}
