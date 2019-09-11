namespace EmojiBlaze.Web.Store.Game.Actions
{
    public class TakeTurnAction
    {
        public TakeTurnAction(Card card)
        {
            Card = card;
        }

        public Card Card { get; }
    }
}