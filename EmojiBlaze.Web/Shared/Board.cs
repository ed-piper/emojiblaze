using EmojiBlaze.Models.Store.Game;
using System.Linq;

namespace EmojiBlaze.Web.Shared
{
    public partial class Board
    {
        private bool GameOver => GameState.Value.GameStage == GameStage.Completed;


        private string GameOverMessage
        {
            get
            {
                if (!GameOver) return string.Empty;

                var scoreGrouping = GameState.Value.Players.GroupBy(x => x.Score).OrderByDescending(x => x.Key).First();
                return scoreGrouping.Count() == 1 ? $"{scoreGrouping.Single().Name} is the winner! " : $"It's a tie between {scoreGrouping.Count()} players!";
            }
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            GameState.Subscribe(this);
        }
    }
}
