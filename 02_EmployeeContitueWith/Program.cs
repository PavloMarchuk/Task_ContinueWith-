using _02_EmployeeContitueWith.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_EmployeeContitueWith
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Main SATRT");
			Task<IEnumerable<Employee>> task = new Task<IEnumerable<Employee>>(DataStorage.GetEmployee);
			//task.Start();
			//IEnumerable<Employee> collection  = DataStorage.GetEmployee();
			task.ContinueWith(tsk => DataStorage.PrintEmployee(task.Result));
			task.Start();
			//DataStorage.PrintEmployee(task.Result);

			Task taskDot = new Task(()=>
			{
				for(int i = 0; i < 120; i++)
				{
					Thread.Sleep(100);
					Console.Write(".");
				}
			});
			taskDot.Start();

			Console.WriteLine("main END");
			Console.ReadKey();

			//Thread.Sleep(10000);

		}
	}
}
