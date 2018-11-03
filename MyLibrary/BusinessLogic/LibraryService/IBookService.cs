// <copyright file="IBookService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using BusinessLogic.LibraryModel;
using System.Collections.Generic;

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Interface for services connected to Book
    /// </summary>
    public interface IBookService : ILibraryService<Book>
    {
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

        /// <summary>
        /// Adds the genre to book
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// The id of new record in pairsBookGenre
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find genre with such id!
        /// or
        /// Can`t find book with such id!
        /// </exception>
        uint AddGenreToBook(uint genreId, uint bookId);

        /// <summary>
        /// Removes the genre from book
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// The id of removed record in Book-Genre pair
        /// or null if there are any pair of specified book and genre
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find genre with such id!
        /// or
        /// Can`t find book with such id!
        /// </exception>
        uint? RemoveGenreFromBook(uint genreId, uint bookId);

        /// <summary>
        /// Get all books by specified genre
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <returns>
        /// Enumeration of books
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find genre with such id!
        /// </exception>
        IEnumerable<Book> GetBooksByGenre(uint genreId);
    }
}