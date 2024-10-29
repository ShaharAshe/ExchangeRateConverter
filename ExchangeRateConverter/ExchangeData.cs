using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ExchangeRateConverter
{
    public class ExchangeData
    {
        private readonly string _FromCountry;
        private readonly string _ToCountry;
        private readonly string _URL;

        public ExchangeData(string from, string to)
        {
            this._FromCountry = from;
            this._ToCountry = to;

            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            Console.WriteLine(basePath);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            var key = configuration["AppSettings:API_KEY"];

            this._URL = $"https://v6.exchangerate-api.com/v6/{key}/latest/{this._FromCountry}";

            Console.WriteLine(this._URL);
            Console.WriteLine("From: {0}",this._FromCountry);
            Console.WriteLine("To: {0}", this._ToCountry);
        }

        public string GetFromCountry()
        {
            return this._FromCountry;
        }
        public string GetToCountry()
        {
            return this._ToCountry;
        }
    }
}