using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mathulator.Services
{
	public class UserService
	{
        // Create
        public void CreateUser() {
            using (var db = new MathulatorDB())
            {
                Console.WriteLine("Inserting a new user");
                db.Add(new User { UserName = "Aaron" });
                db.SaveChanges();
            }
        }

        // Read
        public void ReadUser() {
            using (var db = new MathulatorDB())
            {
                Console.WriteLine("Querying for a user");
                var user = db.Users
                .OrderBy(b => b.UserId)
                .First();
                }
            }

        public void UpdateUser()
        {
            using (var db = new MathulatorDB())
            {
                var user = db.Users;
                Console.WriteLine("Updating the blog and adding a post");
                user.UserName = "https://devblogs.microsoft.com/dotnet";
                user.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();
            }
        }
        public void DeleteUser() 
        {
            using (var db = new MathulatorDB())
            {
                Console.WriteLine("Delete a user");
                db.Remove(user);
                db.SaveChanges();
            }
        }

               
            
	}
}
