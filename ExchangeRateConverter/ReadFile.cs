using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ExchangeRateConverter
{
    public class ReadFile : IRead
    {
        private readonly string _fileName;
        public List<string> _content { get; private set; }

        public ReadFile(string fileName)
        {
            this._fileName = fileName;
        }
        public ExchangeCalculate Process()
        {
            // initial the List with the file content //
            this._content = File.ReadAllLines(this._fileName)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToList();

            if (this._content.Count() < (Utilities.Instance.TO_COUNTRY + 1))
            {
                throw new Exception("[ERROR] - The file format is not good !!!\nThe format need to be:\n< Country coin from >\n< Country coin to >\n...\n");
            }

            ///
            //foreach (string line in this._content)
            //{
            //    Console.WriteLine(line);
            //}
            //Console.WriteLine();
            ///

            return new ExchangeCalculate(new ExchangeData(this._content[Utilities.Instance.FROM_COUNTRY], this._content[Utilities.Instance.TO_COUNTRY]));
        }
    }
}
