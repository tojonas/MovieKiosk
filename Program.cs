using System;

namespace MovieKiosk
{
    class Program
    {
        static void Main(string[] args)
        {
            new Menu("Main menu", new ConsoleUI()).Show();
        }
    }
}
