using ConsoleApp1.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    internal class Menus
    {
        public static void DisplayMovementMenu(Player player, Dungeon dungeon)
        {
            var invalidChoice = true;

            Console.Clear();
            while (invalidChoice)
            {
                // you failed!

                string movementMenu =
                    "Movement Options:\n1.) Kick a new door down\n2.) Enter an unlocked room\n3.) Back" +
                    "\n\nPlease choose (1,2, or 3 to exit)";
                Console.WriteLine(movementMenu);
                var choice = Console.ReadLine();
                //if choice is good
                if (choice == "1" || choice == "2")
                {
                    Actions.MovePlayerToRoom(player, dungeon);
                }
                if (choice == "3")
                {
                    DisplayMainActionsMenu(player, dungeon);
                }

                if (choice == "1" && choice == "2" && choice == "3")
                {
                    invalidChoice = false;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid choice. Please try again");
                }
            }

        }

        public static void DisplayMainActionsMenu(Player player, Dungeon dungeon)
        {
            Console.Clear();
            Console.WriteLine(player.name + "'s turn!\n ------------ \n Actions:");

            string actionMenu = "1.) Move\n2.) Rest and heal\n\nPlease choose (1 or 2)";
            Console.WriteLine(actionMenu);
            var choice = Console.ReadLine();
            //if choice is good then
            if (choice == "1")
            {
                Menus.DisplayMovementMenu(player, dungeon);
            }
            if (choice == "2")
            {
                //RestAndHeal
            }
        }

        public static void DisplayIntro(List<Player> players)
        {
            string dialogue = "\"Ahh... A new batch of rangers looking for their share of loot...\nWelcome";
            for (int i = 0; i < players.Count; i++)
            {
                string tmp = ", " + players[i].name;
                dialogue += tmp;

            }
            dialogue += "\"\n\nPress any key to continue";
            Console.WriteLine(dialogue);
            Console.ReadKey();
        }

    }
}
