using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BEL0130DU1
{
    public class Country
    {
        public string Name { get; set; }
        public AvgPrice AvgPrice { get; set; }
        public double ExchangeRate { get; set; }
        public int? Year { get; set; }
        public bool IsEuropeUnion { get; set; }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"AvgPrice: {AvgPrice}"); 
            Console.WriteLine($"ExchangeRate: {ExchangeRate}");
            Console.WriteLine($"Year: {Year?.ToString() ?? "N/A"}");
            Console.WriteLine($"IsEuropeUnion: {IsEuropeUnion}");
        }
        public double ToEur() => AvgPrice.price * ExchangeRate;
        public double ToEurRounded() => Math.Round(AvgPrice.price * ExchangeRate, 2);

        public void PrintAvgEurSalary()
        {
            Console.WriteLine($"{Name}: {ToEurRounded()} EUR");
        }

    }
}
