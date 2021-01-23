using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mathulator.Services
{
	public class UserService
	{

        // CREATE
        public void CreateUser()
        {
            using (var db = new MathulatorDB())
            {
            bool whileMenuRunning = true;
                while (whileMenuRunning == true)
                {
                    Console.WriteLine("Enter a new username: ");
                    string input = Console.ReadLine();

                    if (db.Users.Any(e => e.UserName == input))
                    {
                        Console.WriteLine("User already exists");
					}
					else
					{
                        var entity =
                            new User() {
                                UserName = input
                            };

                        db.Users.Add(entity);
                        db.SaveChanges();
						Console.WriteLine("YOUR USER HAS BEEN CREATED");
						Console.WriteLine("Press ANY KEY to continue");
                        Console.ReadKey();
                        whileMenuRunning = false;
                    }

                }

				Console.WriteLine("OUT OF THE LOOP");
            }
        }

        // Read
        public void ReadUser() {
            using (var db = new MathulatorDB())
            {
                var user = db.Users
                .OrderBy(b => b.UserId)
                .First();
                }
            }

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
