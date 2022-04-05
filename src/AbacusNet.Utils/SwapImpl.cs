using System.Numerics;

namespace AbacusNet.Utils;

public static class SwapImpl
{
    public static unsafe void Swap<T>(T* left, T* right) where T : unmanaged
    {
        var tmp = *left;

        *left = *right;
        *right = tmp;
    }

    public static void Swap<T>(Span<T> span, int left, int right)
    {
        var tmp = span[left];

        span[left] = span[right];
        span[right] = tmp;
    }

    public static unsafe void SwapIfGreater<T>(T* left, T* right) where T : unmanaged, IComparable<T>
    {
        if ((*left).CompareTo(*right) <= 0)
        {
            return;
        }

        Swap(left, right);
    }
}

