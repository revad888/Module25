using Microsoft.EntityFrameworkCore;
using Module25.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Repositories
{
    public class BookRepository
    {
        public static Book GetBookById(AppContext db, int id)
        {
            return db.Books.FirstOrDefault(x => x.Id == id);
        }
        public static List<Book> GetAllBooks(AppContext db)
        {
            return db.Books.ToList();
        }
        public static void AddBook(AppContext db, Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
        public static void DeleteBookById(AppContext db, int id)
        {
            Book book = GetBookById(db, id);
            db.Books.Remove(book);
            db.SaveChanges();
        }
        public static void UpdateBookYearById(AppContext db, int id, int year)
        {
            Book book = GetBookById(db, id);
            book.Year = year;
            db.Books.Update(book);
            db.SaveChanges();
        }

        public static void TakeBookById(AppContext db, int id, User user)
        {
            Book book = GetBookById(db, id);
            book.BookUser= user;
            db.Books.Update(book);
            db.SaveChanges();
        }

        public static List<Book> GetBooksByGenreAndYear(AppContext db, string genre, int year)
        {
            return db.Books.Where(x => x.Genre.Name == genre.ToUpper() & x.Year == year).ToList();
        }

        public static int BooksCountByAuthor(AppContext db, string author)
        {
            return db.Books.Count(x => x.Author.Name == author);
            
        }

        public static int BooksCountByYear(AppContext db, int year)
        {
            return db.Books.Count(x => x.Year == year);
        }

        public static bool IsBookByAuthorAndName(AppContext db, string author, string name)
        {
           
            return db.Books.Any(x => x.Author.Name == author.ToUpper() & x.Name == name.ToUpper());
        }
        public static bool IsBookOnHeads(AppContext db, Book book) 
        {
            return db.Books.Any(x => x.BookUser != null);
        }

        public static Book GetLastBook(AppContext db)
        {
            return db.Books.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public static List<Book> GetOrderBooks(AppContext db)
        {
            return db.Books.OrderBy(x => x.Name).ToList();
        }
        public static List<Book> GetBooksOrderByYear(AppContext db)
        {
            return db.Books.OrderByDescending(x =>x.Year).ToList();
        }


    }
}
