// <copyright file="GenreController.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using BusinessLogic.LibraryModel;
using BusinessLogic.LibraryService;
using Microsoft.AspNetCore.Mvc;

namespace MyWebLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        /// <summary>
        /// The library service
        /// </summary>
        private ILibraryService libraryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenreController"/> class
        /// </summary>
        /// <param name="libraryService">The library service</param>
        public GenreController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        // GET: api/genre
        /// <summary>
        /// Gets all genres from the Library
        /// </summary>
        /// <returns>
        /// HTTP status code Ok() with the list of genres
        /// or HTTP status code NoContent() if there are any genres in library
        /// </returns>
        [HttpGet]
        public IActionResult GetAllGenres()
        {
            if (this.libraryService.GetAllGenres() != null)
            {
                return Ok(this.libraryService.GetAllGenres());
            }

            return NoContent();
        }

        // GET: api/genre/5
        /// <summary>
        /// Gets the genre by its id
        /// </summary>
        /// <param name="id">The identifier of the genre</param>
        /// <returns>
        /// HTTP status code Ok() with found genre
        /// or HTTP status code NotFound() if there isn`t genre with such id
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult GetGenreById(uint id)
        {
            Genre foundGenre = this.libraryService.GetGenreById(id);
            if (foundGenre == null)
            {
                return NotFound("No genres with such id!");
            }

            return Ok(foundGenre);
        }

        // POST: api/genre
        /// <summary>
        /// Adds the new genre to the genre list
        /// </summary>
        /// <param name="genre">The genre for adding</param>
        /// <returns>
        /// HTTP status code Created() with added genre`s id
        /// or HTTP status code BadRequest() if the genre with such id already exists
        /// </returns>
        [HttpPost]
        public IActionResult AddNewGenre([FromBody]Genre genre)
        {
            // ???
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid genre input");
            }

            try
            {
                uint newGenreId = this.libraryService.AddGenre(genre);
                return Created("genre", newGenreId);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT: api/genre/5
        /// <summary>
        /// Updates the genre
        /// </summary>
        /// <param name="id">The genre identifier</param>
        /// <param name="genre">The genre information</param>
        /// <returns>
        /// HTTP status code Ok() with updated genre`s id
        /// or HTTP status code NotFound() if there is no genres with specified id
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(uint id, [FromBody]Genre genre)
        {
            uint? updatedGenreId = this.libraryService.UpdateGenre(id, genre);
            if (updatedGenreId == null)
            {
                return NotFound("No genres with such id!");
            }

            return Ok(updatedGenreId);
        }

        // DELETE: api/genre/5
        /// <summary>
        /// Deletes the genre from the library
        /// </summary>
        /// <param name="id">The identifier of the genre</param>
        /// <returns>
        /// HTTP status code Ok() with the id of deleted genre
        /// or HTTP status code NotFound() if there are any genre in library with specified id
        /// or HTTP status code BadRequest() if books with specified genre exist
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult RemoveGenre(uint id)
        {
            try
            {
                uint? idOfDeletedGenre = this.libraryService.RemoveGenre(id);
                if (idOfDeletedGenre == null)
                {
                    return NotFound("No genres with such id!");
                }

                return Ok(idOfDeletedGenre);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}