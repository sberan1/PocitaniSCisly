using System;

namespace PocitaniSCisly
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateMethodFor cfor = new CalculateMethodFor();
            Console.WriteLine("nejakej text" + cfor.Calculate(2, 2));
        }
    }

    interface ICalculationMethod
    {
        public double Calculate(double x, int n);
    }
    abstract class CalculationMethod : ICalculationMethod
    {
        public abstract double Calculate(double x, int n);

        protected double spocitejUlohu(double momentalniVysledek, double x, int mocnina, double faktorial)
        {
            double umocneneCislo = Math.Pow(x, mocnina);
            double vysledekFaktorialu = faktorial;

            double mezivysledek = umocneneCislo / vysledekFaktorialu;

            if (mocnina % 2 > 0)
            {
                momentalniVysledek += mezivysledek;
                return momentalniVysledek;
            }

            momentalniVysledek -= mezivysledek;
            return momentalniVysledek;
        }
    }

    class CalculateMethodFor : CalculationMethod
    {
        public override double Calculate(double x, int n)
        {
            double vysledek = 1;
            for (int i = 1; i <= n; i++)
            {
                double factorial = this.spocitejFaktorial(i);
                vysledek = spocitejUlohu(vysledek, x, i, factorial);
            }

            return vysledek;
        }
        private double spocitejFaktorial(int number)
        {
                double result = 1;

                for (int i = 1; i <= number; i++)
                {
                    result *= i;
                }

                return result;
        }
        
    }
    class CalculateMethodRecursion : CalculationMethod
    {
        public double Calculate(double x, int n)
        {
            throw new Exception();
        }
    }
    class CalculateMethodWhile : CalculationMethod
    {
        public double Calculate(double x, int n)
        {
            throw new Exception();
        }
    }
    class CalculateMethodDoWhile : CalculationMethod
    {
        public double Calculate(double x, int n)
        {
            throw new Exception();
        }
    }
}
