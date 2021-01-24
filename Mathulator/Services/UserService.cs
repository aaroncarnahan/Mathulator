using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mathulator.Services
{
    public class UserService
    {
        int currentUser;
        string inputUserName;
        string inputPassword;
        string inputPasswordConfirm;

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
                bool running1 = true;
                while (running1)
                {

                    Console.Clear();
                    Console.WriteLine("Enter a new username:");
                    inputUserName = Console.ReadLine();

                    if (db.Users.Any(e => e.UserName == inputUserName))
                    {
                        Console.Clear();
                        Console.WriteLine("User " + "\"" + inputUserName + "\"" + " already exists.");
                        Console.WriteLine("Press ANY KEY to try again");
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
                    Console.WriteLine("Enter a password");
                    inputPassword = PasswordMask();
                    
                    Console.WriteLine("Confirm password");
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

                var entity =
                    new User()
                    {
                        UserName = inputUserName,
                        UserPassword = inputPassword
                    };

                db.Users.Add(entity);
                db.SaveChanges();
                Console.Clear();
                Console.WriteLine("User " + "\"" + inputUserName + "\"" + " has been created.");
                Console.WriteLine("Press ENTER to Log In");
                Console.ReadKey();
                
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
                    Console.WriteLine("Enter username:");
                    inputUserName = Console.ReadLine();

                    if (db.Users.Any(e => e.UserName == inputUserName))
					{
						Console.WriteLine("User " + "\"" + inputUserName + "\"" + " has been found.");
						Console.WriteLine("Press ENTER to continue");
                        
						Console.WriteLine(GetUserByUsername(inputUserName));
                        Console.ReadLine();


                    }
					else
					{
						Console.WriteLine("User " + "\"" + inputUserName + "\"" + " does not exist.");
                        Console.WriteLine("Press ENTER to continue");
                        Console.ReadKey();
                    }
                }

                bool running2 = true;
                while (running2)
                {
                    Console.WriteLine("Enter password");
                    inputPassword = PasswordMask();

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

                //var entity =
                //    new User()
                //    {
                //        UserName = inputUserName,
                //        UserPassword = inputPassword
                //    };

                //db.Users.Add(entity);
                //db.SaveChanges();
                //Console.Clear();
                //Console.WriteLine("User " + "\"" + inputUserName + "\"" + " has been created.");
                //Console.WriteLine("Press ENTER to Log In");
                //Console.ReadKey();
                //Login();
            }
        }

    

    // GET USER DETAIL (BY USERNAME)
    public int GetUserByUsername(string username)
    {
        using (var db = new MathulatorDB())
        {
            var entity =
                db
                    .Users
                    .Single(e => e.UserName == username);
                return entity.UserId;
                
        }
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

