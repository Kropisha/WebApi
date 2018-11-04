// <copyright file="IBook.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.Collections.Generic;

    /// <summary>
    /// The obvious interface for every book
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">book's instance</param>
        /// <returns>the result of an action</returns>
        Book AddBook(Book book);

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>current book</returns>
        Book GetBook(uint id);

        /// <summary>
        /// Change book's values
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="newBook">current book</param>
        /// <returns>a book instance</returns>
        Book UpdateBook(uint id, Book newBook);

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="id">book's id</param>
        void DeleteBook(uint id);
    }
}
