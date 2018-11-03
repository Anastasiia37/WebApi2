// <copyright file="BookAuthor.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.LibraryModel
{
    public class BookAuthorPair
    {
        /// <summary>
        /// The value of last identifier
        /// </summary>
        private static uint lastId = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookAuthorPair" /> class
        /// </summary>
        /// <param name="bookId">The book identifier</param>
        /// <param name="authorId">The author identifier</param>
        public BookAuthorPair(uint bookId, uint authorId)
        {
            this.BookId = bookId;
            this.AuthorId = authorId;
            this.Id = ++lastId;
        }

        /// <summary>
        /// Gets or sets the identifier for record of matching books and authors
        /// </summary>
        /// <value>
        /// The identifier of book
        /// </value>
        [Required(ErrorMessage = "The record of matching books and authors must have id!")]
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
        /// Gets or sets the identifier for author
        /// </summary>
        /// <value>
        /// The identifier of author
        /// </value>
        [Required(ErrorMessage = "The identifier of author must have id!")]
        [Range(1, uint.MaxValue)]
        public uint AuthorId
        {
            get;
            set;
        }
    }
}