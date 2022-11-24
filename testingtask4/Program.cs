using System;

namespace integrationTesting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double logPlugVar = logPlug(2, 10);
            double logLibrary = Math.Log2(10);

            Console.WriteLine($"Логарифм, подсчитанный с помощью заглушки: {logPlugVar}\nЛогарифм, подсчитанный с помощью встроенной бибилиотеки: {logLibrary}\n");

            double sinPlugVar = sinPlug(1);
            double sinLibrary = Math.Sin(1);

            Console.WriteLine($"Синус, подсчитанный с помощью заглушки: {sinPlugVar}\nСинус, подсчитанный с помощью встроенной бибилиотеки: {sinLibrary}\n");

            double cosPlugVar = cosPlug(1);
            double cosLibrary = Math.Cos(1);

            Console.WriteLine($"Синус, подсчитанный с помощью заглушки: {cosPlugVar}\nСинус, подсчитанный с помощью встроенной библиотеки: {cosLibrary}\n");

            firstFunctionPlug(1);

            secondFunctionPlug(2);





            //while (true)
            //{
            //    Console.WriteLine("Вычисление системы функций");
            //    double x;
            //    while (true) // Ввод x
            //    {
            //        Console.Write("Введите x: ");
            //        try
            //        {
            //            x = Convert.ToDouble(Console.ReadLine());
            //            break;
            //        }
            //        catch
            //        {
            //            Console.WriteLine("Необходимо ввести вещественное число! Повторите ввод!\n");
            //        }
            //    }
            //    SystemOfFunctions(x);
            //    Console.WriteLine("\nВыберите действие:\n1 - Запустить программу повторно\n2 - Выйти из программы");
            //    int answer;
            //    while (true) // Диалог с пользователем о повторном запуске программы
            //    {
            //        try
            //        {
            //            answer = Convert.ToInt32(Console.ReadLine());
            //            if (answer != 1 && answer != 2)
            //            {
            //                Console.WriteLine("Необходимо выбрать действие из предложенных! Повторите ввод!");
            //            }
            //            else
            //            {
            //                break;
            //            }
            //        }
            //        catch
            //        {
            //            Console.WriteLine("Необходимо ввести число 1 или 2! Повторите ввод!\n");
            //        }
            //    }
            //    if (answer == 2)
            //    {
            //        break;
            //    }
            //    Console.Clear();
            //}
        }
        static void SystemOfFunctions(double x) // Решение системы функций
        {
            if (x <= 0)
            {
                FirstFunction(x);
            }
            else
            {
                SecondFunction(x);
            }
        }

        static void FirstFunction(double x) // Решение первой функции
        {
            double result = (MathFunctions.Sin(x) + MathFunctions.Cos(x) + MathFunctions.Cos(x)) * (MathFunctions.Sin(x) + MathFunctions.Cos(x) + MathFunctions.Cos(x));
            Console.WriteLine("((sin({0}) + cos({0})) + cos({0}))^2 = {1}", x, result); ;
        }
        static void SecondFunction(double x) // Решение второй функции
        {
            double result = MathFunctions.Log(Math.E, x) * MathFunctions.Log(5, x);
            Console.WriteLine("ln({0})*log5({0}) = {1}", x, result);
        }

        private static double sinPlug(double x)
        {
            double sin = MathFunctions.Sin(x);
            return sin;
        }

        private static double cosPlug(double x)
        {
            double cos = MathFunctions.Cos(x);
            return cos;
        }

        private static void firstFunctionPlug(double x)
        {
            FirstFunction(x);
        }

        private static void secondFunctionPlug(double x)
        {
            SecondFunction(x);
        }

        private static double logPlug(double osn, double x)
        {
            double log = MathFunctions.Log(osn, x);
            return log;
        }

    }
    public class MathFunctions // Вычисление математических функций
    {
        public static double Sin(double x) // Функция для подсчета синуса по ряду Тейлора
        {
            const double eps = 0.000000000000001;
            double sum = 0;
            double t = x;
            int n = 1;
            while (Math.Abs(t) > eps)
            {
                sum = sum + t;
                n = n + 2;
                t = -t * x * x / (n * (n - 1));
            }
            return sum;
        }

        public static double Cos(double x) // Функция для подсчета косинуса по ряду Тейлора
        {
            const double eps = 0.000000000000001;
            double sum = 0;
            double t = 1;
            int n = 0;
            while (Math.Abs(t) > eps)
            {
                sum = sum + t;
                n = n + 2;
                t = -t * x * x / (n * (n - 1));
            }
            return sum;
        }

        public static double Log(double osn, double x) // Функция для подсчета логарифма (osn - основание; x - число)
        {
            double s = 0.000001;
            while (Math.Pow(osn, s) < x)
            {
                s += 0.000001;
            }
            return s;
        }
    }
}
