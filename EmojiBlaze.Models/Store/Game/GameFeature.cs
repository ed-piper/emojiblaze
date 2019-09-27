using Blazor.Fluxor;

namespace EmojiBlaze.Models.Store.Game
{
    public class GameFeature : Feature<GameState>
    {
        public override string GetName() => "Game";

        protected override GameState GetInitialState()
        {
            return new GameState();
        }
    }
}