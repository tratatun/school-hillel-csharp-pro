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
            cardDeck.PrintAcesPositions();
            cardDeck.Print();

            Console.WriteLine("Moving spades to top");
            cardDeck.MoveSpadesToTop();
            cardDeck.Print();

            Console.WriteLine("Sort deck");
            cardDeck.Sort();
            cardDeck.Print();

            Console.WriteLine("Let's play");
            var game = new GameBlackJack();
            game.Play();

        }
    }
}
