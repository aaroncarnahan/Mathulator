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
		int currentUserId;
		int tempUserId;
		string inputUserName;
		string inputPassword;
		string inputPasswordConfirm;

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

			string userTag;

			if (currentUserId == 0)
			{
				userTag = "User>";
			}
			else
			{
				userTag = userService.GetUserNameById(currentUserId) + ">";
			}

			Console.WriteLine(message);
			Console.Write(userTag);
			string userInput = Console.ReadLine();
			return userInput;
		}

		// PASSWORD MASKING (NOT MY CODE)
		public static string PasswordMask()
		{
			string password = "";
			ConsoleKeyInfo info = Console.ReadKey(true);
			while (info.Key != ConsoleKey.Enter)
			{
				if (info.Key != ConsoleKey.Backspace)
				{
					Console.Write("*");
					password += info.KeyChar;
				}
				else if (info.Key == ConsoleKey.Backspace)
				{
					if (!string.IsNullOrEmpty(password))
					{
						// remove one character from the list of password characters
						password = password.Substring(0, password.Length - 1);
						// get the location of the cursor
						int pos = Console.CursorLeft;
						// move the cursor to the left by one character
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
						// replace it with space
						Console.Write(" ");
						// move the cursor to the left by one character again
						Console.SetCursorPosition(pos - 1, Console.CursorTop);
					}
				}
				info = Console.ReadKey(true);
			}
			// add a new line because user pressed enter at the end of their password
			Console.WriteLine();
			return password;
		}

		// CREATE NEW USER TEXT BANNER
		public void CreateNewUserBanner() 
		{
			Console.Clear();
			Console.WriteLine("CREATE NEW USER");
			Console.WriteLine("---------------");
			Console.WriteLine();
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
							Login();
							break;
						case 2:
							Console.Clear();
							CreateUser();
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
				string input = userInput("");
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
		}


		public void Login()
		{
			using (var db = new MathulatorDB())
			{
				bool running1 = true;
				while (running1)
				{
					Console.Clear();
					Console.WriteLine("LOGIN");
					Console.WriteLine("-----");
					Console.WriteLine();
					Console.WriteLine("Enter username:");
					inputUserName = userInput("");

					if (userService.CheckIfUserExists(inputUserName))
					{
						tempUserId = userService.GetUserIdByUsername(inputUserName);
						running1 = false;
					}
					else
					{
						Console.Clear();
						Console.WriteLine("LOGIN");
						Console.WriteLine("-----");
						Console.WriteLine();
						Console.WriteLine("User " + "\"" + inputUserName + "\"" + " does not exist.");
						Console.WriteLine("Press ENTER to continue");
						Console.ReadKey();
						
					}
				}

				bool running2 = true;
				while (running2)
				{
					string passwordCheck = userService.GetUserPasswordById(tempUserId);

					Console.Clear();
					Console.WriteLine("LOGIN");
					Console.WriteLine("-----");
					Console.WriteLine();
					Console.WriteLine("User " + "\"" + inputUserName + "\"" + " has been found.");
					Console.WriteLine();
					Console.WriteLine("Enter password:");
					Console.WriteLine();
					Console.Write("User>");
					inputPassword = PasswordMask();

					if (inputPassword != passwordCheck)
					{
						Console.Clear();
						Console.WriteLine("LOGIN");
						Console.WriteLine("-----");
						Console.WriteLine();
						Console.WriteLine("Incorrect password.");
						Console.WriteLine("Press ENTER to try again");
						Console.ReadLine();
						Console.Clear();
					}
					else
					{
						currentUserId = userService.GetUserIdByUsername(inputUserName);
						Console.WriteLine(currentUserId);
						running2 = false;
					}
				}

				Console.Clear();
				StartMenu();
			}
		}

		// CREATE USER
		public void CreateUser()
		{
			using (var db = new MathulatorDB())
			{
				bool running1 = true;
				while (running1)
				{

					CreateNewUserBanner();
					Console.WriteLine("WARNING: Write down your username and password. There is no way to recover them if you forget.");
					Console.WriteLine();
					Console.WriteLine("Type a new username then press ENTER");
					inputUserName = userInput("");

					if (userService.CheckIfUserExists(inputUserName))
					{
						Console.Clear();
						Console.WriteLine("User " + "\"" + inputUserName + "\"" + " already exists.");
						Console.WriteLine("Press ANY KEY to try again");
						Console.ReadKey();
					}

					else if (inputUserName == "")
					{
						CreateNewUserBanner();
						Console.WriteLine("Username is blank. Must enter at least 1 character");
						Console.WriteLine("Press ENTER to try again");
						Console.ReadKey();
					}
					
					else
					{
						running1 = false;
					}
				}

				bool running2 = true;
				while (running2)
				{

					bool running3 = true;
					while (running3)
					{

							CreateNewUserBanner();
							Console.WriteLine("Type your new password:");
							Console.WriteLine();
							Console.Write("User>");
							inputPassword = PasswordMask();

						if (inputPassword == "")
						{
							CreateNewUserBanner();
							Console.WriteLine("Password must be at least 1 character long");
							Console.WriteLine("Press ENTER to try again");
							Console.ReadKey();
						}
						else
						{
							running3 = false;
						}
					}

					CreateNewUserBanner();
					Console.WriteLine("Type in your passowrd again to cofrim and then press ENTER");
					Console.WriteLine();
					Console.Write("User>");
					inputPasswordConfirm = PasswordMask();

					
					if (inputPassword != inputPasswordConfirm)
					{
						Console.WriteLine("Passwords do not match. Press ANY KEY to try again");
						Console.ReadLine();
					}
					else
					{
						running2 = false;
					}
				}

				userService.CreateUser(inputUserName, inputPassword);
				CreateNewUserBanner();
				Console.WriteLine("User " + "\"" + inputUserName + "\"" + " has been created.");
				Console.WriteLine("Press ENTER to Log In");
				Console.ReadKey();
				Login();

			}
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
