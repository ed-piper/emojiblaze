using System;
using System.Linq;
using Blazor.Fluxor;
using EmojiBlaze.Models.Board;
using EmojiBlaze.Models.Store.Game.Actions;
using EmojiBlaze.Models.Util;

namespace EmojiBlaze.Models.Store.Game.Reducers
{
    public class StartGameReducer : Reducer<GameState, StartGameAction>
    {
        private readonly ICardGenerator _cardGenerator;
        private readonly int _boardWidth = 4;

        public StartGameReducer(ICardGenerator cardGenerator)
        {
            _cardGenerator = cardGenerator ?? throw new ArgumentNullException(nameof(cardGenerator));
        }
        
        public override GameState Reduce(GameState state, StartGameAction action)
        {
            var gameState = state.Clone();
            gameState.GameStage = GameStage.InProgress;
            gameState.Cards = _cardGenerator.GenerateCards(_boardWidth);
            gameState.Players.First().HasCurrentTurn = true;
            return gameState;
        }
    }
}