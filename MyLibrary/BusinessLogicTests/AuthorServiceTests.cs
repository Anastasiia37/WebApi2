// <copyright file="AuthorServiceTests.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataProvider;
using BusinessLogic.LibraryModel;
using BusinessLogic.LibraryService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    /// <summary>
    /// Tests for Author Services
    /// </summary>
    [TestClass]
    public class AuthorServiceTests
    {
        /// <summary>
        /// Tests the method GetAuthorById
        /// Correct input values
        /// Returned correct author
        /// </summary>
        /// <param name="id">The author identifier</param>
        /// <param name="name">The author name</param>
        [TestMethod]
        [DataRow(1, "TestAuthor")]
        public void GetAuthorById_CorrectId_ReturnedCorrectAuthor(int id, string name)
        {
            // Arrange
            Author expectedAuthor = new Author(name);
            var mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.SetupGet(x => x.Authors).Returns(new List<Author> { expectedAuthor });
            var libraryService = new AuthorService(mockDataProvider.Object);

            // Act
            Author actualAuthor = libraryService.GetById(id);

            // Assert
            Assert.AreEqual(expectedAuthor.FullName, actualAuthor.FullName);
        }

        /// <summary>
        /// Tests the method GetAuthorById
        /// Incorrect input value for id of author
        /// Returned null
        /// </summary>
        [TestMethod]
        public void GetAuthorById_IncorrectId_ReturnedNull()
        {
            // Arrange
            Author author = new Author("TestAuthor");
            var mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.SetupGet(x => x.Authors).Returns(new List<Author> { author });
            var libraryService = new AuthorService(mockDataProvider.Object);
            int id = 100;

            // Act
            Author actualAuthor = libraryService.GetById(id);

            // Assert
            Assert.IsNull(actualAuthor);
        }

        /// <summary>
        /// Tests the method RemoveAuthor
        /// Correct input values
        /// Returned identifier of removed  author
        /// </summary>
        /// <param name="id">The identifier of author</param>
        /// <param name="name">The name of author</param>
        [TestMethod]
        [DataRow(1, "TestAuthor")]
        public void RemoveAuthor_CorrectInput_ReturnedIdOfRemovedAuthorAndDeleteAllBookAuthorPairs
            (int id, string name)
        {
            // Arrange
            int? expectedId = id;
            Author author = new Author(name);
            List<BookAuthorPair> pairBookAuthor = new List<BookAuthorPair>()
            {
                new BookAuthorPair(1, 2),
                new BookAuthorPair(2, 3)
            };
            var mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.SetupGet(x => x.Authors).Returns(new List<Author> { author });
            mockDataProvider.SetupGet(p => p.PairsBookAuthor).Returns(pairBookAuthor);
            var libraryService = new AuthorService(mockDataProvider.Object);

            // Act
            int? actualId = libraryService.Remove(id);
            Author actualAuthor = libraryService.GetById(id);

            // Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.IsNull(actualAuthor);
        }

        /// <summary>
        /// Tests the method RemoveAuthor
        /// Incorrect input value for author id
        /// Returned null
        /// </summary>
        [TestMethod]
        public void RemoveAuthor_NotExistedAuthorId_ReturnedNull()
        {
            // Arrange
            int authorIdForDelete = 100;
            Author author = new Author("TestBook");
            var mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.SetupGet(x => x.Authors).Returns(new List<Author> { author });
            var libraryService = new AuthorService(mockDataProvider.Object);

            // Act
            int? actualId = libraryService.Remove(authorIdForDelete);

            // Assert
            Assert.IsNull(actualId);
        }

        /// <summary>
        /// Tests the method AddAuthor
        /// Correct input values
        /// Returned correct author
        /// </summary>
        /// <param name="name">The name of author</param>
        [TestMethod]
        [DataRow("Test Author")]
        public void AddAuthor_CorrectInput_ReturnedCorrectAuthor(string name)
        {
            // Arrange
            Author authorForAdding = new Author(name);
            Author author = new Author("TestAuthor2");
            var mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.SetupGet(x => x.Authors).Returns(new List<Author> { author });
            var libraryService = new AuthorService(mockDataProvider.Object);
            int countOfAuthorsBeforeAdding = libraryService.GetAll().ToList<Author>().Count;

            // Act
            int idOfAddedAuthor = libraryService.Add(authorForAdding);
            int countOfAuthorsAfterAdding = libraryService.GetAll().ToList<Author>().Count;
            Author addedAuthor = libraryService.GetAll().FirstOrDefault(x => x.Id == idOfAddedAuthor);

            // Assert
            Assert.AreEqual(countOfAuthorsBeforeAdding + 1, countOfAuthorsAfterAdding);
            Assert.AreEqual(authorForAdding, addedAuthor);
        }

        /// <summary>
        /// Tests the method UpdateAuthor
        /// Correct input values
        /// Returned correct author
        /// </summary>
        /// <param name="authorIdForUpdating">The identifier of author for updating</param>
        /// <param name="name">The name of author</param>
        [TestMethod]
        [DataRow(1, "TestAuthor")]
        public void UpdateAuthor_CorrectInput_ReturnedCorrectAuthor(int authorIdForUpdating, string name)
        {
            // Arrange
            Author author = new Author("TestAuthorUpdate");
            Author authorForUpdating = new Author(name);
            Author expectedAuthorAfterUpdating = new Author(name);
            var mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.SetupGet(x => x.Authors).Returns(new List<Author> { author });
            var libraryService = new AuthorService(mockDataProvider.Object);

            // Act
            int? idOfUpdatedAuthor = libraryService.Update(authorIdForUpdating, authorForUpdating);
            Author actualUpdatedAuthor = libraryService.GetAll().FirstOrDefault(x => x.Id == idOfUpdatedAuthor);

            // Assert
            Assert.AreEqual(expectedAuthorAfterUpdating.FullName, actualUpdatedAuthor.FullName);
            Assert.AreEqual(authorIdForUpdating, idOfUpdatedAuthor);
        }

        /// <summary>
        /// Tests the method UpdateAuthor
        /// Incorrect input values for author id
        /// Returned Null
        /// </summary>
        /// <param name="authorIdForUpdating">The identifier of author for updating</param>
        /// <param name="name">The name of author</param>
        [TestMethod]
        [DataRow(100, "TestAuthor")] // Incorrect author id
        public void UpdateAuthor_IncorrectInput_ReturnedNull(int authorIdForUpdating, string name)
        {
            // Arrange
            Author author = new Author("TestBAuthor2");
            var mockDataProvider = new Mock<IDataProvider>();
            mockDataProvider.SetupGet(x => x.Authors).Returns(new List<Author> { author });
            var libraryService = new AuthorService(mockDataProvider.Object);
            Author authorForUpdating = new Author(name);
            Author expectedAuthorAfterUpdating = new Author(name);

            // Act
            int? idOfUpdatedAuthor = libraryService.Update(authorIdForUpdating, authorForUpdating);
            Author actualUpdatedAuthor = libraryService.GetAll().FirstOrDefault(x => x.Id == idOfUpdatedAuthor);

            // Assert
            Assert.IsNull(idOfUpdatedAuthor);
        }
    }
}