using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AbacusNet
{
    public static class Basics
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Sum(double[] items)
        {
            int vectorSize = Vector<double>.Count;
            var accVector = Vector<double>.Zero;
            int i;
            double[] array = items;

            for (i = 0; i <= array.Length - vectorSize; i += vectorSize)
            {
                var v = new Vector<double>(array, i);
                accVector = Vector.Add(accVector, v);
            }

            double result = Vector.Dot(accVector, Vector<double>.One);

            for (int length = array.Length; i < length; i++)
            {
                result += array[i];
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Min(double[] input)
        {
            double min;
            var simdLength = Vector<double>.Count;
            var vmin = new Vector<double>(double.MaxValue);
            var i = 0;

            for (i = 0; i <= input.Length - simdLength; i += simdLength)
            {
                var va = new Vector<double>(input, i);
                vmin = Vector.Min(va, vmin);
            }

            min = double.MaxValue;
            for (int j = 0, length = simdLength; j < length; ++j)
            {
                min = Math.Min(min, vmin[j]);
            }

            for (int length = input.Length; i < length; ++i)
            {
                min = Math.Min(min, input[i]);
            }

            return min;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static double Max(double[] input)
        {
            double max;
            var simdLength = Vector<double>.Count;
            var vmax = new Vector<double>(double.MinValue);
            var i = 0;

            for (i = 0; i <= input.Length - simdLength; i += simdLength)
            {
                var va = new Vector<double>(input, i);
                vmax = Vector.Max(va, vmax);
            }

            max = double.MinValue;
            for (int j = 0, length = simdLength; j < length; ++j)
            {
                max = Math.Max(max, vmax[j]);
            }

            for (int length = input.Length; i < length; ++i)
            {
                max = Math.Max(max, input[i]);
            }

            return max;
        }
    }
}

