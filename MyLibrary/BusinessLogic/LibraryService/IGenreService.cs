using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.LibraryModel;

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Interface for services connected to Genre
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Gets all genres
        /// </summary>
        /// <returns>The list of genres</returns>
        IEnumerable<Genre> GetAllGenres();

        /// <summary>
        /// Gets the genre by identifier
        /// </summary>
        /// <param name="id">The identifier of genre</param>
        /// <returns>Genre with specified id</returns>
       Genre GetGenreById(uint id);

        /// <summary>
        /// Adds the genre to the list of genres
        /// </summary>
        /// <param name="genre">The genre</param>
        /// <returns>The id of the genre</returns>
        uint AddGenre(Genre genre);

        /// <summary>
        /// Updates the genre
        /// </summary>
        /// <param name="genreId">The genre identifier</param>
        /// <param name="genre">The new genre</param>
        /// <returns>The id of updated genre or null if there isn`t genre with specified id</returns>
        uint? UpdateGenre(uint genreId, Genre genre);

        /// <summary>
        /// Removes the genre
        /// </summary>
        /// <param name="id">The identifier of genre</param>
        /// <returns>
        /// The id of genre
        /// or null if there is not genre with such id
        /// or null if books of specified genre exists
        /// </returns>
        uint? RemoveGenre(uint id);
    }
}