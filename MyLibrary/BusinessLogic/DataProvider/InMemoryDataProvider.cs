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
        /// Initializes a new instance of the <see cref="InMemoryDataProvider"/> class.
        /// Fill books and authors by default values
        /// </summary>
        public InMemoryDataProvider()
        {
            this.books = new List<Book>()
            {
                new Book("Я, робот", 1950, 2),          // id = 1
                new Book("Мир одного дня", 1985, 1),    // id = 2
                new Book("Сказки", 2006),               // id = 3
                new Book("Конец вечности", 1955, 2),    // id = 4
                new Book("Красное и черное", 1850, 3),  // id = 5
                new Book("Вий", 1801, 4),               // id = 6
                new Book("Мертвые души", 1777, 4),      // id = 7
            };

            this.authors = new List<Author>()
            {
                new Author("Филип Фармер"),              // id = 1
                new Author("Айзек Азимов"),              // id = 2
                new Author("Стендаль"),                  // id = 3
                new Author("Николай Васильевич Гоголь"), // id = 4
                new Author("Роберт Шекли"),              // id = 5
            };
        }

        /// <summary>
        /// Gets the books
        /// </summary>
        /// <value>
        /// The books
        /// </value>
        public List<Book> Books
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
        public List<Author> Authors
        {
            get
            {
                return this.authors;
            }
        }
    }
}