using System;
using System.Collections.Generic;
using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BusinessLogicTests
{
    [TestClass]
    public class LibraryManagerTest
    {
        private static LibraryManager library;

        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            var dataProvide = new Mock<IDataProvider>();
            dataProvide.Setup(q => q.Authors()).Returns(new List<Author> {
                new Author("George Orwell", 1903),
                new Author("Aldous Huxley", 1894)});
            dataProvide.Setup(q => q.Books()).Returns(new List<Book> {
                new Book("1984", 1949),
                new Book("Animal farm", 1945)});
            dataProvide.Setup(q => q.Genres()).Returns(new List<Genre> {
                new Genre("Romance"),
                new Genre("Science fiction")});
            dataProvide.Setup(q => q.BookAuthors()).Returns(new List<BookAuthor> {
                new BookAuthor(1, 1),
                new BookAuthor(2, 1)});
            dataProvide.Setup(q => q.BookGenres()).Returns(new List<BookGenre> {
                new BookGenre(1, 1),
                new BookGenre(2, 1)});
            library = new LibraryManager(dataProvide.Object);
        }

        #region Add_Correct
        [TestMethod]
        [DataRow("author", 1456u,3u)]
        public void AddAuthor_CorrectValues(string name, uint year, uint id)
        { 
            //act
            Author actual = library.AddAuthor(new Author(name,year));

            //assert
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(year, actual.BirthYear);
            Assert.AreEqual(id, actual.Id);
        }

        [TestMethod]
        [DataRow("book", 1556u, 3u)]
        public void AddBook_CorrectValues(string name, uint year, uint id)
        {
            //act
            Book actual = library.AddBook(new Book(name, year));

            //assert
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(year, actual.Year);
            Assert.AreEqual(id, actual.Id);
        }

        [TestMethod]
        [DataRow("horror",3u)]
        public void AddGenre_CorrectValues(string name, uint id)
        {
            //act
            Genre actual = library.AddGenre(new Genre(name));

            //assert
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(id, actual.Id);
        }

        [TestMethod]
        [DataRow(1u,3u)]
        public void AddAuthorToBook_CorrectValues(uint bookId, uint authorId)
        {
            //arrange
            BookAuthor expected = new BookAuthor(bookId,authorId);

            //act
            BookAuthor actual = library.AddAuthorToBook(new BookAuthor(bookId,authorId));

            //assert
            Assert.AreEqual(expected.BookId, actual.BookId);
            Assert.AreEqual(expected.AuthorId, actual.AuthorId);
        }

        [TestMethod]
        [DataRow(1u, 3u)]
        public void AddGenreToBook_CorrectValues(uint bookId, uint authorId)
        {
            //arrange
            BookGenre expected = new BookGenre(bookId, authorId);

            //act
            BookGenre actual = library.AddGenreToBook(new BookGenre(bookId, authorId));

            //assert
            Assert.AreEqual(expected.BookId, actual.BookId);
            Assert.AreEqual(expected.GenreId, actual.GenreId);
        }

        #endregion
        #region Add_Incorrect
        [TestMethod]
        [DataRow("author", 1456)]
        [ExpectedException(typeof(ArgumentException))]
        public void AddAuthor_IncorrectValues(string name, uint year)
        {
            //act
            Author actual = library.AddAuthor(new Author(name, year));
        }

        [TestMethod]
        [DataRow("book", 1556)]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBook_IncorrectValues(string name, uint year)
        {
            //act
            Book actual = library.AddBook(new Book(name, year));
        }

        [TestMethod]
        [DataRow("ho")]
        [ExpectedException(typeof(ArgumentException))]
        public void AddGenre_IncorrectValues(string name)
        {
            //act
            Genre actual = library.AddGenre(new Genre(name));
        }

        [TestMethod]
        [DataRow(5, 23u)]
        [ExpectedException(typeof(ArgumentException))]
        public void AddAuthorToBook_IncorrectValues(uint bookId, uint authorId)
        {
            //act
            BookAuthor actual = library.AddAuthorToBook(new BookAuthor(bookId, authorId));
        }

        [TestMethod]
        [DataRow(15, 23u)]
        [ExpectedException(typeof(ArgumentException))]
        public void AddGenreToBook_IncorrectValues(uint bookId, uint authorId)
        {
            //act
            BookGenre actual = library.AddGenreToBook(new BookGenre(bookId, authorId));
        }
        #endregion
        #region Get_Correct
        [TestMethod]
        [DataRow("George Orwell", 1903u, 1u)]
        public void GetAuthor_CorrectValues(string name, uint year, uint id)
        {
            //arrange
            Author expected = new Author(name, year);

            //act
             Author actual = library.GetAuthor(id);

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.BirthYear, actual.BirthYear);
            Assert.AreEqual(expected.Id, actual.Id);
        }

        [TestMethod]
        [DataRow("Animal farm", 1945u, 2u)]
        public void GetBook_CorrectValues(string name, uint year, uint id)
        {
            //act
            Book actual = library.GetBook(id);

            //assert
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(year, actual.Year);
            Assert.AreEqual(id, actual.Id);
        }

        [TestMethod]
        [DataRow("Romance", 1u)]
        public void GetGenre_CorrectValues(string name, uint id)
        {
            //act
            Genre actual = library.GetGenre(id);

            //assert
            Assert.AreEqual(name, actual.Name);
            Assert.AreEqual(id, actual.Id);
        }

        #endregion
        #region Get_Incorrect
        [TestMethod]
        [DataRow(5)]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAuthor_IncorrectValues(uint id)
        {
            //act
            Author actual = library.GetAuthor(id);
        }

        [TestMethod]
        [DataRow(12u)]
        [ExpectedException(typeof(ArgumentException))]
        public void GetBook_IncorrectValues(uint id)
        {
            //act
            Book actual = library.GetBook(id);
        }

        [TestMethod]
        [DataRow(100u)]
        [ExpectedException(typeof(ArgumentException))]
        public void GetGenre_IncorrectValues(uint id)
        {
            //act
            Genre actual = library.GetGenre(id);
        }
        #endregion
        #region Update_Correct
        [TestMethod]
        [DataRow("author", 1456u, 2u)]
        public void ChangeAuthor_CorrectValues(string name, uint year, uint id)
        {
            //arrange
            Author expected = new Author(name, year);

            //act
            Author actual = library.UpdateAuthor(id, new Author(name, year));

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.BirthYear, actual.BirthYear);
            Assert.AreEqual(id, actual.Id);
        }

        [TestMethod]
        [DataRow("book", 1556u, 2u)]
        public void ChangeBook_CorrectValues(string name, uint year, uint id)
        {
            //arrange
            Book expected = new Book(name, year);

            //act
            Book actual = library.UpdateBook(id, new Book(name, year));

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Year, actual.Year);
            Assert.AreEqual(id, actual.Id);
        }

        [TestMethod]
        [DataRow(1u, 3u)]
        public void UpdateAuthor_CorrectValues(uint bookId, uint authorId)
        {
            //arrange
            BookAuthor expected = new BookAuthor(bookId, authorId);

            //act
            BookAuthor actual = library.ChangeAuthor(new BookAuthor(bookId, authorId));

            //assert
            Assert.AreEqual(expected.BookId, actual.BookId);
            Assert.AreEqual(expected.AuthorId, actual.AuthorId);
        }

        [TestMethod]
        [DataRow(1u, 3u)]
        public void UpdateGenre_CorrectValues(uint bookId, uint authorId)
        {
            //arrange
            BookGenre expected = new BookGenre(bookId, authorId);

            //act
            BookGenre actual = library.ChangeGenre(new BookGenre(bookId, authorId));

            //assert
            Assert.AreEqual(expected.BookId, actual.BookId);
            Assert.AreEqual(expected.GenreId, actual.GenreId);
        }
        #endregion
        #region Update_Incorrect
        [TestMethod]
        [DataRow("author", 1456, 2u)]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeAuthor_IncorrectValues(string name, uint year, uint id)
        {
            //act
            Author actual = library.UpdateAuthor(id, new Author(name, year));
        }

        [TestMethod]
        [DataRow("book", "1556u", 2u)]
        [ExpectedException(typeof(ArgumentException))]
        public void ChangeBook_IncorrectValues(string name, uint year, uint id)
        {
            //act
            Book actual = library.UpdateBook(id, new Book(name, year));
        }

        [TestMethod]
        [DataRow(1u, 3)]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateAuthor_IncorrectValues(uint bookId, uint authorId)
        {
            //act
            BookAuthor actual = library.ChangeAuthor(new BookAuthor(bookId, authorId));
        }

        [TestMethod]
        [DataRow(1u, "kek")]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateGenre_IncorrectValues(uint bookId, uint authorId)
        {
            //act
            BookGenre actual = library.ChangeGenre(new BookGenre(bookId, authorId));
        }
        #endregion
        #region Delete_Correct
        [TestMethod]
        [DataRow(2u)]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteAuthor_CorrectValues(uint id)
        {
            //act
            library.DeleteAuthor(id);
            Author actual = library.GetAuthor(id);
        }

        [TestMethod]
        [DataRow(2u)]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteBook_CorrectValues(uint id)
        {
            //act
            library.DeleteBook(id);
            Book actual = library.GetBook(id);
        }

        [TestMethod]
        [DataRow(2u)]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteGenre_CorrectValues(uint id)
        {
            //act
            library.DeleteGenre(id);
            Genre actual = library.GetGenre(id);
        }

        [TestMethod]
        [DataRow(3u, 3u)]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteAuthorFromBook_IncorrectValues(uint bookId, uint authorId)
        {
            //act
            library.DeleteAuthorFromBook(new BookAuthor(bookId, authorId));
        }

        [TestMethod]
        [DataRow(3u, 3u)]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteGenreFromBook_IncorrectValues(uint bookId, uint authorId)
        {
            //act
            library.DeleteGenreFromBook(new BookGenre(bookId, authorId));
        }
        #endregion
    }
}
