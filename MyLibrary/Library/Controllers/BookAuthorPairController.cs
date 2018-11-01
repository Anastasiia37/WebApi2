// <copyright file="BookAuthorPairController.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections;
using BusinessLogic.LibraryModel;
using BusinessLogic.LibraryService;
using Microsoft.AspNetCore.Mvc;

namespace MyWebLibrary.Controllers
{
    /// <summary>
    /// Controller for dealing with <see cref="BookAuthorPair" />
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorPairController : ControllerBase
    {
        /// <summary>
        /// The library service
        /// </summary>
        private ILibraryService libraryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookAuthorPairController" /> class
        /// </summary>
        /// <param name="libraryService">The library service</param>
        public BookAuthorPairController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        // GET: api/bookauthorpair
        /// <summary>
        /// Gets all pairs Book-Author from the Library
        /// </summary>
        /// <returns>
        /// HTTP status code Ok() with the list of pairs Book-Author
        /// or HTTP status code NoContent() if there are any pairs of Book-Author in library
        /// </returns>
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            if (this.libraryService.GetAllBookAuthorPair() != null)
            {
                return Ok(this.libraryService.GetAllBookAuthorPair());
            }

            return NoContent();
        }

        // POST: api/bookauthorpair
        /// <summary>
        /// Adds the author to the book
        /// </summary>
        /// <param name="authorId">The author identifier</param>
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

        // DELETE: api/bookauthorpair
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

        // GET: api/bookauthorpair/5
        /// <summary>
        /// Get all books by specified author
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <returns>
        /// HTTP status code Ok() with list of found books
        /// or HTTP status code NotFound() if there are no books with such author
        /// </returns>
        [HttpGet("{authorId}")]
        public IActionResult GetBooksByAuthor(uint authorId)
        {
            List<Book> foundBooks = new List<Book>();
            foreach (var book in this.libraryService.GetBooksByAuthor(authorId))
            {
                foundBooks.Add(book);
            }

            if (foundBooks == null)
            {
                return NotFound("No books with such author!");
            }

            return Ok(foundBooks);
        }
    }
}