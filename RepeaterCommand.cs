namespace MovieKiosk
{
    public class RepeaterCommand : Command
    {
        public RepeaterCommand(string title) : base(title)
        {
        }
        public override void OnExecute(IConsole console)
        {
            var text = ReadText(console, "Enter text:");
            for (int i = 0; i < 10; i++)
            {
                console.Write($"{(i>0?", ":"")}{1+i}.{text}");
            }
        }
    }
}
