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
        /// Initializes a new instance of the <see cref="LibraryService"/> class
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        public LibraryService(IDataProvider dataProvider)
        {
            this.books = dataProvider.GetBooks;
            this.authors = dataProvider.GetAuthors;
            this.genres = dataProvider.GetGenres;
            this.bookAuthor = dataProvider.GetBookAuthor;
            this.bookGenre = dataProvider.GetBookGenre;
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

            uint idOfDeletedBook = bookForDelete.Id;
            this.books.Remove(bookForDelete);
            return idOfDeletedBook;
        }

        /// <summary>
        /// Creates the book
        /// </summary>
        /// <param name="bookName">Name of the book</param>
        /// <param name="year">The year of publishing the book</param>
        /// <returns>The instance of type Book</returns>
        public Book CreateBook(string bookName, int year)
        {
            return new Book(bookName, year);
        }

        /// <summary>
        /// Adds the book to the list of books
        /// </summary>
        /// <param name="book">The book</param>
        /// <returns>The id of the added book</returns>
        /// <exception cref="ArgumentException">The book with such id already exists!</exception>
        public uint AddBook(Book book)
        {
            if (this.books.Where(someBook => someBook.Id == book.Id).Any())
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
        /// <returns>
        /// The id of the updated book or null if there isn`t any book with specified id
        /// </returns>
        public uint? UpdateBook(uint bookId, string newBookName, int newBookYear)
        {
            Book bookForUpdate = this.books.Find(book => book.Id == bookId);
            if (bookForUpdate == null)
            {
                return null;
            }

            bookForUpdate.Name = newBookName;
            bookForUpdate.Year = newBookYear;
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
            if (this.authors.Where(someAuthor => someAuthor.Id == author.Id).Any())
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
        /// Number of deleted books with such author
        /// or null if there isn`t author with specified id
        /// </returns>
        public int? RemoveAuthor(uint authorId)
        {
            Author authorForDelete = this.authors.Find(author => author.Id == authorId);
            if (authorForDelete != null)
            {
                int numberOfBookDeletions = 0;
                this.genres.Where(someGenre => someGenre.Id == genre.Id).Any()


                //????????????????????
                // numberOfBookDeletions = this.books.RemoveAll(book => book.AuthorId == authorId);

                this.authors.Remove(authorForDelete);

                return numberOfBookDeletions;
            }

            return null;
        }
        #endregion AuthorServices

        #region GenreServices

        /// <summary>
        /// Gets all genres
        /// </summary>
        /// <returns>The list of genres in Library</returns>
        public IEnumerable<Genre> GetAllGenres()
        {
            return this.genres;
        }

        /// <summary>
        /// Gets the genre by identifier
        /// </summary>
        /// <param name="id">The genre identifier</param>
        /// <returns>The found genre or null if there is no such genre in library</returns>
        public Genre GetGenreById(uint id)
        {
            return this.genres.Find(genre => genre.Id == id);
        }

        /// <summary>
        /// Adds the genre to Library
        /// </summary>
        /// <param name="genre">The genre for adding</param>
        /// <returns>The id of added genre</returns>
        /// <exception cref="System.ArgumentException">The genre with such id already exists!</exception>
        public uint AddGenre(Genre genre)
        {
            if (this.genres.Where(someGenre => someGenre.Id == genre.Id).Any())
            {
                throw new ArgumentException("The genre with such id already exists!");
            }

            this.genres.Add(genre);
            return genre.Id;
        }

        /// <summary>
        /// Updates the genre
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <param name="genre">The new genre</param>
        /// <returns>The id of updated genre or null if there is no genre with specified id</returns>
        public uint? UpdateGenre(uint genreId, Genre genre)
        {
            Genre genreForUpdate = this.genres.Find(someGenre => someGenre.Id == genreId);
            if (genreForUpdate == null)
            {
                return null;
            }

            genreForUpdate.Name = genre.Name;
            return genreForUpdate.Id;
        }

        /// <summary>
        /// Removes the genre
        /// </summary>
        /// <param name="id">The identifier of genre for removing</param>
        /// <returns>
        /// The id of deleted genre or null if there are no such genre
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Can`t remove this genre because books with this genre exist!
        /// </exception>
        public uint? RemoveGenre(uint id)
        {
            Genre genreForDelete = this.genres.Find(genre => genre.Id == id);
            if (genreForDelete != null)
            {
                if (this.bookGenre.Where(someBookGenre => someBookGenre.GenreId == id).Any())
                {
                    throw new ArgumentException("Can`t remove this genre because books with this genre exist!");
                }

                this.genres.Remove(genreForDelete);

                return genreForDelete.Id;
            }

            return null;
        }
        #endregion
    }
}