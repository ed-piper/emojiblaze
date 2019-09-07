namespace EmojiBlaze.Web.Store.Game.Actions
{
    public class AddPlayerAction
    {
        public AddPlayerAction(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}