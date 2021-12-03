using System;

namespace MovieKiosk
{
    public class Command
    {
        string _title = string.Empty;
        public string Title => _title;
        public Command(string title)
        {
            if(title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            _title = title;
        }
        public virtual void Execute(IConsole console)
        {
            console.Clear();
            console.WriteLine(_title);
            console.WriteLine( new string('=',_title.Length) );
            do
            {
                OnExecute(console);
                console.WriteLine("\nPress (q) to go back to previous menu.");
            }
            while (console.ReadKey() != "q");
        }
        public virtual void OnExecute(IConsole console )
        {
            // We shouldn't end up here
            console.WriteLine("base.OnExecute");
        }
        protected static string ReadText( IConsole console, string prompt)
        {
            console.Write(prompt);
            return console.ReadLine();
        }
        protected static uint ReadUInt(IConsole console, string prompt)
        {
            console.Write(prompt);
            uint input;
            while (uint.TryParse(console.ReadLine(), out input) == false) ;
            return input;
        }
    }
}
