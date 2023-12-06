using System;
using System.Collections.Generic;

namespace laba1f
{
    public class FirstPart
    {
        private readonly int[] array;
        
        public FirstPart(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            var random = new Random();

            array = new int[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10, 10);
            }
        }
        public IReadOnlyList<int> Vector
        {
            get
            {
                return array;
            }
        }
        public int GetCountNegative()
        {
            int count = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    count++;
                }
            }
            return count;
        }
        public int SumAfterMinModule()
        {
            int minIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (Math.Abs(array[i]) < Math.Abs(array[minIndex]))
                {
                    minIndex = i;
                }
            }
            int sum = 0;
            
            for (int i = minIndex + 1; i < array.Length; i++)
            {
                sum += Math.Abs(array[i]);
            }
            return sum;
        }
        public void ReplacementNegativeElements()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    // замена отрицательного элемента его квадратом
                    array[i] = (int)Math.Pow(array[i], 2); 
                }
            } 
        }
        public void SortByAscending()
        {
            Array.Sort(array);
        }   
    }
}
