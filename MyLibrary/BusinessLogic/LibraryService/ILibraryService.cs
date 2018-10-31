// <copyright file="ILibraryService.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

namespace BusinessLogic.LibraryService
{
    /// <summary>
    /// Interface for services of all Library
    /// </summary>
    /// <seealso cref="BusinessLogic.LibraryService.IGenreService" />
    /// <seealso cref="BusinessLogic.LibraryService.IAuthorService" />
    /// <seealso cref="BusinessLogic.LibraryService.IBookService" />
    public interface ILibraryService : IAuthorService, IBookService, IGenreService
    {
    }
}