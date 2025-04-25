using System.Numerics;

namespace TextBasedAd
{
    internal class Program
    {
        public static Random random = new Random();
        public static bool restart = true;
        static void Main(string[] args)
        {
            while (restart)
            {
                Console.Clear();

                Character player = Character.CreateCharacter(); 


                Console.WriteLine("Greetings Adventurer, you find yourself in a dark forest.....");
                Console.WriteLine("You see two paths ahead, one goes right, the other goes left.");
                Console.WriteLine("");
                Console.WriteLine("Which path do you choose to take?");

                string choice = GetUserInput(new List<string> { "left", "right" }, "Which path do you choose?");

                if (choice == "stats")
                {
                    player.DisplayStats();
                    continue;
                }

                if (choice == "left")
                {
                    EnterCabin(player);
                }
                else if (choice == "right")
                {
                    EnterBog(player);
                }

                RestartGame(player);
            }
        }

        static void EnterCabin(Character player)
        {
            RandomEvent();
            Console.WriteLine("You walk down the left pathway, you walk down the narrow pathway, at its ending lies a cabin!");
            Console.WriteLine("");
            string action = GetUserInput(new List<string> { "enter", "continue" }, "Do you'Enter' the cabin? or 'continue' down the path?");

            if (action == "enter")
            {
                Console.WriteLine("as you slowly open the door to the old cabin, you notice the smokey smell of a burnt out fireplace.");
                Console.WriteLine("as you creep inside the cabin, the door shuts violently behind you.");
                Console.WriteLine("");
                Console.WriteLine("what do you do now? Do you try and 'Force' the door open? or do you 'Explore' the cabin?");
                string cabinAction = GetUserInput(new List<string> { "force", "explore" }, "Do you look to 'force' the door or 'explore' the room?");

                if (cabinAction == "force")
                {
                    Console.WriteLine("The door begins to creak under the force being placed upon the hinges");
                    Console.WriteLine("As the door hinges begin to creak and moan under the force, you miss the sound of the wooden floor beneath you giving away");
                    Console.WriteLine("You fall into a pit of broken planks, breaking your ankle and fracturing your arm, you cant stand nevermind climb out.");
                    DeathMessage(player);
                }
                else if (cabinAction == "explore")
                {
                    Console.WriteLine("You look around the cabin, noticing that the building looks in a state of disrepair. You sigh glad you didnt try and force the door.");
                    Console.WriteLine("After pacing around the cabin looking for a way out you notice a hole behind the fireplace, the heating and cooling of the fire must have weakened the boards enough for the wood to give way.");
                    Console.WriteLine("you poke the wooden board with a poker you find near the door, the board comes loose and you can see the forest again.");
                    Console.WriteLine("");
                    Console.WriteLine("do you 'escape' into the forest or 'look' around to see if you can find any items that can help you escape the forest?");

                    string escapeQuestion = GetUserInput(new List<string> { "look", "escape" }, "Do you look to 'escape' or 'look' around for any helpful items");
                    if (escapeQuestion == "look")
                    {
                        Console.WriteLine("you begin to check the areas of the inside of the cabin in question.");
                        Console.WriteLine("Searching the kitchen draws you are surprised to find a detailed map of the forest.");
                        Console.WriteLine("Excitedly you stuff the map into your pockets, knowing you now have safe passage out.");
                        player.Inventory.Add("detailed map");
                    }
                    else if (escapeQuestion == "escape")
                    {
                        Console.WriteLine("You push yourself through the hole, and begin sprinting away from the death trap of a cabin. ");
                        Console.WriteLine("As you look around, you have no idea where you are in the forest. You realise youve been running around in circles for what feels like days.");
                        DeathMessage(player);
                    }
                }
            }
            else if (action == "continue")
            {
                Console.WriteLine("You continue down the pathway, as you walk the cabin behind you gets further and further away.");
                Console.WriteLine("Eventually you begin to hear the faint sound of a distant a river.");
                Console.WriteLine("Realising you are thristy and havent drank in some time you walk towards the sound");
                Console.WriteLine("you lean forward over the river and begin to frantically scoop water into your mouth, gulping down the fresh water.");
                if (player.Perception >= 4)
                {
                    Console.WriteLine("as you're leaning forward, you begin to feel the ground shift under your weight, realising that you're on unstable ground you shift back quickly!");
                    if (player.Agility >= 3)
                    {
                        Console.WriteLine("Your quick reactions save your life!");
                        Console.WriteLine("You watch as the riverbank before you crumbles into the river.");
                        Console.WriteLine("you'd surely have falled into the river if not for your Perception and Agility!");

                    }
                    else
                        DeathMessage(player);

                }
                else
                    DeathMessage(player);
                
                RestartGame(player);
            }
        }

