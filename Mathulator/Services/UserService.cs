using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mathulator.Services
{
    public class UserService
    {

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

        // CREATE
        public void CreateUser()
        {

            using (var db = new MathulatorDB())
            {

                string EnterUsername()
                {
                    Console.Clear();
                    Console.WriteLine("Enter a new username:");
                    string inputUserName = Console.ReadLine();

                    if (db.Users.Any(e => e.UserName == inputUserName))
                    {
                        Console.Clear();
                        Console.WriteLine("User " + "\"" + inputUserName + "\"" + " already exists.");
                        Console.WriteLine("Press ANY KEY to try again");
                        Console.ReadKey();
                        EnterUsername();
                    }

                    return inputUserName;
                }

                string EnterPassword()
                {
                        Console.WriteLine("Enter a password");
                        string inputPassword = PasswordMask();     

                        Console.WriteLine("Confirm password");
                        string inputPasswordConfirm = PasswordMask();   

                        if (inputPassword != inputPasswordConfirm)
                        {
                            Console.WriteLine("Passwords do not match. Press ANY KEY to try again");
                            Console.ReadLine();
                            inputPassword = null;
                            EnterPassword();
                        }
                        
                        return inputPassword;
                }

                string username = EnterUsername();
                string password = EnterPassword();

				var entity =
					new User()
					{
						UserName = username,
						UserPassword = password
					};

				db.Users.Add(entity);
				db.SaveChanges();
				Console.Clear();
				Console.WriteLine("User " + "\"" + username + "\"" + " has been created.");
				Console.WriteLine("Press ANY KEY to continue");
				Console.ReadKey();
			
			}
		}

        // Read
        //public void ReadUser() {
        //    using (var db = new MathulatorDB())
        //    {
        //        var user = db.Users
        //        .OrderBy(b => b.UserId)
        //        .First();
        //        }
        //    }

        //public void UpdateUser()
        //{
        //    using (var db = new MathulatorDB())
        //    {
        //        var user = db.Users;
        //        Console.WriteLine("Updating the blog and adding a post");
        //        user.UserName = "https://devblogs.microsoft.com/dotnet";
        //        user.Posts.Add(
        //            new Post
        //            {
        //                Title = "Hello World",
        //                Content = "I wrote an app using EF Core!"
        //            });
        //        db.SaveChanges();
        //    }
        //}
        //public void DeleteUser() 
        //{
        //    using (var db = new MathulatorDB())
        //    {
        //        Console.WriteLine("Delete a user");
        //        db.Remove(user);
        //        db.SaveChanges();
        //    }
        //}




    }
}
