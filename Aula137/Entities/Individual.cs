using System;
using Aula137.Entities;

namespace Aula137.Entities
{
    internal class Individual : TaxPayer
    {
        public Double HealthExpenditures { get; set; }

        public Individual()
        {
        }

        public Individual(string name, double anualIncome, double healthExpenditures) : base(name, anualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {
            double finalTax = 0.0;
            if (AnualIncome < 20000.0)
            {
                finalTax = AnualIncome * 0.15;
            }
            else
            {
                finalTax = AnualIncome * 0.25;
            }

            if (HealthExpenditures > 0.0)
            {
                finalTax -= HealthExpenditures / 2;
            }
            return finalTax;
        }
    }
}
