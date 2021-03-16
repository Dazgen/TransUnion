using System;
using System.Collections.Generic;

namespace TransUnion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input money amount for 1.1 case:");
            var amount = Double.Parse(Console.ReadLine());
            var atm11 = new ATM11();
            var exchange = atm11.Exchange(amount);
            PrintChange(exchange);

            Console.WriteLine("Input money amount for 1.2 case:");
            amount = Double.Parse(Console.ReadLine());
            var atm12 = new ATM12();
            exchange = atm12.Exchange(amount);
            PrintChange(exchange);

            Console.WriteLine("Input money amount for 1.3 case:");
            amount = Double.Parse(Console.ReadLine());
            var atm13 = new ATM13();
            exchange = atm13.Exchange(amount);
            PrintChange(exchange);

            Console.WriteLine("Input money amount for 1.4 case:");
            amount = Double.Parse(Console.ReadLine());
            var atm14 = new ATM14();
            exchange = atm14.Exchange(amount);
            PrintChange(exchange);

            Console.WriteLine("Input money amount for 1.4 case:");
            amount = Double.Parse(Console.ReadLine());
            var atm15 = new ATM15();
            exchange = atm15.Exchange(amount);
            PrintChange(exchange);
            Console.ReadLine();
        }

        private static void PrintChange(Dictionary<double, int> change)
        {
            if (change == null)
            {
                Console.WriteLine("Cannot exchange this amount");
            }
            else
            {
                Console.WriteLine("Bill \tAmount");
                foreach (var bill in change.Keys)
                {
                    Console.WriteLine(bill + "\t" + change[bill]);
                }
            }
        }
    }
}
