using System;

namespace NavyBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] battlefield = new string[size, size];

            int submarineRow = -1;
            int submarineCol = -1;
            int minesTouched = 3;
            int cruisesDestroyed = 0;

            for (int rows = 0; rows < size; rows++)
            {
                string inputRow = Console.ReadLine();
                for (int cols = 0; cols < size; cols++)
                {
                    battlefield[rows,cols] = inputRow[cols].ToString();

                    if (battlefield[rows,cols] == "S")
                    {
                        submarineRow = rows;
                        submarineCol = cols;
                    }
                }
            }

            while (true)
            {
                battlefield[submarineRow, submarineCol] = "-";   
                string direction = Console.ReadLine();

                switch (direction)
                {
                    case "up":
                        submarineRow--;
                        break;
                    case "down":
                        submarineRow++;
                        break;
                    case "left":
                        submarineCol--;
                        break;
                    case "right":
                        submarineCol++;
                        break;

                      
                }
                if (battlefield[submarineRow,submarineCol]=="C")
                {
                    
                    if (cruisesDestroyed < 3)
                    {
                        cruisesDestroyed++;
                     battlefield[submarineRow, submarineCol] = "-";
                        if (cruisesDestroyed == 3)
                        {
                            Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                            break;
                        }
                    }
                    
                }

                if (battlefield[submarineRow,submarineCol]=="*")
                {
                    if (minesTouched>0)
                    {
                        
                        minesTouched--;
                        battlefield[submarineRow, submarineCol] = "-";

                        if (minesTouched==0)
                        {
                            Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{submarineRow}, {submarineCol}]!");
                            break;
                        }

                    }
                   
                }
               
            }
            battlefield[submarineRow, submarineCol] = "S";

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(battlefield[row,col]);
                }
                Console.WriteLine();
            }

        }
    }
}