using System;
using System.Collections.Generic;

namespace laba1f
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Часть 1:");
            Console.Write("Введите размер массива: ");

            int size = int.Parse(Console.ReadLine());

            var firstPart = new FirstPart(size);
            
            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Количество отрицательных элементов: "  + firstPart.GetCountNegative());
            Console.WriteLine("Сумма модулей элементов после минимального по модулю элемента: " + firstPart.SumAfterMinModule());

            firstPart.ReplacementNegativeElements();
            firstPart.SortByAscending();
            Console.WriteLine("После сортировки по возрастанию:");
            PrintVector(firstPart.Vector);

            Console.WriteLine("Часть 2:");
            
            Console.Write("Введите размер массива: ");
            Console.WriteLine();
            Console.Write("Количество строк: ");
            
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов: ");
            
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];

            Random random = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(-10, 10); 
                }
            }

            Console.WriteLine("Исходная матрица:");
            PrintMatrix(matrix);

            OrderMatrixRows(matrix);

            Console.WriteLine("Матрица после упорядочивания строк:");
            PrintMatrix(matrix);
            int column = FindFirstColumnWithoutNegatives(matrix);
            Console.WriteLine("Номер первого столбца без отрицательных элементов: {0}", column);
            Console.ReadLine();
        }
        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void OrderMatrixRows(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows - 1; j++)
                {
                    int countJ = CountSameElements(matrix, j);
                    int countJplus1 = CountSameElements(matrix, j + 1);
                    if (countJ > countJplus1)
                    {
                        SwapRows(matrix, j, j + 1);
                    }
                }
            }
        }
        static int CountSameElements(int[,] matrix, int row)
        {
            int cols = matrix.GetLength(1);
            int count = 0;

            for (int i = 0; i < cols; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    if (matrix[row, i] == matrix[row, j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        static void SwapRows(int[,] matrix, int row1, int row2)
        {
            int cols = matrix.GetLength(1);
            for (int i = 0; i < cols; i++)
            {
                int temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }
        static int FindFirstColumnWithoutNegatives(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int j = 0; j < cols; j++)
            {
                bool containsNegative = false;
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i, j] < 0)
                    {
                        containsNegative = true;
                        break;
                    }
                }
                if (!containsNegative)
                {
                    return j;
                }
            }
            return -1;
        }
        static void PrintVector(IEnumerable<int> vector)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
    }
}
