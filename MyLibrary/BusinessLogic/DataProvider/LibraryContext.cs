using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.DataProvider
{
    public class LibraryContext : DbContext, IDataProvider
    {
        public DbSet<BookAuthorPair> BookAuthorPairs
        {
            get;
            set;
        }

        public DbSet<BookGenrePair> BookGenrePairs
        {
            get;
            set;
        }

        public DbSet<Book> Books
        {
            get;
            set;
        }

        public DbSet<Author> Authors
        {
            get;
            set;
        }

        public DbSet<Genre> Genres
        {
            get;
            set;
        }

        public List<Book> GetBooks
        {
            get
            {
                return Books.ToList();
            }
        }

        public List<Genre> GetGenres
        {
            get
            {
                return Genres.ToList();
            }
        }

        public List<BookGenrePair> GetPairBookGenre
        {
            get
            {
                return BookGenrePairs.ToList();
            }
        }

        public List<BookAuthorPair> GetPairBookAuthor
        {
            get
            {
                return BookAuthorPairs.ToList();
            }
        }

        public List<Author> GetAuthors
        {
            get
            {
                return Authors.ToList();
            }
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public void Save()
        {
            this.SaveChanges();
        }

        public void AddAuthor(Author author)
        {
            Authors.Add(author);
        }

        public void RemoveAuthor(Author author)
        {
            Authors.Remove(author);
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void AddGenre(Genre genre)
        {
            Genres.Add(genre);
        }

        public void RemoveGenre(Genre genre)
        {
            Genres.Remove(genre);
        }

        public void AddBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
            BookAuthorPairs.Add(pairBookAuthor);
        }

        public void RemoveBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
            BookAuthorPairs.Remove(pairBookAuthor);
        }

        public void AddBookGenrePair(BookGenrePair pairBookGenre)
        {
            BookGenrePairs.Add(pairBookGenre);
        }

        public void RemoveBookGenrePair(BookGenrePair pairBookGenre)
        {
            BookGenrePairs.Remove(pairBookGenre);
        }
    }
}