using System;
using System.Collections.Generic;

namespace MovieKiosk
{
    public class Menu
    {
        private string _title;
        private IConsole _console;
        private IDictionary<uint, Command> _options = new Dictionary<uint, Command>();

        public Menu(string title, IConsole console)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (console == null)
            {
                throw new ArgumentNullException(nameof(console));
            }
            _title = title;
            _console = console;
            // Reading menus from configuration
            
            _options.Add(1, new LookupPriceCommand("Youth or Senior"));
            _options.Add(2, new GroupPriceCommand("Calculate group price"));
            _options.Add(3, new RepeaterCommand("Repeate ten times"));
            _options.Add(4, new ThirdWordCommand("The third word"));
            _options.Add(5, new QuitCommand("Quit"));
        }

        public void Show()
        {
            do
            {
                _console.Clear();
                _console.WriteLine($"{_title}: What do you want to do?");
                _console.WriteLine("==================================");
                foreach (var option in _options)
                {
                    _console.WriteLine($"{option.Key}) {option.Value.Title}");
                }
            }
            while (ExecuteSelection());
        }

        private bool ExecuteSelection()
        {
            while (true)
            {
                var selection = ReadUInt();
                if (_options.ContainsKey(selection) == true)
                {
                    // A Command returning false will exit the current menu
                    return _options[selection].Execute(_console);
                }
            }
        }

        private uint ReadUInt()
        {
            uint input;
            while (uint.TryParse(_console.ReadKey(), out input) == false) ;
            return input;
        }
    }
}