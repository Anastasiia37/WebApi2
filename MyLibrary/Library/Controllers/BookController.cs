// <copyright file="BookController.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using BusinessLogic.LibraryModel;
using BusinessLogic.LibraryService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Controllers
{
    /// <summary>
    /// Controller for dealing with Book
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// The library service
        /// </summary>
        private IBookService libraryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class
        /// </summary>
        /// <param name="libraryService">The library service</param>
        public BookController(IBookService libraryService)
        {
            this.libraryService = libraryService;
        }

        #region Book

        // GET: api/book
        /// <summary>
        /// Gets all books from the Library
        /// </summary>
        /// <returns>
        /// HTTP status code Ok() with the list of books
        /// or HTTP status code NoContent() if there are any books in library
        /// </returns>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            if (this.libraryService.GetAll() != null)
            {
                return Ok(this.libraryService.GetAll());
            }

            return NoContent();
        }

        // GET: api/book/5
        /// <summary>
        /// Gets the book by its id
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>
        /// HTTP status code Ok() with found book
        /// or HTTP status code NotFound() if there isn`t book with such id
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult GetBook(uint id)
        {
            Book foundBook = this.libraryService.GetById(id);
            if (foundBook == null)
            {
                return NotFound("No books with such id!");
            }

            return Ok(foundBook);
        }

        // POST: api/book
        /// <summary>
        /// Adds the new book to the book list
        /// </summary>
        /// <param name="book">The book for adding</param>
        /// <returns>
        /// HTTP status code Created() with added book`s id
        /// or HTTP status code BadRequest() if the book with such id already exists
        /// </returns>
        [HttpPost]
        public IActionResult AddNewBook([FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid book input");
            }

            try
            {
                uint newBookId = this.libraryService.Add(book);
                return Created("book", newBookId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT: api/book/5
        /// <summary>
        /// Updates the book
        /// </summary>
        /// <param name="id">The author identifier</param>
        /// <param name="book">The author information</param>
        /// <returns>
        /// HTTP status code Ok() with updated book`s id
        /// or HTTP status code NotFound() if there is no books with specified id
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBook(uint bookId, [FromBody]Book book)
        {
            uint? updatedBookId = this.libraryService.Update(bookId, book);
            if (updatedBookId == null)
            {
                return NotFound("No books with such id!");
            }

            return Ok(updatedBookId);
        }

        // DELETE: api/book/5
        /// <summary>
        /// Deletes the book from the library
        /// </summary>
        /// <param name="id">The identifier of the book</param>
        /// <returns>
        /// HTTP status code Ok() with deleted book`s id
        /// or HTTP status code NotFound() if there are any book in library with specified id
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(uint id)
        {
            uint? deletedBookId = this.libraryService.Remove(id);
            if (deletedBookId == null)
            {
                return NotFound("No books with such id!");
            }

            return Ok(deletedBookId);
        }

        #endregion Book

        #region BookAuthorPair

        // POST: api/book/
        /// <summary>
        /// Adds the author to the book
        /// </summary>
        /// <param name="genreId">The author identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// HTTP status code Created() with id of new record in pairsBookAuthor
        /// or HTTP status code BadRequest() if the book with such id doesn`t exist
        /// or HTTP status code BadRequest() if the author with such id doesn`t exist
        /// </returns>
        [HttpPost("authorId={authorId}&bookId={bookId}")]
        public IActionResult AddAuthorToBook(uint authorId, uint bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            try
            {
                uint newPairBookAuthorId = this.libraryService.AddAuthorToBook(authorId, bookId);
                return Created("PairBookAuthor", newPairBookAuthorId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE: api/book/
        /// <summary>
        /// Removes the author from book
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// HTTP status code Ok() with removedPairBookAuthorId
        /// or HTTP status code NotFound() if there are o specified author in specified book
        /// or HTTP status code BadRequest() if there is no author or book with specified ids
        /// </returns>
        [HttpDelete("authorId={authorId}&bookId={bookId}")]
        public IActionResult RemoveAuthorFromBook(uint authorId, uint bookId)
        {
            try
            {
                uint? removedPairBookAuthorId = this.libraryService.RemoveAuthorFromBook(authorId, bookId);
                if (removedPairBookAuthorId == null)
                {
                    return NotFound("No specified author in specified book!");
                }

                return Ok(removedPairBookAuthorId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception);
            }
        }

        // GET: api/book/
        /// <summary>
        /// Get all books by specified author
        /// </summary>
        /// <param name="genreId">The author identifier</param>
        /// <returns>
        /// HTTP status code Ok() with list of found books
        /// or HTTP status code NotFound() if there are no books with such author
        /// </returns>
        [HttpGet("authorId={authorId}")]
        public IActionResult GetBooksByAuthor(uint authorId)
        {
            List<Book> foundBooks = new List<Book>();
            foundBooks = this.libraryService.GetBooksByAuthor(authorId).ToList();

            if (foundBooks == null)
            {
                return NotFound("No books with such author!");
            }

            return Ok(foundBooks);
        }

        #endregion BookAuthorPair

        #region BookGenrePair

        // POST: api/book/
        /// <summary>
        /// Adds the genre to the book
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// HTTP status code Created() with id of new record in pairsBookGenre
        /// or HTTP status code BadRequest() if the book with such id doesn`t exist
        /// or HTTP status code BadRequest() if the genre with such id doesn`t exist
        /// </returns>
        [HttpPost("genreId={genreId}&bookId={bookId}")]
        public IActionResult AddGenreToBook(uint genreId, uint bookId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input");
            }

            try
            {
                uint newPairBookGenreId = this.libraryService.AddGenreToBook(genreId, bookId);
                return Created("PairBookAuthor", newPairBookGenreId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE: api/book/
        /// <summary>
        /// Removes the genre from book
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <param name="bookId">The book identifier</param>
        /// <returns>
        /// HTTP status code Ok() with removedPairBookGenreId
        /// or HTTP status code NotFound() if there are o specified genre in specified book
        /// or HTTP status code BadRequest() if there is no author or book with specified ids
        /// </returns>
        [HttpDelete("genreId={genreId}&bookId={bookId}")]
        public IActionResult RemoveGenreFromBook(uint genreId, uint bookId)
        {
            try
            {
                uint? removedPairBookGenreId = this.libraryService.RemoveGenreFromBook(genreId, bookId);
                if (removedPairBookGenreId == null)
                {
                    return NotFound("No specified genre in specified book!");
                }

                return Ok(removedPairBookGenreId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception);
            }
        }

        // GET: api/book/
        /// <summary>
        /// Get all books by specified genre
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <returns>
        /// HTTP status code Ok() with list of found books
        /// or HTTP status code NotFound() if there are no books with such genre
        /// </returns>
        [HttpGet("genreId={genreId}")]
        public IActionResult GetBooksByGenre(uint genreId)
        {
            List<Book> foundBooks = new List<Book>();
            foundBooks = this.libraryService.GetBooksByGenre(genreId).ToList();

            if (foundBooks == null)
            {
                return NotFound("No books with such author!");
            }

            return Ok(foundBooks);
        }

        #endregion BookGenrePair
    }
}