// <copyright file="BooksController.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using WebApi.Library;
    using WebApi.Models;

    [Route("api/books")]
    [ApiController]
    public class BooksController : Controller
    {
        private ILibraryManager library;

        public BooksController(ILibraryManager library)
        {
            this.library = library;
        }

       // [Route("api/books")]
        // GET api/books
        [HttpGet]
        public IEnumerable<Book> GetBooks()
        {
            return this.library.GetBooks();
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            return this.library.GetBook(id);
        }

        // POST api/books
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Book book)
        {
            this.library.UpdateBook(id, book);
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.library.DeleteBook(id);
        }
    }
}