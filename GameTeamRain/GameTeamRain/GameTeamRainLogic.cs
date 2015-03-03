namespace GameTeamRain
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    class GameTeamRainLogic
    {
        static void Main()
        {
            Console.Title = "CSharpGame2048-OnlineTeamRain";
            string[] introSlides = new string[3] { "../../TextFiles/AsciiTelerik.txt", "../../TextFiles/AsciiTeamRain.txt", "../../TextFiles/Ascii2015.txt" };

            for (int i = 0; i < 3; i++)
            {
                PrintLogo(introSlides[i]);
            }
            
            
            GameCore engine = new GameCore();
            Console.CursorVisible = false;
            engine.PrintMatrix();
            while (true)
            {
                engine.ReCalculateMatrix();

                if (engine.IsGameWon())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("You Won");
                    break;
                }
                if (engine.IsGameOver())
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GAME OVER");
                    break;
                }
                engine.PrintMatrix();
            }
        }

        static void PrintLogo(string logo)
        {
            StreamReader reader = new StreamReader(logo);
            Console.BackgroundColor = ConsoleColor.Black;
            using (reader)
            {
                string text = reader.ReadLine();
                while (text!=null)
                {
                    for (int row = 0; row < text.Length; row++)
                    {
                        if (text[row] == '1')
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        Console.Write(text[row]);
                    }
                    Console.WriteLine();
                    text = reader.ReadLine();
                }
            }

            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }
    }
}
