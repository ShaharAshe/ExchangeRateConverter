using System;

namespace ExchangeRateConverter
{
    public sealed class Utilities
    {
        private static Utilities _instance = null;
        private static readonly object _lock = new object();
        private Utilities()
        {
            FILE_NAME = 0;
            FROM_COUNTRY = 0;
            TO_COUNTRY = 1;
            DotenvFileName = "appsettings.json";
        }
        public static Utilities Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Utilities();
                    }
                    return _instance;
                }
            }
        }

        public readonly int FILE_NAME;
        public readonly int FROM_COUNTRY;
        public readonly int TO_COUNTRY;
        public readonly string DotenvFileName;
    }
}