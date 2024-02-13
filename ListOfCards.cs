using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Purpose: The database of all possible cards that can be drawn

namespace TradingCardGameConsole
{
    internal class ListOfCards
    {
        private static double CommonCardProbability = 0.6 / 14;
        private static double EpicCardProbability = 0.3 / 14;
        private static double LegendaryCardProbability = 0.1 / 14;

        private static int CommonCardValue;
        private static int EpicCardValue;
        private static int LegendaryCardValue;

        static ListOfCards()
        {
            InitializeCardValues();
        }

        public static void InitializeCardValues()
        {
            //Random random = new();
            CommonCardValue = 50;
            EpicCardValue = 95;
            LegendaryCardValue = 150;
        }

        public static List<Card> CreateCards()
        {
            var cards = new List<Card>
            {
                // ELEMENTAL GUARDIANS
                // Shadowpaw Raccoon
                new Card("Shadowpaw", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Earth, Type.Racoon, "A clever raccoon with a knack for finding treasures in the forest."),
                new Card("Shadowpaw", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Earth, Type.Racoon, "A clever raccoon with a knack for finding treasures in the forest."),
                new Card("Shadowpaw", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Earth, Type.Racoon, "A clever raccoon with a knack for finding treasures in the forest."),
                
                // Grizzhart Bear
                new Card("Grizzhart", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Water, Type.Bear, "A powerful bear, guardian of the riverlands, feared and respected."),
                new Card("Grizzhart", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Water, Type.Bear, "A powerful bear, guardian of the riverlands, feared and respected."),
                new Card("Grizzhart", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Water, Type.Bear, "A powerful bear, guardian of the riverlands, feared and respected."),
                
                // Tiger Stripefury
                new Card("Stripefury", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Fire, Type.Tiger, "A fierce warrior of the jungle, swift and silent in the hunt."),
                new Card("Stripefury", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Fire, Type.Tiger, "A fierce warrior of the jungle, swift and silent in the hunt."),
                new Card("Stripefury", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Fire, Type.Tiger, "A fierce warrior of the jungle, swift and silent in the hunt."),
                
                // Ferret Swiftgleam
                new Card("Swiftgleam", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Air, Type.Ferret, "Quick and curious, this ferret can slip through shadows unseen."),
                new Card("Swiftgleam", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Air, Type.Ferret, "Quick and curious, this ferret can slip through shadows unseen."),
                new Card("Swiftgleam", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Air, Type.Ferret, "Quick and curious, this ferret can slip through shadows unseen."),
                
                // Lynx Frostwhisper
                new Card("Frostwhisper", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Earth, Type.Lynx, "Silent hunter of the snowy forests, elusive and graceful."),
                new Card("Frostwhisper", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Earth, Type.Lynx, "Silent hunter of the snowy forests, elusive and graceful."),
                new Card("Frostwhisper", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Earth, Type.Lynx, "Silent hunter of the snowy forests, elusive and graceful."),
                
                // Owl Nightseer
                new Card("Nightseer", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Air, Type.Owl, "Wise and mysterious, sees what others cannot in the dark."),
                new Card("Nightseer", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Air, Type.Owl, "Wise and mysterious, sees what others cannot in the dark."),
                new Card("Nightseer", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Air, Type.Owl, "Wise and mysterious, sees what others cannot in the dark."),
                
                // Shark Deepjaw
                new Card("Deepjaw", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Water, Type.Shark, "Ruler of the ocean depths, feared by all sea creatures."),
                new Card("Deepjaw", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Water, Type.Shark, "Ruler of the ocean depths, feared by all sea creatures."),
                new Card("Deepjaw", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Water, Type.Shark, "Ruler of the ocean depths, feared by all sea creatures."),
                
                // Panda Bambooheart
                new Card("Bambooheart", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Earth, Type.Panda, "Gentle and strong, a friend to all in the bamboo forest."),
                new Card("Bambooheart", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Earth, Type.Panda, "Gentle and strong, a friend to all in the bamboo forest."),
                new Card("Bambooheart", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Earth, Type.Panda, "Gentle and strong, a friend to all in the bamboo forest."),
                
                // Gorilla Thunderfist
                new Card("Thunderfist", CommonCardValue, Rarity.Common, CommonCardProbability, Element.Earth, Type.Gorilla, "Protector of the jungle, unmatched in strength and courage."),
                new Card("Thunderfist", EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Earth, Type.Gorilla, "Protector of the jungle, unmatched in strength and courage."),
                new Card("Thunderfist", LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Earth, Type.Gorilla, "Protector of the jungle, unmatched in strength and courage."),
                

                // NEUTRAL
                // Dragon Emberwing
                new Card("Emberwing", 0, Rarity.Common, CommonCardProbability, Element.Fire, Type.Dragon, "With breath of flame, this dragon reigns over mountain peaks."),
                new Card("Emberwing", 0, Rarity.Epic, EpicCardProbability, Element.Fire, Type.Dragon, "With breath of flame, this dragon reigns over mountain peaks."),
                new Card("Emberwing", 0, Rarity.Legendary, LegendaryCardProbability, Element.Fire, Type.Dragon, "With breath of flame, this dragon reigns over mountain peaks."),

                // ANTAGONISTS
                // Voidshard, the Corruption's Herald
                new Card("Voidshard, the Corruption's Herald", -CommonCardValue, Rarity.Common, CommonCardProbability, Element.Corruption, Type.Void, "Seeks to return the world to primordial chaos and darkness."),
                new Card("Voidshard, the Corruption's Herald", -EpicCardValue, Rarity.Epic, EpicCardProbability, Element.Corruption, Type.Void, "Seeks to return the world to primordial chaos and darkness."),
                new Card("Voidshard, the Corruption's Herald", -LegendaryCardValue, Rarity.Legendary, LegendaryCardProbability, Element.Corruption, Type.Void, "Seeks to return the world to primordial chaos and darkness."),

                // Darkmire
                new Card("Darkmire", 0, Rarity.Common, CommonCardProbability, Element.Water, Type.Crocodile, "A dark terror beneath the surface that embodies corrupted depths."),
                new Card("Darkmire", 0, Rarity.Epic, EpicCardProbability, Element.Water, Type.Crocodile, "A dark terror beneath the surface that embodies corrupted depths."),
                new Card("Darkmire", 0, Rarity.Legendary, LegendaryCardProbability, Element.Water, Type.Crocodile, "A dark terror beneath the surface that embodies corrupted depths."),

                // Galeclaw
                new Card("Galeclaw", 0, Rarity.Common, CommonCardProbability, Element.Air, Type.Raven, "Spreads chaos from the skies, a sinister omen of despair."),
                new Card("Galeclaw", 0, Rarity.Epic, EpicCardProbability, Element.Air, Type.Raven, "Spreads chaos from the skies, a sinister omen of despair."),
                new Card("Galeclaw", 0, Rarity.Legendary, LegendaryCardProbability, Element.Air, Type.Raven, "Spreads chaos from the skies, a sinister omen of despair."),

                // Thornhide
                new Card("Thornhide", 0, Rarity.Common, CommonCardProbability, Element.Earth, Type.Boar, "A beast of desolation in Voidshard's corrupted army."),
                new Card("Thornhide", 0, Rarity.Epic, EpicCardProbability, Element.Earth, Type.Boar, "A beast of desolation in Voidshard's corrupted army."),
                new Card("Thornhide", 0, Rarity.Legendary, LegendaryCardProbability, Element.Earth, Type.Boar, "A beast of desolation in Voidshard's corrupted army.")
            };

            return cards;
        }
    }
}
