// <copyright file="IAuthorService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.Collections.Generic;
using BusinessLogic.LibraryModel;

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Interface for services connected to Author
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns>The list of authors</returns>
        IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Gets the author by identifier
        /// </summary>
        /// <param name="id">The identifier of the author</param>
        /// <returns>The instance of Author</returns>
        Author GetAuthorById(uint id);

        /// <summary>
        /// Adds the author
        /// </summary>
        /// <param name="author">The author</param>
        /// <returns>The id of added author</returns>
        uint AddAuthor(Author author);

        /// <summary>
        /// Updates the author
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <param name="author">The new author</param>
        /// <returns>The id of updated author or null if there isn`t author with specified id</returns>
        uint? UpdateAuthor(uint authorId, Author author);

        /// <summary>
        /// Removes the author
        /// </summary>
        /// <param name="authorId">The author identifier</param>
        /// <returns>
        /// Number of book deletings with such author
        /// or null if there isn`t author with specified id
        /// </returns>
        uint? RemoveAuthor(uint authorId);
    }
}