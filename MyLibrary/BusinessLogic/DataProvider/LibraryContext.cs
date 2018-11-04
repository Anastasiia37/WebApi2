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

        public List<Book> GetBooks
        {
            get
            {
                return Books.ToList();
            }
        }

        public List<Author> GetAuthors
        {
            get
            {
                return Authors.ToList();
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

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }
    }
}