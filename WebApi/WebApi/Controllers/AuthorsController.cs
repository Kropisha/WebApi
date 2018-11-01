﻿// <copyright file="AuthorsController.cs" company="PlaceholderCompany">
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
    /// Controller for authors
    /// </summary>
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        /// <summary>
        /// The instance of ILibraryManager
        /// </summary>
        private readonly ILibraryManager library;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="library">current library</param>
        public AuthorsController(ILibraryManager library)
        {
            this.library = library;
        }

        // GET api/authors

        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns>collection with authors</returns>
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return this.library.GetAuthors();
        }

        // GET api/authors/5

        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>current author</returns>
        [HttpGet("{id}")]
        public Author GetAuthor(int id)
        {
            return this.library.GetAuthor(id);
        }

        // POST api/authors

       /// <summary>
       /// Add new author
       /// </summary>
       /// <param name="author">author's instance</param>
       /// <returns>the result of an action</returns>
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

        /// <summary>
        /// Change author's values
        /// </summary>
        /// <param name="id">author's id</param>
        /// <param name="author">current author</param>
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody]Author author)
        {
            this.library.UpdateAuthor(id, author);
        }

        // DELETE api/authors/5

        /// <summary>
        /// Remove author
        /// </summary>
        /// <param name="id">author's id</param>
        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            this.library.DeleteBook(id);
        }
    }
}