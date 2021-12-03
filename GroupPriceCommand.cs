namespace MovieKiosk
{
    public class GroupPriceCommand : Command
    {
        public GroupPriceCommand(string title) : base(title)
        {
        }
        protected override void OnExecute(IConsole console)
        {
            var numberOfTickets = ReadUInt(console, "Number of people:");
            int total = 0;
            for (int i = 0; i < numberOfTickets; i++)
            {
                var age = ReadUInt(console, "Age:");

                var (discountCode, price) = MoviePrices.GetDiscountCodeAndPrice(age);
                console.WriteLine($"Discount: {discountCode} price: {price} sek.");
                total += price;
            }
            console.WriteLine($"Total price for {numberOfTickets} people: {total} sek.");
        }

    }
}
