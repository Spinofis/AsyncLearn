using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class TasksInLoop
    {
	private static IEnumerable<int> numbers = new List<int>() { 1, 2, 3 };

	public async static Task<int[]> Start1()
	{
	    var numbersTasks = numbers.Select(id => ExampleWait(id));
	    return await Task.WhenAll(numbersTasks);
	}

	static async Task Start2()
	{
	    numbers.ToList().ForEach(id =>  ExampleWait(id));
	}

	private async static Task<int> ExampleWait(int i)
	{
	    await Task.Delay(1000 * i);
	    return i;
	}
    }
}
