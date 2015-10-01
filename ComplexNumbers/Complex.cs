using System;
using System.Diagnostics.CodeAnalysis;

namespace ComplexNumbers
{
    public class Complex
    {

        #region Конструкторы

        public Complex(double re = 0, double im = 0)
        {
            this.Re = re;
            this.Im = im;
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Вещественная часть числа
        /// </summary>
        public double Re { get; set; }

        /// <summary>
        /// Мнимая часть числа
        /// </summary>
        public double Im { get; set; }

        /// <summary>
        /// Модуль комплексного числа в полярных координатах
        /// </summary>
        public double R
        {
            get { return Math.Sqrt(Re*Re + Im*Im); }

            set
            {
                var phi = Phi;
                Re = PolarToRectangularMagnitude(value, phi);
                Im = PolarToRectangularAngle(value, phi);
            }
        }
        
        /// <summary>
        /// Аргумент комплексного числа в полярных координатах
        /// </summary>
        public double Phi
        {
            get
            {
                return Re == 0
                    ? Math.PI /2 * Math.Sign(Im)
                    : Math.Atan(Im/Re) + Math.PI*Math.Sign(Re);
            }
            set
            {
                var magnitude = R;
                Re = PolarToRectangularMagnitude(magnitude, value);
                Im = PolarToRectangularAngle(magnitude, value);
            }
        }

        #endregion

        #region Переопределение операций

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im*b.Im, a.Im *b.Re + a.Re*b.Im);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            double denominator = b.Re*b.Re + b.Im*b.Im;
            return new Complex( (a.Re*b.Re + a.Im*b.Im)/ denominator, (a.Im*b.Re - a.Re * b.Im)/ denominator );
        }
        #endregion

        #region Переопределение операций сравнения

        public static bool operator ==(Complex a, Complex b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }
            else
            {
                return a.Equals(b);
            }
        }

        public static bool operator !=(Complex a, Complex b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return Re.GetHashCode() ^ Im.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var complex = obj as Complex;
            if ((object) complex == null)
            {
                return false;
            }
            return (Re == complex.Re) && (Im == complex.Im);
        }

        #endregion

        #region Операторы приведения типов

        /// <summary>
        /// Явное преобразование в вещественное число
        /// </summary>
        /// <param name="a"></param>
        public static explicit operator double(Complex a)
        {
            return a.Re;
        }

        /// <summary>
        /// Неявное преобразование числа double в Complex
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Комплексное число с мнимой частью равной нулю</returns>
        public static implicit operator Complex(double a)
        {
            return new Complex(a);
        }

        #endregion

        #region Методы 
        /// <summary>
        /// Вычисляет вещественную часть комплексного числа заданного в полярных координатах
        /// </summary>
        /// <param name="r">Модуль</param> 
        /// <param name="phi">Угол</param>
        /// <returns>Вещественная часть комплексного числа</returns>
        private static double PolarToRectangularMagnitude(double r, double phi)
        {
            return r*Math.Cos(phi);
        }

        /// <summary>
        /// Вычисляет мнимую часть комплекного числа заданного в полярных координатах
        /// </summary>
        /// <param name="r">Модуль</param>
        /// <param name="phi">Угол</param>
        /// <returns>Мнимая часть комплексного числа</returns>
        private static double PolarToRectangularAngle(double r, double phi)
        {
            return r*Math.Sin(phi);
        }

        public static Complex CreateByPolar(double r=0, double phi = 0)
        {
            return new Complex( PolarToRectangularMagnitude(r, phi), PolarToRectangularAngle(r, phi) );
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", 
                Re == 0 ? "" : Re.ToString("g4"),
                Re != 0 && Im > 0 ? "+" : "",
                Im != 0 ? Im.ToString("g4") + "i" : "" );
        }
        #endregion
    }
}
