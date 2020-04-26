using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class Indexer
    {
        double[] arr;
        int start_ind;
        int subarray_length;
        public Indexer(double[] array,  int start_ind, int subarray_length)
        {
            if (SubArrayCheck(array.Length, start_ind, subarray_length)) // Если подмассив с указанными значениями существует
            {
                this.arr = array;
                this.subarray_length = array.Length;
                this.start_ind = start_ind;
            }
            else throw new ArgumentException();
        }
        public double this[int index] // Обращение по индексу
        {
            get
            {
                if (CheckIndex(index))
                    return arr[index + start_ind];
                else throw new IndexOutOfRangeException("Not supported operation");
            }
            set
            {
                if (CheckIndex(index))
                    arr[index + start_ind] = value;
                else throw new IndexOutOfRangeException("Not supported operation");
            }
        }

        private bool SubArrayCheck(int array_length, int start_ind, int subarray_length) // Проверка на возможность существования указанного подмассива.
        {
            if (subarray_length <= 0 || start_ind < 0 || start_ind + subarray_length > array_length) return false;
            else return true;
        }
        private bool CheckIndex(int index) // Проверка за выходом за границы подмассива
        {
            if (index < 0 || index + start_ind > subarray_length) return false;
            else return true;
        }
        public int get_sub_length => subarray_length;
    }
}
