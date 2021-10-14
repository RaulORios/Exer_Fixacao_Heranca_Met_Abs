using System;
using System.Globalization;
using System.Collections.Generic;
using Exer_Fixacao_Heranca_Met_Abs.Entities;

namespace Exer_Fixacao_Heranca_Met_Abs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            List<TaxPayer> list = new List<TaxPayer>();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char type = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                if (type == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of Employees: ");
                    int numberOfEmployees = int.Parse(Console.ReadLine());
                    list.Add(new Company(name, anualIncome, numberOfEmployees));
                }                

            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID:");
            double sum = 0.0;
            foreach (TaxPayer tax in list)
            {
                Console.WriteLine($"{tax.Name}: $ {tax.Tax().ToString("F2",CultureInfo.InvariantCulture)}");
                sum += tax.Tax();
            }

            Console.WriteLine();
            Console.WriteLine($"TOTAL TAXES: {sum.ToString("F2",CultureInfo.InvariantCulture)}");

            Console.ReadKey();
        }
    }
}
