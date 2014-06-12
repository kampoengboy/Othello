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
            public int r,c;
        }
        public bool hasQuery=false;
        public List<data> query = new List<data>();
        public List<List<data>> listquery = new List<List<data>>();
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
                for(int j=0;j<8;j++)
                {
                    if (!(row[i][j] is ButtonO) && !(row[i][j] is ButtonX))
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
        public void ReverseXtoO(int key)
        {
            //left
            if(findleft(query[key-1].r,query[key-1].c,3))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for(int c=query[key-1].c-1;c>=0;c--)
                {
                    if (row[query[key - 1].r][c] is ButtonX)
                        row[query[key - 1].r][c] = new ButtonO(query[key - 1].r, c);
                    else if (row[query[key].r][c] is ButtonO)
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
                    else if (row[query[key].r][c] is ButtonO)
                        break;
                }
            }
            //up
            if (findup(query[key - 1].r, query[key - 1].c, 3))
            {
                row[query[key - 1].r][query[key - 1].c] = new ButtonO(query[key - 1].r, query[key - 1].c);
                for (int r = query[key - 1].r - 1; r >= 0; r--)
                {
                    if (row[r][query[key-1].c] is ButtonX)
                        row[r][query[key-1].c] = new ButtonO(r, query[key-1].c);
                    else if (row[r][query[key-1].c] is ButtonO)
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
            //dleftdown
            //drightup
            //drightdown
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
                    else if (row[query[key-1].r][c] is ButtonX)
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
                    else if (row[query[key-1].r][c] is ButtonX)
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
            //dleftdown
            //drightup
            //drightdown
        }
        public void fillQueryO()
        {
            Console.WriteLine("Choose Spot : ");
            int idx = 1;
            int yy;
            yy = 0;
            for(int i=0;i<8;i++)
            {
                for(int j=0;j<8;j++)
                {
                    if(!(row[i][j] is ButtonO) && !(row[i][j] is ButtonX))
                    {
                        Console.SetCursorPosition(Console.WindowWidth/2+20,Console.WindowHeight/2-10+yy);
                        if(i==0 && j==0)
                        {
                            if (findright(i, j,1))
                            {
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                hasQuery = true;
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j,1))
                            {
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                hasQuery = true;
                                idx++;
                            }
                        }
                        else if(i==0 && j<=6)
                        {
                            if (findleft(i, j,1))
                            {
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                hasQuery = true;
                                idx++;
                            }
                            else if (findright(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }  
                        }
                        else if(i==0 && j==7)
                        {
                            if (findleft(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i,j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if(i<=6 && j==0)
                        {
                            if (findright(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findup(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if(i==7 && j==0)
                        {
                            if (findup(i,j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findright(i,j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if(i==7 && j<=6)
                        {
                            if (findleft(i,j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(findup(i,j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(findright(i,j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if(i==7 && j==7)
                        {
                            if(findleft(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(findup(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i <= 6 && j == 7)
                        {
                            if(findleft(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(findup(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(finddown(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else
                        {
                            if(findleft(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(findright(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(findup(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if(finddown(i, j,1))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                    }
                }
            }
        }
        public void fillQueryX()
        {
            Console.WriteLine("Choose Spot : ");
            int idx = 1;
            int yy;
            yy = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!(row[i][j] is ButtonO) && !(row[i][j] is ButtonX))
                    {
                        Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 10 + yy);
                        if (i == 0 && j == 0)
                        {
                            if (findright(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i == 0 && j <= 6)
                        {
                            if (findleft(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findright(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i == 0 && j == 7)
                        {
                            if (findleft(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i <= 6 && j == 0)
                        {
                            if (findright(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findup(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i == 7 && j == 0)
                        {
                            if (findup(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findright(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i == 7 && j <= 6)
                        {
                            if (findleft(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findup(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findright(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i == 7 && j == 7)
                        {
                            if (findleft(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findup(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else if (i <= 6 && j == 7)
                        {
                            if (findleft(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findup(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                        else
                        {
                            if (findleft(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findright(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (findup(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                            else if (finddown(i, j, 2))
                            {
                                hasQuery = true;
                                Console.WriteLine("({0}). Row = {1} , Column = {2}", idx, i + 1, j + 1);
                                yy += 2;
                                idx++;
                            }
                        }
                    }
                }
            }
        }
        public bool findleft(int i,int j,int flag)
        {
            data dummy;
            int tmpj = j;
            if (tmpj - 1 < 0)
                tmpj = 0;
            else
                tmpj -= 1;
            if (flag == 1 || flag==3)
            {
                if (row[i][tmpj] is ButtonX)
                {
                    //Console.WriteLine(i + " "+(j-1));
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
            else if(flag==2 || flag==4)
            {
                if (row[i][tmpj] is ButtonO)
                {
                    //Console.WriteLine(i + " "+(j-1));
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
            else if(flag==2 || flag==4)
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
            if (tmpi -1 < 0)
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
        public void Oturn()
        {
            int key;
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 15);
            Console.WriteLine("O turn");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 12);
            fillQueryO();
            if (hasQuery)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2);
                Console.Write("Choice : ");
                key = int.Parse(Console.ReadLine());
                ReverseXtoO(key);
            }
            else
            {
                Console.WriteLine("O Has No Move So it's X turn");
            }
            query.Clear();
        }
        public void Xturn()
        {
            int key;
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 15);
            Console.WriteLine("X turn");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2 - 12);
            fillQueryX();
            if (hasQuery)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 + 20, Console.WindowHeight / 2);
                Console.Write("Choice : ");
                key = int.Parse(Console.ReadLine());
                ReverseOtoX(key);
            }
            else
            {
                Console.WriteLine("X Has No Move So it's O turn");
            }
            query.Clear();
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
