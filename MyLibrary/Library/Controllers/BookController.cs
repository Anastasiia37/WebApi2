// <copyright file="BookController.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using BusinessLogic.LibraryModel;
using BusinessLogic.LibraryService;
using Microsoft.AspNetCore.Mvc;

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
        private ILibraryService libraryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class
        /// </summary>
        /// <param name="libraryService">The library service</param>
        public BookController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

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
            if (this.libraryService.GetAllBooks() != null)
            {
                return Ok(this.libraryService.GetAllBooks());
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
            Book foundBook = this.libraryService.GetBookById(id);
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
        /// or HTTP status code BadRequest() with error message
        /// </returns>
        [HttpPost]
        public IActionResult AddNewBook([FromBody]Book book)
        {
            // ???
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid book input");
            }

            try
            {
                uint newBookId = this.libraryService.AddBook(book);
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
        /// <param name="bookId">The book identifier</param>
        /// <param name="newBookName">New name of the book</param>
        /// <param name="newBookYear">The new publising year of the book</param>
        /// <param name="newAuthorId">The new author identifier of the book</param>
        /// <returns>
        /// HTTP status code Ok() with updated book`s id
        /// or HTTP status code NotFound() if there is no books with specified id
        /// or HTTP status code BadRequest if there is no authors with specified new id</returns>
        [HttpPut("{bookId}/{newBookName}/{newBookYear}/{newAuthorId}")]
        public IActionResult UpdateBook(uint bookId, string newBookName, int newBookYear,
                               uint? newAuthorId = null)
        {
            try
            {
                uint? updatedBookId = this.libraryService.UpdateBook(bookId,
                    newBookName, newBookYear, newAuthorId);
                if (updatedBookId == null)
                {
                    return NotFound("No books with such id!");
                }

                return Ok(bookId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
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
            uint? deletedBookId = this.libraryService.RemoveBook(id);
            if (deletedBookId == null)
            {
                return NotFound("No books with such id!");
            }

            return Ok(deletedBookId);
        }
    }
}
