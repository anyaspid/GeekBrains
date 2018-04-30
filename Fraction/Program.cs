using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
    class Fraction
    {
        int iNumerator;
        int iDenominator;

        //Constructor 1 from 2
        public Fraction()
        {
            iNumerator = 0;
            iDenominator = 1;
        }

        //Constructor 2 from 2
        public Fraction(int iNumerator, int iDenominator)
        {
            this.iNumerator = iNumerator;
            this.iDenominator = iDenominator != 0 ? iDenominator : 1;
        }

        //Plus method with optional reduction
        public Fraction Plus(Fraction fract1, bool bReduce)
        {
            Fraction fTemp = new Fraction();
            fTemp.iNumerator = fract1.iNumerator * this.iDenominator + this.iNumerator * fract1.iDenominator;
            fTemp.iDenominator = fract1.iDenominator * this.iDenominator;
            if (bReduce) { fTemp.Reduction(); }
            return fTemp;
        }

        //Minus method with optional reduction
        public Fraction Minus(Fraction fract1, bool bReduce)
        {
            Fraction fTemp = new Fraction();
            fTemp.iNumerator = this.iNumerator * fract1.iDenominator - fract1.iNumerator * this.iDenominator;
            fTemp.iDenominator = this.iDenominator * fract1.iDenominator;
            if (bReduce) { fTemp.Reduction(); }
            return fTemp;
        }

        //Multiplie method with optional reduction
        public Fraction Multi(Fraction fract1, bool bReduce)
        {
            Fraction fTemp = new Fraction();
            fTemp.iNumerator = this.iNumerator * fract1.iNumerator;
            fTemp.iDenominator = this.iDenominator * fract1.iDenominator;
            if (bReduce) { fTemp.Reduction(); }
            return fTemp;
        }

        //Dividing method with optional reduction
        public Fraction Divide(Fraction fract1, bool bReduce)
        {
            Fraction fTemp = new Fraction();
            fTemp.iNumerator = this.iNumerator * fract1.iDenominator;
            fTemp.iDenominator = this.iDenominator * fract1.iNumerator;
            if (bReduce) { fTemp.Reduction(); }
            return fTemp;
        }

        //Reduction method, I`m an Captain Obvious
        public void Reduction()
        {
            int iReductionMax;
            iReductionMax = iNumerator < iDenominator ? iNumerator : iDenominator;

            for (; iReductionMax > 0; iReductionMax--)
            {
                if (iNumerator % iReductionMax == 0 && iDenominator % iReductionMax == 0)
                {
                    iNumerator /= iReductionMax;
                    iDenominator /= iReductionMax;
                }
            }
        }

        public int Numerator
        {
            get { return this.iNumerator; }
            set { this.iNumerator = value; }
        }

        public int Denominator
        {
            get { return this.iDenominator; }
            set { this.iDenominator = value != 0 ? value : 1; }
        }


        public double GetDoubleValue()
        {
            return ((double)iNumerator / iDenominator);
        }

        public string GetStringValue()
        {
            return iNumerator == 0 ? "0" : (iNumerator.ToString() + "/" + iDenominator.ToString());
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fract1 = new Fraction(200, 600);
            Fraction fract2 = new Fraction()
            {
                Numerator = 3,
                Denominator = 9
            };
            

            Console.WriteLine("Даны два дробных числа, {0} и {1}", fract1.GetStringValue(), fract2.GetStringValue());

            Console.WriteLine("При их сложении получим дробное число {0}, которое сокращается до {1} \nи записывается в десятичном формате с точностью до 3-го знака как {2:F3}.\n", 
                (fract1.Plus(fract2, false)).GetStringValue(),
                (fract1.Plus(fract2, true)).GetStringValue(),
                (fract1.Plus(fract2, false)).GetDoubleValue());

            Console.WriteLine("Вычислив разность получим дробное число {0}, которое сокращается до {1} \nи записывается в десятичном формате с точностью до 3-го знака как {2:F3}.\n",
                (fract1.Minus(fract2, false)).GetStringValue(),
                (fract1.Minus(fract2, true)).GetStringValue(),
                (fract1.Minus(fract2, false)).GetDoubleValue());

            Console.WriteLine("Произведением данных дробей будет дробное число {0}, которое сокращается до {1} \nи записывается в десятичном формате с точностью до 3-го знака как {2:F3}.\n",
                (fract1.Multi(fract2, false)).GetStringValue(),
                (fract1.Multi(fract2, true)).GetStringValue(),
                (fract1.Multi(fract2, false)).GetDoubleValue());

            Console.WriteLine("Частным же будет дробное число {0}, которое сокращается до {1} \nи записывается в десятичном формате с точностью до 3-го знака как {2:F3}.\n",
                (fract1.Divide(fract2, false)).GetStringValue(),
                (fract1.Divide(fract2, true)).GetStringValue(),
                (fract1.Divide(fract2, false)).GetDoubleValue());

            //Pause
            Console.ReadKey();

        }
    }
}
