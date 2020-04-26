using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    public class LinearEquation
    {
        private List<double> coefficients=new List<double>(); // Список коэффициентов

        public LinearEquation(double[] coeff) // Инициализация уравнения массивом коэфф.
        {
            coefficients = coeff.ToList();
        }

        public LinearEquation(List<double> coeff)  // Инициализация уравнения списком коэфф.
        {
            coefficients = coeff.ToList();
        }

        public LinearEquation(string _coeff) // Инициализация уравнения строкой с коэфф. 
        {
            string[] coeff = Regex.Split(_coeff, @"[^\d\.-]"); //regex
            for (int i = 0; i < coeff.Length; i++)
            {
                if (coeff[i] != "")
                {
                    coeff[i] = coeff[i].Replace('.', ','); 
                    coefficients.Add(double.Parse(coeff[i]));
                }
            }
        }
        public LinearEquation(IEnumerable<double> coeff) // Инициализация уравнения  перечислителем
        {
            coefficients = coeff.ToList();
        }

        public LinearEquation(int n)
        {
            if (n > 0)
            {
                coefficients = new List<double>();
                for (int i = 0; i <= n; i++)
                    coefficients.Add(0);
            }
            else throw new ArgumentException();
        }
        public int Size => coefficients.Count;  // Кол-во членов в уравнении

        public void RandomInitialization() // Инициализация уравнения случайными числами от 0 до 3
        {
            Random rand = new Random();
            for (int i = 0; i < Size; i++)
                coefficients[i] = rand.Next(3) / 10;
        }

        public void SameInitialization(double scalar) // Инициализация всех коэффициентов уравнения одним значением
        {
            for (int i = 0; i < Size; i++)
                coefficients[i] = scalar;
        }
        public double this[int index] // Обращение к переменным уравнения по индексу
        {
            get
            {
                if (index >= 0 && index < Size)
                    return coefficients[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Size)
                    coefficients[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }
        // Сложение и вычитание двух линейных уравнений
        public static LinearEquation operator +(LinearEquation a, LinearEquation b) 
        {
            var result = a.coefficients.Zip(b.coefficients, (first, second) => first + second);
            return new LinearEquation(result);
        }
        public static LinearEquation operator -(LinearEquation a, LinearEquation b)
        {
            var result = a.coefficients.Zip(b.coefficients, (first, second) => first - second);
            return new LinearEquation(result);
        }
        // Умножение на скаляр слева и справа
        public static LinearEquation operator *(LinearEquation a, double r)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++)
                result.Add(a[i] * r);
            return new LinearEquation(result);
        }
        public static LinearEquation operator *(double r, LinearEquation a)
        {
            return a * r;
        }
        // умножение на -1
        public static LinearEquation operator -(LinearEquation a)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Size; i++)
                result.Add(-a[i]);
            return new LinearEquation(result);
        }
        // Перегрузка операторов равенства
        public static bool operator ==(LinearEquation a, LinearEquation b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(LinearEquation a, LinearEquation b)
        {
            if (a == b) return false;
            else return true;
        }

        public static implicit operator double[](LinearEquation a) // Неявное преобразование к массиву
        {
            return a.coefficients.ToArray();
        }
        
        public static bool operator true(LinearEquation a) // Разрешимое уравнение
        {
            for (int i = 0; i < a.Size - 1; i++)
                if (a[i] != 0) return true;
            return (a[a.Size - 1] != 0) ? false : true;
        }
        public static bool operator false(LinearEquation a) // Противоречивое уравнение
        {
            if (a) return false;
            else return true;
        }
        public bool IsNull()
        {
            for (int i = 0; i < Size; i++)
                if (this[i] != 0) return false;
            return true;
        }
        public void CopyTo(LinearEquation b)
        {
            b.coefficients = coefficients.ToList();
        }
        public override bool Equals(object obj)
        {
            LinearEquation b = (LinearEquation)obj;
            for (int i = 0; i < Size; i++)
            {
                if (Math.Abs(this[i] - b[i]) > 1e-9) return false;
            }
            return true;
        }

        public override string ToString()
        {
            string res = "";
            int i;
            for (i = 0; i < Size - 2; i++)
            {
                res += (coefficients[i + 1] >= 0) ? (coefficients[i].ToString() + 'x' + (i + 1).ToString() + '+') : (coefficients[i].ToString() + 'x' + (i + 1).ToString());
            }
            res += (coefficients[i].ToString() + 'x' + (i + 1).ToString());
            res += '=' + coefficients[Size - 1].ToString();
            return res;
        }
    }
}
