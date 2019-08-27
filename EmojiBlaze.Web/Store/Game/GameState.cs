namespace EmojiBlaze.Web.Store.Game
{
    public class GameState
    {
        public GameState()
        {
            GameStage = GameStage.NotStarted;
        }
        
        
        public GameStage GameStage { get; set; }
    }
}