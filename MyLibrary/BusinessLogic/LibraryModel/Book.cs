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
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="name">The name of the book</param>
        /// <param name="year">The publishing year of the book</param>
        public Book(string name, int year)
        {
            this.Name = name;
            this.Year = year;
        }

        /// <summary>
        /// Gets or sets the identifier for book
        /// </summary>
        /// <value>
        /// The identifier of book
        /// </value>
        public int Id
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
        /// Gets or sets the publishing year
        /// </summary>
        /// <value>
        /// The publishing year
        /// </value>
        [Required(ErrorMessage = "Book must have the year of publishing!")]
        [Year]
        public int Year
        {
            get;
            set;
        }
    }
}