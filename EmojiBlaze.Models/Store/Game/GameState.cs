using System.Collections.Generic;

namespace EmojiBlaze.Models.Store.Game
{
    public class GameState
    {
        public GameState()
        {
            GameStage = GameStage.NotStarted;
            Players = new List<Player>();
        }
        
        public GameStage GameStage { get; set; }

        public List<Player> Players { get; set; }
        public List<Card> Cards { get; set; }
    }
}