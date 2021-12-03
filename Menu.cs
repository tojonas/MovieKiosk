using System;
using System.Collections.Generic;

namespace MovieKiosk
{
    public class Menu
    {
        private string _title;
        private IConsole _console;
        private IList<Command> _options = new List<Command>();

        public Menu(string title, IConsole console)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if ( console == null )
            {
                throw new ArgumentNullException(nameof(console));
            }
            _title = title;
            _console = console;
            _options.Add(new LookupPriceCommand("Youth or Senior") );
            _options.Add(new GroupPriceCommand("Calculate group price"));
            _options.Add(new RepeaterCommand("Repeate ten times"));
            _options.Add(new ThirdWordCommand("The third word"));
            _options.Add(new Command("Quit"));

        }

        public void Show()
        {
            do
            {
                _console.Clear();
                _console.WriteLine($"{_title}: What do you want to do?");
                _console.WriteLine("==================================");
                int selector = 1;
                foreach (var option in _options)
                {
                    _console.WriteLine($"{selector++}) {option.Title}");
                }
            }
            while (ExecuteSelection());
        }

        private bool ExecuteSelection()
        {
            var selection = ReadUInt();
            if (selection < _options.Count)
            {
                _options[(int)selection - 1].Execute(_console);
                return true;
            }
            return false;
        }

        private uint ReadUInt()
        {
            uint input;
            while (uint.TryParse(_console.ReadKey(), out input) == false) ;
            return input;
        }
    }
}