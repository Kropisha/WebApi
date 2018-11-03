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
    [Route("api/[controller]")]
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

        /// <summary>
        /// Get all books // GET api/books
        /// </summary>
        /// <returns>collection with books</returns>
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return this.library.GetBooks();
        }

        /// <summary>
        /// Get book by id // GET api/books/5
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>current book</returns>
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            try
            {
                this.library.GetBook(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.library.GetBook(id);
        }

        /// <summary>
        /// Add new book // POST api/books
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
                return this.NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Change book's values // PUT api/books/5
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">current book</param>
        /// <returns>the result of editing</returns>
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Book book)
        {
            try
            {
                this.library.UpdateBook(id, book);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Remove book // DELETE api/books/5
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>Result of removing</returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                this.library.DeleteBook(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }
    }
}