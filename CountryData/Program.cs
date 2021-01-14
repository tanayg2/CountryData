using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CountryInfoService.CountryInfoServiceSoapTypeClient client = new CountryInfoService.CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap");

            while (true)
            {
                Console.WriteLine("Enter country name, or type 'Q' to quit");
                Console.WriteLine("Example format: Barbados");
                string countryName = Console.ReadLine();

                if (countryName.Equals("Q"))
                {
                    return;
                }

                string isoCode = client.CountryISOCode(countryName);
                string capitalCity = client.CapitalCity(isoCode);
                CountryInfoService.tCurrency currencyObj = client.CountryCurrency(isoCode);
                string currencyCode = currencyObj.sISOCode;

                Console.WriteLine("\nISO code:\t{0}\nCapital City:\t{1}\nCurrency Code:\t{2}\n\n", isoCode, capitalCity, currencyCode);
            }
        }
    }
}
