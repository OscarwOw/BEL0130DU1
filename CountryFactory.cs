using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL0130DU1
{
    public sealed class CountryFactory
    {
        private static readonly Lazy<CountryFactory> lazyInstance = new Lazy<CountryFactory>(() => new CountryFactory());
        public static CountryFactory Instance => lazyInstance.Value;
        private CountryFactory() { }

        public List<Country> ParseCountryStringsList(IEnumerable<string> lines)
        {
            List<Country> countries = new List<Country>();
            foreach (string line in lines)
            {
                Country country = new Country();
                var values = line.Split(';');
                country.Name = values[0];
                country.AvgPrice = ParseAvgPrice(values[1]);
                country.ExchangeRate = double.Parse(values[2]);
                country.Year = ParseYear(values[3]);
                country.IsEuropeUnion = values[4]=="ano"?true:false;
                countries.Add(country);
            }
            return countries;
        }
        private AvgPrice ParseAvgPrice(string avgprice)
        {
            AvgPrice result = new AvgPrice();
            var values = avgprice.Split(" ");
            result.Currency = values[0];
            result.price = double.Parse(values[1]);
            return result;
        }
        private int? ParseYear(string year)
        {
            if (string.IsNullOrEmpty(year))
            {
                return null;
            }
            return int.Parse(year.Split("-")[0]);
        }

        public double GetAvarageEUSalary(List<Country> countries)
        {
            return Math.Round(GetEUCountries(countries).Select(c=>c.ToEurRounded()).Average(),2);
        }
        private List<Country> GetEUCountries(List<Country> c) => c.Where(c => c.IsEuropeUnion).ToList();
        private List<Country> GetCountriesByYear(List<Country> countries,int year) => countries.Where(c=>c.Year==year||c.Year==null).ToList();
        public Country GetTopCountryBySalaryByYear(List<Country> countries,int year) => GetCountriesByYear(countries,year).OrderByDescending(c => c.ToEurRounded()).FirstOrDefault();



    }

}
