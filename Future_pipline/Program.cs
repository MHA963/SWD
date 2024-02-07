// using System;
// using System.Threading.Tasks;

// class Program
// {
//     static async Task Main(string[] args)
//     {
//         Task<int> futureValue = CalculateValueAsync();

//         Console.WriteLine("Doing other work while waiting for the future value...");

//         int result = await futureValue;

//         Console.WriteLine($"Future value: {result}");
//     }
//     static async Task<int> CalculateValueAsync()
//     {
//         await Task.Delay(2000); // Simulate a time-consuming operation
//         return 42;
//     }
// }



using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> data = new List<int> { 1, 2, 3, 4, 5 };

        Pipeline<int> pipeline = new Pipeline<int>()
            .AddFilter(new FilterSquare())
            .AddFilter(new FilterAddTwo());

        List<int> result = pipeline.Process(data);

        Console.WriteLine("Input data: " + string.Join(", ", data));
        Console.WriteLine("Processed data: " + string.Join(", ", result));
    }
}

interface IFilter<T>
{
    T Process(T input);
}

class FilterSquare : IFilter<int>
{
    public int Process(int input)
    {
        return input * input;
    }
}

class FilterAddTwo : IFilter<int>
{
    public int Process(int input)
    {
        return input + 2;
    }
}

class Pipeline<T>
{
    private List<IFilter<T>> filters = new List<IFilter<T>>();

    public Pipeline<T> AddFilter(IFilter<T> filter)
    {
        filters.Add(filter);
        return this;
    }

    public List<T> Process(List<T> input)
    {
        List<T> result = new List<T>();

        foreach (T item in input)
        {
            T currentItem = item;
            foreach (var filter in filters)
            {
                currentItem = filter.Process(currentItem);
            }
            result.Add(currentItem);
        }

        return result;
    }
}
