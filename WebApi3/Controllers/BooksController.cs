// <copyright file="BooksController.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi3.Controllers
{
    using System;
    using System.Collections.Generic;
    using BusinessLogic;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Books controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /// <summary>
        /// Library instance
        /// </summary>
        private readonly ILibraryManager books;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="books">library instance</param>
        public BooksController(ILibraryManager books)
        {
            this.books = books;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>collection with books</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            if ((List<Book>)this.books.GetBooks() == null)
            {
                return this.NotFound("The library hasn't got books.");
            }         

            return this.Ok(this.books.GetBooks());
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>current book</returns>
        [HttpGet("{id}")]
        public ActionResult<Book> Get(uint id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid book id.");
            }

            try
            {
                this.books.GetBook(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            if (this.books.GetBook(id) == null)
            {
                return this.NotFound("We don't have book with this id.");
            }

            return this.Ok();
        }

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">book's instance</param>
        /// <returns>the result of an action</returns>
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid book information input.");
            }

            try
            {
                this.books.AddBook(book);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Created("books", book);
        }

        /// <summary>
        /// Change book's values
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">current book</param>
        /// <returns>editing action</returns>
        [HttpPut("{id}")]
        public IActionResult Edit(uint id, [FromBody]Book book)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid book information input.");
            }

            if (this.books.GetBook(id) == null)
            {
                return this.NotFound("We don't have book with this id.");
            }

            try
            {
                this.books.UpdateBook(id, book);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>removing action</returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(uint id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid book id.");
            }

            if (this.books.GetBook(id) == null)
            {
                return this.NotFound("We don't have book with this id.");
            }

            try
            {
                this.books.DeleteBook(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }
    }
}