using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
    public static class ArrayExtensions
    {
        public static void FillArrayByRow(this int[,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            for (var j = 0; j < arr.GetLength(1); j++)
                arr[i, j] = i + j;
        }

        public static void FillArrayByColumn(this int[,] arr)
        {
            for (var i = 0; i < arr.GetLength(0); i++)
            for (var j = 0; j < arr.GetLength(1); j++)
                arr[j, i] = i + j;
        }

        public static void Variant1(this double[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                arr[i] = i;

            double sum = 0;
            
            for (var i = 0; i < arr.Length; i++)
                sum += arr[i];
        }

        public static void Variant2(this LinkedList<double> list, int size)
        {
            for (var i = 0; i < size; i++)
                list.AddLast(Convert.ToDouble(i));

            double sum = 0;
            for (var i = 0; i < size; i++)
                sum += list.ElementAt(i);
        }

        public static void Variant3(this ArrayList list)
        {
            for (var i = 0; i < list.Capacity; i++)
                list.Add((double) i);
            
            double sum = 0;
            for (var i = 0; i < list.Capacity; i++)
                sum += (double) list[i];
        }
        
        public static void Variant1(this HashSet<int> hashSet)
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (!hashSet.Contains(i)) 
                    hashSet.Add(i);
            }
        }
        
        public static void Variant2(this HashSet<int> hashSet)
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (!hashSet.Contains(0))
                    hashSet.Add(0);
            }
        }
    }
}