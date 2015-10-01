using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ComplexNumbers;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var c1 = new Complex(1,1);
            // Вызов ToString() для числа 1+1i
            Console.WriteLine("Создали новый экземпляр комплексного числа: c1 = {0}\n", c1);
            // Отображение вещественной и мнимой частей
            Console.WriteLine("Отображение свойств: с1.Re = {0}, c1.Im = {1}",c1.Re, c1.Im);
            Console.WriteLine("Вычислимые свойства: с1.R = {0}, c1.Phi = {1}\n",c1.R, c1.Phi);

            c1.Re = 1;
            c1.Im = -5;
            var c2 = Complex.CreateByPolar(Math.Sqrt(2), Math.PI/4);
            Console.WriteLine("Создали новый экземпляр комплексного числа c2, используя полярные координаты:");
            Console.WriteLine("c2( sqrt(2), PI/4 ) = {0}\n",c2);

            var c3 = new Complex(im:-10);
            Console.WriteLine("Создали новый экземпляр комплексного числа c3 = {0}\n",c3);

            Console.WriteLine("Арифметические операции:");
            var c4 = new Complex(2,0);
            var c5 = new Complex(2.0);
            var c6 = new Complex(3, 7);
            var c7 = new Complex(6, -9.5);
            var c8 = new Complex(im: 4);

            Console.WriteLine("({0}) * ({1}) = {2}", c4, c5, c4 * c5 );
            Console.WriteLine("({0}) * ({1}) = {2}", c6, c7, c6 * c7);
            Console.WriteLine("({0}) * ({1}) = {2}\n", c3, c8, c3 * c8);

            Console.WriteLine("({0}) + ({1}) = {2}", c4, c5, c4 + c5);
            Console.WriteLine("({0}) + ({1}) = {2}", c6, c7, c6 + c7);
            Console.WriteLine("({0}) + ({1}) = {2}\n", c3, c8, c3 + c8);

            Console.WriteLine("({0}) - ({1}) = {2}", c4, c5, c4 - c5);
            Console.WriteLine("({0}) - ({1}) = {2}", c6, c7, c6 - c7);
            Console.WriteLine("({0}) - ({1}) = {2}\n", c3, c8, c3 - c8);

            Console.WriteLine("({0}) / ({1}) = {2}", c4, c5, c4 / c5);
            Console.WriteLine("({0}) / ({1}) = {2}", c6, c7, c6 / c7);
            Console.WriteLine("({0}) / ({1}) = {2}\n", c3, c8, c3 / c8);

            Console.WriteLine("Операции сравнения:");
            var c9 = new Complex(2.8,3);
            var c10 = new Complex(2.8,3);
            var c11 = new Complex(4,1);

            Console.WriteLine("({0}) == ({1}) => {2}", c9, c10, c9 == c10 );
            Console.WriteLine("({0}) == ({1}) => {2}\n", c9, c11, c9 == c11);

            Console.WriteLine("({0}) != ({1}) => {2}", c9, c10, c9 != c10);
            Console.WriteLine("({0}) != ({1}) => {2}\n", c9, c11, c9 != c11);

            Console.WriteLine("Явное преобразование в вещественное число:");
            Console.WriteLine("{0} => {1}\n", c9, (double) c9);

            Console.WriteLine("Неявное преобразование из вещественного числа");
            Console.WriteLine("({0}) + {1} = {2}", c11,2,c11 + 2);

            Console.ReadKey();
        }
    }
}
