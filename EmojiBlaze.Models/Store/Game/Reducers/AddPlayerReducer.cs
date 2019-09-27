using System;
using System.Linq;
using Blazor.Fluxor;
using EmojiBlaze.Models.Store.Game.Actions;
using EmojiBlaze.Models.Util;

namespace EmojiBlaze.Models.Store.Game.Reducers
{
    public class AddPlayerReducer : Reducer<GameState, AddPlayerAction>
    {
        public override GameState Reduce(GameState state, AddPlayerAction action)
        {
            var gameState = state.Clone();
            if (gameState.Players.Any(x => string.Equals(x.Name, action.Name, StringComparison.CurrentCultureIgnoreCase)))
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