using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace ExchangeRateConverter
{
    public class ExchangeData
    {
        public string FromCountry { get; private set; }
        public string ToCountry { get; private set; }
        public decimal FromData { get; private set; }
        public decimal ToData { get; private set; }

        private readonly string _URL;

        public ExchangeData(string from, string to)
        {
            this.FromCountry = from;
            this.ToCountry = to;
            this._URL = $"https://v6.exchangerate-api.com/v6/{ApiKey()}/latest/{this.FromCountry}";

            Task.Run(() => InitializeAsync(new HttpClient())).Wait();
        }

        private string ApiKey()
        {
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(Utilities.Instance.DotenvFileName, optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return configuration["AppSettings:API_KEY"];
        }

        private async Task InitializeAsync(HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.GetAsync(this._URL);
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var apiData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResponse);
            var exchangeData = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(apiData["conversion_rates"].ToString());

            FromData = exchangeData[this.FromCountry];
            ToData = exchangeData[this.ToCountry];
        }
    }
}
