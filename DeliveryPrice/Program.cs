using System;
using System.Collections.Generic;
using System.Linq;
namespace DeliveryPrice
{
    internal class HomeWork
    {
        private decimal GetFullPrice(
                                    IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            decimal fullPrice = default;
            if (Validation(destinations, clients, infantsIds, childrenIds, prices, currencies))
            {
                prices = ConvertPricesToUSD(prices, currencies);
                CalculateDiscounts(destinations, clients, infantsIds, childrenIds, ref prices);
                foreach (decimal pr in prices)
                    fullPrice += pr;
            }

            return fullPrice;
        }
        private IEnumerable<decimal> ConvertPricesToUSD(IEnumerable<decimal> prices, IEnumerable<string> currencies)
        {
            int iter = 0;
            List<decimal> modPrices = prices.ToList();
            foreach (string cur in currencies)
            {
                if (cur == "EUR")
                    modPrices[iter] *= 1.19m; //exchange rate dollar - euro
                iter++;
            }
            return modPrices;
        }
        private bool Validation(IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            int checkCount = destinations.Count();
            if (checkCount == clients.Count() && checkCount == prices.Count()
                && checkCount == currencies.Count() && infantsIds.Count() + childrenIds.Count() < checkCount)
                return true;
            return false;
        }
        private void CalculateDiscounts(IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    ref IEnumerable<decimal> prices)
        {
            decimal[] modPrices = prices.ToArray();
            int[] infId = infantsIds.ToArray();
            int[] chId = childrenIds.ToArray();

            //var merged = destinations.Zip(prices, (a, b) => Tuple.Create(a, b));

            int iter = 0, infIter = 0, chIter = 0;
            string prevAddr = "";
            decimal percentDiscount = 1;
            foreach (string dest in destinations)
            {
                if (dest.Contains("Wayne Street"))
                    modPrices[iter] += 10;

                if (dest.Contains("North Heather Street"))
                    modPrices[iter] -= 5.36m;

                if (chIter < chId.Length && chId[chIter] == iter)
                {
                    percentDiscount -= 0.25m;
                    chIter++;
                }
                else if (infIter < infId.Length && infId[infIter] == iter)
                {
                    percentDiscount -= 0.5m;
                    infIter++;
                }
                if (dest.Contains(prevAddr))
                    percentDiscount -= 0.15m;
                modPrices[iter] *= percentDiscount;
                percentDiscount = 1;
                prevAddr = dest.Substring(4);
                iter++;
            }
            prices = modPrices;
        }
        public decimal InvokePriceCalculatiion()
        {
            var destinations = new[]
            {
                "949 Fairfield Court, Madison Heights, MI 48071",
                "367 Wayne Street, Hendersonville, NC 28792",
                "910 North Heather Street, Cocoa, FL 32927",
                "911 North Heather Street, Cocoa, FL 32927",
                "706 Tarkiln Hill Ave, Middleburg, FL 32068",
            };

            var clients = new[]
            {
                "Autumn Baldwin",
                "Jorge Hoffman",
                "Amiah Simmons",
                "Sariah Bennett",
                "Xavier Bowers",
            };

            var infantsIds = new[] { 2 };
            var childrenIds = new[] { 3, 4 };

            var prices = new[] { 100, 25.23m, 58, 23.12m, 125 };
            var currencies = new[] { "USD", "USD", "EUR", "USD", "USD" };

            return GetFullPrice(destinations, clients, infantsIds, childrenIds, prices, currencies);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HomeWork hw = new HomeWork();
            Console.WriteLine(hw.InvokePriceCalculatiion());
        }
    }
}
