using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
     class Foo
    {
	public DateTime Now { get; set; }
    }

    class TasksInLoop
    {
	public DateTime Now { get; set; }

	public static async Task PopulateDates()
	{
	    var ordinals = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };

	    var foos = ordinals.Select(o => new Foo()); //.ToList();

	    var tasks = foos.Select(f => PopulateDateAsync(f)); //.ToList();

	    await Task.WhenAll(tasks);

	    var firstNow = foos.ElementAt(0).Now;
	    var firstTaskStatus = tasks.ElementAt(0).Status;
	    Console.WriteLine(firstNow);
	    Console.WriteLine(firstTaskStatus);
	}

	private static Task PopulateDateAsync(Foo foo)
	{
	    return Task.Run(() => PopulateDate(foo));
	}

	private static async Task PopulateDate(Foo foo)
	{
	   await Task.Delay(2000);
	    foo.Now = DateTime.Now;
	}
    }
    
}
