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
using System.Net.Http;

namespace ExchangeRateConverter
{
    public class Controller
    {
        
        private readonly IRead _read;
        private readonly ExchangeCalculate _calc;

        public Controller(IRead read)
        {
            this._read = read;
            this._calc = this._read.Process();
        }

        public void Run()
        {
            this._calc.Calculate(this._read._content);
            this._calc.Print();
        }
    }
}
