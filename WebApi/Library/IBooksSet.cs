// <copyright file="IBooksSet.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Library
{
    using System.Collections.Generic;
    using System.Web.Http;
    using WebApi.Models;

    /// <summary>
    /// Set the  obvious interface for every books set
    /// </summary>
    public interface IBooksSet
    {
        /// <summary>
        /// For creating books
        /// </summary>
        /// <param name="book">book instance</param>
        void CreateBook([FromBody] Book book);

        /// <summary>
        /// Delete one book
        /// </summary>
        /// <param name="id">book's id</param>
        void DeleteBook(int id);

        /// <summary>
        /// Edit exist book
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">book's instance</param>
        void EditBook(int id, [FromBody] Book book);

        /// <summary>
        /// Get one book
        /// </summary>
        /// <param name="id">book`s id</param>
        /// <returns>one book</returns>
        Book GetBook(int id);

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        IEnumerable<Book> GetBooks();
    }
}