using System;
using System.Collections.Generic;
using System.Linq;

namespace TradingCardGameConsole
{
    public class Player
    {
        public int Currency { get; set; } // Renamed to 'Essence' in the narrative, but kept as 'Currency' in code for clarity
        public List<Card> Inventory { get; private set; }

        public Player(int startingCurrency)
        {
            Currency = startingCurrency;
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
            if (Currency >= drawCost)
            {
                // Assuming DrawCard is a class name, and DrawCardWithProbability is a static method within it.
                Card drawnCard = DrawCard.DrawCardWithProbability(deck);
                Currency -= drawCost; // Deduct the cost of drawing a card
                Currency += drawnCard.Value; // Add the value of the drawn card to essence
                Inventory.Add(drawnCard); // Add the drawn card to the inventory
                Console.WriteLine($"Drawn Card: {drawnCard.Name}, Essence after draw: {Currency}");
            }
            else
            {
                Console.WriteLine("Not enough essence to draw a card.");
            }
        }

        // helper class to hold the grouped card information
        public class CardGroup
        {
            public string Name { get; set; }
            public Rarity Rarity { get; set; }
            public int Value { get; set; }
            public int Count { get; set; }
            public int TotalValue { get; set; }
        }


        // Method to allow the player to sell a card from their inventory
        public void SellCard()
        {
            Console.WriteLine($"\nTotal Essence: {Currency}");
            var sellableCards = Inventory
                .Where(card => card.Value > 0 && card.Name != "Voidshard, the Corruption's Herald")
                .GroupBy(card => new { card.Name, card.Rarity, card.Value })
                .Select(group => new CardGroup // Changed from anonymous type to CardGroup
                {
                    Name = group.Key.Name,
                    Rarity = group.Key.Rarity,
                    Value = group.Key.Value,
                    Count = group.Count(),
                    TotalValue = group.Key.Value * group.Count()
                })
                .OrderByDescending(card => card.TotalValue) // Order by TotalValue descending
                .ToList();

            if (!sellableCards.Any())
            {
                Console.WriteLine("No sellable cards in your inventory.");
                return;
            }

            for (int i = 0; i < sellableCards.Count; i++)
            {
                var card = sellableCards[i];
                Console.WriteLine($"{i + 1}. {card.Name}, {card.Rarity} - Value: {card.Value} | Owned: {card.Count} - Total Value: {card.TotalValue}");
            }
            Console.WriteLine($"{sellableCards.Count + 1}. Sell All");

            Console.Write("Enter your choice (or 0 to cancel): ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice == sellableCards.Count + 1)
            {
                SellAllCards(sellableCards);
            }
            else if (choice > 0 && choice <= sellableCards.Count)
            {
                var selectedCardGroup = sellableCards[choice - 1];
                // Proceed with selling logic for selected card group...
            }
            else
            {
                Console.WriteLine("Sale cancelled or invalid choice.");
            }
        }

        private void SellAllCards(List<CardGroup> sellableCards)
        {
            int totalEssenceEarned = sellableCards.Sum(cardGroup => cardGroup.TotalValue);
            foreach (var cardGroup in sellableCards)
            {
                RemoveCardsFromInventory(cardGroup.Name, cardGroup.Rarity, cardGroup.Count);
            }
            Currency += totalEssenceEarned;
            Console.WriteLine($"Sold all sellable cards for {totalEssenceEarned} essence. Total essence: {Currency}");
        }



        private void RemoveCardsFromInventory(string name, Rarity rarity, int count)
        {
            var removedCount = 0;
            for (int i = Inventory.Count - 1; i >= 0; i--)
            {
                if (Inventory[i].Name == name && Inventory[i].Rarity == rarity)
                {
                    Inventory.RemoveAt(i);
                    removedCount++;
                    if (removedCount == count) break;
                }
            }
        }

        public void CheckInventory(List<Card> allCards)
        {
            // Define guardian types
            var guardianTypes = new List<Type> { Type.Racoon, Type.Bear, Type.Tiger, Type.Ferret, Type.Dragon, Type.Lynx, Type.Owl, Type.Shark, Type.Panda, Type.Gorilla, Type.Crocodile, Type.Raven, Type.Boar, Type.Void };

            // Filter allCards to include only Guardians
            var allGuardians = allCards.Where(card => guardianTypes.Contains(card.Type)).ToList();

            // Owned guardians
            var ownedGuardians = Inventory.Where(card => guardianTypes.Contains(card.Type)).ToList();

            // Missing guardians
            var missingGuardians = allGuardians
                .GroupBy(card => new { card.Name, card.Rarity })
                .Select(group => new { group.Key.Name, group.Key.Rarity, Count = group.Count() })
                .Where(g => !ownedGuardians.Any(owned => owned.Name == g.Name && owned.Rarity == g.Rarity))
                .ToList();

            Console.WriteLine("\nOwned Guardians:");
            foreach (var card in ownedGuardians.GroupBy(card => new { card.Name, card.Rarity })
                                                .Select(group => new { group.Key.Name, group.Key.Rarity, Count = group.Count() })
                                                .OrderBy(card => card.Name)) // Order by Name
            {
                Console.WriteLine($"{card.Name}, {card.Rarity} - Owned: {card.Count}");
            }

            Console.WriteLine("\nMissing Guardians:");
            foreach (var card in missingGuardians.OrderBy(card => card.Name)) // Order by Name
            {
                Console.WriteLine($"{card.Name}, {card.Rarity}");
            }

            if (missingGuardians.Count == 0)
            {
                Console.WriteLine("Congratulations! You've collected all Guardian cards!");
            }
        }


    }
}