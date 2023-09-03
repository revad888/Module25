using Module25.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Repositories
{
    public class GenreRepository
    {
        public static void AddGenre(AppContext db, Genre genre)
        {
            db.Genres.Add(genre);
            db.SaveChanges();
        }
    }
}
