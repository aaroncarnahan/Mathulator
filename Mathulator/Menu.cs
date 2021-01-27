using System;
using System.Collections.Generic;
using System.Text;
using Figgle;

// My using statements
using Mathulator.Modules;
using Mathulator.Services;

namespace Mathulator
{
	public class Menu
	{
		// USER ACCOUNTS
		UserService userService= new UserService();

		// TOPBAR NAVIGATION BOILERPLATE
		TopBarNavigation topbar = new TopBarNavigation();

		public void navigationTitle(string navTitle) {
			String navigationTitle = navTitle;
			topbar.CheckNavigation(navigationTitle);
			topbar.PrintNavigation();
		}

		// USER INPUT FORMATTING
		public string userInput(string message){
			Console.WriteLine(message);
			Console.Write("User>");
			string userInput = Console.ReadLine();
			return userInput;

		}

		//OPENING SCREEN
		public void OpeningScreen() {
			Console.WriteLine(
			FiggleFonts.CyberMedium.Render("Welcome to"));
			Console.WriteLine(
			FiggleFonts.NancyJImproved.Render("Mathulator"));

			Console.WriteLine("Select an option:");
			Console.WriteLine("");
			Console.WriteLine("1. Log In");
			Console.WriteLine("2. Create New User");
			Console.WriteLine("3. Exit Program");

			bool whileMenuRunning = true;
			while (whileMenuRunning == true)
			{
				string input = userInput("");
				if (input == "1" || input == "2" || input == "3")
				{
					int caseSwitch = Int32.Parse(input);
					switch (caseSwitch)
					{
						case 1:
							Console.Clear();
							userService.Login();
							break;
						case 2:
							Console.Clear();
							userService.CreateUser();
							break;
						case 3:
							Environment.Exit(0);
							break;
						default:
							whileMenuRunning = false;
							break;
					}
				}
				else
				{
					Console.Clear();
					OpeningScreen();
				}
			}
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
				string input = userInput("Enter number for menu item");
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
