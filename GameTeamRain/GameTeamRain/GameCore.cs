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
            InitCoreMatrix();
        }

        public void InitCoreMatrix()
        {

        }
        public bool IsGameWon()
        {
            
        }

        public bool IsGameOver()
        {

        }

        public void addNewNumber()
        {

        }

        public void PrintMatrix()
        {

        }

        public bool ReCalculateMatrix()
        {
            bool isChangeCoreMatrix = false;
            while (!isChangeCoreMatrix)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key.ToString())
                {
                    case "RightArrow": isChangeCoreMatrix = CalculateRightDirection();
                        break;
                    case "UpArrow": isChangeCoreMatrix = CalculateUpDirection();
                        break;
                    case "DownArrow": isChangeCoreMatrix = CalculateDownDirection();
                        break;
                    case "LeftArrow": isChangeCoreMatrix = CalculateLeftDirection();
                        break;
                    default:
                        break;
                }
            }
            return isChangeCoreMatrix;
        }
        public bool CalculateDirection(ushort[,] currentMatrix)
        {
            bool isChange = false;
            for (int row = 0; row < currentMatrix.GetLength(0); row++)
            {
                int position = 0;
                ushort currentCell = 0;
                for (int col = 0; col < currentMatrix.GetLength(1) - 1; col++)
                {
                    if (currentMatrix[row, col] != 0)
                    {
                        for (int cell = col + 1; cell < currentMatrix.GetLength(1); cell++)
                        {
                            if ((currentMatrix[row, cell] != 0))
                            {
                                if ((currentMatrix[row, col] == currentMatrix[row, cell]))
                                {
                                    currentCell = (ushort)(currentMatrix[row, col] * 2);
                                    currentMatrix[row, col] = 0;
                                    currentMatrix[row, cell] = 0;
                                    currentMatrix[row, position] = currentCell;
                                    position++;
                                    col = cell;
                                    isChange = true;
                                    break;
                                }
                                else
                                {
                                    currentCell = currentMatrix[row, col];
                                    currentMatrix[row, col] = 0;
                                    currentMatrix[row, position] = currentCell;
                                    position++;
                                    col = cell - 1;
                                    isChange = true;
                                    break;
                                }

                            }
                        }
                    }
                }
                if ((position == 0) && (currentMatrix[row, position] == 0))
                {

                    for (int j = 0; j < currentMatrix.GetLength(0); j++)
                    {
                        if (currentMatrix[row, j] != 0)
                        {
                            currentMatrix[row, position] = currentMatrix[row, j];
                            currentMatrix[row, j] = 0;
                            isChange = true;
                            break;
                        }
                    }
                }
                if ((currentMatrix[row, currentMatrix.GetLength(1) - 2] == 0) && currentMatrix[row, currentMatrix.GetLength(1) - 1] != 0)
                {
                    currentMatrix[row, position] = currentMatrix[row, currentMatrix.GetLength(1) - 1];
                    currentMatrix[row, currentMatrix.GetLength(1) - 1] = 0;
                }
            }
            return isChange;
        }
        public bool CalculateRightDirection()
        {
            ushort[,] currentMatrix = new ushort[this.coreMatrix.GetLength(0), this.coreMatrix.GetLength(1)];
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    currentMatrix[row, col] = this.coreMatrix[row, this.coreMatrix.GetLength(1) - col - 1];
                }
            }

            bool isChange = CalculateDirection(currentMatrix);

            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    this.coreMatrix[row, col] = currentMatrix[row, this.coreMatrix.GetLength(1)-col-1];
                }
            }
            return isChange;
        }

        public bool CalculateLeftDirection()
        {
           bool isChange = CalculateDirection(this.coreMatrix);
           return isChange;
            
        }

        public bool CalculateUpDirection()
        {
            ushort[,] currentMatrix = new ushort[this.coreMatrix.GetLength(0), this.coreMatrix.GetLength(1)];
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    currentMatrix[row,col]=this.coreMatrix[col,this.coreMatrix.GetLength(1)-row-1];
                }
            }
            bool isChange = CalculateDirection(currentMatrix);

            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    this.coreMatrix[col, this.coreMatrix.GetLength(1) - row - 1] =currentMatrix[row, col];
                }
            }

            return isChange;
        }

        public bool CalculateDownDirection()
        {
            ushort[,] currentMatrix = new ushort[this.coreMatrix.GetLength(0), this.coreMatrix.GetLength(1)];

            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    currentMatrix[row, col] = this.coreMatrix[this.coreMatrix.GetLength(1) - col - 1,row];
                }
            }

            bool isChange = CalculateDirection(currentMatrix);

            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    this.coreMatrix[this.coreMatrix.GetLength(1) - col - 1, row] = currentMatrix[row, col];
                }
            }
            return isChange;
        }
    }
}
