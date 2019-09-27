using System.Linq;
using Blazor.Fluxor;
using EmojiBlaze.Models.Store.Game.Actions;
using EmojiBlaze.Models.Util;

namespace EmojiBlaze.Models.Store.Game.Reducers
{
    public class TakeTurnReducer : Reducer<GameState, TakeTurnAction>
    {
        public override GameState Reduce(GameState state, TakeTurnAction action)
        {
            var gameState = state.Clone();

            if (gameState.Cards.Count(x => !x.IsFaceDown) == 2)
            {
                gameState.Cards.ForEach(x => x.IsFaceDown = true);
            }

            gameState.Cards.Find(x => x == action.Card).IsFaceDown = !action.Card.IsFaceDown;

            var faceUpCards = gameState.Cards.Where(x => !x.IsFaceDown).ToList();
            
            if (faceUpCards.Count != 2) return gameState;

            if (faceUpCards[0].Symbol == faceUpCards[1].Symbol)
            {
                faceUpCards[0].IsInPlay = false;
                faceUpCards[1].IsInPlay = false;
                gameState.Players.First(x => x.HasCurrentTurn).Score += 1;
            }

            var currentPlayer = gameState.Players.First(x => x.HasCurrentTurn);
            var currentPlayerIndex = gameState.Players.IndexOf(currentPlayer);
            var newPlayerIndex = currentPlayerIndex == gameState.Players.Count - 1 ? 0 : currentPlayerIndex + 1;
            gameState.Players[currentPlayerIndex].HasCurrentTurn = false;
            gameState.Players[newPlayerIndex].HasCurrentTurn = true;

            if (gameState.Cards.All(x => !x.IsInPlay))
            {
                gameState.GameStage = GameStage.Completed;
            }

            return gameState;
        }
    }
}