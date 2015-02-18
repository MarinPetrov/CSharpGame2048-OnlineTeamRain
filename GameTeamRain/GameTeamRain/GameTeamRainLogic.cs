namespace GameTeamRain
{
    using System;
    using System.Collections.Generic;
    class GameTeamRainLogic
    {
        static void Main()
        {
            GameCore engine = new GameCore();
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
                    Console.WriteLine("GAME OVER");
                }
                engine.PrintMatrix();
            }
        }
    }
}
