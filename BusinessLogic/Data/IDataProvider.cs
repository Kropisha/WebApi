// <copyright file="IDataProvider.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.Collections.Generic;

    /// <summary>
    /// The obvious interface for initializing
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Set the default collection of authors
        /// </summary>
        /// <returns>collection of authors</returns>
        IEnumerable<Author> Authors();

        /// <summary>
        /// Set the default collection of books and authors
        /// </summary>
        /// <returns>collection of books and authors</returns>
        IEnumerable<BookAuthor> BookAuthors();

        /// <summary>
        /// Set the default collection of books and genres
        /// </summary>
        /// <returns>collection of books and genres</returns>
        IEnumerable<BookGenre> BookGenres();

        /// <summary>
        /// Set the default collection of books
        /// </summary>
        /// <returns>collection of books</returns>
        IEnumerable<Book> Books();

        /// <summary>
        /// Set the default collection of genres
        /// </summary>
        /// <returns>collection of genres</returns>
        IEnumerable<Genre> Genres();
    }
}