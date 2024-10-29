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
            var utilities = Utilities.Instance;
            Console.WriteLine("Singleton Value: " + utilities.FILE_NAME);

            try
            {
                Console.WriteLine("Hello World {0} {1}\n", args[utilities.FILE_NAME], args.Length);
                string[] lines = File.ReadAllLines(args[utilities.FILE_NAME])
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .Select(line => line.Trim())
                    .ToArray();

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
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
