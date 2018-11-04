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
        /// Initializes a new instance of the <see cref="InMemoryDataProvider"/> class
        /// Fill books and authors by default values
        /// </summary>
        public InMemoryDataProvider()
        {
            this.books = new List<Book>()
            {
                new Book("Book 1", 1950),           // id = 1
                new Book("Book 2", 1985),           // id = 2, has two authors
                new Book("Book 3", 2006),           // id = 3, has no author
                new Book("Book 4", 1955),           // id = 4, has three authors
                new Book("Book 5", 1850),           // id = 5
                new Book("Book 6", 1801),           // id = 6
                new Book("Book 7", 1777),           // id = 7
            };

            this.authors = new List<Author>()
            {
                new Author("Author 1"),              // id = 1
                new Author("Author 2"),              // id = 2
                new Author("Author 3"),              // id = 3
                new Author("Author 4"),              // id = 4
                new Author("Author 5"),              // id = 5, no book with such author
                new Author("Author 6"),              // id = 5, no book with such author
            };

            this.genres = new List<Genre>()
            {
                new Genre("Genre 1"),         // id = 1
                new Genre("Genre 2"),         // id = 2
                new Genre("Genre 3"),         // id = 3
                new Genre("Genre 4"),         // id = 4, no book with such genre
                new Genre("Genre 5"),         // id = 5
                new Genre("Genre 6"),         // id = 6
                new Genre("Genre 7"),         // id = 7
                new Genre("Genre 8"),         // id = 8
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

        /// <summary>
        /// Gets the genres
        /// </summary>
        /// <value>
        /// The genres
        /// </value>
        public List<Genre> Genres
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
        public List<BookGenrePair> PairsBookGenre
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
        public List<BookAuthorPair> PairsBookAuthor
        {
            get
            {
                return this.pairBookAuthor;
            }
        }

        /// <summary>
        /// Adds the author
        /// </summary>
        /// <param name="author">The author</param>
        public void AddAuthor(Author author)
        {
            authors.Add(author);
        }

        /// <summary>
        /// Adds the book
        /// </summary>
        /// <param name="book">The book</param>
        public void AddBook(Book book)
        {
            books.Add(book);
        }

        /// <summary>
        /// Adds the pair book-author
        /// </summary>
        /// <param name="pairBookAuthor">The pair book-author</param>
        public void AddBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
            this.pairBookAuthor.Add(pairBookAuthor);
        }

        /// <summary>
        /// Adds the book-genre pair
        /// </summary>
        /// <param name="pairBookGenre">The pair book-genre</param>
        public void AddBookGenrePair(BookGenrePair pairBookGenre)
        {
            this.pairBookGenre.Add(pairBookGenre);
        }

        /// <summary>
        /// Adds the genre
        /// </summary>
        /// <param name="genre">The genre</param>
        public void AddGenre(Genre genre)
        {
            this.genres.Add(genre);
        }

        /// <summary>
        /// Removes the author
        /// </summary>
        /// <param name="author">The author</param>
        public void RemoveAuthor(Author author)
        {
            this.authors.Remove(author);
        }

        /// <summary>
        /// Removes the book
        /// </summary>
        /// <param name="book">The book</param>
        public void RemoveBook(Book book)
        {
            this.books.Remove(book);
        }

        /// <summary>
        /// Removes the book-author pair
        /// </summary>
        /// <param name="pairBookAuthor">The pair book-author</param>
        public void RemoveBookAuthorPair(BookAuthorPair pairBookAuthor)
        {
            this.pairBookAuthor.Remove(pairBookAuthor);
        }

        /// <summary>
        /// Removes the book-genre pair
        /// </summary>
        /// <param name="pairBookGenre">The pair book-genre</param>
        public void RemoveBookGenrePair(BookGenrePair pairBookGenre)
        {
            this.pairBookGenre.Remove(pairBookGenre);
        }

        /// <summary>
        /// Removes the genre
        /// </summary>
        /// <param name="genre">The genre</param>
        public void RemoveGenre(Genre genre)
        {
            this.genres.Remove(genre);
        }

        /// <summary>
        /// Saves the changes in instance
        /// </summary>
        public void Save()
        {
        }
    }
}