using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAd
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Strength { get; set; }
        public int Perception { get; set; }

        public List<string> Inventory { get; private set; } = new List<string>();

        public static void AddToInventory(List<string> inventory, string item)
        {
            if (!inventory.Contains(item))
            {
                inventory.Add(item);
                Console.WriteLine($"You have added {item} to your inventory!");
                Console.WriteLine("Your current inventory: " + string.Join(", ", inventory));

            }
            else
            {
                Console.WriteLine("You already have that item!");
            }
        }

        public void DisplayStats()
        {
            Console.WriteLine("\n--- Character Stats ---");
            Console.WriteLine($"Health:  {Health}");
            Console.WriteLine($"Strength: {Strength}");
            Console.WriteLine($"Agility:  {Agility}");
            Console.WriteLine($"Intellect:   {Intellect}");
            Console.WriteLine($"Perception: {Perception}");
            Console.WriteLine("Inventory: " + (Inventory.Count > 0 ? string.Join(", ", Inventory) : "Empty"));
            Console.WriteLine("------------------------\n");
        }

        public static Character CreateCharacter()
        {
            Character character = new Character();
            int totalPoints = 10;

            Console.WriteLine("You have 10 points to allocate to your stats");
            Console.WriteLine("Distribute them among Strength, Intelligence, Agility, Perception and Intellect");

            character.Strength = AllocateStat("Strength", ref totalPoints);
            character.Intellect = AllocateStat("Intelligence", ref totalPoints);
            character.Agility = AllocateStat("Agility", ref totalPoints);
            character.Perception = AllocateStat("Perception", ref totalPoints);

            character.Health = totalPoints;

            Console.WriteLine($"Remaining {totalPoints} have been assigned to Health");
            
            Console.WriteLine($"The stats of {character}");
            character.DisplayStats();
            
            return character;
        }
        public static int AllocateStat(string statName, ref int remainingPoints)
        {
            int value = 0;
            while(true)
            {
                Console.WriteLine($"How many Points do you want to allocate to {statName}? (0 to 9");
                string input = Console.ReadLine();
                if (int.TryParse(input, out value) && value > 0 && value <= remainingPoints)
                {
                    remainingPoints -= value;
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid Entry please enter a number within the allowed range.");
                }
            }

        }
        public void ModifyStat(string stat, int amount)
        {
            switch (stat.ToLower())
            {
                case "strength":
                    Strength = Math.Max(0, Strength + amount);
                    break;
                case "intellect":
                    Intellect = Math.Max(0, Intellect + amount);
                    break;
                case "perception":
                    Perception = Math.Max(0, Perception + amount);
                    break;
                case "agility":
                    Agility = Math.Max(0, Agility + amount);
                    break;
                case "health":
                    Health = Math.Max(0, Health + amount);
                    break;
                default:
                    Console.WriteLine("not used");
                    break;
            }
        }
    }

   
}
