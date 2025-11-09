using System.Text;

class Program
{
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
    static void swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
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
        Console.OutputEncoding = Encoding.UTF8;
        int size = 10000;
        int times = 1000;
        Timing t = new Timing();

        //1. Trường hợp tốt nhất (mảng ngẫu nhiên) 
        int[] best = GenerateValue(size);
        t.startTime();
        for (int i = 0; i < times; i++)
        {
            int[] copy = (int[])best.Clone();
            quickSort(copy, 0, copy.Length - 1);
        }
        t.stopTime();
        Console.WriteLine($"Thời gian trung bình (trường hợp tốt nhất): {t.Result().TotalMilliseconds / times} ms");

        //2. Trường hợp trung bình (mảng gần ngẫu nhiên)
        int[] avg = GenerateValue(size);
        Array.Sort(avg); // sắp xếp rồi đảo một phần => "gần như ngẫu nhiên"
        for (int i = 0; i < size / 10; i++)
        {
            int a = i;
            int b = size - i - 1;
            int temp = avg[a];
            avg[a] = avg[b];
            avg[b] = temp;
        }
        t.startTime();
        for (int i = 0; i < times; i++)
        {
            int[] copy = (int[])avg.Clone();
            quickSort(copy, 0, copy.Length - 1);
        }
        t.stopTime();
        Console.WriteLine($"Thời gian trung bình (trường hợp trung bình): {t.Result().TotalMilliseconds / times} ms");

        //3. Trường hợp xấu nhất (mảng tăng dần)
        int[] worst = new int[size];
        for (int i = 0; i < size; i++) worst[i] = i;
        t.startTime();
        for (int i = 0; i < times; i++)
        {
            int[] copy = (int[])worst.Clone();
            quickSort(copy, 0, copy.Length - 1);
        }
        t.stopTime();
        Console.WriteLine($"Thời gian trung bình (trường hợp xấu nhất): {t.Result().TotalMilliseconds / times} ms");
    }
}

