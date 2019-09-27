using System.Collections.Generic;
using EmojiBlaze.Models.Store.Game;

namespace EmojiBlaze.Models.Board
{
    public interface ICardGenerator
    {
        List<Card> GenerateCards(int lengthWidth);
    }
}