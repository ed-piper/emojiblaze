using Blazor.Fluxor;
using EmojiBlaze.Web.Store.Game;
using EmojiBlaze.Web.Store.Game.Actions;
using EmojiBlaze.Web.Util;

namespace Pairs.Store.Game.Reducers
{
    public class AddPlayerReducer : Reducer<GameState, AddPlayerAction>
    {
        public override GameState Reduce(GameState state, AddPlayerAction action)
        {
            var gameState = state.Clone();
            gameState.Players.Add(new Player(action.Name));
            return gameState;
        }
    }
}