// <copyright file="LibraryServiceTests.cs" company="Peretiatko Anastasiia">
// Copyright (c) Peretiatko Anastasiia. All rights reserved.
// </copyright>

using System;
using System.Linq;
using BusinessLogic.DataProvider;
using BusinessLogic.LibraryModel;
using BusinessLogic.LibraryService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogicTests
{
    /// <summary>
    /// Tests for Library Services
    /// </summary>
    [TestClass]
    public class LibraryServiceTests
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private static IDataProvider dataProvider;

        /// <summary>
        /// The instance of Library service for testing
        /// </summary>
        private static ILibraryService libraryService;

        /// <summary>
        /// Initializes test data
        /// </summary>
        /// <param name="testContext">The test context</param>
        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            // Arrange
            dataProvider = new InMemoryDataProvider();
            libraryService = new LibraryService(dataProvider);
        }

        #region BookTests

        /// <summary>
        /// Tests the method GetBookById
        /// Correct input values
        /// Returned correct book
        /// </summary>
        /// <param name="id">The book identifier</param>
        /// <param name="name">The book name</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow(4u, "Конец вечности", 1955, 2u)]
        public void GetBookByIdTest_CorrectId_ReturnedCorrectBook(uint id, string name,
            int year, uint authorId)
        {
            // Arrange
            Book expectedBook = new Book(name, year, authorId);

            // Act
            Book actualBook = libraryService.GetBookById(id);

            // Assert
            Assert.AreEqual(expectedBook.Name, actualBook.Name);
            Assert.AreEqual(expectedBook.Year, actualBook.Year);
            Assert.AreEqual(expectedBook.AuthorId, actualBook.AuthorId);
        }

        /// <summary>
        /// Tests the method GetBookById
        /// Incorrect input value for id of book
        /// Returned null
        /// </summary>
        [TestMethod]
        public void GetBookByIdTest_IncorrectId_ReturnedNull()
        {
            // Arrange
            uint id = 100;

            // Act
            Book actualBook = libraryService.GetBookById(id);

            // Assert
            Assert.IsNull(actualBook);
        }

        /// <summary>
        /// Tests the method RemoveBook
        /// Correct input values
        /// Returned identifier of removed book
        /// </summary>
        /// <param name="id">The identifier of book</param>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow(4u, "Конец вечности", 1955, 2u)]
        public void RemoveBookTest_CorrectInput_ReturnedIdOfRemovedBook(uint id,
            string name, int year, uint authorId)
        {
            // Arrange
            uint? expectedId = id;
            Book expectedBook = null;

            // Act
            uint? actualId = libraryService.RemoveBook(id);
            Book actualBook = libraryService.GetBookById(id);

            // Assert
            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedBook, actualBook);
        }

        /// <summary>
        /// Tests the method RemoveBook
        /// Incorrect input value for book id
        /// Returned null
        /// </summary>
        [TestMethod]
        public void RemoveBookTest_NotExistedBookId_ReturnedNull()
        {
            // Arrange
            uint bookIdForDelete = 100;

            // Act
            uint? actualId = libraryService.RemoveBook(bookIdForDelete);

            // Assert
            Assert.IsNull(actualId);
        }

        /// <summary>
        /// Tests the method CreateBook
        /// Correct input values
        /// Returned correct book
        /// </summary>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow("Мечты роботов", 1960, 2u)]
        public void CreateBookTest_CorrectInput_ReturnedCorrectBook(string name, int year, uint authorId)
        {
            // Arrange
            Book expectedBook = new Book(name, year, authorId);

            // Act
            Book actualBook = libraryService.CreateBook(name, year, authorId);

            // Assert
            Assert.AreEqual(expectedBook.Name, actualBook.Name);
            Assert.AreEqual(expectedBook.Year, actualBook.Year);
            Assert.AreEqual(expectedBook.AuthorId, actualBook.AuthorId);
        }

        /// <summary>
        /// Tests the method CreateBook
        /// Incorrect input value for author id
        /// Expected ArgumentException
        /// </summary>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow("Я, Легенда", 1960, 100u)]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateBookTest_NotExistingAuthorId_ExpectedArgumentException(string name, int year, uint authorId)
        {
            // Arrange

            // Act
            Book actualBook = libraryService.CreateBook(name, year, authorId);

            // Assert
            Assert.IsNull(actualBook);
        }

        /// <summary>
        /// Tests the method AddBook
        /// Correct input values
        /// Returned correct book
        /// </summary>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow("Ревизор", 1960, 3u)]
        public void AddBookTest_CorrectInput_ReturnedCorrectBook(string name, int year, uint authorId)
        {
            // Arrange
            Book bookForAdding = new Book(name, year, authorId);
            int countOfBooksBeforeAdding = libraryService.GetAllBooks().ToList<Book>().Count;

            // Act
            uint idOfAddedBook = libraryService.AddBook(bookForAdding);
            int countOfBooksAfterAdding = libraryService.GetAllBooks().ToList<Book>().Count;
            Book addedBook
                = libraryService.GetAllBooks().FirstOrDefault(book => book.Id == idOfAddedBook);

            // Assert
            Assert.AreEqual(countOfBooksBeforeAdding + 1, countOfBooksAfterAdding);
            Assert.AreEqual(bookForAdding, addedBook);
        }

        /// <summary>
        /// Tests the method AddBook
        /// Incorrect input values for author id
        /// Expected ArgumentException
        /// </summary>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow("Ревизор", 1960, 100u)]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBookTest_InCorrectAuthorIdInput_ExpectedException(string name, int year, uint authorId)
        {
            // Arrange
            Book bookForAdding = new Book(name, year, authorId);
            int countOfBooksBeforeAdding = libraryService.GetAllBooks().ToList<Book>().Count;
            uint idOfLastBook = Convert.ToUInt32(libraryService.GetAllBooks().Max<Book>(book => book.Id));

            // Act
            uint idOfAddedBook = libraryService.AddBook(bookForAdding);
            int countOfBooksAfterAdding = libraryService.GetAllBooks().ToList<Book>().Count;
            uint idOfLastBookAfterAdding
                = libraryService.GetAllBooks().ToList<Book>().Last<Book>().Id;
            Book addedBook
                = libraryService.GetAllBooks().FirstOrDefault(book => book.Id == idOfLastBookAfterAdding);

            // Assert
            Assert.AreEqual(countOfBooksBeforeAdding + 1, countOfBooksAfterAdding);
            Assert.AreEqual(bookForAdding, addedBook);
        }

        /// <summary>
        /// Tests the method UpdateBook
        /// Correct input values
        /// Returned correct book
        /// </summary>
        /// <param name="bookIdForUpdating">The identifier of book for updating</param>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow(3u, "Сказки народов мира", 1960, null)]
        public void UpdateBookTest_CorrectInput_ReturnedCorrectBook(uint bookIdForUpdating,
            string name, int year, uint? authorId)
        {
            // Arrange
            Book expectedBookAfterUpdating = new Book(name, year, authorId);

            // Act
            uint? idOfUpdatedBook = libraryService.UpdateBook(bookIdForUpdating, name, year, authorId);
            Book actualUpdatedBook
                = libraryService.GetAllBooks().FirstOrDefault(book => book.Id == idOfUpdatedBook);

            // Assert
            Assert.AreEqual(expectedBookAfterUpdating.Name, actualUpdatedBook.Name);
            Assert.AreEqual(expectedBookAfterUpdating.Year, actualUpdatedBook.Year);
            Assert.AreEqual(expectedBookAfterUpdating.AuthorId, actualUpdatedBook.AuthorId);
            Assert.AreEqual(bookIdForUpdating, idOfUpdatedBook);
        }

        /// <summary>
        /// Tests the method UpdateBook
        /// Incorrect input values for author id
        /// Expected ArgumentException
        /// </summary>
        /// <param name="bookIdForUpdating">The identifier of book for updating</param>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        [TestMethod]
        [DataRow(3u, "Сказки народов мира и вселенной", 1960, 100u)] // Incorrect author id
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateBookTest_IncorrectInput_ExpectedException(uint bookIdForUpdating,
            string name, int year, uint? authorId)
        {
            // Arrange
            Book expectedBookAfterUpdating = new Book(name, year, authorId);

            // Act
            uint? idOfUpdatedBook = libraryService.UpdateBook(bookIdForUpdating, name, year, authorId);
            Book actualUpdatedBook
                = libraryService.GetAllBooks().FirstOrDefault(book => book.Id == idOfUpdatedBook);
        }

        /// <summary>
        /// Tests the method UpdateBook
        /// Incorrect input values for book id
        /// Returned Null
        /// </summary>
        /// <param name="bookIdForUpdating">The identifier of book for updating</param>
        /// <param name="name">The name of book</param>
        /// <param name="year">The publishing year</param>
        /// <param name="authorId">The author identifier</param>
        /// [TestMethod]
        [DataRow(100u, "Сказки народов мира и вселенной", 1960, null)] // Incorrect book id
        public void UpdateBookTest_IncorrectInput_ReturnedNull(uint bookIdForUpdating,
            string name, int year, uint? authorId)
        {
            // Arrange
            Book expectedBookAfterUpdating = new Book(name, year, authorId);

            // Act
            uint? idOfUpdatedBook = libraryService.UpdateBook(bookIdForUpdating, name, year, authorId);
            Book actualUpdatedBook
                = libraryService.GetAllBooks().FirstOrDefault(book => book.Id == idOfUpdatedBook);

            // Assert
            Assert.IsNull(idOfUpdatedBook);
        }

        #endregion BookTests

        #region AuthorTests

        /// <summary>
        /// Tests the method GetAuthorById
        /// Correct input values
        /// Returned correct author
        /// </summary>
        /// <param name="id">The identifier of author.</param>
        /// <param name="fullName">The full name of author</param>
        [TestMethod]
        [DataRow(3u, "Стендаль")]
        public void GetAuthorByIdTest_CorrectId_ReturnedCorrectAuthor(uint id, string fullName)
        {
            // Arrange
            Author expectedAuthor = new Author(fullName);

            // Act
            Author actualAuthor = libraryService.GetAuthorById(id);

            // Assert
            Assert.AreEqual(expectedAuthor.FullName, actualAuthor.FullName);
        }

        /// <summary>
        /// Tests the method GetAuthorById
        /// Incorrect input values for author id
        /// Returned null
        /// </summary>
        [TestMethod]
        public void GetAuthorByIdTest_IncorrectId_ReturnedNull()
        {
            // Arrange
            uint id = 100u;

            // Act
            Author actualAuthor = libraryService.GetAuthorById(id);

            // Assert
            Assert.IsNull(actualAuthor);
        }

        /// <summary>
        /// Tests the method RemoveAuthor
        /// Correct input values
        /// Returned correct number of books deletions
        /// </summary>
        /// <param name="id">The identifier of author for removing</param>
        /// <param name="expectedNumberOfBooksDeletions">The expected number of books deletions</param>
        [TestMethod]
        [DataRow(4u, 2)]
        [DataRow(5u, 0)]
        public void RemoveAuthorTest_CorrectInput_ReturnedCorrectNumberOfBooksDeletions(uint id,
            int? expectedNumberOfBooksDeletions)
        {
            // Act
            int? actualNumberOfBooksDeletions = libraryService.RemoveAuthor(id);
            Author actualAuthor = libraryService.GetAuthorById(id);

            // Assert
            Assert.AreEqual(expectedNumberOfBooksDeletions, actualNumberOfBooksDeletions);
            Assert.IsNull(actualAuthor);
        }

        /// <summary>
        /// Tests the method RemoveAuthor
        /// Incorrect input value for author id
        /// Returned null
        /// </summary>
        [TestMethod]
        public void RemoveAuthorTest_NotExistedAuthorId_ReturnedNull()
        {
            // Arrange
            uint authorForDelete = 100;

            // Act
            int? actualNumberOfBooksDeletions = libraryService.RemoveAuthor(authorForDelete);

            // Assert
            Assert.IsNull(actualNumberOfBooksDeletions);
        }

        /// <summary>
        /// Tests the method AddAuthor
        /// Correct input values
        /// Returned correct instance of Author
        /// </summary>
        /// <param name="fullName">The full name of author</param>
        [TestMethod]
        [DataRow("Ларри Нивен")]
        public void AddAuthorTest_CorrectInput_ReturnedCorrectAuthor(string fullName)
        {
            // Arrange
            Author authorForAdding = new Author(fullName);
            int countOfAuthorsBeforeAdding = libraryService.GetAllAuthors().ToList<Author>().Count;

            // Act
            uint idOfAddedAuthor = libraryService.AddAuthor(authorForAdding);
            int countOfAuthorsAfterAdding = libraryService.GetAllAuthors().ToList<Author>().Count;
            Author addedAuthor
                = libraryService.GetAllAuthors().FirstOrDefault(author => author.Id == idOfAddedAuthor);

            // Assert
            Assert.AreEqual(countOfAuthorsBeforeAdding + 1, countOfAuthorsAfterAdding);
            Assert.AreEqual(authorForAdding, addedAuthor);
        }

        /// <summary>
        /// Tests the method UpdateAuthor
        /// Correct input values
        /// Returned correct instance of Author
        /// </summary>
        /// <param name="authorIdForUpdating">The author identifier of author for updating</param>
        /// <param name="fullName">The full name of author</param>
        [TestMethod]
        [DataRow(2u, "Айзек Айзекович Азимов")]
        public void UpdateAuthorTest_CorrectInput_ReturnedCorrectAuthor(uint authorIdForUpdating,
            string fullName)
        {
            // Arrange
            Author expectedAuthorAfterUpdating = new Author(fullName);

            // Act
            uint? idOfUpdatedAuthor = libraryService.UpdateAuthor(authorIdForUpdating, expectedAuthorAfterUpdating);
            Author actualUpdatedAuthor
                = libraryService.GetAllAuthors().FirstOrDefault(author => author.Id == idOfUpdatedAuthor);

            // Assert
            Assert.AreEqual(expectedAuthorAfterUpdating.FullName, actualUpdatedAuthor.FullName);
            Assert.AreEqual(authorIdForUpdating, idOfUpdatedAuthor);
        }

        /// <summary>
        /// Tests the method UpdateAuthor
        /// Incorrect input values for author id
        /// Returned null
        /// </summary>
        /// <param name="authorIdForUpdating">The author identifier of author for updating</param>
        /// <param name="fullName">The full name of author</param>
        [TestMethod]
        [DataRow(100u, "Авторов Автор Авторович")] // Incorrect Author id
        public void UpdateAuthorTest_IncorrectInput_ReturnedNull(uint authorIdForUpdating,
            string fullName)
        {
            // Arrange
            Author expectedAuthorAfterUpdating = new Author(fullName);

            // Act
            uint? idOfUpdatedAuthor
                = libraryService.UpdateAuthor(authorIdForUpdating, new Author(fullName));
            Author actualUpdatedAuthor
                = libraryService.GetAllAuthors().FirstOrDefault(author => author.Id == idOfUpdatedAuthor);

            // Assert
            Assert.IsNull(idOfUpdatedAuthor);
        }

        #endregion AuthorTests
    }
}