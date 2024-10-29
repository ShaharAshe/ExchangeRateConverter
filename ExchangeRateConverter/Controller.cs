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
        //private readonly List<string> _countriesCoinNames; // need to be !! deprecated !! //
        private readonly List<string> _valuesExc; // need to be !! deprecated !! //

        public Controller(string fileName)
        {
            // initial the Lists
            //this._countriesCoinNames = new List<string>();
            this._valuesExc = new List<string>();
            
            // initial the List with the file content //
            this._fileContent = File.ReadAllLines(fileName)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())
                .ToList();
            
            GetvaluesExc();

            foreach (string line in this._fileContent)
            {
                Console.WriteLine(line);
            }
            //Console.WriteLine("-------");
            //foreach (string c in this._countriesCoinNames)
            //{
            //    Console.WriteLine(c);
            //}
            Console.WriteLine("-------");
            foreach (string v in this._valuesExc)
            {
                Console.WriteLine(v);
            }
        }

        private void GetvaluesExc()
        {
            //for (int i = 0; i < Utilities.Instance.TO_COUNTRY + 1; ++i)
            //{
            //    this._countriesCoinNames.Add(this._fileContent[i]);
            //}
            for (int i = Utilities.Instance.TO_COUNTRY + 1; i < this._fileContent.Count(); ++i)
            {
                this._valuesExc.Add(this._fileContent[i]);
            }
        }
    }
}
