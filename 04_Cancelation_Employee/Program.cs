using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_Cancelation_Employee
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Main SATRT");
			var cancelTok5rs = new CancellationTokenSource();
			Task<IEnumerable<Employee>> task = new Task<IEnumerable<Employee>>(DataStorage.GetEmployee, cancelTok5rs.Token);			
			task.ContinueWith(tsk => DataStorage.PrintEmployee(task.Result, cancelTok5rs.Token));
			task.Start();
			Thread.Sleep(8000);
			try
			{
				cancelTok5rs.Cancel();
				task.Wait();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}

		
		}
	}
}
