namespace MovieKiosk
{
    internal class QuitCommand : Command
    {
        public QuitCommand(string title) : base(title)
        {
        }

        public override bool Execute(IConsole console)
        {
            // This will exit the current menu
            return false;
        }
    }
}