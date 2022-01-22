using System.Globalization;
using Aula137.Entities;
using System.Collections;
using System.Text;

double totalTaxes = 0.0;

Console.Write("Enter the number of tax payers: ");
int n = int.Parse(Console.ReadLine());
List<TaxPayer> taxpayers = new List<TaxPayer>();

for (int i = 1; i <= n; i++)
{
    Console.WriteLine();
    Console.WriteLine($"Tax Payer #{i} data:");
    Console.Write("Individual or company (i/c)? ");
    char type = char.Parse(Console.ReadLine());
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Anual income: ");
    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    if (type == 'i')
    {
        Console.Write("Health expenditures: ");
        double healthExpenditure = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
        TaxPayer taxPayer = new Individual(name, anualIncome, healthExpenditure);
        taxpayers.Add(taxPayer);
    }
    else
    {
        Console.Write("Number of employees: ");
        int numberOfEmployees = int.Parse(Console.ReadLine());
        TaxPayer taxPayer = new Company(name, anualIncome, numberOfEmployees);
        taxpayers.Add(taxPayer);

    }

}


Console.WriteLine();
Console.WriteLine("TAXES PAID:");
foreach(TaxPayer taxPayer in taxpayers)
{
    StringBuilder sb = new StringBuilder();
    sb.Append(taxPayer.Name);
    sb.Append(": $ ");
    sb.Append(taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));
    Console.WriteLine(sb.ToString());
    totalTaxes += taxPayer.Tax();
}

Console.WriteLine();
Console.WriteLine("TOTAL TAXES: $ " + totalTaxes);