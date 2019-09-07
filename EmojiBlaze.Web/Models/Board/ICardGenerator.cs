using System.Collections.Generic;
using EmojiBlaze.Web.Store.Game;

namespace EmojiBlaze.Web.Models.Board
{
    public interface ICardGenerator
    {
        List<Card> GenerateCards(int lengthWidth);
    }
}