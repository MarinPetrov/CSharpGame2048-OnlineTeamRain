namespace GameTeamRain
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    class GameTeamRainLogic
    {
        static void Main()
        {
            Console.Title = "CSharpGame2048-OnlineTeamRain";

            string telerik = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011111111110011111111100110000000111111111001111110000111100110001100000000000001100110011001111111110011000000011111111100110000110011110011001100000000000000110011001100110000000001100000001100000000011000011000110001101100000000000000011001100110011111111100110000000111111111001100001100011000111100000000000000000000110000001111111110011000000011111111100111111100001100011110000000000000000000011000000110000000001100000001100000000011110000000110001101100000000000000000001100000011111111100110000000111111111001100110000111100110011000000000000000000110000001111111110011111110011111111100110000110011110011000110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            char[,] charArray = new char[19, 79];
            int counter = 0;
            for (int row = 0; row < 19; row++)
            {
                for (int col = 0; col < 79; col++)
                {
                    charArray[row, col] = telerik[counter];
                    counter++;
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < 19; row++)
            {
                for (int col = 0; col < 79; col++)
                {
                    if (charArray[row, col] == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(charArray[row, col]);
                }
                Console.WriteLine();
            }

            Thread.Sleep(4000);
            Console.Clear();

            GameCore engine = new GameCore();
            Console.CursorVisible = false;
            engine.PrintMatrix();
            while (true)
            {
                engine.ReCalculateMatrix();

                if (engine.IsGameWon())
                {
                    Console.WriteLine("You Won");
                }
                if (engine.IsGameOver())
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("GAME OVER");
                }
                engine.PrintMatrix();
            }
        }
    }
}
