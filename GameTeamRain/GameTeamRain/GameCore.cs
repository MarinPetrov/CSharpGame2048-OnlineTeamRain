namespace GameTeamRain
{
    using System;
    using System.Collections.Generic;
    class GameCore
    {
        private ushort[,] coreMatrix;
        private Random randomNumber = new Random();
        public GameCore()
        {
            this.coreMatrix = new ushort[4, 4];
        }
    }
}
