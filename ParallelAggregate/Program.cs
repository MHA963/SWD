using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//MapReduce
// class Program
// {
//     static void Main(string[] args)
//     {
//         string[] words = { "apple", "banana", "apple", "cherry", "banana", "apple", "apple", "banana", "cherry" };

//         var wordCountMap = words.AsParallel()
//             .GroupBy(word => word) // Map phase
//             .ToDictionary(group => group.Key, group => group.Count()); // Reduce phase (combine)

//         foreach (var entry in wordCountMap)
//         {
//             Console.WriteLine($"Word: {entry.Key}, Count: {entry.Value}");
//         }
//     }
// }



 //Parallel aggregation 
class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        int sum = 0;
        object lockObject = new object(); // Used for synchronization

        Parallel.For(
            0, numbers.Length, // Loop range
            () => 0, // Local state initialization
            (index, state, localSum) => localSum + numbers[index], // Loop body
            localSum => // Local state aggregation
            {
                lock (lockObject)
                {
                    sum += localSum;
                }
            }
        );
        Console.WriteLine("Sum of numbers: " + sum);
    }
}
