// <copyright file="ILibraryManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Library
{
    using System.Collections.Generic;
    using WebApi.Models;

    /// <summary>
    /// Set the  obvious interface for every library
    /// </summary>
    public interface ILibraryManager
    {
        /// <summary>
        /// Add new author
        /// </summary>
        /// <param name="author">author's instance</param>
        /// <returns>the result of an action</returns>
        Author AddAuthor(Author author);

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">book's instance</param>
        /// <returns>the result of an action</returns>
        Book AddBook(Book book);

        /// <summary>
        /// Remove author
        /// </summary>
        /// <param name="id">author's id</param>
        void DeleteAuthor(int id);

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="id">book's id</param>
        void DeleteBook(int id);

        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>current author</returns>
        Author GetAuthor(int id);

        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns>collection with authors</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>current book</returns>
        Book GetBook(int id);

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>collection with books</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Change author's values
        /// </summary>
        /// <param name="id">author's id</param>
        /// <param name="author">current author</param>
        void UpdateAuthor(int id, Author author);

        /// <summary>
        /// Change book's values
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">current book</param>
        void UpdateBook(int id, Book book);
    }
}
