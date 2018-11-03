// <copyright file="LibraryService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using BusinessLogic.DataProvider;
using BusinessLogic.LibraryModel;
using System.Collections.Generic;

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Class for library entities
    /// </summary>
    public class LibraryService
    {
        /// <summary>
        /// The books
        /// </summary>
        protected List<Book> books;

        /// <summary>
        /// The authors
        /// </summary>
        protected List<Author> authors;

        /// <summary>
        /// The genres
        /// </summary>
        protected List<Genre> genres;

        /// <summary>
        /// The books with genres
        /// </summary>
        protected List<BookGenrePair> pairsBookGenre;

        /// <summary>
        /// The books with authors
        /// </summary>
        protected List<BookAuthorPair> pairsBookAuthor;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryService"/> class
        /// </summary>
        /// <param name="dataProvider">The data provider</param>
        public LibraryService(IDataProvider dataProvider)
        {
            this.books = dataProvider.GetBooks;
            this.authors = dataProvider.GetAuthors;
            this.genres = dataProvider.GetGenres;
            this.pairsBookAuthor = dataProvider.GetPairBookAuthor;
            this.pairsBookGenre = dataProvider.GetPairBookGenre;
        }
    }
}