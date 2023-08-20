﻿using ExchangeRateUpdater.Domain;
using ExchangeRateUpdater.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRateUpdater
{
    public static class Program
    {
        private static IExchangeRateProvider provider;
        private static IEnumerable<Currency> currencies => new InMemoryReadOnlyCurrenciesRepository().GetAll();

        public static void Main(string[] args)
        {
            try
            {
                var rates = provider.GetExchangeRates(currencies);

                Console.WriteLine($"Successfully retrieved {rates.Count()} exchange rates:");
                foreach (var rate in rates)
                {
                    Console.WriteLine(rate.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not retrieve exchange rates: '{e.Message}'.");
            }

            Console.ReadLine();
        }
    }
}
