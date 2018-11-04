// <copyright file="BookService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using BusinessLogic.DataProvider;
using BusinessLogic.LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Book Services
    /// </summary>
    /// <seealso cref="BusinessLogic.LibraryService.LibraryService" />
    /// <seealso cref="BusinessLogic.LibraryService.IBookService" />
    public class BookService : LibraryService, IBookService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        public BookService(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        #region BookServices

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>
        /// The list of books
        /// </returns>
        public IEnumerable<Book> GetAll()
        {
            return this.books;
        }

        /// <summary>
        /// Gets the book by its identifier
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>
        /// Found book or null if there isn`t book with specified id</returns>
        public Book GetById(uint id)
        {
            return this.books.FirstOrDefault(book => book.Id == id);
        }

        /// <summary>
        /// Removes the book from the library,
        /// and all records in pairsBookAuthor and pairsBookGenre with such book id
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>
        /// The id of removed book or null if there isn`t book with such id
        /// </returns>
        public uint? Remove(uint id)
        {
            Book bookForDelete = this.books.FirstOrDefault(book => book.Id == id);
            if (bookForDelete == null)
            {
                return null;
            }

            this.pairsBookAuthor.RemoveAll(pair => pair.BookId == id);
            this.pairsBookGenre.RemoveAll(pair => pair.BookId == id);
            uint idOfDeletedBook = bookForDelete.Id;
            this.books.Remove(bookForDelete);
            return idOfDeletedBook;
        }

        /// <summary>
        /// Adds the book to the list of books
        /// </summary>
        /// <param name="book">The book</param>
        /// <returns>The id of the added book</returns>
        /// <exception cref="ArgumentException">The book with such id already exists!</exception>
        public uint Add(Book book)
        {
            if (this.books.Any(someBook => someBook.Id == book.Id))
            {
                throw new ArgumentException("The book with such id already exists!");
            }

            this.books.Add(book);
            return book.Id;
        }

        /// <summary>
        /// Updates the book`s information
        /// </summary>
        /// <param name="bookId">The author identifier</param>
        /// <param name="book">The book`s information</param>
        /// <returns>
        /// The id of the updated book or null if there isn`t any book with specified id
        /// </returns>
        public uint? Update(uint bookId, Book book)
        {
            Book bookForUpdate = this.books.FirstOrDefault(someBook => someBook.Id == bookId);
            if (bookForUpdate == null)
            {
                return null;
            }

            bookForUpdate.Name = book.Name;
            bookForUpdate.Year = book.Year;
            return bookForUpdate.Id;
        }

        #endregion BookServices

        #region BookAuthorPairService

        /// <summary>
        /// Adds the author to book
        /// </summary>
         /// <param name="bookId">The book identifier</param>
       /// <param name="authorId">The author identifier</param>
        /// <returns>
        /// The id of new record in pairsBookAuthor
        /// </returns>
        /// <exception cref="ArgumentException">Can`t find author with such id!
        /// or
        /// Can`t find book with such id!</exception>
        public uint AddAuthorToBook(uint bookId, uint authorId)
        {
            if (!this.authors.Any(someAuthor => someAuthor.Id == authorId))
            {
                throw new ArgumentException("Can`t find author with such id!");
            }

            if (!this.books.Any(someBook => someBook.Id == bookId))
            {
                throw new ArgumentException("Can`t find book with such id!");
            }

            if (this.pairsBookAuthor.Any(somePair => somePair.BookId == bookId & somePair.AuthorId == authorId))
            {
                throw new ArgumentException("Such book has such author!");
            }

            BookAuthorPair pairForAdding = new BookAuthorPair(bookId, authorId);
            this.pairsBookAuthor.Add(pairForAdding);
            return pairForAdding.Id;
        }

        /// <summary>
        /// Removes the author from book
        /// </summary>
        /// <param name="bookId">The book identifier</param>
        /// <param name="authorId">The author identifier</param>
        /// <returns>
        /// The id of removed record in Book-Author pair
        /// or null if there are any pair of specified book and author
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find author with such id!
        /// or
        /// Can`t find book with such id!
        /// </exception>
        public uint? RemoveAuthorFromBook(uint bookId, uint authorId)
        {
            if (!this.authors.Any(someAuthor => someAuthor.Id == authorId))
            {
                throw new ArgumentException("Can`t find author with such id!");
            }

            if (!this.books.Any(someBook => someBook.Id == bookId))
            {
                throw new ArgumentException("Can`t find book with such id!");
            }

            BookAuthorPair pairForRemoving = this.pairsBookAuthor.FirstOrDefault(
                pairBookAuthor => pairBookAuthor.AuthorId == authorId
                && pairBookAuthor.BookId == bookId);
            if (pairForRemoving == null)
            {
                return null;
            }

            uint removedPairId = pairForRemoving.Id;
            this.pairsBookAuthor.Remove(pairForRemoving);
            return removedPairId;
        }

        /// <summary>
        /// Get all books by specified author
        /// </summary>
        /// <param name="genreId">The author identifier</param>
        /// <returns>
        /// Enumeration of books
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find author with such id!
        /// </exception>
        public IEnumerable<Book> GetBooksByAuthor(uint authorId)
        {
            if (!this.authors.Any(someAuthor => someAuthor.Id == authorId))
            {
                throw new ArgumentException("Can`t find author with such id!");
            }

            var foundBooks = this.pairsBookAuthor.Where(entry => entry.AuthorId == authorId).
                Select(entry => this.GetById(entry.BookId));
            return foundBooks;
        }

        #endregion BookAuthorPairService

        #region BookGenrePairService

        /// <summary>
        /// Adds the genre to book
        /// </summary>
        /// <param name="bookId">The book identifier</param>
        /// <param name="genreId">The genre identifier</param>
        /// <returns>
        /// The id of new record in pairsBookGenre
        /// </returns>
        /// <exception cref="ArgumentException">Can`t find genre with such id!
        /// or
        /// Can`t find book with such id!</exception>
        public uint AddGenreToBook(uint bookId, uint genreId)
        {
            if (!this.genres.Any(someGenre => someGenre.Id == genreId))
            {
                throw new ArgumentException("Can`t find genre with such id!");
            }

            if (!this.books.Any(someBook => someBook.Id == bookId))
            {
                throw new ArgumentException("Can`t find book with such id!");
            }

            if (this.pairsBookGenre.Any(somePair => somePair.BookId == bookId & somePair.GenreId == genreId))
            {
                throw new ArgumentException("Such book has such genre!!");
            }

            BookGenrePair pairForAdding = new BookGenrePair(bookId, genreId);
            this.pairsBookGenre.Add(pairForAdding);
            return pairForAdding.Id;
        }

        /// <summary>
        /// Removes the genre from book
        /// </summary>
        /// <param name="bookId">The book identifier</param>
        /// <param name="genreId">The genre identifier</param>
        /// <returns>
        /// The id of removed record in Book-Genre pair
        /// or null if there are any pair of specified book and genre
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Can`t find genre with such id!
        /// or
        /// Can`t find book with such id!
        /// </exception>
        public uint? RemoveGenreFromBook(uint bookId, uint genreId)
        {
            if (!this.genres.Any(someGenre => someGenre.Id == genreId))
            {
                throw new ArgumentException("Can`t find genre with such id!");
            }

            if (!this.books.Any(someBook => someBook.Id == bookId))
            {
                throw new ArgumentException("Can`t find book with such id!");
            }

            BookGenrePair pairForRemoving = this.pairsBookGenre.FirstOrDefault(
                pairBookGenre => pairBookGenre.GenreId == genreId
                && pairBookGenre.BookId == bookId);
            if (pairForRemoving == null)
            {
                return null;
            }

            uint removedPairId = pairForRemoving.Id;
            this.pairsBookGenre.Remove(pairForRemoving);
            return removedPairId;
        }

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
        public IEnumerable<Book> GetBooksByGenre(uint genreId)
        {
            if (!this.genres.Any(someGenre => someGenre.Id == genreId))
            {
                throw new ArgumentException("Can`t find genre with such id!");
            }

            var foundBooks = this.pairsBookGenre.Where(entry => entry.GenreId == genreId).
                Select(entry => this.GetById(entry.BookId));
            return foundBooks;
        }

        #endregion BookGenrePairService
    }
}