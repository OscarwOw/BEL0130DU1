using BEL0130DU1;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("cs-CZ");
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string? csv = FileHandler.Instance.ReadAllText(args[0]);
        if (csv == null)
        {
            return;
        }
        var lines =FileHandler.Instance.GetCountries(csv);
        List<Country> countries = CountryFactory.Instance.ParseCountryStringsList(lines);
        Console.WriteLine($"Průměrný plat: {CountryFactory.Instance.GetAvarageEUSalary(countries)}");
        Console.WriteLine($"Nejvyšší plat v roce 2023: {CountryFactory.Instance.GetTopCountryBySalaryByYear(countries, 2023).Name}\n");
        countries.ForEach(country => country.PrintAvgEurSalary());
    }
}