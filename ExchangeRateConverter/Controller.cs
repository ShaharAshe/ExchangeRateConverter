using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Threading;
using System.Numerics;

namespace ExchangeRateConverter
{
    public class Controller
    {
        private readonly List<string> _fileContent; // need to be !! deprecated !! //
        private readonly ExchangeData _exchangeData;
        private readonly Dictionary<decimal, decimal> _exchangeCalculateData;

        public Controller(string fileName)
        {
            // initial the List with the file content //
            this._fileContent = File.ReadAllLines(fileName)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToList();

            // !! need to change that and removed the new to another place !!! //
            try
            {
                this._exchangeData = new ExchangeData(_fileContent[Utilities.Instance.FROM_COUNTRY], _fileContent[Utilities.Instance.TO_COUNTRY]);
            }
            catch (Exception e)
            {
                throw new Exception("[ERROR] - The file format is not good !!!\nThe format need to be:\n< Country coin from >\n< Country coin to >\n...\n");
            }

            foreach (string line in this._fileContent)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();

            this._exchangeCalculateData = new Dictionary<decimal, decimal>();
        }

        public void Run()
        {
            this.Calculate();
            this.Print();
        }

        private void Calculate()
        {
            for (int i = Utilities.Instance.TO_COUNTRY + 1; i < this._fileContent.Count(); ++i)
            {
                decimal data = decimal.Parse(this._fileContent[i]);
                this._exchangeCalculateData.Add(data, (data * (this._exchangeData.RateData)));
            }
        }

        private void Print()
        {
            foreach (var entry in this._exchangeCalculateData)
            {
                Console.WriteLine(entry.Value);
            }
        }
    }
}
