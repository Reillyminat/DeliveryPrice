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
            if (!IsDataValid(destinations, clients, infantsIds, childrenIds, prices, currencies))
            {
                return fullPrice;
            }

            prices = ConvertPricesToUSD(prices, currencies);
            CalculateDiscounts(destinations, clients, infantsIds, childrenIds, ref prices);
            foreach (var value in prices)
                fullPrice += value;
            return fullPrice;
        }
        private IEnumerable<decimal> ConvertPricesToUSD(IEnumerable<decimal> prices, IEnumerable<string> currencies)
        {
            var iter = 0;
            List<decimal> modPrices = prices.ToList();
            foreach (var currency in currencies)
            {
                if (currency == "EUR")
                    modPrices[iter] *= 1.19m; //exchange rate dollar - euro
                iter++;
            }
            return modPrices;
        }
        private bool IsDataValid(IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    IEnumerable<decimal> prices,
                                    IEnumerable<string> currencies)
        {
            var checkCount = destinations.Count();
            if (checkCount == clients.Count() && checkCount == prices.Count()
                && checkCount == currencies.Count() && infantsIds.Count() + childrenIds.Count() <= checkCount)
                return true;
            return false;
        }
        private void CalculateDiscounts(IEnumerable<string> destinations,
                                    IEnumerable<string> clients,
                                    IEnumerable<int> infantsIds,
                                    IEnumerable<int> childrenIds,
                                    ref IEnumerable<decimal> prices)
        {
            decimal[] resultPrices = prices.ToArray();
            int[] infantsIdArray = infantsIds.ToArray();
            int[] childrensIdArray = childrenIds.ToArray();

            int index = 0, infantsIterator = 0, childIterator = 0;
            var prevAddr = "";
            var percentDiscount = 1m;
            foreach (var dest in destinations)
            {
                if (dest.Contains("Wayne Street"))
                    resultPrices[index] += 10;

                if (dest.Contains("North Heather Street"))
                    resultPrices[index] -= 5.36m;

                if (childIterator < childrensIdArray.Length && childrensIdArray[childIterator] == index)
                {
                    percentDiscount -= 0.25m;
                    childIterator++;
                }
                else if (infantsIterator < infantsIdArray.Length && infantsIdArray[infantsIterator] == index)
                {
                    percentDiscount -= 0.5m;
                    infantsIterator++;
                }
                if (dest.Contains(prevAddr))
                    percentDiscount -= 0.15m;

                resultPrices[index] *= percentDiscount;
                percentDiscount = 1;
                prevAddr = dest.Substring(dest.IndexOf(' '));
                index++;
            }
            prices = resultPrices;
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
