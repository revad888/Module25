using Module25.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Repositories
{
    public class AuthorRepository
    {
        public static void AddAuthor(AppContext db, Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
        }
    }
}
