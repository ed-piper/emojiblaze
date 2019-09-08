using Blazor.Fluxor;
using EmojiBlaze.Web.Store.Game;
using EmojiBlaze.Web.Store.Game.Actions;
using EmojiBlaze.Web.Util;

namespace Pairs.Store.Game.Reducers
{
    public class FlipCardReducer : Reducer<GameState, FlipCardAction>
    {
        public override GameState Reduce(GameState state, FlipCardAction action)
        {
            var gameState = state.Clone();
            gameState.Cards.Find(x => x == action.Card).IsFaceDown = !action.Card.IsFaceDown;
            return gameState;
        }
    }
}