using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Continue
{
	class Program
	{
		static void Main(string[] args)
		{
			Task task1 = new Task(MyTask);
			//Task taskContinue = task1.ContinueWith(new Action<Task>(ContinueTask));
			Task taskContinue = task1.ContinueWith(
				tsk=>
				{
					Console.WriteLine("ContinueTask() запущен.");
					for(int count = 0; count < 5; count++)
					{
						Thread.Sleep(500);
						Console.WriteLine("В методе ContinueTask(), счетчик равен: " + count);
					}
					Console.WriteLine("ContinueTask() завершен.");
				}
				);
			task1.Start();
			taskContinue.Wait();
			Console.WriteLine("Main Thread finished");
			Console.ReadKey();
		}
		static void MyTask()
		{
			Console.WriteLine("MyTask() запущен.");

			for(int count = 0; count < 5; count++)
			{
				Thread.Sleep(500);
				Console.WriteLine("В методе MyTask(), счетчик равен: " + count);
			}

			Console.WriteLine("MyTask() завершен.");
		}

		static void ContinueTask(Task task)
		{
			Console.WriteLine("ContinueTask() запущен.");

			for(int count = 0; count < 5; count++)
			{
				Thread.Sleep(500);
				Console.WriteLine("В методе ContinueTask(), счетчик равен: " + count);
			}

			Console.WriteLine("ContinueTask() завершен.");
		}

	}
}


