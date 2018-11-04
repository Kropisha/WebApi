// <copyright file="AuthorsController.cs" company=MyCompany">
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
    /// Authors Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        /// <summary>
        /// Library instance
        /// </summary>
        private readonly ILibraryManager library;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorsController"/> class.
        /// </summary>
        /// <param name="library">library instance</param>
        public AuthorsController(ILibraryManager library)
        {
            this.library = library;
        }

        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns>collection with authors</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            if ((List<Author>)this.library.GetAuthors() == null)
            {
                return this.NotFound("The library hasn't got authors.");
            }

            return this.Ok(this.library.GetAuthors());
        }

        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>current author</returns>
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(uint id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid author id.");
            }

            try
            {
                this.library.GetAuthor(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            if (this.library.GetAuthor(id) == null)
            {
                return this.NotFound("We don't have author with this id.");
            }

            return this.Ok();
        }

        /// <summary>
        /// Add new author
        /// </summary>
        /// <param name="author">author's instance</param>
        /// <returns>the result of an action</returns>
        [HttpPost]
        public IActionResult AddAuthor([FromBody]Author author)
        {
            Author currentAuthor = null;
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            try
            {
               currentAuthor = this.library.AddAuthor(author);
            }
            catch (ArgumentException ex)
            {
                return this.BadRequest(ex.Message);
            }

            return this.Created("authors", currentAuthor);
        }

        /// <summary>
        /// Add author to book
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="authorId">author's id</param>
        /// <returns>link between book and author</returns>
        [HttpPost("{bookId},{authorId}")]
        public ActionResult<BookAuthor> AddAuthorToBook(uint bookId, uint authorId)
        {
            BookAuthor author = new BookAuthor(bookId, authorId);
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            if (this.library.GetBook(bookId) == null)
            {
                return this.NotFound("Wrong book id");
            }

            if (this.library.GetAuthor(authorId) == null)
            {
                return this.NotFound("Wrong author id");
            }

            try
            {
                this.library.AddAuthorToBook(author);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Change author's values
        /// </summary>
        /// <param name="id">author's id</param>
        /// <param name="author">current author</param>
        /// <returns>editing action</returns>
        [HttpPut("{id}")]
        public IActionResult Edit(uint id, [FromBody]Author author)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            if (this.library.GetAuthor(id) == null)
            {
                return this.NotFound("We don't have author with this id.");
            }

            try
            {
                this.library.UpdateAuthor(id, author);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Change author for book
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="authorId">author's id</param>
        /// <returns>link between book and author</returns>
        [HttpPut("{bookId},{authorId}")]
        public ActionResult<BookAuthor> ChangeAuthor(uint bookId, uint authorId)
        {
            BookAuthor newAuthor = new BookAuthor(bookId, authorId);
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            if (this.library.GetBook(newAuthor.BookId) == null)
            {
                return this.NotFound("No book with this id");
            }

            try
            {
                this.library.ChangeAuthor(newAuthor);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Remove author
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>removing action</returns>
        [HttpDelete("{id}")]
        public IActionResult Remove(uint id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid author id.");
            }

            if (this.library.GetAuthor(id) == null)
            {
                return this.NotFound("We don't have author with this id.");
            }

            try
            {
                this.library.DeleteAuthor(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Delete author from book
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="authorId">author's id</param>
        /// <returns>deleting action</returns>
        [HttpDelete("{bookId},{authorId}")]
        public IActionResult DeleteAuthorFromBook(uint bookId, uint authorId)
        {
            BookAuthor oldAuthor = new BookAuthor(bookId, authorId);
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            if (this.library.GetBook(oldAuthor.BookId) == null)
            {
                return this.NotFound("No book with this id");
            }

            Author current = this.library.GetAuthor(oldAuthor.AuthorId);
            if (oldAuthor.AuthorId != current.Id)
            {
                return this.NotFound("Wrong author id");
            }

            try
            {
                this.library.DeleteAuthorFromBook(oldAuthor);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }
    }
}