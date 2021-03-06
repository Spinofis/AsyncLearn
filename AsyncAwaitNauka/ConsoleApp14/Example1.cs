using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Example1
    {
	public static async Task Start1()
	{
	    var watch = Stopwatch.StartNew();
	    var x = await Task.Run(() => { return Async2(); });
	    var y = await Task.Run(() => { return Async3(); });
	    //await Task.WhenAll(new Task[] { Async2(), Async3() });
	    Console.WriteLine(x + y);
	    Console.WriteLine(watch.ElapsedMilliseconds);
	}


	public static async Task Start3() 
	{
	    var x = Async2();
	    int y = 1 + 1;
	    Console.WriteLine("I dont need async result");
	    Console.WriteLine($"I need async result - {await x}");
	    Console.Read();
	}

	public static async Task Start4() 
	{
	    Task<int> task2 = Async2();
	    Console.Read();
	    Console.WriteLine("Working...");
	    Console.WriteLine(await task2);
	}

	public static async Task<int> Async2()
	{
	    await Task.Delay(5000);
	    Console.WriteLine("Finished");
	    return 2;
	}

	public static async Task<int> Async3()
	{
	    await Task.Delay(5000);
	    return 3;
	}


	public async Task<int> GetUrlContentLengthAsync()
	{
	    var client = new HttpClient();

	    Task<string> getStringTask =
		client.GetStringAsync("https://docs.microsoft.com/dotnet");

	    DoIndependentWork();

	    string contents = await getStringTask;

	    return contents.Length;
	}

	void DoIndependentWork()
	{
	    Console.WriteLine("Working...");
	}
    }
}
