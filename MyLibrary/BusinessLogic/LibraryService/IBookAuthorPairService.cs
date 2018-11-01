// <copyright file="IBookAuthorPairService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using BusinessLogic.LibraryModel;

namespace BusinessLogic.LibraryService
{
    public interface IBookAuthorPairService
    {
        /// <summary>
        /// Gets all book-author pairs from the library
        /// </summary>
        /// <returns>The list of all book-author pairs</returns>
        IEnumerable<BookAuthorPair> GetAllBookAuthorPair();

        /// <summary>
        /// Adds the author to book
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// The id of new record in pairsBookAuthor
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find author with such id!
        /// or
        /// Can`t find book with such id!
        /// </exception>
        uint AddAuthorToBook(uint authorId, uint bookId);

        /// <summary>
        /// Removes the author from book
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// The id of removed record in Book-Author pair
        /// or null if there are any pair of specified book and author
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find author with such id!
        /// or
        /// Can`t find book with such id!
        /// </exception>
        uint? RemoveAuthorFromBook(uint authorId, uint bookId);

        /// <summary>
        /// Get all books by specified author
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <returns>
        /// Enumeration of books
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find author with such id!
        /// </exception>
        IEnumerable<Book> GetBooksByAuthor(uint authorId);
    }
}
