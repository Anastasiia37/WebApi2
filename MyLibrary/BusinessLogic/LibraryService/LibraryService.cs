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
        private List<BookGenrePair> pairsBookGenre;

        /// <summary>
        /// The books with authors
        /// </summary>
        private List<BookAuthorPair> pairsBookAuthor;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        public LibraryService(IDataProvider dataProvider)
        {
            this.books = dataProvider.GetBooks;
            this.authors = dataProvider.GetAuthors;
            this.genres = dataProvider.GetGenres;
            this.pairsBookAuthor = dataProvider.GetPairBookAuthor;
            this.pairsBookGenre = dataProvider.GetPairBookGenre;
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
        /// Removes the book from the library,
        /// and all records in pairsBookAuthor and pairsBookGenre with such book id
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>
        /// The id of removed book or null if there isn`t book with such id
        /// </returns>
        public uint? RemoveBook(uint id)
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
        /// Removes the author if there are no books of such author in the library
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <returns>
        /// Number of deleted books with such author
        /// or null if there isn`t author with specified id
        /// </returns>
        public uint? RemoveAuthor(uint authorId)
        {
            Author authorForDelete = this.authors.FirstOrDefault(author => author.Id == authorId);
            if (authorForDelete != null)
            {
                this.pairsBookAuthor.RemoveAll(pair => pair.AuthorId == authorId);
                this.authors.Remove(authorForDelete);
                return authorId;
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
            if (this.genres.Any(someGenre => someGenre.Id == genre.Id))
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
                if (this.pairsBookGenre.Any(someBookGenre => someBookGenre.GenreId == id))
                {
                    throw new ArgumentException("Can`t remove this genre because books with this genre exist!");
                }

                this.genres.Remove(genreForDelete);

                return genreForDelete.Id;
            }

            return null;
        }
        #endregion

        #region BookAuthorPairService
        /// <summary>
        /// Gets all book-author pairs from the library
        /// </summary>
        /// <returns>The list of all book-author pairs</returns>
        public IEnumerable<BookAuthorPair> GetAllBookAuthorPair()
        {
            return this.pairsBookAuthor;
        }

        /// <summary>
        /// Adds the author to book
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// The id of new record in pairsBookAuthor
        /// </returns>
        /// <exception cref="ArgumentException">Can`t find author with such id!
        /// or
        /// Can`t find book with such id!</exception>
        public uint AddAuthorToBook(uint authorId, uint bookId)
        {
            if (!this.authors.Any(someAuthor => someAuthor.Id == authorId))
            {
                throw new ArgumentException("Can`t find author with such id!");
            }

            if (!this.books.Any(someBook => someBook.Id == bookId))
            {
                throw new ArgumentException("Can`t find book with such id!");
            }

            BookAuthorPair pairForAdding = new BookAuthorPair(bookId, authorId);
            this.pairsBookAuthor.Add(pairForAdding);
            return pairForAdding.Id;
        }

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
        public uint? RemoveAuthorFromBook(uint authorId, uint bookId)
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
        /// <param name="authorId">The author identifier</param>
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

            var booksId = from entry in pairsBookAuthor
                                        where entry.AuthorId == authorId
                                        select GetBookById(entry.BookId);
            return booksId;
            /*foreach (uint bookId in booksId)
            {
                yield return GetBookById(bookId);
            }*/
        }
        #endregion
    }
}