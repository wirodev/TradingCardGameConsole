using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// Purpose: to create a Card for the game

namespace TradingCardGameConsole
{
    // define the possible rarities of a card
    public enum Rarity
    {
        Common,
        Epic,
        Legendary
    }

    // define the types of a card
    public enum Type
    {
        Racoon,
        Bear,
        Tiger,
        Ferret,
        Dragon,
        Lynx,
        Owl,
        Shark,
        Panda,
        Gorilla,
        Crocodile,
        Raven,
        Boar,
        Void
    }

    // define the elements of a card
    public enum Element
    {
        Earth,
        Water,
        Fire,
        Air,
        Corruption
    }

    public class Card
    {
        // card class properties, each card has a name a given rarity a value and a probability to be drawn
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        public int Value { get; set; }
        public double Probability { get; set; }
        public Element Element {  get; set; }
        public Type Type { get; set; }
        public string Description { get; set; }


        // constructor to initialize instance of class
        public Card(string name, int value, Rarity rarity, double probability, Element element, Type type, string description)
        {
            Name = name;
            Value = value;
            Rarity = rarity;
            Probability = probability;
            Element = element;
            Type = type;
            Description = description;
        }
    }
}
