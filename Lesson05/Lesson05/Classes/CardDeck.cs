using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05.Classes
{
    public class CardDeck
    {
        private List<Card> _cards = new List<Card>();

        public CardDeck()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
                {
                    _cards.Add(new Card ( suit, value));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            _cards = _cards.OrderBy(c => random.Next()).ToList();
        }

        public void Sort()
        {
            _cards = _cards.OrderBy(c => c.Suit).ThenBy(c => c.Value).ToList();
        }

        public Card GetCard(int index = 0)
        {
            Card card = _cards[index];
            _cards.RemoveAt(index);
            return card;
        }

        public void Print()
        {
            foreach (var card in _cards)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
        }

        public int GetCardsCount()
        {
            return _cards.Count;
        }

        public void PrintAcesPositions()
        {
            for (int i = 0; i < GetCardsCount(); i++)
            {
                if (GetCard(i).Value == CardValue.Ace)
                {
                    Console.WriteLine($"Card {GetCard(i).Value} of {GetCard(i).Suit} is at position {i}");
                }
            }
        }

        public void MoveSpadesToTop()
        {
            var newDeck = new CardDeck();
            int spadesCount = 0;
            foreach (var card in _cards)
            {
                if (card.Suit == CardSuit.Spades)
                {
                    newDeck._cards.Insert(spadesCount++, card);
                }
                else
                {
                    newDeck._cards.Add(card);
                }
            }

            _cards = newDeck._cards;
        }

    }

    public struct Card
    {
        public CardSuit Suit { get; }
        public CardValue Value { get; }

        public Card(CardSuit cardSuit, CardValue cardValue)
        {
            Suit = cardSuit;
            Value = cardValue;
        }
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
