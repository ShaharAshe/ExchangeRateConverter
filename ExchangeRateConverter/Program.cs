using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;


namespace ExchangeRateConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Controller app = new Controller(new ReadFile(args[Utilities.Instance.FILE_NAME]));
                app.Run();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.Error.WriteLine("[ERROR] - You need to insert a file name in the arguments vector !!!");
            }
            catch (AggregateException e)
            {
                Console.Error.WriteLine("[ERROR] - Http Request !!!");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
