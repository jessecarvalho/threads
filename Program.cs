using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        TVChannel channel1 = new TVChannel("Channel 1");
        TVChannel channel2 = new TVChannel("Channel 2");

        Thread channel1Thread = new Thread(channel1.Watch);
        Thread channel2Thread = new Thread(channel2.Watch);

        channel1Thread.Start();
        channel2Thread.Start();
        
        Thread.Sleep(5000);
        channel1.StopBroadcast();
        Thread.Sleep(2000);
        channel2.StopBroadcast();

        channel1Thread.Join();
        channel2Thread.Join();

        Console.WriteLine("All channels have stopped broadcasting.");
    }
}

class TVChannel
{
    private readonly string name;
    private bool broadcasting;

    public TVChannel(string name)
    {
        this.name = name;
        this.broadcasting = true;
    }

    public void Watch()
    {
        Console.WriteLine($"{name} started broadcasting.");

        while (broadcasting)
        {
            Console.WriteLine($"Watching {name}...");
            Thread.Sleep(1000); 
        }

        Console.WriteLine($"{name} stopped broadcasting.");
    }

    public void StopBroadcast()
    {
        broadcasting = false;
    }
}
