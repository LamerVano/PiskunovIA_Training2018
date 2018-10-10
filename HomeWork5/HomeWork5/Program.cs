using System;

namespace HomeWork5
{
    class Program
    {
        static void Main(string[] args)
        {
            BigNumber bigNumber = new BigNumber(-24);
            bigNumber = bigNumber.Sum(-80);
            Console.WriteLine(bigNumber.ToString());
            bigNumber = bigNumber.Multiply(-10);
            Console.WriteLine(bigNumber.ToString());
            bigNumber = bigNumber.Subtraction(83);
            Console.WriteLine(bigNumber.ToString());
            bigNumber = bigNumber.Sum(903);
            Console.WriteLine(bigNumber.ToString());
            bigNumber = bigNumber.Multiply(bigNumber.ToString());
            Console.WriteLine(bigNumber.ToString());
            bigNumber = bigNumber.Multiply(bigNumber.Number, bigNumber.IsSigned);
            Console.WriteLine(bigNumber.ToString());
            bigNumber = bigNumber.Subtraction(BigNumber.CalcFactorial(21));
            Console.WriteLine(bigNumber.ToString());
            Console.Read();
        }
    }
}
