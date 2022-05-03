namespace RoverApp
{
    internal class Rover
    {
        public static int UP = 24;
        public static int DOWN = 25;
        public static int LEFT = 17;
        public static int RIGHT = 26;
        private int[,] chart { get; set; }
        public Rover(int size)
        {
            int direction = new Random().Next(24, 28);
            if (direction == 27) direction = LEFT;
            chart = new int[size, size];
            CreateMatrix(size);
            chart[0, 0] = SetCorrectDirection(0, 0, chart.GetLength(0) - 1, direction);
            PrinTMatrix();
        }

        public void Move(ConsoleKeyInfo Key)
        {
            switch (Key.Key)
            {
                case ConsoleKey.UpArrow:
                    NextMove(UP);
                    break;
                case ConsoleKey.DownArrow:
                    NextMove(DOWN);
                    break;
                case ConsoleKey.RightArrow:
                    NextMove(RIGHT);
                    break;
                case ConsoleKey.LeftArrow:
                    NextMove(LEFT);
                    break;
                default:
                    PrinTMatrix();
                    Console.WriteLine("Please press the correct key.");
                    break;
            }
        }

        //This method changes the arrow index based on the input arrow.
        private void NextMove(int directionASCII)
        {
            int[] arr = FindIndex(directionASCII);

            if (chart[arr[0], arr[1]] != directionASCII)
            {
                chart[arr[0], arr[1]] = SetCorrectDirection(arr[0], arr[1], chart.GetLength(0) - 1, directionASCII);
                PrinTMatrix();
                return;
            }
            chart[arr[0], arr[1]] = 0;

            if (directionASCII == UP)
            {
                if (arr[0] != 0) arr[0] -= 1;
            }
            if (directionASCII == DOWN)
            {
                if (arr[0] != chart.GetLength(0)) arr[0] += 1;
            }
            if (directionASCII == RIGHT)
            {
                if (arr[1] != chart.GetLength(0)) arr[1] += 1;
            }
            if (directionASCII == LEFT)
            {
                if (arr[1] != 0) arr[1] -= 1;
            }
            chart[arr[0], arr[1]] = SetCorrectDirection(arr[0], arr[1], chart.GetLength(0) - 1, directionASCII);
            PrinTMatrix();
        }

        //Creates matrix based on size
        private void CreateMatrix(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    chart[i, j] = 0;
                }
            }
        }

        //Returns the index of the arrow, indecs[0] would be the x axis and indecs[1] would be y
        private int[] FindIndex(int directionASCII)
        {
            int[] indecs = new int[2];

            for (int i = 0; i < chart.GetLength(0); i++)
            {
                for (int j = 0; j < chart.GetLength(1); j++)
                {
                    if (chart[i, j] == UP || chart[i, j] == DOWN || chart[i, j] == RIGHT || chart[i, j] == LEFT)
                    {
                        indecs[0] = i;
                        indecs[1] = j;
                        return indecs;
                    }
                }
            }
            return indecs;
        }

        //Sets the correct direction, just so the arrow wont go out of matrix limits
        private int SetCorrectDirection(int x, int y, int maxIndex, int direction)
        {
            // corners
            if (x == 0)
            {
                if (y == 0 && (direction == UP || direction == LEFT))
                {
                    return direction == UP ? DOWN : RIGHT;
                }
                if (y == maxIndex && (direction == UP || direction == RIGHT))
                {
                    return direction == UP ? LEFT : DOWN;
                }
            }
            if (x == maxIndex)
            {
                if (y == 0 && (direction == DOWN || direction == LEFT))
                {
                    return direction == DOWN ? UP : RIGHT;
                }
                if (y == maxIndex && (direction == DOWN || direction == RIGHT))
                {
                    return direction == DOWN ? UP : LEFT;
                }
            }
            // at the edge but between corners
            if (x > 0 && x < maxIndex)
            {
                if (y == 0 && direction == LEFT)
                {
                    return RIGHT;
                }
                if (y == maxIndex && direction == RIGHT)
                {
                    return LEFT;
                }
            }
            if (y > 0 && y < maxIndex)
            {
                if (x == 0 && direction == UP)
                {
                    return DOWN;
                }
                if (x == maxIndex && direction == DOWN)
                {
                    return UP;
                }
            }
            return direction;
        }

        private void PrinTMatrix()
        {
            for (int i = 0; i < chart.GetLength(0); i++)
            {
                for (int j = 0; j < chart.GetLength(0); j++)
                {
                    if (chart[i, j] == UP || chart[i, j] == DOWN || chart[i, j] == RIGHT || chart[i, j] == LEFT)
                    {
                        Console.Write((char)chart[i, j] + " ");
                    }
                    else
                    {
                        Console.Write(chart[i, j] + " ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
