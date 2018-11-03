// <copyright file="GenreService.cs" company="Peretiatko Anastasiia">
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
    /// Genre services
    /// </summary>
    /// <seealso cref="BusinessLogic.LibraryService.LibraryService" />
    /// <seealso cref="BusinessLogic.LibraryService.IGenreService" />
    public class GenreService : LibraryService, IGenreService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenreService"/> class
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        public GenreService(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        #region GenreServices

        /// <summary>
        /// Gets all genres
        /// </summary>
        /// <returns>The list of genres in Library</returns>
        public IEnumerable<Genre> GetAll()
        {
            return this.genres;
        }

        /// <summary>
        /// Gets the genre by identifier
        /// </summary>
        /// <param name="id">The genre identifier</param>
        /// <returns>The found genre or null if there is no such genre in library</returns>
        public Genre GetById(uint id)
        {
            return this.genres.FirstOrDefault(genre => genre.Id == id);
        }

        /// <summary>
        /// Adds the genre to Library
        /// </summary>
        /// <param name="genre">The genre for adding</param>
        /// <returns>The id of added genre</returns>
        /// <exception cref="System.ArgumentException">The genre with such id already exists!</exception>
        public uint Add(Genre genre)
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
        public uint? Update(uint genreId, Genre genre)
        {
            Genre genreForUpdate = this.genres.FirstOrDefault(someGenre => someGenre.Id == genreId);
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
        public uint? Remove(uint id)
        {
            Genre genreForDelete = this.genres.FirstOrDefault(genre => genre.Id == id);
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

        #endregion GenreServices
    }
}