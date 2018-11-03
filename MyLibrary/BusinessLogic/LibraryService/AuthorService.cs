// <copyright file="AuthorService.cs" company="Peretiatko Anastasiia">
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
    /// Author Services
    /// </summary>
    /// <seealso cref="BusinessLogic.LibraryService.LibraryService" />
    /// <seealso cref="BusinessLogic.LibraryService.IAuthorService" />
    public class AuthorService : LibraryService, IAuthorService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorService"/> class
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        public AuthorService(IDataProvider dataProvider) : base(dataProvider)
        {
        }

        #region AuthorServices

        /// <summary>
        /// Gets all authors from the library
        /// </summary>
        /// <returns>The list of all authors</returns>
        public IEnumerable<Author> GetAll()
        {
            return this.authors;
        }

        /// <summary>
        /// Gets the author by identifier
        /// </summary>
        /// <param name="id">The identifier of author</param>
        /// <returns>The author</returns>
        public Author GetById(uint id)
        {
            return this.authors.FirstOrDefault(author => author.Id == id);
        }

        /// <summary>
        /// Adds the author to the author list
        /// </summary>
        /// <param name="author">The new author</param>
        /// <returns>The id of added author</returns>
        /// <exception cref="ArgumentException">The author with such id already exists!</exception>
        public uint Add(Author author)
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
        public uint? Update(uint authorId, Author author)
        {
            Author authorForUpdate = this.authors.FirstOrDefault(someAuthor => someAuthor.Id == authorId);
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
        public uint? Remove(uint authorId)
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
    }
}