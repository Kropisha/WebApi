// <copyright file="LibraryController.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Controller
{
    using System.Collections.Generic;
    using System.Web.Http;
    using WebApi.Library;
    using WebApi.Models;
    [Route("api/[controller]")]

    /// <summary>
    /// Library instance
    /// </summary>
    public class LibraryController : ApiController
    {
        /// <summary>
        /// set of books
        /// </summary>
        private IBooksSet _booksSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryController"/> class
        /// </summary>
        public LibraryController()
        {
            _booksSet = BooksSet.GetInstance();
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>the set of books</returns>
        [Route("api/library")]
        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
             return _booksSet.GetBooks();
        }

        /// <summary>
        /// Get one book by id
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>one book</returns>
        [Route("api/library/{id}")]
        [HttpGet]
        public Book GetById(int id)
        {
            return _booksSet.GetBook(id);
        }

        /// <summary>
        /// Create book
        /// </summary>
        /// <param name="book">book instance</param>
        [Route("api/library/create/{book}")]
        [HttpPost]
        public void CreateBook(Book book)
        {
            _booksSet.CreateBook(book);   
        }

        /// <summary>
        /// Edit exists book
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">book's instance</param>
        [Route("api/library/edit/{id},{book}")]
        [HttpPut]
        public void EditBook(int id, Book book)
        {
            _booksSet.EditBook(id, book);
        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="id">book's id</param>
        [Route("api/library/delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _booksSet.DeleteBook(id);
        }
    }
}
