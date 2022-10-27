using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{sin(2)}");
            Console.WriteLine($"{Math.Sin(2)}");
            Console.WriteLine($"{cos(-2)}");
            Console.WriteLine($"{Math.Cos(-2)}");
            Console.WriteLine($"{log(2, 8)}");
            //https://math.semestr.ru/math/taylor.php


        }


        static double log(double osn, double x)
        {
            double degree = 0.000001;

            while(Math.Pow(osn, degree) < x)
            {
                degree += 0.000001;
            }

            return degree;

        }

        static double sin(double x)
        {
            const double eps = 1e-15;  // погрешность вычислений
            double s = 0;  // начальная сумма
            double r = x;   // первый член ряда
            int n = 1;         // показатель степени
            while (Math.Abs(r) > eps) // условие выполнения цикла 
            {
                s = s + r;      // добавление члена ряда
                n = n + 2;  // наращивание  n:  1,3,5,7,...
                r = -r * x * x / (n * (n - 1)); // новый член ряда
            }
            return s;       // возврат результата
        }

        static double cos(double x)
        {
            const double eps = 1e-15;  // погрешность вычислений
            double s = 0;  // начальная сумма
            double r = 1;   // первый член ряда
            int n = 0;         // показатель степени
            while (Math.Abs(r) > eps) // условие выполнения цикла
            {
                s = s + r;      // добавление члена ряда
                n = n + 2;  // наращивание  n:  1,3,5,7,...
                r = -r * x * x / (n * (n - 1)); // новый член ряда
            }
            return s;       // возврат результата
        }




    }
}