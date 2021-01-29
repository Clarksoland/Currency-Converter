using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialise Variables
            bool isStaff = false;
            double poundsIn = -1;
            int conversionCurrency = -1;
            double currencyOut = -1;
            string currencyType = string.Empty;
            double transactionFee = -1;
            double totalCost = -1;
            double discount = 0;

            while (true)
            {

                // User Inputs

                // Checking if customer is a member of staff
                while (true)
                {
                    Console.Write("Is the current customer a member of staff? (Y / N): ");

                    string temp;

                    temp = Console.ReadLine();

                    if (temp.ToLower() == "y") { isStaff = true; break; }
                    else if (temp.ToLower() == "n") { isStaff = false; break; }

                    Console.Clear();
                }
                Console.Clear();

                // Asking the user to input the amount of GBP to be converted
                while (true)
                {
                    Console.Write("Please enter the number of Pounds to be converted (Minimum £0.01, Max £2500): ");

                    try { poundsIn = Convert.ToDouble(Console.ReadLine()); }
                    catch { Console.Clear(); }

                    // Making use of Math.Truncate to avoid rounding up (always round down when it comes to money)
                    poundsIn = Math.Truncate(100 * poundsIn) / 100;

                    if (poundsIn > 0 && poundsIn <= 2500) { break; }

                    Console.Clear();
                }

                Console.Clear();

                // Asking the user to input the desired output currency
                while (true)
                {
                    Console.WriteLine("Please enter the number of the currency that you wish to convert into (1 - 5):" +
                        "\n1: USD (US Dollars)" +
                        "\n2: EUR (Euros)" +
                        "\n3: BRL (Brazilian Real)" +
                        "\n4: JPY (Japanese Yen)" +
                        "\n5: TRY (Turkish Lira)");

                    try { conversionCurrency = Convert.ToInt32(Console.ReadLine()); }
                    catch { Console.Clear(); }

                    if (conversionCurrency >= 1 && conversionCurrency <= 5) { break; }

                    Console.Clear();
                }

                Console.Clear();

                // Convert GBP to requested currency
                if (conversionCurrency == 1) { currencyOut = poundsIn * 1.4; currencyType = "USD"; }
                else if (conversionCurrency == 2) { currencyOut = poundsIn * 1.14; currencyType = "EUR"; }
                else if (conversionCurrency == 3) { currencyOut = poundsIn * 4.77; currencyType = "BRL"; }
                else if (conversionCurrency == 4) { currencyOut = poundsIn * 151.05; currencyType = "JPY"; }
                else { currencyOut = poundsIn * 5.68; currencyType = "TRY"; }
                currencyOut = Math.Truncate(100 * currencyOut) / 100;

                // Calculate Transaction Fees
                if (poundsIn <= 300) { transactionFee = poundsIn * 0.035; }
                else if (poundsIn > 300 && poundsIn <= 750) { transactionFee = poundsIn * 0.03; }
                else if (poundsIn > 750 && poundsIn <= 1000) { transactionFee = poundsIn * 0.025; }
                else if (poundsIn > 1000 && poundsIn <= 2000) { transactionFee = poundsIn * 0.02; }
                else { transactionFee = poundsIn * 0.015; }
                transactionFee = Math.Truncate(100 * transactionFee) / 100;

                // Calculate Total Cost
                totalCost = poundsIn + transactionFee;
                totalCost = Math.Truncate(100 * totalCost) / 100;

                // Check for (and apply) staff discount if appropriate
                if (isStaff)
                {
                    discount = totalCost * 0.05;
                    discount = Math.Truncate(discount * 100) / 100;

                    totalCost -= discount;
                }

                // Outputs
                Console.WriteLine("Currency out: {0} {1}.\n", currencyOut, currencyType);
                Console.WriteLine("Transaction Fee: £{0}.\n", transactionFee);
                Console.WriteLine("Discount: £{0}.\n", discount);
                Console.WriteLine("\nTotal Cost: £{0}.", totalCost);

                Console.ReadKey();

                Console.Clear();
            }
        }
    }
}
