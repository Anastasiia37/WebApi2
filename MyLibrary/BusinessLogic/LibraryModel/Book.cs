// <copyright file="Book.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.LibraryModel
{
    /// <summary>
    /// The class for book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The value of last identifier
        /// </summary>
        private static uint lastId = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="name">The name of the book</param>
        /// <param name="year">The publishing year of the book</param>
        /// <param name="authorId">The author identifier of the book</param>
        public Book(string name, int year, uint? authorId = null)
        {
            this.Name = name;
            this.Year = year;
            this.AuthorId = authorId;
            this.Id = ++lastId;
        }

        /// <summary>
        /// Gets or sets the identifier for book
        /// </summary>
        /// <value>
        /// The identifier of book
        /// </value>
        [Required(ErrorMessage = "Book must have id!")]
        [Range(1, uint.MaxValue)]
        public uint Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the name of book
        /// </summary>
        /// <value>
        /// The name of book
        /// </value>
        [Required(ErrorMessage = "Book must have name!")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Invalid length of book`s name!")]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the author identifier
        /// </summary>
        /// <value>
        /// The author identifier
        /// </value>
        [Range(1, uint.MaxValue)]
        public uint? AuthorId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the publishing year
        /// </summary>
        /// <value>
        /// The publishing year
        /// </value>
        [Required(ErrorMessage = "Book must have the year of publishing!")]
        [Year(ErrorMessage = "The year of publishing must be in range "
                           + "from -500 year B.C. until this year!")]
        public int Year
        {
            get;
            set;
        }
    }
}