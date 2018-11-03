// <copyright file="AuthorsController.cs" company="PlaceholderCompany">
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

        /// <summary>
        /// Get all authors // GET api/authors
        /// </summary>
        /// <returns>collection with authors</returns>
        [HttpGet]
        public IEnumerable<Author> GetAuthors()
        {
            return this.library.GetAuthors();
        }

        /// <summary>
        /// Get author by id // GET api/authors/5
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>current author</returns>
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            try
            {
                this.library.GetAuthor(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.library.GetAuthor(id);
        }

        /// <summary>
        /// Add new author // POST api/authors
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
                return this.NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Change author's values // PUT api/authors/5
        /// </summary>
        /// <param name="id">author's id</param>
        /// <param name="author">current author</param>
        /// <returns>the result of editing</returns>
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody]Author author)
        {
            try
            {
                this.library.UpdateAuthor(id, author);
            }
            catch (ArgumentException exception)
            {
                return this.NotFound(exception.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Remove author // DELETE api/authors/5
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>the result of removing</returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                this.library.DeleteAuthor(id);
            }
            catch (ArgumentException exception)
            {
                return this.NotFound(exception.Message);
            }

            return this.Ok();
        }
    }
}