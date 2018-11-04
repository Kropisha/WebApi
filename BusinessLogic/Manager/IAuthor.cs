// <copyright file="IAuthor.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.Collections.Generic;

    /// <summary>
    /// The obvious interface for every author
    /// </summary>
    public interface IAuthor
    {
        /// <summary>
        /// Add new author
        /// </summary>
        /// <param name="author">author's instance</param>
        /// <returns>the result of an action</returns>
        Author AddAuthor(Author author);

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>current author</returns>
        Author GetAuthor(uint id);

        /// <summary>
        /// Change author's values
        /// </summary>
        /// <param name="id">author's id</param>
        /// <param name="newAuthor">current author</param>
        /// <returns>an author instance</returns>
        Author UpdateAuthor(uint id, Author newAuthor);

        /// <summary>
        /// Remove author
        /// </summary>
        /// <param name="id">author's id</param>
        void DeleteAuthor(uint id);
    }
}
