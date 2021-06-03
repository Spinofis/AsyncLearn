using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
	static async Task Main(string[] args)
	{
	    //var watch = Stopwatch.StartNew();
	    //var x = await Task.Run(() => { return Async2(); });
	    //var y = await Task.Run(() => { return Async3(); });
	    ////await Task.WhenAll(new Task[] { Async2(), Async3() });
	    //Console.WriteLine(x + y);
	    //Console.WriteLine(watch.ElapsedMilliseconds);

	    //await AsyncVoidExceptions_CannotBeCaughtByCatch();
	    //Console.Read();

	    //int x = await Async2();
	    //int y = 1 + 1;
	    //Console.WriteLine("I dont need async result");
	    //Console.WriteLine($"I need async result - {x}");
	    //Console.Read();

	    //Task<int> task2 = Async2();
	    //Console.Read();
	    //Console.WriteLine("Working...");
	    //Console.WriteLine(await task2);

	    //Async2();
	    //Console.Read();
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

	public static async Task Async4() 
	{
	    await Async2();
	}

	public static async Task AsyncVoidExceptions_CannotBeCaughtByCatch()
	{
	    try
	    {
		await ThrowExceptionAsync();
	    }
	    catch (Exception)
	    {
		// The exception is never caught here!
		throw;
	    }
	}

	private static async Task ThrowExceptionAsync()
	{
	    Task.Delay(500);
	    throw new InvalidOperationException();
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
