using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ExchangeRateConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Controller app = new Controller(args[Utilities.Instance.FILE_NAME]);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Error.WriteLine("[ERROR] - You need to insert a file name in the arguments vector !!!");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}
