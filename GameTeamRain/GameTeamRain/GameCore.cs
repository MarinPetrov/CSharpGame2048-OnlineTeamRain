namespace GameTeamRain
{
    using System;
    using System.Collections.Generic;
    class GameCore
    {
        private ushort[,] coreMatrix;
        private Random randomNumber;
        public GameCore()
        {
            this.coreMatrix = new ushort[4, 4];
            this.randomNumber = new Random();
            InitCoreMatrix();
        }

        private void InitCoreMatrix()
        {
            int row = (ushort)(randomNumber.Next(0, 4));
            int col = (ushort)(randomNumber.Next(0, 4));
            if (row + col < 4)
            {
                this.coreMatrix[row, col] = 2;
            }
            else
            {
                this.coreMatrix[row, col] = 4;
            }

        }
        public bool IsGameWon()
        {
            bool isWon = false;
            for (int i = 0; i < this.coreMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.coreMatrix.GetLength(1); j++)
                {
                    if (coreMatrix[i, j] == 2048)
                    {
                        isWon = true;
                    }
                }
            }

            return isWon;
        }

        public bool IsGameOver()
        {
            bool gameLost = true;
            for (int i = 0; i < this.coreMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.coreMatrix.GetLength(1); j++)
                {
                    if (this.coreMatrix[i, j] == 0)
                    {
                        gameLost = false;
                        return gameLost;
                    }
                }
            }
            for (int i = 0; i < this.coreMatrix.GetLength(0); i++)
            {
                int col = 0;
                for (int j = 1; j < this.coreMatrix.GetLength(1); j++)
                {
                    if (this.coreMatrix[i, col] == this.coreMatrix[i, j])
                    {
                        gameLost = false;
                        return gameLost;
                    }
                    else
                    {
                        col++;
                    }
                }
            }
            for (int k = 0; k < this.coreMatrix.GetLength(1); k++)
            {
                int row = 0;
                for (int j = 1; j < this.coreMatrix.GetLength(0); j++)
                {
                    if (this.coreMatrix[row, k] == this.coreMatrix[j, k])
                    {
                        gameLost = false;
                        return gameLost;
                    }
                    else
                    {
                        row++;
                    }
                }
            }

            return gameLost;
        }

        public void AddNewNumber()
        {
            List<ushort[]> randomPositions = new List<ushort[]>();
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    if (this.coreMatrix[row, col] == 0)
                    {
                        randomPositions.Add(new ushort[] { (ushort)row, (ushort)col });
                    }
                }
            }
            if (randomPositions.Count != 0)
            {
                int number = this.randomNumber.Next(randomPositions.Count);
                ushort x = randomPositions[number][0];
                ushort y = randomPositions[number][1];

                if (this.randomNumber.Next(10) < 7)
                {
                    this.coreMatrix[x, y] = 2;
                }
                else
                {
                    this.coreMatrix[x, y] = 4;
                }
            }
        }

        public void PrintMatrix()
        {
            Console.CursorTop = 1;
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                Console.CursorLeft = 5;

                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    int num = this.coreMatrix[row, col];
                    switch (num)
                    {
                        case 0: Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                        case 2: Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case 4: Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case 8: Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 16: Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 32: Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 64: Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 128: Console.ForegroundColor = ConsoleColor.DarkCyan;
                            break;
                        case 256: Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        case 512: Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                        case 1024: Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        default: Console.ForegroundColor = ConsoleColor.Red;
                            break;
                    }

                    Console.Write("{0,5}", (this.coreMatrix[row, col]));

                }
                Console.CursorTop += 2;
            }
        }

        public void ReCalculateMatrix()
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
            if (isChangeCoreMatrix)
            {
                AddNewNumber();
            }
        }
        private bool CalculateDirection(ushort[,] currentMatrix)
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
                    isChange = true;
                }
                if ((currentMatrix[row, currentMatrix.GetLength(1) - 3] == 0) && (currentMatrix[row, currentMatrix.GetLength(1) - 2] != 0))
                {
                    currentMatrix[row, position] = currentMatrix[row, currentMatrix.GetLength(1) - 2];
                    currentMatrix[row, currentMatrix.GetLength(1) - 2] = 0;
                    isChange = true;
                }
            }
            return isChange;
        }
        public bool CalculateRightDirection()
        {
            ushort[,] currentMatrix = new ushort[this.coreMatrix.GetLength(0), this.coreMatrix.GetLength(1)];
            //rotate matrix to left
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    currentMatrix[row, col] = this.coreMatrix[row, this.coreMatrix.GetLength(1) - col - 1];
                }
            }

            bool isChange = CalculateDirection(currentMatrix);
            //rotate matrix to right
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    this.coreMatrix[row, col] = currentMatrix[row, this.coreMatrix.GetLength(1) - col - 1];
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
            //rotate matrix to left
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    currentMatrix[row, col] = this.coreMatrix[col, this.coreMatrix.GetLength(1) - row - 1];
                }
            }
            bool isChange = CalculateDirection(currentMatrix);
            //rotate matrix to up
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    this.coreMatrix[col, this.coreMatrix.GetLength(1) - row - 1] = currentMatrix[row, col];
                }
            }

            return isChange;
        }

        public bool CalculateDownDirection()
        {

            ushort[,] currentMatrix = new ushort[this.coreMatrix.GetLength(0), this.coreMatrix.GetLength(1)];
            //rotate matrix to left 
            for (int row = 0; row < this.coreMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.coreMatrix.GetLength(1); col++)
                {
                    currentMatrix[row, col] = this.coreMatrix[this.coreMatrix.GetLength(1) - col - 1, row];
                }
            }

            bool isChange = CalculateDirection(currentMatrix);
            //rotate matrix to right
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
