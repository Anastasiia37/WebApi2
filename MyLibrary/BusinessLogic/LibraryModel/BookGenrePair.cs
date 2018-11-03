// <copyright file="BookGenrePair.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.LibraryModel
{
    /// <summary>
    /// Matches books and related genres
    /// </summary>
    public class BookGenrePair
    {
        /// <summary>
        /// The value of last identifier
        /// </summary>
        private static uint lastId = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookGenrePair" /> class
        /// </summary>
        /// <param name="bookId">The book identifier</param>
        /// <param name="genreId">The genre identifier</param>
        public BookGenrePair(uint bookId, uint genreId)
        {
            this.BookId = bookId;
            this.GenreId = genreId;
            this.Id = ++lastId;
        }

        /// <summary>
        /// Gets or sets the identifier for record of matching books and genres
        /// </summary>
        /// <value>
        /// The identifier of book
        /// </value>
        [Required(ErrorMessage = "The record of matching books and genres must have id!")]
        [Range(1, uint.MaxValue)]
        public uint Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the identifier for book
        /// </summary>
        /// <value>
        /// The identifier of book
        /// </value>
        [Required(ErrorMessage = "The identifier of book must have id!")]
        [Range(1, uint.MaxValue)]
        public uint BookId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the identifier for genre
        /// </summary>
        /// <value>
        /// The identifier of genre
        /// </value>
        [Required(ErrorMessage = "The identifier of genre must have id!")]
        [Range(1, uint.MaxValue)]
        public uint GenreId
        {
            get;
            set;
        }
    }
}