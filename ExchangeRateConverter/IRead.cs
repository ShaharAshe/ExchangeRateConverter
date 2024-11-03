using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateConverter
{
    public interface IRead
    {
        List<string> _content { get; }

        ExchangeCalculate Process();
    }
}
