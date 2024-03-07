using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of elements (N): ");
        if (int.TryParse(Console.ReadLine(), out int N) && N > 0)
        {
            int[] originalArray = new int[N];
            int[] evenArray;
            int[] oddArray;
            Random rand = new Random();

            for (int i = 0; i < N; i++)
            {
                originalArray[i] = rand.Next(1, 27);
            }

            evenArray = new int[N];
            oddArray = new int[N];
            int evenCount = 0, oddCount = 0;

            for (int i = 0; i < N; i++)
            {
                if (originalArray[i] % 2 == 0)
                {
                    evenArray[evenCount++] = originalArray[i];
                }
                else
                {
                    oddArray[oddCount++] = originalArray[i];
                }
            }

            ConvertToLetters(evenArray);

            ConvertToLetters(oddArray);

            Console.WriteLine("Array with even values:");
            DisplayArray(evenArray, evenCount);

            Console.WriteLine("\nArray with odd values:");
            DisplayArray(oddArray, oddCount);

            int evenUppercaseCount = CountUppercaseLetters(evenArray, evenCount);
            int oddUppercaseCount = CountUppercaseLetters(oddArray, oddCount);

            Console.WriteLine($"\nUppercase letter count in evenArray: {evenUppercaseCount}");
            Console.WriteLine($"Uppercase letter count in oddArray: {oddUppercaseCount}");

            if (evenUppercaseCount > oddUppercaseCount)
            {
                Console.WriteLine("evenArray contains more uppercase letters.");
            }
            else if (oddUppercaseCount > evenUppercaseCount)
            {
                Console.WriteLine("oddArray contains more uppercase letters.");
            }
            else
            {
                Console.WriteLine("Both arrays have an equal number of uppercase letters.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a positive integer for N.");
        }

        Console.ReadKey();
    }

    static void ConvertToLetters(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = array[i] + 'A' - 1;
            if (array[i] > 'Z')
            {
                array[i] -= 26;
            }
        }
    }

    static int CountUppercaseLetters(int[] array, int count)
    {
        int uppercaseCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (array[i] >= 'A' && array[i] <= 'Z')
            {
                uppercaseCount++;
            }
        }
        return uppercaseCount;
    }

    static void DisplayArray(int[] array, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Console.Write((char)array[i] + " ");
        }
    }
}
