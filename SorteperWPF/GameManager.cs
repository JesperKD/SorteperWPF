using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SorteperWPF
{
    public class GameManager
    {
        static Player player = new Player();
        static Player cpu = new Player();
        static List<Card> deck = DeckManager.CreateDeck();

        /// <summary>
        /// Equally spreads out the deck between the player and cpu
        /// </summary>
        public void DealCards()
        {
            Random random = new Random();

            player.Hand = new List<Card>();
            cpu.Hand = new List<Card>();

            //Empties deck equally between the two players
            while (deck.Count > 0)
            {
                try
                {
                    Card card = deck[random.Next(deck.Count)];
                    player.Hand.Add(card);
                    deck.Remove(card);

                    card = deck[random.Next(deck.Count)];
                    cpu.Hand.Add(card);
                    deck.Remove(card);
                }
                catch (Exception)
                {

                }

            }
        }

        /// <summary>
        /// Registers and removes matching pairs from players hands
        /// </summary>
        public void FindPlayerPairs()
        {
            // copies the cards to a temp list
            List<Card> tempCards = new List<Card>(player.Hand);

            //Goes through the cards of the cpu
            foreach (Card card in player.Hand)
            {
                //Checks for matches
                var x = player.Hand.FindAll(c => c.Value == card.Value);
                if (x.Count == 2)
                {
                    // removes matches from temp list
                    foreach (Card matchingCard in x)
                    {
                        if (matchingCard.Value != 11 && matchingCard.suit != "Spades")
                        {
                            tempCards.Remove(matchingCard);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Registers and removes matching pairs from players hands
        /// </summary>
        public void FindCpuPairs()
        {
            // copies the cards to a temp list
            List<Card> tempCards = new List<Card>(cpu.Hand);

            //Goes through the cards of the cpu
            foreach (Card card in cpu.Hand)
            {
                //Checks for matches
                var x = cpu.Hand.FindAll(c => c.Value == card.Value);
                if (x.Count == 2)
                {
                    // removes matches from temp list
                    foreach (Card matchingCard in x)
                    {
                        if (matchingCard.Value != 11 && matchingCard.suit != "Spades")
                        {
                            tempCards.Remove(matchingCard);
                        }
                    }
                }
            }
        }

        public void RegisterCard(string imageName)
        {
            string[] splitString = imageName.Split('/');
            Card card = new Card(0);

            string cardData = splitString[4];

            if (cardData.ToArray()[1] == 'C')
            {
                card.suit = "Clubs";
            }
            else if (cardData.ToArray()[1] == 'H')
            {
                card.suit = "Hearts";
            }
            else if (cardData.ToArray()[1] == 'S')
            {
                card.suit = "Spades";
            }
            else if (cardData.ToArray()[1] == 'D')
            {
                card.suit = "Diamonds";
            }

            card.Value = Convert.ToInt32(cardData.ToArray()[2]);

            PlayerTurn(card);
        }

        /// <summary>
        /// Deals with the choice made by the player
        /// </summary>
        public void PlayerTurn(Card card)
        {
            player.Hand.Add(card);
            cpu.Hand.Remove(card);
        }

        /// <summary>
        /// Makes cpu grab card from player during cpu turn
        /// </summary>
        public void CpuTurn()
        {
            Random random = new Random();
            int cpuChoice = random.Next(player.Hand.Count);

            cpu.Hand.Add(player.Hand.ElementAt(cpuChoice));
            player.Hand.RemoveAt(cpuChoice);
        }

        /// <summary>
        /// Returns a sorted list of the players Cards
        /// </summary>
        /// <returns></returns>
        public List<Card> SortedPlayerHand()
        {
            List<Card> SortedList = player.Hand.OrderBy(o => o.Value).ToList();
            return SortedList;
        }

        /// <summary>
        /// Returns a sorted list of the CPU's cards
        /// </summary>
        /// <returns></returns>
        public List<Card> SortedCPUHand()
        {
            List<Card> SortedList = cpu.Hand.OrderBy(o => o.Value).ToList();
            return SortedList;
        }

    }
}
