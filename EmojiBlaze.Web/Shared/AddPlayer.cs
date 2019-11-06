using EmojiBlaze.Models.Store.Game;
using EmojiBlaze.Models.Store.Game.Actions;

namespace EmojiBlaze.Web.Shared
{
    public partial class AddPlayer
    {
        private string PlayerName { get; set; }

        private bool CanStartGame => GameState.Value.GameStage != GameStage.InProgress &&
                                 GameState.Value.Players.Count > 1;

        private void StartGame()
        {
            Dispatcher.Dispatch(new StartGameAction());
        }

        private void Add()
        {
            Dispatcher.Dispatch(new AddPlayerAction(PlayerName));
            PlayerName = string.Empty;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            GameState.Subscribe(this);
        }
    }
}
