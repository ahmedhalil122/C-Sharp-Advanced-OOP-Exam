using System;
using System.Collections.Generic;
using System.Linq;

namespace Rubber_Duck_Debuggers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] timeInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] tasksInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> tasks = new(tasksInput);
            Queue<int> timeSequence = new(timeInput);


            Dictionary<string, int> ducks = new()
            {
                { "Darth Vader Ducky", 0 },
                { "Thor Ducky", 0 },
                { "Big Blue Rubber Ducky", 0 },
                { "Small Yellow Rubber Ducky", 0 }
            };


            while (timeSequence.Any() && tasks.Any())
            {

                int points = timeSequence.Peek() * tasks.Peek();
                if (points >= 0 && points <= 240)
                {
                    if ((points > 0) && (points <= 60))
                    {
                        ducks["Darth Vader Ducky"]++;
                    }
                    else if ((points > 60) && (points <= 120))
                    {
                        ducks["Thor Ducky"]++;
                    }
                    else if ((points > 120) && (points <= 180))
                    {
                        ducks["Big Blue Rubber Ducky"]++;
                    }
                    else if ((points > 180) && (points <= 240))
                    {
                        ducks["Small Yellow Rubber Ducky"]++;
                    }
                    tasks.Pop();
                    timeSequence.Dequeue();
                    continue;
                }

                else
                {

                    tasks.Push(tasks.Pop() - 2);
                    timeSequence.Enqueue(timeSequence.Dequeue());
                }




            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");

            foreach (var duck in ducks)
            {
                Console.WriteLine($"{duck.Key}: {duck.Value}");
            }

        }
    }
}