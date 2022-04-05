using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using static AbacusNet.Basics;


namespace AbacusNet
{
    public static class DescriptiveStatistics
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Mean(double[] items)
        {
            return Sum(items) / items.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Median(double[] items)
        {
            var arr = items;
            Array.Sort(arr);

            double median;
            var middle = arr.Length / 2;

            if (arr.Length % 2 == 0)
            {
                median = (arr[middle - 1] + arr[middle]) / 2.0d;
            }
            else
            {
                median = arr[middle];
            }

            return median;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Variance(double[] items)
        {
            var mean = Mean(items);
            var vectorMean = new Vector<double>(mean);

            int vectorSize = Vector<double>.Count;
            var accVector = Vector<double>.Zero;
            int i;
            double[] array = items;

            for (i = 0; i <= array.Length - vectorSize; i += vectorSize)
            {
                var v = new Vector<double>(array, i);
                var v2 = v - vectorMean;
                var v3 = v2 * v2;

                accVector = Vector.Add(accVector, v3);
            }

            double result = Vector.Dot(accVector, Vector<double>.One);

            for (int length = items.Length; i < length; i++)
            {
                var sub = items[i] - mean;
                result += sub * sub;
            }

            return result / items.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double StandardDeviation(double[] values)
        {
            return Math.Sqrt(Variance(values));
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Covariance(double[] values1, double[] values2)
        {
            double mean_values1 = Mean(values1);
            var vectorMean1 = new Vector<double>(mean_values1);
            double mean_values2 = Mean(values2);
            var vectorMean2 = new Vector<double>(mean_values2);

            int vectorSize = Vector<double>.Count;
            var accVector = Vector<double>.Zero;
            int i;
            double[] array1 = values1;
            double[] array2 = values2;

            for (i = 0; i <= array1.Length - vectorSize; i += vectorSize)
            {
                var v1 = new Vector<double>(array1, i) - vectorMean1;
                var v2 = new Vector<double>(array2, i) - vectorMean2;
                var v3 = v1 * v2;

                accVector = Vector.Add(accVector, v3);
            }

            double result = Vector.Dot(accVector, Vector<double>.One);

            for (int length = values1.Length; i < length; i++)
            {
                result += (values1[i] - mean_values1) * (values2[i] - mean_values2);
            }

            return result / (values1.Length - 1);
        }
    }
}

