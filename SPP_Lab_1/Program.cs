using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_Lab_1
{
    //compare methode
    public class myReverserClass : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }

    }
    class QuickSort
    {
        IComparer comparer = new myReverserClass();

        public void ToSort(int[] array,int left,int right)
        {
            int x = array[left + (right - left) / 2];
            int i = left;
            int j = right;
            while(i<=j)
            {
                while (comparer.Compare(array[i], x)==(1)) i++;
                while (comparer.Compare(array[j], x) == (-1)) j--;
                if(i<=j)
                {
                    Swap(array, i, j);
                    i++;
                    j--;
                }
            }
            if (comparer.Compare(i, right)==1)
                ToSort(array, i, right);
            if (comparer.Compare(left , j)==1)
                ToSort(array, left, j);

        }
        public void Swap(int[] array,int firstElementIndex, int secondElementIndex)
        {
            int temp = array[firstElementIndex];
            array[firstElementIndex] = array[secondElementIndex];
            array[secondElementIndex] = temp;
        }
        
    }
   

    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickSort = new QuickSort();
            Random rand = new Random();
            int[] a = new int[1000];
            for (int i = 0; i < a.Length; i++)
                a[i] = rand.Next(-50000,50000);
            quickSort.ToSort(a,0,a.Length-1);
            foreach (var temp in a)
            {
                Console.Write("{0} ",temp);
            }
            Console.ReadKey();
        }
    }
}
