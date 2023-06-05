using System;
using System.Collections.Generic;

namespace TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            string[,] field = new string[fieldSize, fieldSize];

            Queue<string> directions = new Queue<string>(Console.ReadLine().Split(", "));

            bool outOfBounds = false;

            int collectedHazelnuts = 0;

            int squirrelRow = -1;
            int squirrelCol = -1;

            for (int row = 0; row < fieldSize; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = rowInput[col].ToString();

                    if (field[row, col] == "s")
                    {
                        squirrelRow = row;
                        squirrelCol = col;
                    }
                }
            }

            while (directions.Count > 0)
            {
                string direction = directions.Dequeue();

                switch (direction)
                {
                    case "up":
                        squirrelRow--;
                        break;
                    case "down":
                        squirrelRow++;
                        break;
                    case "left":
                        squirrelCol--;
                        break;
                    case "right":
                        squirrelCol++;
                        break;
                }

                if (OutOfRange(squirrelRow, squirrelCol, fieldSize))
                {
                    Console.WriteLine("The squirrel is out of the field.");
                    PrintHazelnuts();
                    return;
                }

                if (field[squirrelRow, squirrelCol] == "h")
                {
                    collectedHazelnuts++;
                    field[squirrelRow, squirrelCol] = "*";
                }

                if (field[squirrelRow, squirrelCol] == "t")
                {
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    PrintHazelnuts();
                    return;
                }
            }

            if (collectedHazelnuts < 3)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
                PrintHazelnuts();
            }
            else
            {
                Console.WriteLine("Good job! You have collected all hazelnuts!");
                PrintHazelnuts();
            }

            void PrintHazelnuts()
            {
                Console.WriteLine($"Hazelnuts collected: {collectedHazelnuts}");
            }
        }

        static bool OutOfRange(int row, int col, int fieldSize)
        {
            return row < 0 || row >= fieldSize || col < 0 || col >= fieldSize;
        }
    }
}
