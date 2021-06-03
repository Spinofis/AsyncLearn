using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class ExceptionCatching
    {
	public static async Task Start1() 
	{
	    await AsyncVoidExceptions_CannotBeCaughtByCatch();
	    Console.Read();
	}

	 static async Task AsyncVoidExceptions_CannotBeCaughtByCatch()
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
	    await Task.Delay(5000);
	    throw new InvalidOperationException();
	}
    }
}
