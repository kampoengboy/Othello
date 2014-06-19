using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tes_othello
{
    class Program
    {
        public static void AI()
        {
            AI_Mode othello = new AI_Mode();
            othello.newBoard();
            while (!othello.Allfilled())
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
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2 - 5);
            if (othello.scoreO > othello.scoreX)
                Console.Write("O WIN");
            else if (othello.scoreO < othello.scoreX)
                Console.Write("X WIN");
            else
                Console.Write("DRAW");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 - 3);
            Console.Write("PRESS ENTER TO SEE THE BOARD..!!!");
            Console.ReadKey();
            Console.Clear();
            othello.PrintBoard();
            Console.ReadKey();
        }
        public static void PvP()
        {
            Board othello = new Board();
            othello.newBoard();
            while (!othello.Allfilled())
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
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth/2 -4 ,Console.WindowHeight/2 - 5);
            if (othello.scoreO > othello.scoreX)
                Console.Write("O WIN");
            else if (othello.scoreO < othello.scoreX)
                Console.Write("X WIN");
            else
                Console.Write("DRAW");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 18, Console.WindowHeight / 2 - 3);
            Console.Write("PRESS ENTER TO SEE THE BOARD..!!!");
            Console.ReadKey();
            Console.Clear();
            othello.PrintBoard();
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            string flag;
            Console.SetWindowSize(100, 53);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Title = "OTHELLO";
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth/2-5,3);
                Console.WriteLine("OTHELLO");
                Console.SetCursorPosition(Console.WindowWidth/2-15,5);
                Console.WriteLine("CHOOSE PLAY MODE OR 0 TO QUIT");
                Console.SetCursorPosition(0, 8);
                for (int i = 0; i < Console.WindowWidth;i++ )
                {
                    Console.Write("=");
                }
                Console.SetCursorPosition(0, 19);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("1. Player Vs Computer (Player as O)");
                Console.WriteLine("2. Player Vs Player");
                Console.Write("Choose : ");
                flag = Console.ReadLine();
                switch(flag)
                {
                    case "0": return;
                    case "1": Console.Clear(); AI(); return;
                    case "2": Console.Clear(); PvP(); return;
                    default: Console.WriteLine("There is no such Choice..!! Try Again..!!!"); break;
                }
            }
        }
    }
}
