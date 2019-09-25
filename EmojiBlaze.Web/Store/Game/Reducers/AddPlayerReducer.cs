using System.Linq;
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
            if (gameState.Players.Any(x => x.Name.ToLower().Trim() == action.Name))
            {
                //TODO: Players can't have matching names, so present some sort of error message                 
            }
            else
            {
                gameState.Players.Add(new Player(action.Name));    
            }
            
            return gameState;
        }
    }
}