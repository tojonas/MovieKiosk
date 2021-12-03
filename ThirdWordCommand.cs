using System;

namespace MovieKiosk
{
    public class ThirdWordCommand : Command
    {
        public ThirdWordCommand(string title) : base(title)
        {

        }
        public override void OnExecute(IConsole console)
        {
            console.Write("Enter a sentence with at least three words:");
            var words = GetAtLeastThreeWords(console);

            console.WriteLine($"The third word is: {words[2]}");
        }
        private string[] GetAtLeastThreeWords(IConsole console)
        {
            string[] words;
            while ((words = console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)).Length < 3)
            {
                console.Write("Not enough words, please try again:");
            }
            return words;
        }
    }
}
