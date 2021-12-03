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
            var words = GetAtLeastWords(console,3);

            console.WriteLine($"The third word is: {words[2]}");
        }
        private string[] GetAtLeastWords(IConsole console, uint numberOfWords)
        {
            string[] words;
            while ((words = console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)).Length < numberOfWords)
            {
                console.Write("Not enough words, please try again:");
            }
            return words;
        }
    }
}
