using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace ExchangeRateConverter
{
    public class Controller
    {
        private readonly List<string> _fileContent; // need to be !! deprecated !! //
        
        public Controller(string fileName)
        {
            // initial the List with the file content //
            this._fileContent = File.ReadAllLines(fileName)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToList();

            foreach (string line in this._fileContent)
            {
                Console.WriteLine(line);
            }
        }
    }
}
