using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_Cancelation_Token
{
	class Program
	{
		static void MyTask(object ct)
		{
			CancellationToken token = (CancellationToken)ct;
			token.ThrowIfCancellationRequested();
			Console.WriteLine("MyTask() запущен.");

			for(int count = 0; count < 5; count++)
			{
				if(token.IsCancellationRequested)
				{
					Console.WriteLine("ЗАПИТ НА ЗАВЕРШЕННЯ");
					token.ThrowIfCancellationRequested();
				}
				Thread.Sleep(500);
				Console.WriteLine("В методе MyTask(), счетчик равен: " + count);
			}

			Console.WriteLine("MyTask() завершен.");
		}
		static void Main(string[] args)
		{
			var cancelTok5rs = new CancellationTokenSource();
			Task task = Task.Factory.StartNew(MyTask, cancelTok5rs.Token);
			Thread.Sleep(2000);
			
			try
			{
				cancelTok5rs.Cancel();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}


		}
	}
}
