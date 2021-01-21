using System;
using System.Collections.Generic;
using System.Text;

// My using statements
using Mathulator.Modules;


namespace Mathulator
{
	// MAIN MENU
	public class Menu
	{
		// TOPBAR NAVIGATION BOILERPLATE
		TopBarNavigation topbar = new TopBarNavigation();

		public void navigationTitle(string navTitle) {
			String navigationTitle = navTitle;
			topbar.CheckNavigation(navigationTitle);
			topbar.PrintNavigation();
		}

		// USER INPUT FORMATTING
		public string userInput(string message, int x, int y) {
			Console.SetCursorPosition(x, y);
		
			Console.WriteLine(message);
			Console.Write("User>");
			string userInput = Console.ReadLine();
			return userInput;

		}

		// START MENU
		public void StartMenu()
		{
			//TOPBAR NAVIGATION
			navigationTitle("Main Menu");

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("Welcome to Mathulator!");
			Console.WriteLine("");
			Console.WriteLine("1. Multiplication");
			Console.WriteLine("2. Division");

			bool whileMenuRunning = true;
			while (whileMenuRunning == true)
			{
				string input = userInput("Enter number for menu item", 0, 8);
				if (input == "1" || input == "2")
				{
					int caseSwitch = Int32.Parse(input);
					switch (caseSwitch)
					{
						case 1:
							Console.Clear();
							MultiplicationMainMenu();
							break;
						case 2:
							Console.WriteLine("2. Division");
							break;
						default:
							whileMenuRunning = false;
							break;
					}
				}
				else
				{
					Console.Clear();
					StartMenu();
				}
			}

			Console.WriteLine("out of the loop");
			Console.ReadKey();
		}

		// MAIN MENU > MULTIPLICATION
		public void MultiplicationMainMenu()
		{

			//TOPBAR NAVIGATION
			String navigationTitle = "Multiplication";
			topbar.CheckNavigation(navigationTitle);
			topbar.PrintNavigation();

			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("1. Flash Cards: Multiplication Table");
			Console.WriteLine("2. Division");
			Console.WriteLine("3. Go Back");

			bool whileMenuRunning = true;
			while (whileMenuRunning == true)
			{

				int caseSwitch = Int32.Parse(Console.ReadLine());

				switch (caseSwitch)
				{
					case 1:
						Console.Clear();
						MultiplicationTableMainMenu();
						break;
					case 2:
						Console.WriteLine("2. Division");
						break;
					case 3:
						Console.Clear();
						topbar.nav.Remove(navigationTitle);
						StartMenu();
						break;
					default:
						whileMenuRunning = false;
						break;
				}

			}

			Console.WriteLine("out of the loop");
			Console.ReadKey();
		}

		// MAIN MENU > MULTIPLICATION > MULTIPLICATION TABLE
		public void MultiplicationTableMainMenu()
		{

			//TOPBAR NAVIGATION
			//TOPBAR NAVIGATION
			String navigationTitle = "Multiplication Table";
			topbar.CheckNavigation(navigationTitle);
			topbar.PrintNavigation();


			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("1. Display Multiplication Table");
			Console.WriteLine("2. Placeholder");
			Console.WriteLine("2. Go Back");

			bool whileMenuRunning = true;
			while (whileMenuRunning == true)
			{

				int caseSwitch = Int32.Parse(Console.ReadLine());

				switch (caseSwitch)
				{
					case 1:
						Console.Clear();
						MultiplicationTable multiplicationTable = new MultiplicationTable();
						multiplicationTable.StartMultiplicationTable();
						break;
					case 2:
						Console.WriteLine("2. Division");
						break;
					case 3:
						Console.Clear();
						topbar.nav.Remove(navigationTitle);
						MultiplicationMainMenu();
						break;
					default:
						whileMenuRunning = false;
						break;
				}

			}

			Console.WriteLine("out of the loop");
			Console.ReadKey();
		}
	}
}
