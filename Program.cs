using System;
using System.Collections.Generic;

namespace Palindorme
{
    class Program
    {
        static void Main(string[] args)
        {
            long result = GetMaxPalindrome(99999, 10000, out long a, out long b, out long iterations);
            Console.WriteLine(string.Format("{0}x{1}={2}", a, b, result));
            Console.WriteLine(string.Format("Iterations: {0}", iterations));
            Console.ReadLine();
        }

        static bool IsPalindrome(long number)
        {
            long x, y;
            x = number;
            y = 0;
            while (x>0)
            {
                y = y * 10 + (x % 10);
                x = x / 10;
            }
            if (y == number)
                return true;
            return false;
        }

        static int[] GetPrimeNumbersSieveOfEratosthenes(int UpNumber)
        {
            int[] arr = new int[UpNumber];
            int n = 0;
            for (int i = 2; i * i <= UpNumber; i++)
            {
                if (arr[i] == 0)
                {
                    for (int j = 2; j * i < UpNumber; j++)
                    {
                        arr[j * i] = 1;
                        n++;
                    }
                }
            }
            return arr;
        }

        static long GetMaxPalindrome(int maxValue, int minValue, out long a, out long b, out long iterations)
        {
            a = 0;
            b = 0;
            long c = 0;
            iterations = 0;
            long maxb = 0;
            List<long> listPrimeNumbers = new List<long>();
            int[] primeNumbers = GetPrimeNumbersSieveOfEratosthenes(maxValue);
            for (int i = primeNumbers.Length - 1; i > minValue;  i--)
            {
                iterations++;
                if (primeNumbers[i] == 0) listPrimeNumbers.Add(i);
            }
            maxb = listPrimeNumbers.Count - 1;
            for (int i = 0; i <= maxb; i++)
            {
                a = listPrimeNumbers[i];
                for (int j = i; j < maxb; j++)
                {
                    b = listPrimeNumbers[j];
                    iterations++;
                    if (IsPalindrome(a * b))
                    {
                        if ((a * b) > c)
                        {
                            maxb = j;
                            c = a * b;
                            break;
                        }
                    }
                }
            }
            return c;
        }
    }
}
