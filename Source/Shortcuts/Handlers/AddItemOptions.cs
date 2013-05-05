namespace Shortcuts.Handlers
{
    public class AddItemOptions
    {
        public string Name { get; set; }
        public string Text { get; set; }
       
        public AddItemOptions(string name, string text)
        {
            Name = name;
            Text = text;
        }
    }
}