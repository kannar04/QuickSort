using System.Text;

class Program
{
    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static int partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
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

    static void quickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = partition(arr, low, high);
            quickSort(arr, low, pi - 1);
            quickSort(arr, pi + 1, high);
        }
    }

    static int[] GenerateValue(int size)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(0, 100000);
        }
        return arr;
    }

    static void Main(string[] args)
    {
        int size = 100000;
        int times = 1000000;
        Timing timer = new Timing();

        int[] arrBase = GenerateValue(size);

        int[] arrBest = new int[size];
        int[] arrAvg = new int[size];
        int[] arrWorst = new int[size];
        Array.Copy(arrBase, arrAvg, size);   // average
        Array.Copy(arrBase, arrBest, size);  // best
        Array.Copy(arrBase, arrWorst, size); // worst

        // Best Case: sắp xếp tăng dần (pivot chia đều)
        Array.Sort(arrBest);

        // Worst Case: sắp xếp giảm dần (pivot cuối cùng cực lệch)
        Array.Sort(arrWorst);
        Array.Reverse(arrWorst);

        // Đo thời gian 
        timer.startTime();
        for (int i = 0; i < times; i++)
            quickSort(arrBest, 0, size - 1);
        timer.stopTime();
        double bestTime = timer.Result().TotalMilliseconds / times;

        timer.startTime();
        for (int i = 0; i < times; i++)
            quickSort(arrAvg, 0, size - 1);
        timer.stopTime();
        double avgTime = timer.Result().TotalMilliseconds / times;

        timer.startTime();
        for (int i = 0; i < times; i++)
            quickSort(arrWorst, 0, size - 1);
        timer.stopTime();
        double worstTime = timer.Result().TotalMilliseconds / times;

        // In kết quả
        Console.WriteLine("==== Kết quả thời gian (QuickSort) ====");
        Console.WriteLine($"Số phần tử: {size:N0}");
        Console.WriteLine($"Tốt nhất   : {bestTime:F2} ms");
        Console.WriteLine($"Trung bình : {avgTime:F2} ms");
        Console.WriteLine($"Xấu nhất   : {worstTime:F2} ms");
    }
}
