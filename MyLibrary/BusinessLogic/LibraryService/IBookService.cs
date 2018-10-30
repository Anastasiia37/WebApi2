// <copyright file="IBookService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.Collections.Generic;
using BusinessLogic.LibraryModel;

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Interface for services connected to Book
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>The list of books</returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// Gets the book by identifier
        /// </summary>
        /// <param name="id">The identifier of book</param>
        /// <returns>Book with specified id</returns>
        Book GetBookById(uint id);

        /// <summary>
        /// Removes the book
        /// </summary>
        /// <param name="id">The identifier of book</param>
        /// <returns>
        /// The id of removed book or null if there isn`t book with such id
        /// </returns>
        uint? RemoveBook(uint id);

        /// <summary>
        /// Creates the book
        /// </summary>
        /// <param name="bookName">Name of the book</param>
        /// <param name="year">The year of publishing the book</param>
        /// <param name="authorId">The book`s author identifier</param>
        /// <returns>The instance of type Book</returns>
        /// <exception cref="ArgumentException">Can`t create book! Invalid author id!</exception>
        Book CreateBook(string bookName, int year, uint? authorId = null);

        /// <summary>
        /// Adds the book to the list of books
        /// </summary>
        /// <param name="book">The book</param>
        /// <returns>The id of the added book</returns>
        uint AddBook(Book book);

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
        uint? UpdateBook(uint bookId, string newBookName, int newBookYear, uint? newAuthorId = null);
    }
}