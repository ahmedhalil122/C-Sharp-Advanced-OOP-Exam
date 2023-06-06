using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace ApocalypsePreparation;

internal class Program
{
    static void Main(string[] args)
    {
        Queue<int> textile = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

        Dictionary<string, int> healingItems = new()
        {
            { "Patch", 0 },
            { "Bandage", 0 },
            { "MedKit", 0 }
        };
        while (textile.Any() && medicaments.Any())
        {
            int sum = textile.Peek() + medicaments.Peek();

            if (sum == 30 || sum == 40 || sum == 100)
            {
                if (sum == 30)
                {
                    healingItems["Patch"]++;
                }
                else if (sum == 40)
                {
                    healingItems["Bandage"]++;
                }
                else if (sum == 100)
                {
                    healingItems["MedKit"]++;
                }
                textile.Dequeue();
                medicaments.Pop();
            }
            else if (sum > 100)
            {
                healingItems["MedKit"]++;
                textile.Dequeue();
                medicaments.Pop();
                int medicamentToIncrease = medicaments.Pop();
                medicaments.Push(medicamentToIncrease + (Math.Abs(100 - sum)));
            }
            else
            {
                textile.Dequeue();
                int currentMedicaments = medicaments.Pop();

                medicaments.Push(currentMedicaments + 10);
            }

        }

        if (!textile.Any() && !medicaments.Any())
        {
            Console.WriteLine("Textiles and medicaments are both empty.");
            foreach (var item in healingItems.Where(x => x.Value != 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
        else if (!textile.Any())
        {
            Console.WriteLine("Textiles are empty.");
            foreach (var item in healingItems.Where(x => x.Value != 0).OrderByDescending(x => x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
        }
        else if (!medicaments.Any())
        {
            Console.WriteLine("Medicaments are empty.");
            foreach (var item in healingItems.Where(x => x.Value != 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.WriteLine($"Textiles left: {string.Join(", ", textile)}");
        }
    }
}