using System;

namespace EmojiBlaze.Models.Store.Game
{
    public class Card 
    {
        public Card(string symbol)
        {
            Symbol = symbol;
            IsFaceDown = true;
            Id = Guid.NewGuid();
            IsInPlay = true;
        }

        public void SetCardPosition(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; private set; }
        
        public int Y { get; private set; }

        public string Symbol { get; }

        public bool IsFaceDown { get; set; }

        public bool IsInPlay { get; set; }
        public Guid Id { get; }
    }
}