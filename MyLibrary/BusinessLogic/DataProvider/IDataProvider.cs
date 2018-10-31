﻿// <copyright file="IDataProvider.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.Collections.Generic;
using BusinessLogic.LibraryModel;

namespace BusinessLogic.DataProvider
{
    /// <summary>
    /// Interface for data providers
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Gets the books
        /// </summary>
        /// <value>
        /// The books
        /// </value>
        List<Book> GetBooks
        {
            get;
        }

        /// <summary>
        /// Gets the authors
        /// </summary>
        /// <value>
        /// The authors
        /// </value>
        List<Author> GetAuthors
        {
            get;
        }

        /// <summary>
        /// Gets the genres
        /// </summary>
        /// <value>
        /// The genres
        /// </value>
        List<Genre> GetGenres
        {
            get;
        }

        /// <summary>
        /// Gets the pair of book and its genre
        /// </summary>
        /// <value>
        /// The pair of book and its genre
        /// </value>
        List<BookGenre> GetBookGenre
        {
            get;
        }

        /// <summary>
        /// Gets the pair of book and its author
        /// </summary>
        /// <value>
        /// The pair of book and its author
        /// </value>
        List<BookAuthor> GetBookAuthor
        {
            get;
        }
    }
}