        static void EnterBog(Character player)
        {
            Console.WriteLine("You wander into a deep bog, the wet ground beneath you starts to slush and rise up to meet your footfall as you walk");
            Console.WriteLine("as you persist further into the bog, you begin to tire, even starting to stumble as you push onwards.");
            player.ModifyStat("strength", -1);
            Console.WriteLine("You feel drained. Your Strength is reduced by 1.");
            if (player.Perception >= 5)
            {
                Console.WriteLine("You feel the vibrations of something else in the water.");
                Console.WriteLine("as your eyes scan around you see the big yellow eyes of a crocodile staring back at you");
                if (player.Intellect >= 4)
                {
                    Console.WriteLine("You remember reading that crocodiles mainly hunt using ambush tactics, by staying away and keeping your guard up, you should be majorly safe!");

                }
                else if (player.Strength >= 5)
                {
                    Console.WriteLine("You have no care for the crocodile that hunts you, believing that you are the predator and it is your prey.");
                    Console.WriteLine("In fact you hope the beast approaches you, looking eagerly for a fight!");
                    Console.WriteLine("The crocodile, sensing your bloodlust, realises you arent the easy meal it planned and backs off into the swamp.");
                }
                else
                {
                    Console.WriteLine("you carry on walking, completely aware of the crocodile, but unfortunately ill-equipped to deal with it head on.");
                    Console.WriteLine("the crocodile, sensing you are no real threat as well as slowed down by the bog underfoot.");
                    DeathMessage(player);
                }

            }
            else
            {
                Console.WriteLine("your tiredness numbs your senses, you dont notice that you are being stalked by a giant beast.");
                Console.WriteLine("Your lack of Perception leads you to being hunted by a Crocodile, the beast lurches forward and pulls you deeper into the swamp.");
                DeathMessage(player);
            }
        }


        public static void RestartGame(Character player)
        {
            Console.WriteLine("You have unfortunately died. would you like to replay the adventure? or would you like to quit the game?");
            string restartAction = GetUserInput(new List<string> { "yes", "no" }, "Do you want to Replay the adventure?");

            if (restartAction == "yes")
            {
                restart = true;
            }
            else if (restartAction == "no")
            {
                restart = false;
            }
        }

        static void RandomEvent()
        {
            int roll = random.Next(1, 11);

            if (roll == 1)
            {
                Console.WriteLine("\nTo your surprise a rustle of bushes behind you shows a Fox kit.");
                Console.WriteLine("\nThe brush with such young life has stilled some of the anxiety within your chest.");
            }
            else if (roll == 2)
            {
                Console.WriteLine("\nA flash of steel infront of your eyes catches you by surprise, you quickly look to see an arrow embedded into a nearby tree");
                Console.WriteLine("\nYour heart begins to race more after such a close encounter with death.");
            }
            else if (roll == 3)
            {
                Console.WriteLine("\nYou trip over something in the darkness of the forest.");
                Console.WriteLine("\nLooking you notice the hilt of a weapon of some kind, you raise the sword and find it dirty but usable.");
            }
        }

        public static void DeathMessage(Character player)
        {
            Console.WriteLine("Unfortunately, you have died, there was a way for you to have survived");
            Console.WriteLine("Maybe with different stats or if you found an item to help.");
            Console.WriteLine("the outcome would be different, Please try again!");
            RestartGame(player);
        }

        public static string GetUserInput(List<string> validChoices, string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine()?.Trim().ToLower();

            } while (!validChoices.Contains(input));

            return input;
        }
    }
}








