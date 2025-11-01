using System.Text;

internal class Program
{
    static int Partition(Array arr, int low, int high)
    {
        int pivot = (int)arr.GetValue(high);
        int i = low - 1;

        for (int j = low; j <= high - 1; j++)
        {
            if ((int)arr.GetValue(j) < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, high);
        return i + 1;
    }

    static void Swap(Array arr, int i, int j)
    {
        int temp = (int)arr.GetValue(i);
        arr.SetValue(arr.GetValue(j), i);
        arr.SetValue(temp, j);
    }

    static void QuickSort(Array arr, int low, int high)
    {
        if (low < high)
        {
            int pivot = Partition(arr, low, high);
            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }
    }
    private static void Main(string[] args)
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        

        int n = 1000000; 
        Array ar = Array.CreateInstance(typeof(int), n);
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
            ar.SetValue(rnd.Next(1, 1000), i);

        /*Console.WriteLine("Trước khi sắp xếp:");
        for (int i = 0; i < n; i++)
            Console.Write($"{ar.GetValue(i)} ");
        Console.WriteLine();*/


        Timing t = new Timing();
        t.startTime();
        QuickSort(ar, 0, n - 1);
        t.StopTime();
        Console.WriteLine($"Thời gian để sắp xếp: {t.Result().TotalMilliseconds:F4} ms");

        /*Console.WriteLine("\nSau khi sắp xếp:");
        for (int i = 0; i < n; i++)
            Console.Write($"{ar.GetValue(i)} ");
        Console.WriteLine();*/
    }

}
