using System;
using System.Collections.Generic;
using System.Text;

namespace Mathulator.Modules
{
	public class MultiplicationTable
	{
		public void StartMultiplicationTable() {
			Console.WriteLine("Enter the highest number you want to multiply to");
			int maximum = Int32.Parse(Console.ReadLine());
			

			bool running = true;
			while (running == true)
			{
				for (int number1 = 0; number1 <= maximum; number1++)
				{

					for (int number2 = 0; number2 <= maximum; number2++)
					{
						Console.WriteLine(number1 + " x " + number2 + " = " + number1 * number2);
						Console.ReadLine();
						Console.Clear();
					}
					
				}

				running = false;

			}

			Console.WriteLine("Out of the loop");
			

		}
	}
}
