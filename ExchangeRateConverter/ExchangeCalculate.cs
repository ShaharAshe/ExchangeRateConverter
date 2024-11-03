using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ExchangeRateConverter
{
    public class ExchangeCalculate
    {
        private readonly ExchangeData _exchangeData;
        private readonly Dictionary<decimal, List<decimal>> _exchangeCalculateData;

        public ExchangeCalculate(ExchangeData exchangeData)
        {
            this._exchangeCalculateData = new Dictionary<decimal, List<decimal>>();
            this._exchangeData = exchangeData;
        }

        public void Calculate(List<string> content)
        {
            for (int i = Utilities.Instance.TO_COUNTRY + 1; i < content.Count(); ++i)
            {
                decimal data = decimal.Parse(content[i]);
                List<decimal> val = new List<decimal> { data };
                this._exchangeCalculateData.Add(data, val);
                Task.Run(() => val[0] = (val[0] * (this._exchangeData.RateData))).Wait();
            }
        }

        public void Print()
        {
            foreach (var entry in this._exchangeCalculateData)
            {
                Console.WriteLine(entry.Value[0]);
            }
        }
    }
}
