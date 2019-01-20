using System;

namespace CultureInGdansk
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                
                
                    // Initialize array for example.
                    char[] array = new char[4];
                    array[0] = 'p';
                    array[1] = 'e';
                    array[2] = 'r';
                    array[3] = 'l';

                    // Display the array.
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i]);
                    }
                    Console.WriteLine();

                    // Resize the array from 4 to 5 elements.
                    Array.Resize(ref array, 5);
                array[4] = '5';
                    // Display the array that has been resized.
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i]);
                    }
                    Console.WriteLine();
                Console.ReadKey();
            }
    }
    }
}
