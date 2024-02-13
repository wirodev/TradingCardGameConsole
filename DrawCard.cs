using System;
using System.Collections.Generic;
using System.Linq;

//Purpose: to make drawing new cards possible

namespace TradingCardGameConsole
{
    class DrawCard
    {
        public static Card DrawCardWithProbability(List<Card> cards)
        {
            // Generate a random number and find the corresponding card using the cumulative probability method
            Random rng = new Random();
            double randomNumber = rng.NextDouble(); // Random number between 0 and 1
            double cumulativeSum = 0;

            foreach (var card in cards)
            {
                cumulativeSum += card.Probability; // Directly use defined probabilities
                if (randomNumber <= cumulativeSum)
                {
                    return card;
                }
            }

            // fallback if probabilities are not correctly set
            return cards.Last();
        }
    }
}
