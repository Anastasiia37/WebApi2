// <copyright file="ListsDataProvider.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using BusinessLogic.LibraryModel;
using System.Collections.Generic;

namespace BusinessLogic.DataProvider
{
    /// <summary>
    /// Data Provider for Library Service that provides data in a list
    /// </summary>
    /// <seealso cref="BusinessLogic.DataProvider.IDataProvider" />
    public class InMemoryDataProvider : IDataProvider
    {
        /// <summary>
        /// The books
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// The authors
        /// </summary>
        private List<Author> authors;

        /// <summary>
        /// The genres
        /// </summary>
        private List<Genre> genres;

        /// <summary>
        /// The books with genres
        /// </summary>
        private List<BookGenrePair> pairBookGenre;

        /// <summary>
        /// The books with authors
        /// </summary>
        private List<BookAuthorPair> pairBookAuthor;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryDataProvider"/> class.
        /// Fill books and authors by default values
        /// </summary>
        public InMemoryDataProvider()
        {

                this.books = new List<Book>()
            {
                new Book("Я, робот", 1950),          // id = 1
                new Book("Мир одного дня", 1985),    // id = 2, has two authors
                new Book("Сказки", 2006),            // id = 3, has no author
                new Book("Конец вечности", 1955),    // id = 4, has three authors
                new Book("Красное и черное", 1850),  // id = 5
                new Book("Вий", 1801),               // id = 6
                new Book("Мертвые души", 1777),      // id = 7
            };

            this.authors = new List<Author>()
            {
                new Author("Филип Фармер"),              // id = 1
                new Author("Айзек Азимов"),              // id = 2
                new Author("Стендаль"),                  // id = 3
                new Author("Николай Васильевич Гоголь"), // id = 4
                new Author("Роберт Шекли"),              // id = 5, no book with such author
                new Author("Омар Хаям"),              // id = 5, no book with such author
            };

            this.genres = new List<Genre>()
            {
                new Genre("Научная фантастика"),         // id = 1
                new Genre("Классика"),                   // id = 2
                new Genre("Роман"),                      // id = 3
                new Genre("Фэнтези"),                    // id = 4, no book with such genre
                new Genre("Фольклор"),                   // id = 5
                new Genre("Приключения"),                // id = 6
                new Genre("Ужасы"),                      // id = 7
                new Genre("Повесть"),                    // id = 8
            };

            this.pairBookGenre = new List<BookGenrePair>()
            {
                new BookGenrePair(1, 1),         // id = 1
                new BookGenrePair(2, 6),         // id = 2
                new BookGenrePair(2, 1),         // id = 3
                new BookGenrePair(3, 5),         // id = 4
                new BookGenrePair(4, 1),         // id = 5
                new BookGenrePair(4, 6),         // id = 6
                new BookGenrePair(5, 3),         // id = 7
                new BookGenrePair(5, 2),         // id = 8
                new BookGenrePair(7, 8),         // id = 9
                new BookGenrePair(7, 2),         // id = 10
                new BookGenrePair(7, 6),         // id = 11
                new BookGenrePair(6, 7),         // id = 12
            };

            this.pairBookAuthor = new List<BookAuthorPair>()
            {
                new BookAuthorPair(1, 2),         // id = 1
                new BookAuthorPair(2, 1),         // id = 2
                new BookAuthorPair(2, 4),         // id = 3
                new BookAuthorPair(4, 3),         // id = 4
                new BookAuthorPair(4, 2),         // id = 5
                new BookAuthorPair(4, 6),         // id = 6
                new BookAuthorPair(5, 3),         // id = 7
                new BookAuthorPair(6, 4),         // id = 8
                new BookAuthorPair(7, 4),         // id = 9
            };
        }

        /// <summary>
        /// Gets the books
        /// </summary>
        /// <value>
        /// The books
        /// </value>
        public List<Book> GetBooks
        {
            get
            {
                return this.books;
            }
        }

        /// <summary>
        /// Gets the authors
        /// </summary>
        /// <value>
        /// The authors
        /// </value>
        public List<Author> GetAuthors
        {
            get
            {
                return this.authors;
            }
        }

        /// <summary>
        /// Gets the genres
        /// </summary>
        /// <value>
        /// The genres
        /// </value>
        public List<Genre> GetGenres
        {
            get
            {
                return this.genres;
            }
        }

        /// <summary>
        /// Gets the pair of book and its genre
        /// </summary>
        /// <value>
        /// The pair of book and its genre
        /// </value>
        public List<BookGenrePair> GetPairBookGenre
        {
            get
            {
                return this.pairBookGenre;
            }
        }

        /// <summary>
        /// Gets the pair of book and its author
        /// </summary>
        /// <value>
        /// The pair of book and its author
        /// </value>
        public List<BookAuthorPair> GetPairBookAuthor
        {
            get
            {
                return this.pairBookAuthor;
            }
        }

        public void AddAuthor()
        {
        }

        public void AddAuthor(Author author)
        {
        }

        public void AddBook(Book book)
        {
        }

        public void AddBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
        }

        public void AddBookGenrePair(BookGenrePair pairBookGenre)
        {
        }

        public void AddGenre(Genre genre)
        {
        }

        public void RemoveAuthor(Author author)
        {
        }

        public void RemoveBook(Book book)
        {
        }

        public void RemoveBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
        }

        public void RemoveBookGenrePair(BookGenrePair pairBookGenre)
        {
        }

        public void RemoveGenre(Genre genre)
        {
        }

        public void Save()
        {
        }
    }
}