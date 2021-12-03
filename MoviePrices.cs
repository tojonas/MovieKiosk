using System.Collections.Generic;

namespace MovieKiosk
{
    public static class MoviePrices
    {
        static Dictionary<Discounts, int> PriceDiscounts = new Dictionary<Discounts, int>()
        {
            { Discounts.Infant, 0 },
            { Discounts.Youth, 64 },
            { Discounts.Regular, 120 },
            { Discounts.Senior, 90 },
            { Discounts.SuperSenior, 0 }
        };
        // The enum value is used to determine the age limits
        public enum Discounts
        {
            Infant = 5,
            Youth = 20,
            Regular = 30,
            Senior = 64,
            SuperSenior = 100
        }

        public static (Discounts discountCode, int price) GetDiscountCodeAndPrice(uint age)
        {
            // I hate if else if so I'm returning as soon as the condition is met making the if else not matter...
            // https://blog.codinghorror.com/flattening-arrow-code/
            if (age < (int)Discounts.Infant)
            {
                return (Discounts.Infant, PriceDiscounts[Discounts.Infant]);
            }
            else if (age < (int)Discounts.Youth)
            {
                return (Discounts.Youth, PriceDiscounts[Discounts.Youth]);
            }
            else if (age > (int)Discounts.SuperSenior) // Important to check higher ages first
            {
                return (Discounts.SuperSenior, PriceDiscounts[Discounts.SuperSenior]);
            }
            else if (age > (int)Discounts.Senior)
            {
                return (Discounts.Senior, PriceDiscounts[Discounts.Senior]);
            }
            else
            {
                return (Discounts.Regular, PriceDiscounts[Discounts.Regular]);
            }
        }

        public static (Discounts discountCode, int price) GetDiscountCodeAndPriceEx(uint age)
        {
            // This is the way I would write it without else
            if (age < (int)Discounts.Infant)
            {
                return (Discounts.Infant, PriceDiscounts[Discounts.Infant]);
            }
            if (age < (int)Discounts.Youth)
            {
                return (Discounts.Youth, PriceDiscounts[Discounts.Youth]);
            }
            if (age > (int)Discounts.SuperSenior) // Important to check higher ages first
            {
                return (Discounts.SuperSenior, PriceDiscounts[Discounts.SuperSenior]);
            }
            if (age > (int)Discounts.Senior)
            {
                return (Discounts.Senior, PriceDiscounts[Discounts.Senior]);
            }
            return (Discounts.Regular, PriceDiscounts[Discounts.Regular]);
        }

    }
}
