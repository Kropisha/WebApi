// <copyright file="BooksController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Library;
    using WebApi.Models;

    /// <summary>
    /// Books controller
    /// </summary>
    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        /// <summary>
        /// The instance of ILibraryManager
        /// </summary>
        private ILibraryManager library;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="library">current library</param>
        public BooksController(ILibraryManager library)
        {
            this.library = library;
        }

        // GET api/books

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>collection with books</returns>
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return this.library.GetBooks();
        }

        // GET api/books/5

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>current book</returns>
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return this.library.GetBook(id);
        }

        // POST api/books

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">book's instance</param>
        /// <returns>the result of an action</returns>
        [HttpPost]
        public IActionResult AddBook([FromBody]Book book)
        {
            try
            {
                Book currentAuthor = this.library.AddBook(book);
                return this.Created("authors", currentAuthor);
            }
            catch (ArgumentException exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        // PUT api/books/5

        /// <summary>
        /// Change book's values
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">current book</param>
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody]Book book)
        {
            this.library.UpdateBook(id, book);
        }

        // DELETE api/books/5

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="id">book's id</param>
        [HttpDelete("{id}")]
        public void Remowe(int id)
        {
            this.library.DeleteBook(id);
        }
    }
}