using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_Paralel_Invoke
{
	class Program
	{
		static void Met1()
		{
			Console.WriteLine("Met1() RUN");
			for(int i = 0; i < 80; i++)
			{
				Thread.Sleep(50);
				Console.Write("*");
			}
			Console.WriteLine("\nMet1() fin");
		}

		static void Met2()
		{
			Console.WriteLine("Met2() RUN");
			for(int i = 0; i < 80; i++)
			{
				Thread.Sleep(50);
				Console.Write("0");
			}
			Console.WriteLine("\nMet2() fin");
		}


		static void Main(string[] args)
		{
			Console.WriteLine(Environment.MachineName);
			Console.WriteLine(Environment.ProcessorCount);
			Console.WriteLine(Environment.UserName);
			Console.WriteLine(Environment.Version);
			var option = new ParallelOptions
			{
				MaxDegreeOfParallelism = Environment.ProcessorCount >2? Environment.ProcessorCount -1:1
			};
			Parallel.Invoke(Met1, Met2, Met1, Met2);
			Console.WriteLine("MAIN fin");
		}
	}
}


