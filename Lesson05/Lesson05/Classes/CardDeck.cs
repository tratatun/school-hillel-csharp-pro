using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05.Classes
{
    public class CardDeck
    {
        public List<Card> Cards = new List<Card>();

        public CardDeck()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    Cards.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            Cards = Cards.OrderBy(c => random.Next()).ToList();
        }

        public void Sort()
        {
            Cards = Cards.OrderBy(c => c.Suit).ThenBy(c => c.Value).ToList();
        }

        public Card GetCard()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        public void Print()
        {
            foreach (var card in Cards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }



    }

    public struct Card
    {
        public CardSuit Suit { get; set; }
        public CardValue Value { get; set; }
    }
    
    public enum CardSuit
    {         
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum CardValue
    {
        //Two, Three, Four, Five, 
        Six = 6, Seven, Eight, Nine, Ten,
        Jack, Queen, King, Ace
    }
}
