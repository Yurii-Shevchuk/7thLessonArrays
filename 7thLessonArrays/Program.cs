namespace _7thLessonArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Today we are sorting arrays using different sorting algorithms");
            int[] arraySelectionAsc = GenerateArray(10);
            Console.WriteLine("Unsorted array:");
            printArray(arraySelectionAsc);
            Console.WriteLine("Array sorted by selection sort in ascending order:");
            Sort(arraySelectionAsc, SortAlgorithmType.Selection, OrderBy.Asc);
            printArray(arraySelectionAsc);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("Unsorted array:");
            int[] arraySelectionDesc = GenerateArray(10);
            printArray(arraySelectionDesc);
            Console.WriteLine("Array sorted by selection sort in descending order:");
            Sort(arraySelectionDesc, SortAlgorithmType.Selection, OrderBy.Desc);
            printArray(arraySelectionDesc);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            int[] arrayBubbleAsc = GenerateArray(10);
            Console.WriteLine("Unsorted array:");
            printArray(arrayBubbleAsc);
            Console.WriteLine("Array sorted by bubble sort in ascending order:");
            Sort(arrayBubbleAsc, SortAlgorithmType.Bubble, OrderBy.Asc);
            printArray(arrayBubbleAsc);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            int[] arrayBubbleDesc = GenerateArray(10);
            Console.WriteLine("Unsorted array:");
            printArray(arrayBubbleDesc);
            Console.WriteLine("Array sorted by bubble sort in descending order:");
            Sort(arrayBubbleDesc, SortAlgorithmType.Bubble, OrderBy.Desc);
            printArray(arrayBubbleDesc);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            int[] arrayInjectionAsc = GenerateArray(10);
            Console.WriteLine("Unsorted array:");
            printArray(arrayInjectionAsc);
            Console.WriteLine("Array sorted by injection sort in ascending order:");
            Sort(arrayInjectionAsc, SortAlgorithmType.Injection, OrderBy.Asc);
            printArray(arrayInjectionAsc);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            int[] arrayInjectionDesc = GenerateArray(10);
            Console.WriteLine("Unsorted array:");
            printArray(arrayInjectionDesc);
            Console.WriteLine("Array sorted by injection sort in descending order:");
            Sort(arrayInjectionDesc, SortAlgorithmType.Injection, OrderBy.Desc);
            printArray(arrayInjectionDesc);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");



        }

        static void Sort(int[] array, SortAlgorithmType sortAlgorithmType, OrderBy orderBy)
        {
            switch(sortAlgorithmType)
            {
                case SortAlgorithmType.Selection:
                    SelectionSort(array, orderBy);
                    break;
                case SortAlgorithmType.Bubble:
                    BubbleSort(array, orderBy);
                    break;
                case SortAlgorithmType.Injection:
                    InjectionSort(array, orderBy);
                    break;
                default: break;
            }
        }
        static void SelectionSort(int[] arr, OrderBy orderBy)
        {

            for(int i = 0; i < arr.Length - 1; i++)
            {
                int minElIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    bool shouldSwap = (orderBy == 0) ? (arr[j] < arr[minElIndex]) : (arr[j] > arr[minElIndex]);
                    if (shouldSwap)
                    {
                        minElIndex = j;
                    }
                }
                (arr[i], arr[minElIndex]) = (arr[minElIndex], arr[i]);
            }
        }
        static void BubbleSort(int[] arr, OrderBy orderBy)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for(int j = 0; j< arr.Length - i - 1; j++)
                {
                    bool shouldSwap = (orderBy == 0) ? (arr[j] > arr[j+1]) : (arr[j] < arr[j+1]);
                    if (shouldSwap)
                    {
                        (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                    }
                }
            }
        }

        static void InjectionSort(int[] arr, OrderBy orderBy)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && ((orderBy == 0 && arr[j] > key) || ((int)orderBy == 1 && arr[j] < key )))
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j+1] = key;
            }
        }
        static void printArray(int[] arr)
        {
            foreach(int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();
        }

        static int[] GenerateArray(int length)
        {
            if(length <=0)
            {
                throw new ArgumentException("The specified array length is incorrect");
            }
            Random rnd = new Random();
            int[] arr = new int[length];
            for (int i = 0; i<arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 101);
            }
           return arr;
        }
        enum SortAlgorithmType
        {
            Selection,
            Bubble,
            Injection,
        }

        enum OrderBy
        {
            Asc,
            Desc,
        }

    }
}