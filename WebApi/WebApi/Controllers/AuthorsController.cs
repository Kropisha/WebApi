// <copyright file="AuthorsController.cs" company="My Company Name">
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

    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private ILibraryManager library;

        public AuthorsController(ILibraryManager library)
        {
            this.library = library;
        }

        // GET api/authors
        [HttpGet]
        public IEnumerable<Author> GetBooks()
        {
            return this.library.GetAuthors();
        }

        // GET api/authors/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return this.library.GetAuthor(id);
        }

        // POST api/authors
        [HttpPost]
        public IActionResult AddAuthor([FromBody]Author author)
        {
            try
            {
                Author currentAuthor = this.library.AddAuthor(author);
                return this.Created("authors", currentAuthor);
            }
            catch (ArgumentException exception)
            {
                return this.BadRequest(exception.Message);
            }
        }

        // PUT api/authors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Author author)
        {
            this.library.UpdateAuthor(id, author);
        }

        // DELETE api/authors/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.library.DeleteBook(id);
        }
    }
}