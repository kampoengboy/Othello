using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tes_othello
{
    class FunctionFind : MainItem
    {
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
    }
}
