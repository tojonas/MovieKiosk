using System;

namespace MovieKiosk
{
    public class RepeaterCommand :Command
    {
        public RepeaterCommand(string title ) :base(title)
        {
        }
        public override void OnExecute(IConsole console)
        {
            var text = ReadText(console, "Enter text:" );
            for (int i = 0; i < 10; i++)
            {
                if (i > 0) console.Write(", ");
                console.Write(text);
            }
        }
    }
}
