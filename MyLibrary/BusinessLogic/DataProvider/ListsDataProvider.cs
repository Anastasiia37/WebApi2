// <copyright file="ListsDataProvider.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.Collections.Generic;
using BusinessLogic.LibraryModel;

namespace BusinessLogic.DataProvider
{
    /// <summary>
    /// Data Provider for Library Service that provides data in a list
    /// </summary>
    /// <seealso cref="BusinessLogic.DataProvider.IDataProvider" />
    public class ListsDataProvider : IDataProvider
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
        private List<BookGenre> bookGenre;

        /// <summary>
        /// The books with authors
        /// </summary>
        private List<BookAuthor> bookAuthor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListsDataProvider"/> class.
        /// Fill books and authors by default values
        /// </summary>
        public ListsDataProvider()
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

            this.bookGenre = new List<BookGenre>()
            {
                new BookGenre(1, 1),         // id = 1
                new BookGenre(2, 6),         // id = 2
                new BookGenre(2, 1),         // id = 3
                new BookGenre(3, 5),         // id = 4
                new BookGenre(4, 1),         // id = 5
                new BookGenre(4, 6),         // id = 6
                new BookGenre(5, 3),         // id = 7
                new BookGenre(5, 2),         // id = 8
                new BookGenre(7, 8),         // id = 9
                new BookGenre(7, 2),         // id = 10
                new BookGenre(7, 6),         // id = 11
                new BookGenre(6, 7),         // id = 12
            };

            this.bookAuthor = new List<BookAuthor>()
            {
                new BookAuthor(1, 2),         // id = 1
                new BookAuthor(2, 1),         // id = 2
                new BookAuthor(2, 4),         // id = 3
                new BookAuthor(4, 3),         // id = 4
                new BookAuthor(4, 2),         // id = 5
                new BookAuthor(4, 6),         // id = 6
                new BookAuthor(5, 3),         // id = 7
                new BookAuthor(6, 4),         // id = 8
                new BookAuthor(7, 4),         // id = 9
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
        public List<BookGenre> GetBookGenre
        {
            get
            {
                return this.bookGenre;
            }
        }

        /// <summary>
        /// Gets the pair of book and its author
        /// </summary>
        /// <value>
        /// The pair of book and its author
        /// </value>
        public List<BookAuthor> GetBookAuthor
        {
            get
            {
                return this.bookAuthor;
            }
        }
    }
}