using System;
using System.Threading;

public class ThreadPPPI
{
    static int forNumber = 0;
    
    public static void Func1()
    {
        Action counter = () =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Counter: {0}", i);
                Thread.Sleep(1000);
            }
        };

        Thread thread = new Thread(new ThreadStart(counter));

        thread.Start();

        Console.WriteLine("Start");

        thread.Join();

        Console.WriteLine("Finish");
    }

    public static async Task Func2(string message)
    {
        Func<string, Task> print = async (value) =>
        {
            await Task.Delay(500);
            Console.WriteLine(value);
        };

        await print(message);
    }

    public static async Task Func3(int number)
    {
        await Task.Run(() =>
        {
            int result = 0;
            for (int ctr = 0; ctr <= number; ctr++)
            {
                result += ctr;
            }
            forNumber = result;
        });
    }

    public static async Task Main()
    {
        Func1();
        await Func2("Hi!");
        await Func3(500);
        Console.WriteLine(forNumber);

    }
}