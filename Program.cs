using System;

namespace TradingCardGameConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListOfCards.InitializeCardValues();
            var cards = ListOfCards.CreateCards();
            var player = new Player(200); // Starting with 200 essence
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. Start Game");
                Console.WriteLine("2. Game Lore");
                Console.WriteLine("3. Exit Game");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        StartGame(player, cards);
                        break;
                    case "2":
                        DisplayGameLore();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        static void StartGame(Player player, List<Card> cards)
        {
            bool inGame = true;
            while (inGame)
            {
                Console.WriteLine("\nGame Menu:");
                Console.WriteLine("1. Draw Card");
                Console.WriteLine("2. Sell Card");
                Console.WriteLine("3. Check Inventory");
                Console.WriteLine("4. Back to Menu");
                Console.Write("Choose an action: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        player.DrawCardFromDeck(cards);
                        break;
                    case "2":
                        player.SellCard();
                        break;
                    case "3":
                        player.CheckInventory(cards);
                        break;
                    case "4":
                        inGame = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }


        static void DisplayGameLore()
        {
            Console.WriteLine("\nGame Lore:");
            Console.WriteLine(GameLore.GetLore());
        }
    }
}
