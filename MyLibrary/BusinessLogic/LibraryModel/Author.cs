// <copyright file="Author.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.LibraryModel
{
    /// <summary>
    /// The class for author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// The value of last identifier
        /// </summary>
        private static uint lastId = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class
        /// </summary>
        /// <param name="fullName">The full name of author</param>
        public Author(string fullName)
        {
            this.FullName = fullName;
            this.Id = ++lastId;
        }

        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        /// <value>
        /// The identifier of author
        /// </value>
        [Required]
        [Range(1, uint.MaxValue)]
        public uint Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the full name of author
        /// </summary>
        /// <value>
        /// The full name of author
        /// </value>
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Invalid length of author fullname")]
        public string FullName
        {
            get;
            set;
        }
    }
}