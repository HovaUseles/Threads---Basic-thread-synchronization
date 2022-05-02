using System;
using System.Reflection;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Exercise 1");
        Console.WriteLine("2. Exercise 2 and 3");

        switch (Console.ReadKey(true).KeyChar)
        {
            case '1':
                Exercise1.Exercise1Controller();
                break;
            case '2':
                Exercise2.Exercise2Controller();
                break;
        }

        Console.Read();
    }
}

#region Exercise1
static class Exercise1
{
    public static void Exercise1Controller()
    {
        Counter counter = new Counter();

        Thread upCountThread = new Thread(counter.UpCount);
        Thread downCountThread = new Thread(counter.DownCount);

        upCountThread.Start();
        downCountThread.Start();
    }
}

class Counter
{
    public int counter;
    private object _lock = new object();
    public void UpCount()
    {
        while (true)
        {
            Monitor.Enter(_lock);
            counter += 2;
            Console.WriteLine("Count up: " + counter);
            Monitor.Exit(_lock);
            Thread.Sleep(1000);
        }
    }
    public void DownCount()
    {
        while (true)
        {
            Monitor.Enter(_lock);
            counter--;
            Console.WriteLine("Count down: " + counter);
            Monitor.Exit(_lock);
            Thread.Sleep(1000);

        }
    }
}

#endregion



#region Exercise 2 & 3
static class Exercise2
{
    static public void Exercise2Controller()
    {
        Printer printer = new Printer();
        Thread starThread = new Thread(printer.StarPrint);
        Thread HashtagThread = new Thread(printer.HashtagPrint);

        starThread.Start();
        HashtagThread.Start();
    }
}

class Printer
{
    public int counter;
    object _lock = new object();

    public void StarPrint()
    {
        while (true)
        {

            Monitor.Enter(_lock);
            for (int i = 0; i < 60; i++)
            {
                Console.Write('*');
                counter++;
                Thread.Sleep(10);
            }
            Console.Write(" " + counter + "\n");
            Monitor.Exit(_lock);
        }
    }

    public void HashtagPrint()
    {
        while (true)
        {

            Monitor.Enter(_lock);
            for (int i = 0; i < 60; i++)
            {
                Console.Write('#');
                counter++;
                Thread.Sleep(10);
            }
            Console.Write(" " + counter + "\n");
            Monitor.Exit(_lock);
        }
    }
}
#endregion