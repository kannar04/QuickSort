using System;

class Program
{
    static int partition(int[] arr, int low, int high, string mode)
    {
        int pivotIndex;

        if (mode == "best")
            pivotIndex = (low + high) / 2;     // pivot giữa
        else if (mode == "average")
            pivotIndex = new Random().Next(low, high + 1); // pivot ngẫu nhiên
        else
            pivotIndex = high;                 // pivot cuối → worst case

        int pivot = arr[pivotIndex];
        swap(arr, pivotIndex, high); // đưa pivot về cuối
        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                swap(arr, i, j);
            }
        }

        swap(arr, i + 1, high);
        return i + 1;
    }

    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void quickSort(int[] arr, int low, int high, string mode)
    {
        if (low < high)
        {
            int pi = partition(arr, low, high, mode);
            quickSort(arr, low, pi - 1, mode);
            quickSort(arr, pi + 1, high, mode);
        }
    }

    static int[] GenerateValue(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
            arr[i] = rand.Next(0, 100000);
        return arr;
    }

    static void Main(string[] args)
    {
        Timing timer = new Timing();
        int size = 10000;
        int times = 1000;

        int[] data = GenerateValue(size);

        int[] best = (int[])data.Clone();
        Array.Sort(best); // sắp xếp tăng dần
        int[] clone = (int[])best.Clone();
        timer.startTime();
        for (int i = 0; i < times; i++)
            quickSort(clone, 0, size - 1, "best");
        timer.stopTime();
        Console.WriteLine($"Best case: {timer.Result().TotalMilliseconds / times:F4} ms");

        int[] avg = (int[])data.Clone();
        timer.startTime();
        for (int i = 0; i < times; i++)
            quickSort((int[])avg.Clone(), 0, size - 1, "average");
        timer.stopTime();
        Console.WriteLine($"Average case: {timer.Result().TotalMilliseconds / times:F4} ms");

        int[] worstDesc = (int[])data.Clone();
        Array.Sort(worstDesc);
        Array.Reverse(worstDesc); // sắp xếp giảm dần
        int[] clone2 = (int[])worstDesc.Clone();
        timer.startTime();
        for (int i = 0; i < times; i++)
            quickSort(clone2, 0, size - 1, "worst");
        timer.stopTime();
        Console.WriteLine($"Worst case (descending): {timer.Result().TotalMilliseconds / times:F4} ms");
    }
}
