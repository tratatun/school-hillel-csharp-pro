using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson05.Classes
{
    // вартість карток: Туз - 11 очок; Король – 4 очки; Леді/Дама-3 бали; Джек/Валет – 2 очки; Інші карти за їх номіналом

    public class GameBlackJack
    {
        private CardDeck Deck { get; set; }
        private List<Card> PlayerCards { get; set; }
        private List<Card> DealerCards { get; set; }

        private bool IsPlayerStoped { get; set; }
        private bool IsDealerStoped { get; set; }

        public GameBlackJack()
        {
            Deck = new CardDeck();
            Deck.Shuffle();
            PlayerCards = new List<Card>();
            DealerCards = new List<Card>();
        }

        private void Start()
        {
            PlayerCards.Add(Deck.GetCard());
            PlayerCards.Add(Deck.GetCard());
            DealerCards.Add(Deck.GetCard());
            DealerCards.Add(Deck.GetCard());
            Print();
        }

        private void Print()
        {
            Console.WriteLine("");
            Console.WriteLine("Player cards:");
            foreach (var card in PlayerCards)
            {
                Console.Write($"<{card.Value} of {card.Suit}> ");
            }

            Console.WriteLine("");
            Console.WriteLine("Dealer cards:");
            foreach (var card in DealerCards)
            {
                Console.Write($"<{card.Value} of {card.Suit}> ");
            }
        }

        private void PlayerMove()
        {
            Console.WriteLine("");
            Console.WriteLine("Player move");
            Console.WriteLine("1 - get card");
            Console.WriteLine("2 - stop");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                PlayerCards.Add(Deck.GetCard());
            }
            Print();
        }

        private void DealerMove()
        {
            Console.WriteLine("");
            Console.WriteLine("Dealer move");
            if (GetDealerScore() < 17)
            {
                DealerCards.Add(Deck.GetCard());
            }
            else
            {
                IsDealerStoped = true;
            }
            Print();
        }

        public void Play()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to start");
            Console.WriteLine("Press Esc to stop");
            


            var stop = Console.ReadKey();
            while (stop.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("");
                Console.WriteLine("Decide whos turn is first? Press 1 for player");

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.D1)
                {
                    Start();

                    PlayerMove();

                    DealerMove();
                }
                else
                {
                    Start();

                    DealerMove();

                    PlayerMove();
                }

                Console.WriteLine("");
                if(GetPlayerScore() > 21)
                {
                    Console.WriteLine("Player lost");
                    PrintScore();
                    ResetGame();
                }
                else if(GetDealerScore() > 21)
                {
                    Console.WriteLine("Dealer lost");
                    PrintScore();
                    ResetGame();
                }
                else if(IsPlayerStoped && IsDealerStoped && GetPlayerScore() == GetDealerScore())
                {
                    Console.WriteLine("Draw");
                    PrintScore();
                    ResetGame();
                }
                else if(IsPlayerStoped && IsDealerStoped && GetPlayerScore() > GetDealerScore())
                {
                    Console.WriteLine("Player won");
                    PrintScore();
                    ResetGame();
                }
                else if(IsPlayerStoped && IsDealerStoped && GetPlayerScore() < GetDealerScore())
                {
                    Console.WriteLine("Dealer won");
                    PrintScore();
                    ResetGame();
                }
                stop = Console.ReadKey();
            }
        }

        private void ResetGame()
        {
            PlayerCards.Clear();
            DealerCards.Clear();
            Deck = new CardDeck();
            Deck.Shuffle();
        }

        private void PrintScore()
        {
            Console.WriteLine("");
            Console.WriteLine($"Player score: {GetPlayerScore()}");
            Console.WriteLine($"Dealer score: {GetDealerScore()}");
        }

        private int GetCardValue(Card card)
        {
            switch (card.Value)
            {
                case CardValue.Ace:
                    return 11;
                case CardValue.King:
                    return 4;
                case CardValue.Queen:
                    return 3;
                case CardValue.Jack:
                    return 2;
                default:
                    return (int)card.Value;
            }
        }

        private int GetPlayerScore()
        {
            int score = 0;
            foreach (var card in PlayerCards)
            {
                score += GetCardValue(card);
            }

            return score;
        }

        private int GetDealerScore()
        {
            int score = 0;
            foreach (var card in DealerCards)
            {
                score += GetCardValue(card);
            }

            return score;
        }
    }
}
