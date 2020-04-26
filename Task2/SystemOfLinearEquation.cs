using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class SystemOfLinearEquation
    {
        private List<LinearEquation> system = new List<LinearEquation>(); // Хранение каждого из уравнений в списке
        private int n; // Размерность системы

        public SystemOfLinearEquation(int n)
        {
            this.n = n; // Размерность системы
        }
        public LinearEquation this[int index] // Обращение по индексу к уравнениям системы
        {
            get
            {
                if (index >= 0 && index < Size)
                    return system[index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Size)
                    system[index] = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public int Size => system.Count; // Возвращает кол-во элементов в списке
        public void Add(LinearEquation a) // Добавляем уравнение в систему
        {
            if (a.Size == n + 1)
                system.Add(a); 
            else throw new ArgumentException();
        }

        public void Delete(int index)
        {
            system.RemoveAt(index); // Удаляем уравнение из системы с указанным индексом
        }
        public void SteppingUp() // Приведение к ступенчатому виду
        {
            int c, z;
            double p1, p2;
            for (int i = 0; i < Size; i++)
            {
                z = i;
                if (this[i][z] == 0)
                {
                    while (this[i][z] == 0 && z < n) z++;
                    c = 1;
                    while ((i + c) < Size && this[i + c][z] == 0) c++;
                    if ((i + c) == Size) return;
                    Swap(this[i], this[i + c]);
                }
                for (int j = i + 1; j < Size; j++)
                {
                    p1 = this[i][z];
                    p2 = this[j][z];
                    this[j] = this[j] * p1 - this[i] * p2;
                }
            }
        }

        public double[] SolveSystem() // Решение системы
        {
            while (this[Size - 1].IsNull()) 
                this.Delete(Size - 1); // Удаление нулевых строк из списка
            if (this[Size - 1])
            {
                if (Size == n)
                {
                    double[] solve = new double[n];
                    for (int i = Size - 1; i >= 0; i--)
                    {
                        solve[i] = this[i][n]; // Решение - последний член системы
                        for (int j = i + 1; j < n; j++)
                        {
                            solve[i] -= this[i][j] * solve[j];
                        }
                        solve[i] /= this[i][i];
                    }
                    return solve;
                }
                else throw new ArgumentException("Система имеет бесконечно много решений");
            }
            else throw new ArgumentException("Система не имеет решений");
        }
        private void Swap(LinearEquation a, LinearEquation b)
        {
            LinearEquation tmp = new LinearEquation(a);
            b.CopyTo(a); // Копирование самих значений экземпляра, без copyto присваивался бы указатель
            tmp.CopyTo(b);
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Size; i++)
                res += this[i].ToString() + '\n';
            return res;
        }
    }
}
