// <copyright file="IGenre.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.Collections.Generic;

    /// <summary>
    /// The obvious interface for every genre
    /// </summary>
    public interface IGenre
    {
        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="genre">genre's instance</param>
        /// <returns>the result of an action</returns>
        Genre AddGenre(Genre genre);

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>genres collection</returns>
        IEnumerable<Genre> GetGenres();

        /// <summary>
        /// Get genre by id
        /// </summary>
        /// <param name="id">genre's id</param>
        /// <returns>current genre</returns>
        Genre GetGenre(uint id);

        /// <summary>
        /// Remove genre
        /// </summary>
        /// <param name="id">genre's id</param>
        void DeleteGenre(uint id);
    }
}
