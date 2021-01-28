using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Mathulator.Services
{
    public class UserService
    {


        // LOGIN
        public bool CheckIfUserExists(string inputUserName) 
        {
            using (var db = new MathulatorDB())
            {
                if (db.Users.Any(e => e.UserName == inputUserName))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

		//CREATE USER
		public bool CreateUser(string inputUserName, string inputPassword)
		{
			using (var db = new MathulatorDB())
			{
                var entity =
                    new User()
                    {
                        UserName = inputUserName,
                        UserPassword = inputPassword
                    };

                db.Users.Add(entity);
                db.SaveChanges();
            }

            return true;
		}

		// GET USER DETAIL (BY USERNAME)
		public int GetUserIdByUsername(string username)
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

    // GET USER PASSWORD (BY ID)
    public string GetUserPasswordById(int id)
    {
        using (var db = new MathulatorDB())
        {
            var entity =
                db
                    .Users
                    .Single(e => e.UserId == id);
                return entity.UserPassword;
        }
    }

        // GET USER NAME (BY ID)
        public string GetUserNameById(int id)
        {
            using (var db = new MathulatorDB())
            {
                var entity =
                    db
                        .Users
                        .Single(e => e.UserId == id);
                return entity.UserName;
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

