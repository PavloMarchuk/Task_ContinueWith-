using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Multiple_ContinueWith
{
	class Program
	{
		static Int64 Sum(object arg)
		{
			Int64 sum = 1, x = (Int32)arg;
			for(; x > 0; x--)
				//checked
				{
					sum *= 2;
				}
			return sum;
		}
		static void Main(string[] args)
		{
			Task<Int64> task = new Task<Int64>(Sum, 64);

			Task continueWith = task.ContinueWith(tsk =>
			{
				Console.WriteLine($"Result={tsk.Result}");
			}, TaskContinuationOptions.OnlyOnRanToCompletion);

			Task continueWithError = task.ContinueWith(tsk =>
			{
				Console.WriteLine($"Result=ERROR");
			}, TaskContinuationOptions.OnlyOnFaulted);

			task.Start();
			Thread.Sleep(3000);


		}
	}
}
