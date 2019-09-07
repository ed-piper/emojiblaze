using Blazor.Fluxor;

namespace EmojiBlaze.Web.Store.Game
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