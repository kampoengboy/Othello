using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Tes_othello
{
    class Board
    {
        public struct data
        {
            public int startr, startc, endr, endc,status;
        }
        public List<data> query = new List<data>();
        public Button[] col;
        public List<Button[]> row = new List<Button[]>(); //Polymorphism
        public int y = Console.WindowHeight / 2 -5;
        public int x = Console.WindowWidth / 2 - 20;
        public Board()
        {
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
        }
        public bool Allfilled()
        {
            for(int i=0;i<8;i++)
            {
                foreach(Button j in row[i])
                {
                    if (j is Button)
                        return false;
                }
            }
            return true;
        }
        public void PrintBoard()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 1);
            Console.WriteLine("OTHELLO");
            Console.SetCursorPosition(22,27);
            Console.Write("ROW");
            Console.SetCursorPosition(43,7);
            Console.Write("COLUMN");
            Arena();
            int idxX, idxY;
            int c=4;
            idxY = Console.WindowHeight / 2 - 13;
            idxX = Console.WindowWidth / 2 - 18;
            Console.SetCursorPosition(idxX, idxY);
            for (int i = 0; i < 8; i++)
            {
               foreach (Button j in row[i])
               {
                    if (j is ButtonO)
                        Console.Write(((ButtonO)j).button);
                    else if (j is ButtonX)
                        Console.Write(((ButtonX)j).button);
                    else
                        Console.Write(" ");
                    Console.SetCursorPosition(idxX + c, idxY);
                    c += 4;
                }
                idxY += 4;
                Console.SetCursorPosition(idxX, idxY);
                c = 4;
            }
        }
        public void Reverse()
        {

        }
        public void fillQueryO()
        {
            for(int i=0;i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    if(row[i][j] is ButtonO)
                    {
                        findleft(i,j);
                        findright(i,j);
                        findup(i,j);
                        finddown(i,j);
                    }
                }
            }
        }
        public void findleft(int i,int j)
        {
            data dummy;
            if (row[i][j - 1] is ButtonX)
            {
                for (int c = j - 2; c >= 0; c--)
                {
                    if(row[i][c] is ButtonO)
                    {
                        dummy.startr = dummy.endr = i;
                        dummy.startc = j - 1;
                        dummy.endc = c + 1;
                        dummy.status = 1;
                        query.Add(dummy);
                    }
                }
            }
        }
        public void findright(int i,int j)
        {
            data dummy;
            if (row[i][j + 1] is ButtonX)
            {
                for (int c = j + 2; c <8; c++)
                {
                    if (row[i][c] is ButtonO)
                    {
                        dummy.startr = dummy.endr = i;
                        dummy.startc = j + 1;
                        dummy.endc = c - 1;
                        dummy.status = 2;
                        query.Add(dummy);
                    }
                }
            }
        }
        public void findup(int i,int j)
        {
            data dummy;
            if (row[i-1][j] is ButtonX)
            {
                for (int r = i - 2; r >= 0; r--)
                {
                    if (row[r][j] is ButtonO)
                    {
                        dummy.startc = dummy.endc = j;
                        dummy.startr = i - 1;
                        dummy.endr = r + 1;
                        dummy.status = 3;
                        query.Add(dummy);
                    }
                }
            }
        }
        public void finddown(int i,int j)
        {
            data dummy;
            if (row[i + 1][j] is ButtonX)
            {
                for (int r = i + 2; r < 8; r++)
                {
                    if (row[r][j] is ButtonO)
                    {
                        dummy.startc = dummy.endc = j;
                        dummy.startr = i + 1;
                        dummy.endr = r - 1;
                        dummy.status = 4;
                        query.Add(dummy);
                    }
                }
            }
        }
        public void Oturn()
        {
            int x, y;
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 15);
            Console.WriteLine("O turn");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 12);
            Console.Write("Row Number    = ");
            x = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 11);
            Console.Write("Column Number = ");
            y = int.Parse(Console.ReadLine());
            row[x-1][y-1] = new ButtonO(x-1, y-1);
        }
        public void Xturn()
        {
            int x, y;
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 15);
            Console.WriteLine("X turn");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 12);
            Console.Write("Row Number    = ");
            x = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 11);
            Console.Write("Column Number = ");
            y = int.Parse(Console.ReadLine());
            row[x-1][y-1] = new ButtonX(x-1, y-1);
        }
        public void Arena()
        {
            y = Console.WindowHeight / 2 - 5;
            x = Console.WindowWidth / 2 - 20;
            for (int k = 0; k < 8; k++)
            {
                y = Console.WindowHeight / 2 - 15;
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
            y = Console.WindowHeight / 2 - 13;
            x = Console.WindowWidth / 2 - 22;
            for (int i = 1; i <= 8; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(i);
                y += 4;
            }
            y = Console.WindowHeight / 2 - 17;
            x = Console.WindowWidth / 2 - 18;
            for(int i=1;i<=8;i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(i);
                x += 4;
            }
        }
    }
}
