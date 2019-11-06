namespace EmojiBlaze.Web.Shared
{
    public partial class PlayerList
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            GameState.Subscribe(this);
        }
    }
}
