using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    //Structure for complex numbers
    struct SComplex
    {
        public double re;
        public double im;

        public SComplex Plus(SComplex x)
        {
            SComplex y;
            y.re = this.re + x.re;
            y.im = this.im + x.im;
            return y;
        }

        public SComplex Minus(SComplex x)
        {
            SComplex y;
            y.re = this.re - x.re;
            y.im = this.im - x.im;
            return y;
        }

        /* Probably wrong
        public SComplex Multi(SComplex x)
        {
            SComplex y;
            y.im = this.im * x.im + this.re * x.im;
            y.re = this.re * x.im - this.im * x.re;
            return y;
        }
        */

        public SComplex Multi(SComplex x)
        {
            SComplex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }

        public string ToString()
        {
            if (re != 0)
            {
                if (im > 0) { return re + "+" + im + "i"; }     //Common output, re + im * i
                else { return re + "" + im + "i"; }             //im < 0, re - im * i
            } else { return im + "i"; }                         //re = 0, im * i
        }


    }

    //Class for complex numbers
    class CComplex
    {
        double im;
        double re;

        // Констуктор без параметров.
        public CComplex()
        {
            im = 0;
            re = 0;
        }

        public CComplex(double im, double re)
        {
            this.im = im;
            this.re = re;
        }
        public CComplex Plus(CComplex x2)
        {
            CComplex x3 = new CComplex();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }

        public CComplex Minus(CComplex x2)
        {
            CComplex x3 = new CComplex();
            x3.im = im - x2.im;
            x3.re = re - x2.re;
            return x3;
        }

        public CComplex Multi(CComplex x2)
        {
            CComplex x3 = new CComplex();
            x3.im = re * x2.im + im * x2.re;
            x3.re = re * x2.re - im * x2.im;
            return x3;
        }

        // Свойства - это механизм доступа к данным класса.
        public double Im
        {
            get { return im; }
            set
            {
                // Для примера ограничимся только положительными числами.
                if (value >= 0) im = value;
            }
        }
        // Специальный метод, который возвращает строковое представление данных
        public string ToString()
        {
            if (re != 0)
            {
                if (im > 0)     { return re + "+" + im + "i"; } //Common output, re + im * i
                else            { return re + "" + im + "i"; }  //im < 0, re - im * i
            } else              { return im + "i"; }            //re = 0, im * i
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            //Structure usage
            SComplex complex1_1;
            complex1_1.re = 1;
            complex1_1.im = 1;
            SComplex complex1_2;
            complex1_2.re = 2;
            complex1_2.im = 2;

            Console.WriteLine("Вызов методов структуры:");
            Console.WriteLine("Суммой {0} и {1} будет {2}\n",
                complex1_1.ToString(),
                complex1_2.ToString(),
                (complex1_1.Plus(complex1_2)).ToString());

            Console.WriteLine("Разностью {0} и {1} будет {2}\n",
                complex1_1.ToString(),
                complex1_2.ToString(),
                (complex1_1.Minus(complex1_2)).ToString());

            Console.WriteLine("Произведением {0} и {1} будет {2}\n",
                complex1_1.ToString(),
                complex1_2.ToString(),
                (complex1_1.Multi(complex1_2)).ToString());

            //Class usage
            CComplex complex2_1 = new CComplex(1, 1);
            CComplex complex2_2 = new CComplex(2, 2);

            Console.WriteLine("Вызов методов класса:");
            Console.WriteLine("Суммой {0} и {1} будет {2}\n",
                complex2_1.ToString(),
                complex2_2.ToString(),
                (complex2_1.Plus(complex2_2)).ToString());

            Console.WriteLine("Разностью {0} и {1} будет {2}\n",
                complex2_1.ToString(),
                complex2_2.ToString(),
                (complex2_1.Minus(complex2_2)).ToString());

            Console.WriteLine("Произведением {0} и {1} будет {2}\n",
                complex2_1.ToString(),
                complex2_2.ToString(),
                (complex2_1.Multi(complex2_2)).ToString());

            //Pause
            Console.ReadKey();
        }
    }



}
