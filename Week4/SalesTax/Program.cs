using System;

namespace SalesTax
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSalesTax();
        }

        private static void RunSalesTax()
        {
            Console.Write("Enter an amount: ");
            string amoutnInText = Console.ReadLine();
            Console.Write("Enter a two character state code: ");
            string stateCode = Console.ReadLine();
            if(decimal.TryParse(amoutnInText, out decimal amount))
            {
                decimal taxToPay = SalesTax(amount, stateCode);
                Console.WriteLine($"You mus pay {taxToPay:C} in sales tax.");
            }
            else
            {
                Console.WriteLine("You did not enter a valid amount!");
            }
        }

        private static decimal SalesTax(decimal amount, string stateCode)
        {
            decimal rate = 0.0M;
            switch(stateCode)
            {
                case "OR": // Oregon
                case "AK": // Alaska
                case "MT": // Montana
                    rate = 0.0M;
                    break;
                case "ND": // North Dakota
                case "WI": // Wisconsin
                case "MD": // Maryland
                case "VA": // Virginia
                    rate = 0.05M;
                    break;
                case "IL": // Illinois
                    rate = 0.0886M;
                    break;
                case "CA": // California
                    rate = 0.0825M;
                    break;
                default:   // Most U.S. States
                    rate = 0.06M;
                    break;
            }
            return amount * rate;
        }
    }
}
