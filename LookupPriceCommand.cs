namespace MovieKiosk
{
    public class LookupPriceCommand : Command
    {
        public LookupPriceCommand(string title) : base(title)
        {
        }
        public override void OnExecute(IConsole console)
        {
            var age = ReadUInt(console, "Enter age:");
            var (discountCode, price) = MoviePrices.GetDiscountCodeAndPrice(age);
            console.WriteLine($"Discount: {discountCode} price: {price} sek.");
        }
    }
}
