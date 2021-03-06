﻿// <copyright file="AuthorController.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using BusinessLogic.LibraryModel;
using BusinessLogic.LibraryService;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    /// <summary>
    /// Controller for dealing with Author
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// The library service
        /// </summary>
        private ILibraryService libraryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorController"/> class
        /// </summary>
        /// <param name="libraryService">The library services</param>
        public AuthorController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        // GET: api/author
        /// <summary>
        /// Gets all authors from the Library
        /// </summary>
        /// <returns>
        /// HTTP status code Ok() with the list of authors
        /// or HTTP status code NoContent() if there are any authors in library
        /// </returns>
        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            if (this.libraryService.GetAllAuthors() != null)
            {
                return Ok(this.libraryService.GetAllAuthors());
            }

            return NoContent();
        }

        // GET: api/author/5
        /// <summary>
        /// Gets the author by its id
        /// </summary>
        /// <param name="id">The identifier of the author</param>
        /// <returns>
        /// HTTP status code Ok() with found author
        /// or HTTP status code NotFound() if there isn`t author with such id
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(uint id)
        {
            Author foundAuthor = this.libraryService.GetAuthorById(id);
            if (foundAuthor == null)
            {
                return NotFound("No authors with such id!");
            }

            return Ok(foundAuthor);
        }

        // POST: api/author
        /// <summary>
        /// Adds the new author to the author list
        /// </summary>
        /// <param name="author">The new author</param>
        /// <returns>
        /// HTTP status code Created() with added author`s id
        /// or HTTP status code BadRequest() with error message
        /// </returns>
        [HttpPost]
        public IActionResult AddNewAuthor([FromBody]Author author)
        {
            ///???
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid author input");
            }

            try
            {
                uint newAuthorId = this.libraryService.AddAuthor(author);
                return Created("author", newAuthorId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT: api/author/5
        /// <summary>
        /// Updates the author
        /// </summary>
        /// <param name="id">The author identifier</param>
        /// <param name="author">The author information</param>
        /// <returns>
        /// HTTP status code Ok() with updated author`s id
        /// or HTTP status code NotFound() if there is no authors with specified id
        /// or HTTP status code BadRequest() if trying to update author`s id
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(uint id, [FromBody]Author author)
        {
            try
            {
                uint? updatedAuthorId = this.libraryService.UpdateAuthor(id, author);
                if (updatedAuthorId == null)
                {
                    return NotFound("No authors with such id!");
                }

                return Ok(updatedAuthorId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE: api/author/5
        /// <summary>
        /// Deletes the author from the library
        /// </summary>
        /// <param name="id">The identifier of the author</param>
        /// <returns>
        /// HTTP status code Ok() with the number of deleted books
        /// or HTTP status code NotFound() if there are any author in library with specified id
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult RemoveAuthor(uint id)
        {
            int? numberOfDeletedBooks = this.libraryService.RemoveAuthor(id);
            if (numberOfDeletedBooks == null)
            {
                return NotFound("No authors with such id!");
            }

            return Ok($"{numberOfDeletedBooks} books were removed with author");
        }
    }
}