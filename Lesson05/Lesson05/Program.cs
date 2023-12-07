using Lesson05.Classes;

namespace Lesson05
{
    internal class Program
    {
        // Game "21"
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var cardDeck = new CardDeck();

            Console.WriteLine("Shuffle deck");
            cardDeck.Shuffle();
            PrintAcesPositions(cardDeck);
            cardDeck.Print();

            Console.WriteLine("Moving spades to top");
            cardDeck = MoveSpadesToTop(cardDeck);
            cardDeck.Print();

            Console.WriteLine("Sort deck");
            cardDeck.Sort();
            cardDeck.Print();

            Console.WriteLine("Let's play");
            var game = new GameBlackJack();
            game.Play();

        }


        public static void PrintAcesPositions(CardDeck deck)
        {
            for (int i = 0; i < deck.Cards.Count; i++)
            {
                if (deck.Cards[i].Value == CardValue.Ace)
                {
                    Console.WriteLine($"Card {deck.Cards[i].Value} of {deck.Cards[i].Suit} is at position {i}");
                }
            }
        }

        public static CardDeck MoveSpadesToTop(CardDeck deck)
        {
            var newDeck = new CardDeck();
            int spadesCount = 0;
            foreach (var card in deck.Cards)
            {
                if (card.Suit == CardSuit.Spades)
                {
                    newDeck.Cards.Insert(spadesCount++, card);
                }
                else
                {
                    newDeck.Cards.Add(card);
                }
            }

            return newDeck;
        }

    }
}
