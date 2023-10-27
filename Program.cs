using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICalc_with_My_Array
{
    interface ICalc
    {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);
    }

    class MyArray2D : ICalc
    {
        private int[,] array;

        public int Rows { get; }
        public int Columns { get; }

        public MyArray2D(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            array = new int[Rows, Columns];
        }

        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < Rows && j >= 0 && j < Columns)
                {
                    return array[i, j];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (i >= 0 && i < Rows && j >= 0 && j < Columns)
                {
                    array[i, j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void FillRandom()
        {
            Random random = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    array[i, j] = random.Next(1, 101);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void SetElement(int i, int j, int value)
        {
            this[i, j] = value;
        }

        public int Less(int valueToCompare)
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] < valueToCompare)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int Greater(int valueToCompare)
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] > valueToCompare)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int columns = int.Parse(Console.ReadLine());

            MyArray2D my_Massive = new MyArray2D(rows, columns);
            my_Massive.FillRandom();
            my_Massive.Print();

            Console.WriteLine("\nВведите координаты элемента и его новое значение:");
            Console.Write("i: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("j: ");
            int j = int.Parse(Console.ReadLine());
            Console.Write("Значение: ");
            int value = int.Parse(Console.ReadLine());

            my_Massive.SetElement(i, j, value);

            Console.WriteLine("\nМассив после изменения:");
            my_Massive.Print();

            Console.Write("Введите значение для сравнения: ");
            int valueToCompare = int.Parse(Console.ReadLine());

            int lessCount = my_Massive.Less(valueToCompare);
            int greaterCount = my_Massive.Greater(valueToCompare);

            Console.WriteLine($"Количество элементов меньше {valueToCompare}: {lessCount}");
            Console.WriteLine($"Количество элементов больше {valueToCompare}: {greaterCount}");

            Console.ReadKey();
        }
    }
}




