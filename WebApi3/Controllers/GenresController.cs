// <copyright file="GenresController.cs" company=MyCompany">
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
    /// Genres controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        /// <summary>
        /// Library instance
        /// </summary>
        private readonly ILibraryManager library;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenresController"/> class.
        /// </summary>
        /// <param name="library">library instance</param>
        public GenresController(ILibraryManager library)
        {
            this.library = library;
        }

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>collection with genres</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            if ((List<Genre>)this.library.GetGenres() == null)
            {
                return this.NotFound("The library hasn't got genres.");
            }

            return this.Ok(this.library.GetGenres());
        }

        /// <summary>
        /// Get genre by id
        /// </summary>
        /// <param name="id">genre's id</param>
        /// <returns>current genre</returns>
        [HttpGet("{id}")]
        public ActionResult<Genre> GetGenre(uint id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid genre id.");
            }

            try
            {
                this.library.GetGenre(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            if (this.library.GetGenre(id) == null)
            {
                return this.NotFound("We don't have genres with this id.");
            }

            return this.Ok();
        }

        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="genre">genre's instance</param>
        /// <returns>the result of adding genre</returns>
        [HttpPost]
        public IActionResult AddGenre([FromBody]Genre genre)
        {
            Genre currentGenre = null;
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            try
            {
               currentGenre = this.library.AddGenre(genre);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Created("authors", currentGenre);
        }

        /// <summary>
        /// Add genre to book
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="authorId">author's id</param>
        /// <returns>link between book and genre</returns>
        [HttpPost("{bookId},{authorId}")]
        public ActionResult<BookGenre> AddGenreToBook(uint bookId, uint authorId)
        {
            BookGenre genre = new BookGenre(bookId, authorId);
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            if (this.library.GetBook(genre.BookId) == null)
            {
                return this.NotFound("Wrong book id");
            }

            Genre current = this.library.GetGenre(genre.GenreId);
            if (genre.GenreId != current.Id)
            {
                return this.NotFound("Wrong genre id");
            }

            try
            {
                this.library.AddGenreToBook(genre);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Change genre for book
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="authorId">author's id</param>
        /// <returns>link between book and genre</returns>
        [HttpPut("{bookId},{authorId}")]
        public ActionResult<BookGenre> ChangeGenre(uint bookId, uint authorId)
        {
            BookGenre newGenre = new BookGenre(bookId, authorId);
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            if (this.library.GetBook(newGenre.BookId) == null)
            {
                return this.NotFound("No book with this id");
            }

            try
            {
                this.library.ChangeGenre(newGenre);
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
                return this.BadRequest("Invalid genre id.");
            }

            if (this.library.GetGenre(id) == null)
            {
                return this.NotFound("We don't have genre with this id.");
            }

            try
            {
                this.library.DeleteGenre(id);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }

        /// <summary>
        /// Delete genre from book
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="authorId">author's id</param>
        /// <returns>deleting action</returns>
        [HttpDelete("{bookId},{authorId}")]
        public IActionResult DeleteGenreFromBook(uint bookId, uint authorId)
        {
            BookGenre oldGenre = new BookGenre(bookId, authorId);
            if (!ModelState.IsValid)
            {
                return this.BadRequest("Invalid infornation input.");
            }

            if (this.library.GetBook(oldGenre.BookId) == null)
            {
                return this.NotFound("No book with this id");
            }

            Genre current = this.library.GetGenre(oldGenre.GenreId);
            if (oldGenre.GenreId != current.Id)
            {
                return this.NotFound("Wrong author id");
            }

            try
            {
                this.library.DeleteGenreFromBook(oldGenre);
            }
            catch (ArgumentException ex)
            {
                return this.NotFound(ex.Message);
            }

            return this.Ok();
        }
    }
}