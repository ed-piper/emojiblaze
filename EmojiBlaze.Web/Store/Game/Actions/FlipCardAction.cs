namespace EmojiBlaze.Web.Store.Game.Actions
{
    public class FlipCardAction
    {
        public FlipCardAction(Card card)
        {
            Card = card;
        }

        public Card Card { get; }
    }
}