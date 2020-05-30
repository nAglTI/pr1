using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_30_05_20_SEM
{
    class Program
    {
        static void Main(string[] args)
        {
            var llist = new LinkedList<int>();

            llist.AddLast(1488);
            llist.AddLast(228);
            llist.AddLast(3);
            llist.AddLast(666);

            Console.WriteLine(llist.IndexOf(228));
            Console.WriteLine(llist.IndexOf(1488));
            Console.WriteLine(llist.IndexOf(2));
            Console.WriteLine(llist.IndexOf(-1));

            int[] arr = new int[100];
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                arr[i] = rnd.Next(0, 101);
            }

            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

            InsertBinarySearch(13);

            void InsertBinarySearch(int val)
            {
                Array.Resize(ref arr, arr.Length + 1);
                int index = BinarySearch(arr, val, 0, arr.Length - 1);
                for (int i = arr.Length - 2; i > index; i--)
                    arr[i] = arr[i + 1];

                arr[index] = val;
            }

        }

        public static int BinarySearch(int[] array, int val, int left, int right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] < val && array[mid] >= val)
                return mid + 1;

            else if (array[mid] > val)
                return BinarySearch(array, val, left, mid);
            else
                return BinarySearch(array, val, mid + 1, right);
        }
    }



    public static class IndexOfnerGGWP
    {
        public static int IndexOf<T>(this LinkedList<T> FList, T val)
        {
            int index = 0;

            foreach (T value in FList)
            {
                if (value.Equals(val))
                {
                    return index;
                }

                index++;
            }
            return -1;
        }
    }
}
