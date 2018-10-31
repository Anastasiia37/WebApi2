// <copyright file="LibraryService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataProvider;
using BusinessLogic.LibraryModel;

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Library Services
    /// </summary>
    /// <seealso cref="BusinessLogic.LibraryService.ILibraryService" />
    public class LibraryService : ILibraryService
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
        /// Initializes a new instance of the <see cref="LibraryService"/> class
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        public LibraryService(IDataProvider dataProvider)
        {
            this.books = dataProvider.Books;
            this.authors = dataProvider.Authors;
        }

        #region BookServices

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>
        /// The list of books
        /// </returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return this.books;
        }

        /// <summary>
        /// Gets the book by its identifier
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>
        /// Found book or null if there isn`t book with specified id</returns>
        public Book GetBookById(uint id)
        {
            return this.books.Find(book => book.Id == id);
        }

        /// <summary>
        /// Removes the book from the library
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>
        /// The id of removed book or null if there isn`t book with such id
        /// </returns>
        public uint? RemoveBook(uint id)
        {
            Book bookForDelete = this.books.Find(book => book.Id == id);
            if (bookForDelete == null)
            {
                return null;
            }

            uint DeletedBookId = bookForDelete.Id;
            this.books.Remove(bookForDelete);
            return DeletedBookId;
        }

        /// <summary>
        /// Adds the book to the list of books
        /// </summary>
        /// <param name="book">The book</param>
        /// <returns>The id of the added book</returns>
        /// <exception cref="ArgumentException">Don`t have author with such id!</exception>
        public uint AddBook(Book book)
        {
            if (!this.authors.Any(author => author.Id == book.AuthorId)
                && book.AuthorId != null)
            {
                throw new ArgumentException("Don`t have author with such id!");
            }

            if (this.books.Any(someBook => someBook.Id == book.Id))
            {
                throw new ArgumentException("The book with such id already exists!");
            }

            this.books.Add(book);
            return book.Id;
        }

        /// <summary>
        /// Updates the book
        /// </summary>
        /// <param name="bookId">The identifier of the book for updating</param>
        /// <param name="newBookName">New name of the book</param>
        /// <param name="newBookYear">The new publishing year of the book</param>
        /// <param name="newAuthorId">The new author identifier of the book</param>
        /// <returns>
        /// The id of the updated book or null if there isn`t any book with specified id
        /// </returns>
        /// <exception cref="ArgumentException">Don`t have author with such id!</exception>
        public uint? UpdateBook(uint bookId, string newBookName, int newBookYear, uint? newAuthorId = null)
        {
            Book bookForUpdate = this.books.Find(book => book.Id == bookId);
            if (bookForUpdate == null)
            {
                return null;
            }

            bookForUpdate.Name = newBookName;
            bookForUpdate.Year = newBookYear;
            if (!this.authors.Any(author => author.Id == newAuthorId)
                && newAuthorId != null)
            {
                throw new ArgumentException("Can`t update book! Don`t have author with such id!");
            }

            bookForUpdate.AuthorId = newAuthorId;
            return bookId;
        }

        #endregion BookServices

        #region AuthorServices

        /// <summary>
        /// Gets all authors from the library
        /// </summary>
        /// <returns>The list of all authors</returns>
        public IEnumerable<Author> GetAllAuthors()
        {
            return this.authors;
        }

        /// <summary>
        /// Gets the author by identifier
        /// </summary>
        /// <param name="id">The identifier of author</param>
        /// <returns>The author</returns>
        public Author GetAuthorById(uint id)
        {
            return this.authors.Find(author => author.Id == id);
        }

        /// <summary>
        /// Adds the author to the author list
        /// </summary>
        /// <param name="author">The new author</param>
        /// <returns>The id of added author</returns>
        /// <exception cref="ArgumentException">The author with such id already exists!</exception>
        public uint AddAuthor(Author author)
        {
            if (this.authors.Any(someAuthor => someAuthor.Id == author.Id))
            {
                throw new ArgumentException("The author with such id already exists!");
            }

            this.authors.Add(author);
            return author.Id;
        }

        /// <summary>
        /// Updates the author`s information
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <param name="author">The author`s information</param>
        /// <returns>
        /// The id of updated author or null if there isn`t author with specified id
        /// </returns>
        /// <exception cref="ArgumentException">You can`t update author`s id!</exception>
        public uint? UpdateAuthor(uint authorId, Author author)
        {
            Author authorForUpdate = this.authors.Find(someAuthor => someAuthor.Id == authorId);
            if (authorForUpdate == null)
            {
                return null;
            }

            authorForUpdate.FullName = author.FullName;
            return authorForUpdate.Id;
        }

        /// <summary>
        /// Removes the author from the library
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <returns>
        /// Number of book deletings with such author
        /// or null if there isn`t author with specified id
        /// </returns>
        public int? RemoveAuthor(uint authorId)
        {
            Author authorForDelete = this.authors.Find(author => author.Id == authorId);
            if (authorForDelete != null)
            {
                int numberOfBookDeletions = 0;
                numberOfBookDeletions = this.books.RemoveAll(book => book.AuthorId == authorId);
                this.authors.Remove(authorForDelete);

                return numberOfBookDeletions;
            }

            return null;
        }

        #endregion AuthorServices
    }
}
