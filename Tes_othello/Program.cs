﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

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
                    othello.Xturn_AI();
                    if (othello.hasQueryX)
                        othello.hasQueryX = false;
                    else
                        break;
                }
                else
                {
                    othello.Xturn_AI();
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
            PvPMode othello = new PvPMode();
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
            Console.SetWindowSize(120, Console.LargestWindowHeight);
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Title = "OTHELLO";
                while (true)
                {
                    Console.Clear();
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 3);
                    Console.WriteLine("OTHELLO");
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 5);
                    Console.WriteLine("CHOOSE PLAY MODE OR 0 TO QUIT");
                    Console.SetCursorPosition(0, 8);
                    for (int i = 0; i < Console.WindowWidth; i++)
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
                    bool inputComplete = false;
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    while (!inputComplete)
                    {
                        System.ConsoleKeyInfo key = System.Console.ReadKey(true);
                        if (key.Key == System.ConsoleKey.Enter)
                        {
                            inputComplete = true;
                        }
                        else if (char.IsDigit(key.KeyChar) || key.Key == ConsoleKey.Backspace)
                        {
                            if (char.IsDigit(key.KeyChar) && sb.Length < 1)
                            {
                                sb.Append(key.KeyChar);
                                System.Console.Write(key.KeyChar.ToString());
                            }
                            else if (key.Key == ConsoleKey.Backspace)
                            {
                                if (sb.Length > 0)
                                {
                                    sb.Remove(sb.Length - 1, 1);
                                    System.Console.Write("\b \b");
                                }
                            }
                        }
                    }
                    flag = sb.ToString();
                    switch (flag)
                    {
                        case "0": return;
                        case "1": Console.Clear(); AI(); break;
                        case "2": Console.Clear(); PvP(); break;
                        default: Console.WriteLine("There is no such Choice..!! Try Again..!!!"); break;
                    }
                    if (flag == "1" || flag == "2")
                        break;
                }
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 3);
                Console.WriteLine("OTHELLO");
                Console.SetCursorPosition(0, 8);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }
                Console.SetCursorPosition(0, 19);
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write("=");
                }
                Console.SetCursorPosition(0, 12);
                Console.Write("TRY AGAIN ? (Y/N) : ");
                bool Complete = false;
                System.Text.StringBuilder ss = new System.Text.StringBuilder();
                while (!Complete)
                {
                    System.ConsoleKeyInfo key = System.Console.ReadKey(true);
                    if (key.Key == System.ConsoleKey.Enter)
                    {
                        Complete = true;
                    }
                    else if (key.Key== ConsoleKey.Y || key.Key==ConsoleKey.N || key.Key == ConsoleKey.Backspace)
                    {
                        if ((key.Key==ConsoleKey.Y || key.Key==ConsoleKey.N) && ss.Length < 1)
                        {
                            ss.Append(key.KeyChar);
                            System.Console.Write(key.KeyChar.ToString());
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            if (ss.Length > 0)
                            {
                                ss.Remove(ss.Length - 1, 1);
                                System.Console.Write("\b \b");
                            }
                        }
                    }
                }
                flag = ss.ToString();
                if (flag == "N" || flag == "n")
                    break;
            } while (true);
        }
    }
}
