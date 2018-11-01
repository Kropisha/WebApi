using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WebApi.Library;
using WebApi.Models;

namespace WebApiTests
{
    [TestClass]
    public class LibraryManagerTest
    {
        public static ILibraryManager library;

        [ClassInitialize]
        public static void TestInitialize(TestContext testContext)
        {
            library = new LibraryManager();
        }

        [TestMethod]
        [DataRow(4, "Ray Bradbury", 1920)]
        public void GetAuthor(int id, string name, int year)
        {
            //arrange
            Author expected = new Author(id, name, year);
            //act
            Author actual = library.GetAuthor(id);

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.BirthYear, actual.BirthYear);
        }

        [TestMethod]
        [DataRow(2, "Animal farm", 1, 1945)]
        public void GetBook(int id, string name, int authorId, int year)
        {
            //arrange
            Book expected = new Book(id, name, authorId, year);
            //act
            Book actual = library.GetBook(id);

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.AuthorId, actual.AuthorId);
            Assert.AreEqual(expected.Year, actual.Year);
        }

        [TestMethod]
        [DataRow(8,"name",4,1979)]
        public void AddBook(int id, string name, int authorId, int year)
        {
            //arrange
            Book expected = new Book(id, name, authorId, year);

            //act
            Book actual = library.AddBook(new Book(id, name, authorId, year));

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.AuthorId, actual.AuthorId);
            Assert.AreEqual(expected.Year, actual.Year);
        }

        [TestMethod]
        [DataRow(8, "name", 1979)]
        public void AddAuthor(int id, string name, int birthYear)
        {
            //arrange
            Author expected = new Author(id, name, birthYear);

            //act
            Author actual = library.AddAuthor(new Author(id, name, birthYear));

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.BirthYear, actual.BirthYear);
        }

        [TestMethod]
        [DataRow(4)]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteAuthor(int id)
        {
            //act
            library.DeleteAuthor(id);
            Author actual = library.GetAuthor(id);

        }

        [TestMethod]
        [DataRow(4)]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteBook(int id)
        {
            //act
            library.DeleteBook(id);
            Book actual = library.GetBook(id);

        }

        [TestMethod]
        [DataRow(4,"name",5,1456)]
        public void UpdateBook(int id, string name, int authorId, int year)
        {
            //arrange
            Book expected = new Book(id, name, authorId, year);
            //act
            library.UpdateBook(id, expected);
            Book actual = library.GetBook(id);

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.AuthorId, actual.AuthorId);
            Assert.AreEqual(expected.Year, actual.Year);
        }

        [TestMethod]
        [DataRow(4, "name", 1456)]
        public void UpdateAuthor(int id, string name, int year)
        {
            //arrange
            Author expected = new Author(id, name, year);
            //act
            library.UpdateAuthor(id, expected);
            Author actual = library.GetAuthor(id);

            //assert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.BirthYear, actual.BirthYear);
        }
    }
}
