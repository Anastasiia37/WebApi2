using System.Collections.Generic;
using System.Linq;
using BusinessLogic.LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.DataProvider
{
    /// <summary>
    /// Class for using daatabase
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// <seealso cref="BusinessLogic.DataProvider.IDataProvider" />
    public class LibraryContext : DbContext, IDataProvider
    {
        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>
        /// The books.
        /// </value>
        private DbSet<Book> books
        {
            get;
            set;
        }

        private DbSet<Author> authors
        {
            get;
            set;
        }

        private DbSet<Genre> genres
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the book -author pairs
        /// </summary>
        /// <value>
        /// The book-author pairs
        /// </value>
        private DbSet<BookAuthorPair> bookAuthorPairs
        {
            get;
            set;
        }

        private DbSet<BookGenrePair> bookGenrePairs
        {
            get;
            set;
        }

        public List<Book> Books
        {
            get
            {
                return books.ToList();
            }
        }

        public List<Genre> Genres
        {
            get
            {
                return genres.ToList();
            }
        }

        public List<BookGenrePair> PairsBookGenre
        {
            get
            {
                return bookGenrePairs.ToList();
            }
        }

        public List<BookAuthorPair> PairsBookAuthor
        {
            get
            {
                return bookAuthorPairs.ToList();
            }
        }

        public List<Author> Authors
        {
            get
            {
                return authors.ToList();
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
            authors.Add(author);
        }

        public void RemoveAuthor(Author author)
        {
            authors.Remove(author);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public void AddGenre(Genre genre)
        {
            genres.Add(genre);
        }

        public void RemoveGenre(Genre genre)
        {
            genres.Remove(genre);
        }

        public void AddBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
            bookAuthorPairs.Add(pairBookAuthor);
        }

        public void RemoveBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
            bookAuthorPairs.Remove(pairBookAuthor);
        }

        public void AddBookGenrePair(BookGenrePair pairBookGenre)
        {
            bookGenrePairs.Add(pairBookGenre);
        }

        public void RemoveBookGenrePair(BookGenrePair pairBookGenre)
        {
            bookGenrePairs.Remove(pairBookGenre);
        }
    }
}