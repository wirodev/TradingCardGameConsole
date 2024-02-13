using System;
using System.Collections.Generic;
using System.Linq;

namespace TradingCardGameConsole
{
    public class Player
    {
        public int Coins { get; set; } // Renamed to 'Essence' in the narrative, but kept as 'Coins' in code for clarity
        public List<Card> Inventory { get; private set; }

        public Player(int startingCoins)
        {
            Coins = startingCoins;
            Inventory = new List<Card>();
        }

        // Method to add a card to the player's inventory
        public void AddCard(Card card)
        {
            Inventory.Add(card);
            Console.WriteLine($"Added {card.Name} to inventory.");
        }

        // Method for the player to draw a card, affecting their essence and adding the card to their inventory
        public void DrawCardFromDeck(List<Card> deck)
        {
            const int drawCost = 50; // Cost in essence to draw a card
            if (Coins >= drawCost)
            {
                // Assuming DrawCard is a class name, and DrawCardWithProbability is a static method within it.
                Card drawnCard = DrawCard.DrawCardWithProbability(deck);
                Coins -= drawCost; // Deduct the cost of drawing a card
                Coins += drawnCard.Value; // Add the value of the drawn card to essence
                Inventory.Add(drawnCard); // Add the drawn card to the inventory
                Console.WriteLine($"Drawn Card: {drawnCard.Name}, Essence after draw: {Coins}");
            }
            else
            {
                Console.WriteLine("Not enough essence to draw a card.");
            }
        }

        // Method to allow the player to sell a card from their inventory
        public void SellCard()
        {
            Console.WriteLine("Select a card to sell:");
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Inventory[i].Name} - Value: {Inventory[i].Value}");
            }
            Console.Write("Enter the number of the card to sell (or 0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= Inventory.Count)
            {
                Card cardToSell = Inventory[choice - 1];
                Coins += cardToSell.Value; // Add card value to essence
                Inventory.RemoveAt(choice - 1); // Remove the card from inventory
                Console.WriteLine($"Sold {cardToSell.Name} for {cardToSell.Value} essence. Total essence: {Coins}");
            }
            else
            {
                Console.WriteLine("Sale cancelled or invalid choice.");
            }
        }
    }
}
