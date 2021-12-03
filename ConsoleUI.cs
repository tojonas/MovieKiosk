using System;

namespace MovieKiosk
{
    internal class ConsoleUI : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public string ReadKey()
        {
            return Console.ReadKey(true).KeyChar.ToString();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string text)
        {
            Console.Write(text); 
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}