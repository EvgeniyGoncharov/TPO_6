using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace tpo_lab_6
{
	class Program
	{
		static void FindDividers(int number)
		{
			int num = number;
			List<string> dividers = new List<string>();
			dividers.Add("1");
			while (num % 2 == 0)
			{
				dividers.Add("2");
				num /= 2;
			}
			for (int i = 3; i <= num;)
			{
				if (num % i == 0)
				{
					dividers.Add(i.ToString());
					num /= i;
				}
				else
				{
					i += 2;
				}
			}
			Console.WriteLine($"Dividers {number}: " + String.Join(" ", dividers));
		}

		static void ThreadTask(int start, int stop)
		{
			for (int i = start; i < stop; i++)
			{
				FindDividers(i);
			}
		}

		static void Main()
		{
			int threadNum = 8;
			Task[] taskList = new Task[threadNum];
			Console.Write("Введите N: ");
			int n = Convert.ToInt32(Console.ReadLine());
			for (int i = 0; i < threadNum; i++)
			{
				int start, stop;
				start = i == 0 ? i * n / threadNum + 1 : i * n / threadNum;
				stop = i == threadNum - 1 ? (i + 1) * n / threadNum + 1 : (i + 1) * n / threadNum;
				taskList[i] = new Task(() = > ThreadTask(start, stop));
				taskList[i].Start();
			}
			Task.WaitAll(taskList);
		}
	}
}