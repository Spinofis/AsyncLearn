using AsyncAwait;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
	static async Task Main(string[] args)
	{
	   await TasksInLoop.PopulateDates();
	}
    }
}
