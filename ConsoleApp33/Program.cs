using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть номер студента:");
        int studnum = Convert.ToInt32(Console.ReadLine());
        int sizearray = (int)(20 + 0.6 * studnum);
        int[] nums = GenerateRandomArray(sizearray);
        Console.WriteLine("Невідсортований масив:");
        PrintArray(nums);
        SortArray(nums);
        Console.WriteLine("Відсортований масив:");
        PrintArray(nums);
        Console.WriteLine("Число для пошуку у масиві:");
        int search = Convert.ToInt32(Console.ReadLine());
        int result = BinarySearch(nums, search);
        Console.WriteLine($"{search} повторюється {result} разів у масиві");
    }

    static int[] GenerateRandomArray(int size)
    {
        int[] nums = new int[size];
        Random random = new Random();
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = random.Next(10, 100);
        }
        return nums;
    }

    static void SortArray(int[] nums)
    {
        if (nums.Length < 2)
        {
            return;
        }
        int mid = nums.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[nums.Length - mid];
        Array.Copy(nums, 0, left, 0, mid);
        Array.Copy(nums, mid, right, 0, nums.Length - mid);
        SortArray(left);
        SortArray(right);
        Sort(nums, left, right);
    }

    static void Sort(int[] nums, int[] left, int[] right)
    {
        int i = 0; 
        int j = 0; 
        int k = 0; 

        while (i < left.Length && j < right.Length)
        {
            if (left[i] <= right[j])
            {
                nums[k] = left[i];
                i++;
            }
            else
            {
                nums[k] = right[j];
                j++;
            }
            k++;
        }

        while (i < left.Length)
        {
            nums[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length)
        {
            nums[k] = right[j];
            j++;
            k++;
        }
    }

    static int BinarySearch(int[] nums, int numb)
    {
        int count = 0;
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int midValue = nums[mid];

            if (midValue == numb)
            {
                count++;
            }

            if (midValue > numb)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return count;
    }

    static void PrintArray(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            Console.Write($" {nums[i]} ");
        }
        Console.WriteLine();
    }
}