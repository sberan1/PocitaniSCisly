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
        private double spocitejFaktorial(int cislo)
        {
            double vysledek = 1;

            for (int i = 1; i <= cislo; i++)
            {
                vysledek *= i;
            }

            return vysledek;
        }

    }
    class CalculateMethodRecursion : CalculationMethod
    {
        public override double Calculate(double x, int n)
        {
            return spocitejRekurzivne(x, n);
        }

        private double spocitejRekurzivne(double x, int cislo, int mocnina = 1, double vysledek = 1)
        {
            if (mocnina >= cislo - 1)
            {
                return vysledek;
            }

            double factorial = spocitejFaktorial(cislo);
            vysledek = spocitejUlohu(vysledek, x, mocnina, factorial);

            return spocitejRekurzivne(x, cislo, mocnina + 1, vysledek);
        }

        private double spocitejFaktorial(int cislo, int mocnina = 1, double vysledek = 1)
        {
            if (mocnina >= cislo - 1)
            {
                return vysledek;
            }

            vysledek *= mocnina;

            return spocitejFaktorial(cislo, mocnina + 1, vysledek);
        }
        class CalculateMethodWhile : CalculationMethod
        {
            public override double Calculate(double x, int n)
            {
                int mocnina = 1;
                double vysledek = 1;

                while (mocnina <= n)
                {

                    double factorial = spocitejFaktorial(mocnina);
                    vysledek = spocitejUlohu(vysledek, x, mocnina, factorial);

                    mocnina++;
                }

                return vysledek;
            }

            private double spocitejFaktorial(int cislo)
            {
                int mocnina = 1;
                double vysledek = 1;

                while (mocnina <= cislo)
                {
                    vysledek *= mocnina;
                    mocnina++;
                }

                return vysledek;
            }
            class CalculateMethodDoWhile : CalculationMethod
            {
                public override double Calculate(double x, int n)
                {
                    int mocnina = 1;
                    double vysledek = 1;

                    do
                    {
                        double factorial = spocitejFaktorial(mocnina);
                        vysledek = spocitejUlohu(vysledek, x, mocnina, factorial);

                        mocnina++;
                    } while (mocnina <= n);

                    return vysledek;
                }

                private double spocitejFaktorial(int cislo)
                {
                    int mocnina = 1;
                    double vysledek = 1;

                    do
                    {
                        vysledek *= mocnina;
                        mocnina++;
                    } while (mocnina <= cislo);

                    return vysledek;
                }
            }
        }
    }
}
