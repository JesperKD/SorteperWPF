using System.Collections.Generic;

namespace SorteperWPF
{
    public static class DeckManager
    {
        /// <summary>
        /// Creates a deck of 51 cards with no 11 of Clubs
        /// </summary>
        /// <returns></returns>
        public static List<Card> CreateDeck()
        {
            List<Card> Deck = new List<Card>();

            for (int i = 0; i < 13; i++)
            {
                Card card = new Card(i + 1);
                card.suit = "Hearts";
                card.imgName = "H" + card.Value;
                Deck.Add(card);
            }

            for (int i = 0; i < 13; i++)
            {
                Card card = new Card(i + 1);
                card.suit = "Spades";
                card.imgName = "S" + card.Value;
                Deck.Add(card);
            }

            for (int i = 0; i < 13; i++)
            {
                Card card = new Card(i + 1);
                card.suit = "Clubs";
                card.imgName = "C" + card.Value;
                if (card.Value != 11)
                {
                    Deck.Add(card);
                }
            }

            for (int i = 0; i < 13; i++)
            {
                Card card = new Card(i + 1);
                card.suit = "Diamonds";
                card.suit = "D" + card.Value;
                Deck.Add(card);
            }

            return Deck;
        }

    }
}
