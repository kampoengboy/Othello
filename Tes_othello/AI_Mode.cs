using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
namespace Tes_othello
{
    class AI_Mode
    {
        public struct data
        {
            public int r, c;
        }
        int idx;
        int tmpy;
        public int scoreO, scoreX;
        public bool hasQueryO = false;
        public bool hasQueryX = false;
        public List<data> query = new List<data>();
        public Queue<data> coordinate = new Queue<data>();
        public Button[] col;
        public List<Button[]> row = new List<Button[]>(); //Polymorphism
        public int y = Console.WindowHeight / 2 - 5;
        public int x = Console.WindowWidth / 2 - 20;
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
        public void scoreboard()
        {
            scoreO = 0; scoreX = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (row[i][j] is ButtonO)
                        scoreO++;
                    else if (row[i][j] is ButtonX)
                        scoreX++;
                }
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 8);
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight - 7);
            Console.Write("SCORE");
            Console.SetCursorPosition(4, Console.WindowHeight - 5);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("O");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" = {0}",scoreO);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth - 10, Console.WindowHeight - 5);
            Console.Write("X");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" = {0}", scoreX);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public bool Allfilled()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!(row[i][j] is ButtonO) && !(row[i][j] is ButtonX))
                        return false;
                }
            }
            return true;
        }
        public void PrintBoard()
        {
            int cc = 0;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, 1);
            Console.WriteLine("OTHELLO");
            Console.SetCursorPosition(30, 27);
            Console.Write("ROW");
            Console.SetCursorPosition(54, 7);
            Console.Write("COLUMN");
            Arena();
            int idxX, idxY;
            int num = 1;
            int c = 4;
            idxY = Console.WindowHeight / 2 - 18;
            idxX = Console.WindowWidth / 2 - 18;
            Console.SetCursorPosition(idxX, idxY);
            for (int i = 0; i < 8; i++)
            {
                foreach (Button j in row[i])
                {
                    if (coordinate.Count > 0)
                    {
                        if (coordinate.Peek().r == i && coordinate.Peek().c == cc)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.SetCursorPosition(idxX + c - 5, idxY);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("(" + num + ")");
                            num++;
                            coordinate.Dequeue();
                        }
                        else
                        {
                            if (j is ButtonO)
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                Console.Write(((ButtonO)j).button);
                            }
                            else if (j is ButtonX)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                Console.Write(((ButtonX)j).button);
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                Console.Write(" ");
                            }
                        }
                    }
                    else
                    {
                        if (j is ButtonO)
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(((ButtonO)j).button);
                        }
                        else if (j is ButtonX)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(((ButtonX)j).button);
                        }
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.Write(" ");
                        }
                    }
                    Console.SetCursorPosition(idxX + c, idxY);
                    c += 4;
                    cc++;
                    Console.ResetColor();
                }
                cc = 0;
                idxY += 4;
                Console.SetCursorPosition(idxX, idxY);
                c = 4;
            }
            scoreboard();
        }
        public void ReverseXtoO(int key)
        {
            //left
            if (findleft(query[key - 1].r, query[key - 1].c, 3))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int c = query[key - 1].c - 1; c >= 0; c--)
                {
                    if (row[query[key - 1].r][c] is ButtonX)
                        row[query[key - 1].r][c] = new ButtonO(query[key - 1].r, c);
                    else if (row[query[key - 1].r][c] is ButtonO)
                        break;
                }
            }
            //right
            if (findright(query[key - 1].r, query[key - 1].c, 3))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int c = query[key - 1].c + 1; c < 8; c++)
                {
                    if (row[query[key - 1].r][c] is ButtonX)
                        row[query[key - 1].r][c] = new ButtonO(query[key - 1].r, c);
                    else if (row[query[key - 1].r][c] is ButtonO)
                        break;
                }
            }
            //up
            if (findup(query[key - 1].r, query[key - 1].c, 3))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r - 1; r >= 0; r--)
                {
                    if (row[r][query[key - 1].c] is ButtonX)
                        row[r][query[key - 1].c] = new ButtonO(r, query[key - 1].c);
                    else if (row[r][query[key - 1].c] is ButtonO)
                        break;
                }
            }
            //down
            if (finddown(query[key - 1].r, query[key - 1].c, 3))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r + 1; r < 8; r++)
                {
                    if (row[r][query[key - 1].c] is ButtonX)
                        row[r][query[key - 1].c] = new ButtonO(r, query[key - 1].c);
                    else if (row[r][query[key - 1].c] is ButtonO)
                        break;
                }
            }
            //dleftup
            if (findDleftup(query[key - 1].r, query[key - 1].c, 3))
            {
                int j = query[key - 1].c;
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r - 1; r >= 0; r--)
                {
                    j--;
                    if (j < 0) break;
                    if (row[r][j] is ButtonX)
                        row[r][j] = new ButtonO(r, j);
                    else if (row[r][j] is ButtonO)
                        break;
                }
            }
            //dleftdown
            if (findDleftdown(query[key - 1].r, query[key - 1].c, 3))
            {
                int j = query[key - 1].c;
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r + 1; r < 8; r++)
                {
                    j--;
                    if (j < 0) break;
                    if (row[r][j] is ButtonX)
                        row[r][j] = new ButtonO(r, j);
                    else if (row[r][j] is ButtonO)
                        break;
                }
            }
            //drightup
            if (findDrightup(query[key - 1].r, query[key - 1].c, 3))
            {
                int j = query[key - 1].r;
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int c = query[key - 1].c + 1; c < 8; c++)
                {
                    j--;
                    if (j - 1 < 0) break;
                    if (row[j][c] is ButtonX)
                        row[j][c] = new ButtonO(j, c);
                    else if (row[j][c] is ButtonO)
                        break;
                }
            }
            //drightdown
            if (findDrightdown(query[key - 1].r, query[key - 1].c, 3))
            {
                int j = query[key - 1].c;
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r + 1; r < 8; r++)
                {
                    j++;
                    if (j + 1 > 7) break;
                    if (row[r][j] is ButtonX)
                        row[r][j] = new ButtonO(r, j);
                    else if (row[r][j] is ButtonO)
                        break;
                }
            }
        }
        public void ReverseOtoX(int key)
        {
            //left
            if (findleft(query[key - 1].r, query[key - 1].c, 4))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int c = query[key - 1].c - 1; c >= 0; c--)
                {
                    if (row[query[key - 1].r][c] is ButtonO)
                        row[query[key - 1].r][c] = new ButtonX(query[key - 1].r, c);
                    else if (row[query[key - 1].r][c] is ButtonX)
                        break;
                }
            }
            //right
            if (findright(query[key - 1].r, query[key - 1].c, 4))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int c = query[key - 1].c + 1; c < 8; c++)
                {
                    if (row[query[key - 1].r][c] is ButtonO)
                        row[query[key - 1].r][c] = new ButtonX(query[key - 1].r, c);
                    else if (row[query[key - 1].r][c] is ButtonX)
                        break;
                }
            }
            //up
            if (findup(query[key - 1].r, query[key - 1].c, 4))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r - 1; r >= 0; r--)
                {
                    if (row[r][query[key - 1].c] is ButtonO)
                        row[r][query[key - 1].c] = new ButtonX(r, query[key - 1].c);
                    else if (row[r][query[key - 1].c] is ButtonX)
                        break;
                }
            }
            //down
            if (finddown(query[key - 1].r, query[key - 1].c, 4))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r + 1; r < 8; r++)
                {
                    if (row[r][query[key - 1].c] is ButtonO)
                        row[r][query[key - 1].c] = new ButtonX(r, query[key - 1].c);
                    else if (row[r][query[key - 1].c] is ButtonX)
                        break;
                }
            }
            //dleftup
            if (findDleftup(query[key - 1].r, query[key - 1].c, 4))
            {
                int j = query[key - 1].c;
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r - 1; r >= 0; r--)
                {
                    j--;
                    if (j - 1 < 0) break;
                    if (row[r][j] is ButtonO)
                        row[r][j] = new ButtonX(r, j);
                    else if (row[r][j] is ButtonX)
                        break;
                }
            }
            //dleftdown
            if (findDleftdown(query[key - 1].r, query[key - 1].c, 4))
            {
                int j = query[key - 1].c;
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r + 1; r < 8; r++)
                {
                    j--;
                    if (j - 1 < 0) break;
                    if (row[r][j] is ButtonO)
                        row[r][j] = new ButtonX(r, j);
                    else if (row[r][j] is ButtonX)
                        break;
                }
            }
            //drightup
            if (findDrightup(query[key - 1].r, query[key - 1].c, 4))
            {
                int j = query[key - 1].r;
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int c = query[key - 1].c + 1; c < 8; c++)
                {
                    j--;
                    if (j - 1 < 0) break;
                    if (row[j][c] is ButtonO)
                        row[j][c] = new ButtonX(j, c);
                    else if (row[j][c] is ButtonX)
                        break;
                }
            }
            //drightdown
            if (findDrightdown(query[key - 1].r, query[key - 1].c, 4))
            {
                int j = query[key - 1].c;
                row[query[key - 1].r][query[key - 1].c] = new ButtonX(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r + 1; r < 8; r++)
                {
                    j++;
                    if (j + 1 > 7) break;
                    if (row[r][j] is ButtonO)
                        row[r][j] = new ButtonX(r, j);
                    else if (row[r][j] is ButtonX)
                        break;
                }
            }
        }
        public void fillQueryO()
        {
            data dummy;
            Console.WriteLine("Choose Spot : ");
            idx = 1;
            int yy;
            yy = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!(row[i][j] is ButtonO) && !(row[i][j] is ButtonX))
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 15 + yy);
                        if (findleft(i, j, 1))
                        {
                            hasQueryO = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findright(i, j, 1))
                        {
                            hasQueryO = true;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findup(i, j, 1))
                        {
                            hasQueryO = true;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (finddown(i, j, 1))
                        {
                            hasQueryO = true;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findDleftup(i, j, 1))
                        {
                            hasQueryO = true;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findDleftdown(i, j, 1))
                        {
                            hasQueryO = true;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findDrightup(i, j, 1))
                        {
                            hasQueryO = true;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findDrightdown(i, j, 1))
                        {
                            hasQueryO = true;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                    }
                }
            }
        }
        public void fillQueryX()
        {
            data dummy;
            Console.WriteLine("Choose Spot : ");
            idx = 1;
            int yy;
            yy = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!(row[i][j] is ButtonO) && !(row[i][j] is ButtonX))
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 15 + yy);
                        if (findleft(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findright(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (findup(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            coordinate.Enqueue(dummy);
                            yy += 2;
                            idx++;
                        }
                        else if (finddown(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            yy += 2;
                            idx++;
                        }
                        else if (findDleftup(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            yy += 2;
                            idx++;
                        }
                        else if (findDleftdown(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            yy += 2;
                            idx++;
                        }
                        else if (findDrightup(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            yy += 2;
                            idx++;
                        }
                        else if (findDrightdown(i, j, 2))
                        {
                            hasQueryX = true;
                            Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                            dummy.r = i; dummy.c = j;
                            coordinate.Enqueue(dummy);
                            tmpy = Console.WindowHeight / 2 - 15 + yy;
                            yy += 2;
                            idx++;
                        }
                    }
                }
            }
        }
        public bool findleft(int i, int j, int flag)
        {
            data dummy;
            int tmpj = j;
            if (tmpj - 1 < 0)
                tmpj = 0;
            else
                tmpj -= 1;
            if (flag == 1 || flag == 3)
            {
                if (row[i][tmpj] is ButtonX)
                {
                    for (int c = j - 2; c >= 0; c--)
                    {
                        if (flag == 1)
                        {
                            if (row[i][c] is ButtonX) continue;
                            else if (!(row[i][c] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[i][c] is ButtonX) continue;
                            else if (!(row[i][c] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else if (flag == 2 || flag == 4)
            {
                if (row[i][tmpj] is ButtonO)
                {
                    for (int c = j - 2; c >= 0; c--)
                    {
                        if (flag == 2)
                        {
                            if (row[i][c] is ButtonO) continue;
                            else if (!(row[i][c] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[i][c] is ButtonO) continue;
                            else if (!(row[i][c] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool findright(int i, int j, int flag)
        {
            data dummy;
            int tmpj = j;
            if (tmpj + 1 > 7)
                tmpj = 7;
            else
                tmpj += 1;
            if (flag == 1 || flag == 3)
            {
                if (row[i][tmpj] is ButtonX)
                {
                    for (int c = j + 2; c < 8; c++)
                    {
                        if (flag == 1)
                        {
                            if (row[i][c] is ButtonX) continue;
                            else if (!(row[i][c] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[i][c] is ButtonX) continue;
                            else if (!(row[i][c] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else if (flag == 2 || flag == 4)
            {
                if (row[i][tmpj] is ButtonO)
                {
                    for (int c = j + 2; c < 8; c++)
                    {
                        if (flag == 2)
                        {
                            if (row[i][c] is ButtonO) continue;
                            else if (!(row[i][c] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[i][c] is ButtonO) continue;
                            else if (!(row[i][c] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool findup(int i, int j, int flag)
        {
            data dummy;
            int tmpi = i;
            if (tmpi - 1 < 0)
                tmpi = 0;
            else
                tmpi -= 1;
            if (flag == 1 || flag == 3)
            {
                if (row[tmpi][j] is ButtonX)
                {
                    for (int r = i - 2; r >= 0; r--)
                    {
                        if (flag == 1)
                        {
                            if (row[r][j] is ButtonX) continue;
                            else if (!(row[r][j] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[r][j] is ButtonX) continue;
                            else if (!(row[r][j] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else
            {
                if (row[tmpi][j] is ButtonO)
                {
                    for (int r = i - 2; r >= 0; r--)
                    {
                        if (flag == 2)
                        {
                            if (row[r][j] is ButtonO) continue;
                            else if (!(row[r][j] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[r][j] is ButtonO) continue;
                            else if (!(row[r][j] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool finddown(int i, int j, int flag)
        {
            data dummy;
            int tmpi = i;
            if (tmpi + 1 > 7)
                tmpi = 7;
            else
                tmpi += 1;
            if (flag == 1 || flag == 3)
            {
                if (row[tmpi][j] is ButtonX)
                {
                    for (int r = i + 2; r < 8; r++)
                    {
                        if (flag == 1)
                        {
                            if (row[r][j] is ButtonX) continue;
                            else if (!(row[r][j] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[r][j] is ButtonX) continue;
                            else if (!(row[r][j] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else
            {
                if (row[tmpi][j] is ButtonO)
                {
                    for (int r = i + 2; r < 8; r++)
                    {
                        if (flag == 2)
                        {
                            if (row[r][j] is ButtonO) continue;
                            else if (!(row[r][j] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[r][j] is ButtonO) continue;
                            else if (!(row[r][j] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool findDleftup(int i, int j, int flag)
        {
            data dummy;
            int tmpi = i, tmpj = j;
            if (tmpj - 1 < 0 || tmpi - 1 < 0)
            {
                tmpj = 0;
                tmpi = i;
            }
            else
            {
                tmpj -= 1;
                tmpi -= 1;
            }
            int k = tmpj;
            if (flag == 1 || flag == 3)
            {
                if (row[tmpi][tmpj] is ButtonX)
                {
                    for (int r = tmpi - 1; r >= 0; r--)
                    {
                        k--;
                        if (k < 0)
                            break;
                        if (flag == 1)
                        {
                            if (row[r][k] is ButtonX) continue;
                            else if (!(row[r][k] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[r][k] is ButtonX) continue;
                            else if (!(row[r][k] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else
            {
                if (row[tmpi][tmpj] is ButtonO)
                {
                    for (int r = tmpi - 1; r >= 0; r--)
                    {
                        k--;
                        if (k < 0)
                            break;
                        if (flag == 2)
                        {
                            if (row[r][k] is ButtonO) continue;
                            else if (!(row[r][k] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[r][k] is ButtonO) continue;
                            else if (!(row[r][k] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool findDleftdown(int i, int j, int flag)
        {
            data dummy;
            int tmpi = i, tmpj = j;
            if (tmpj - 1 < 0 || tmpi + 1 > 7)
            {
                tmpj = 0;
                tmpi = i;
            }
            else
            {
                tmpj -= 1;
                tmpi += 1;
            }
            int k = tmpj;
            if (flag == 1 || flag == 3)
            {
                if (row[tmpi][tmpj] is ButtonX)
                {
                    for (int r = tmpi + 1; r < 8; r++)
                    {
                        k--;
                        if (k < 0) break;
                        if (flag == 1)
                        {
                            if (row[r][k] is ButtonX) continue;
                            else if (!(row[r][k] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[r][k] is ButtonX) continue;
                            else if (!(row[r][k] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else
            {
                if (row[tmpi][tmpj] is ButtonO)
                {
                    for (int r = tmpi + 1; r < 8; r++)
                    {
                        k--;
                        if (k < 0) break;
                        if (flag == 2)
                        {
                            if (row[r][k] is ButtonO) continue;
                            else if (!(row[r][k] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[r][k] is ButtonO) continue;
                            else if (!(row[r][k] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool findDrightup(int i, int j, int flag)
        {
            data dummy;
            int tmpi = i, tmpj = j;
            if (tmpi - 1 < 0 || tmpj + 1 > 7)
            {
                tmpi = 0;
                tmpj = j;
            }
            else
            {
                tmpi -= 1;
                tmpj += 1;
            }
            int k = tmpi;
            if (flag == 1 || flag == 3)
            {
                if (row[tmpi][tmpj] is ButtonX)
                {
                    for (int c = tmpi + 1; c < 8; c++)
                    {
                        k--;
                        if (k < 0) break;
                        if (flag == 1)
                        {
                            if (row[k][c] is ButtonX) continue;
                            else if (!(row[k][c] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[k][c] is ButtonX) continue;
                            else if (!(row[k][c] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else
            {
                if (row[tmpi][tmpj] is ButtonO)
                {
                    for (int c = tmpi + 1; c < 8; c++)
                    {
                        k--;
                        if (k < 0) break;
                        if (flag == 2)
                        {
                            if (row[k][c] is ButtonO) continue;
                            else if (!(row[k][c] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[k][c] is ButtonO) continue;
                            else if (!(row[k][c] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool findDrightdown(int i, int j, int flag)
        {
            data dummy;
            int tmpi = i, tmpj = j;
            if (tmpj + 1 > 7 || tmpi + 1 > 7)
            {
                tmpj = j;
                tmpi = i;
            }
            else
            {
                tmpj += 1;
                tmpi += 1;
            }
            int k = tmpj;
            if (flag == 1 || flag == 3)
            {
                if (row[tmpi][tmpj] is ButtonX)
                {
                    for (int r = tmpi + 1; r < 8; r++)
                    {
                        k++;
                        if (k > 7)
                            break;
                        if (flag == 1)
                        {
                            if (row[r][k] is ButtonX) continue;
                            else if (!(row[r][k] is ButtonO))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 3)
                        {
                            if (row[r][k] is ButtonX) continue;
                            else if (!(row[r][k] is ButtonO))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            else
            {
                if (row[tmpi][tmpj] is ButtonO)
                {
                    for (int r = tmpi + 1; r < 8; r++)
                    {
                        k++;
                        if (k > 7)
                            break;
                        if (flag == 2)
                        {
                            if (row[r][k] is ButtonO) continue;
                            else if (!(row[r][k] is ButtonX))
                                break;
                            else
                            {
                                dummy.r = i;
                                dummy.c = j;
                                query.Add(dummy);
                                return true;
                            }
                        }
                        else if (flag == 4)
                        {
                            if (row[r][k] is ButtonO) continue;
                            else if (!(row[r][k] is ButtonX))
                                break;
                            else
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        public void Oturn()
        {
            string flag;
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 20);
                Console.WriteLine("O turn");
                Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 17);
                fillQueryO();
                PrintBoard();
                if (hasQueryO)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 20, tmpy + 2);
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Write("Choice : ");
                    bool inputComplete = false;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    while (!inputComplete)
                    {
                        System.ConsoleKeyInfo key = System.Console.ReadKey(true);

                        if (key.Key == System.ConsoleKey.Enter)
                        {
                            inputComplete = true;
                        }
                        else if (char.IsDigit(key.KeyChar))
                        {
                            sb.Append(key.KeyChar);
                            System.Console.Write(key.KeyChar.ToString());
                        }
                    }
                    flag = sb.ToString();
                    if (flag != "" && flag.Length <= 2)
                    {
                        if (Convert.ToInt32(flag) <= idx - 1 && Convert.ToInt32(flag) >= 1)
                        {
                            ReverseXtoO(Convert.ToInt32(flag));
                            query.Clear();
                            break;
                        }
                    }
                }
                else
                    break;
                query.Clear();
            }
        }
        public void Xturn()
        {
            Random a = new Random();
            int key;
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 20);
                Console.WriteLine("X turn");
                Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 17);
                fillQueryX();
                PrintBoard();
                if (hasQueryX)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 + 20, tmpy + 2);
                    key = a.Next(1, idx);
                    Thread.Sleep(1500);
                    Console.Write("Computer Choose List {0}",key);
                    Console.ReadKey();
                    ReverseOtoX(key);
                    query.Clear();
                    break;
                }
                else
                    break;
                query.Clear();
            }
        }
        public void Arena()
        {
            y = Console.WindowHeight / 2 - 5;
            x = Console.WindowWidth / 2 - 20;
            for (int k = 0; k < 8; k++)
            {
                y = Console.WindowHeight / 2 - 20;
                for (int i = 0; i <= 8; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine("-----");
                    if (i != 8)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            y++;
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine("|   |");
                        }
                    }
                    y++;
                }
                x += 4;
            }
            y = Console.WindowHeight / 2 - 18;
            x = Console.WindowWidth / 2 - 22;
            for (int i = 1; i <= 8; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(i);
                y += 4;
            }
            y = Console.WindowHeight / 2 - 22;
            x = Console.WindowWidth / 2 - 18;
            for (int i = 1; i <= 8; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(i);
                x += 4;
            }
        }
    }
}
