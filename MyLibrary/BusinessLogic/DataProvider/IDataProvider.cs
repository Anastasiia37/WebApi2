// <copyright file="IDataProvider.cs" company="Peretiatko Anastasiia">
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
        List<Book> Books
        {
            get;
        }

        /// <summary>
        /// Gets the authors
        /// </summary>
        /// <value>
        /// The authors
        /// </value>
        List<Author> Authors
        {
            get;
        }
    }
}