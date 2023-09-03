using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module25.Entities;

namespace Module25.Repositories
{
    public class UserRepository
    {
        public static User GetUserById(AppContext db, int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public static List<User> GetAllUsers(AppContext db)
        {
            return db.Users.ToList();
        }

        public static void AddUSer(AppContext db, User user) 
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public static void DeleteUserById(AppContext db, int id)
        {
            User user = GetUserById(db, id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public static void DeleteUser(AppContext db, User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public static void ChangeUserNameById(AppContext db, int id, string newName)
        {
            User user = GetUserById(db, id);
            user.Name = newName;
            db.Users.Update(user);
            db.SaveChanges();
        }

        public static int BooksCountOnHeads(AppContext db, User user)
        {
            return user.Books.Count();
        }
         
    }
}
