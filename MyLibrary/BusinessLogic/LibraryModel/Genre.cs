// <copyright file="Genre.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.LibraryModel
{
    /// <summary>
    /// Defines different genres of books
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// The value of last identifier
        /// </summary>
        private static uint lastId = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Genre" /> class
        /// </summary>
        /// <param name="name">The genre name</param>
        public Genre(string name)
        {
            this.Name = name;
            this.Id = ++lastId;
        }

        /// <summary>
        /// Gets or sets the identifier for genre
        /// </summary>
        /// <value>
        /// The identifier of genre
        /// </value>
        [Required(ErrorMessage = "Genre must have id!")]
        [Range(1, uint.MaxValue)]
        public uint Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the name of genre
        /// </summary>
        /// <value>
        /// The genre name
        /// </value>
        [Required(ErrorMessage = "Genre must have name!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Invalid length of genre name!")]
        public string Name
        {
            get;
            set;
        }
    }
}