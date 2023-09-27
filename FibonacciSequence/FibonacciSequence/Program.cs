using System.Diagnostics.CodeAnalysis;

namespace FibonacciSequence;
class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Input integer number: ");
        string numString = Console.ReadLine();
        bool flag = false;
        long.TryParse(numString, out long num);
        do
        {
            if (long.TryParse(numString, out num))
            {
                long first = 0;
                long second = 1;

                long n;
                long sum = 0;
                Console.WriteLine($"{first};{first} sum\n{second};{second} sum");
                sum += first + second;
                for (int i = 1; i < num; i++)
                {
                    n = first + second;
                    sum += (first + second) - first;
                    
                    first = second;
                    second = n;
                    Console.WriteLine($"{n};{sum} sum");
                }
                flag = true;
            }
            else
            {
                Console.WriteLine("Wrong input , try again: ");
                numString = Console.ReadLine();
                flag = false;
            }
        }while (flag == false);

        long sum1 = 0;
        Console.WriteLine(0);
        //for (int i = 0; i < num; i++)
        //{
        //    long temp = Fibonacci(i);
        //    sum1 += Fibonacci(i-1);
        //    Console.WriteLine(temp + " " + sum1);
        //}
        
    }

    static long Fibonacci(int num)
    {
        if(num >= 2)
        {
            return Fibonacci(num - 1) + Fibonacci(num - 2);
        }
        return 1;
    }
}