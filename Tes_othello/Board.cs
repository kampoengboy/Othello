using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Tes_othello
{
    class Board
    {
        public Button[] col;
        public List<Button[]> row = new List<Button[]>(); //Polymorphism
        public int y = Console.WindowHeight / 2 -5;
        public int x = Console.WindowWidth / 2 - 20;
        public Board()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 1);
            Console.WriteLine("OTHELLO");
            Arena();
            tampilAwal();
            for (int i = 0; i < 8; i++ )
            {
                Button[] col = new Button[8];
                for(int j=0;j<8;j++)
                {
                    if ((i == 3 && j == 3) || (i == 4 && j == 4))
                        col[j] = new ButtonX(i, j);
                    else if ((i == 3 && j == 4) || (i == 4 && j == 3))
                        col[j] = new ButtonO(i, j);
                }
                row.Add(col);
            }
            //FOR PRINT THE MAP
            /*for(int i=0;i<8;i++)
            {
                foreach (Button j in row[i])
                    {
                        if (j is ButtonO)
                            Console.Write("o ");
                        else if (j is ButtonX)
                            Console.Write("x ");
                        else
                            Console.Write("# ");
                    }
               Console.WriteLine();
            }*/
        }
        public void Oturn()
        {
            int x, y;
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 20);
            Console.WriteLine("O turn");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 18);
            Console.WriteLine("Row Number    = ");
            x = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 17);
            Console.Write("Column Number = ");
            y = int.Parse(Console.ReadLine());
            row[x][y] = new ButtonO(x, y);
        }
        public void Xturn()
        {
            int x, y;
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 20);
            Console.WriteLine("X turn");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 18);
            Console.WriteLine("Row Number    = ");
            x = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 17);
            Console.Write("Column Number = ");
            y = int.Parse(Console.ReadLine());
            row[x][y] = new ButtonX(x, y);
        }
        public void Arena()
        {
            for (int k = 0; k < 8; k++)
            {
                y = Console.WindowHeight / 2 - 20;
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
           Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 6);
           Console.Write("x");
           Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 - 6);
           Console.Write("o");
           Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 2);
           Console.Write("o");
           Console.SetCursorPosition(Console.WindowWidth / 2 - 2, Console.WindowHeight / 2 - 2);
           Console.Write("x");
       }
    }
}
