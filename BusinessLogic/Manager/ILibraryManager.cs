// <copyright file="ILibraryManager.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    /// <summary>
    /// Interface for library manager
    /// </summary>
    public interface ILibraryManager : IBook, IAuthor, IGenre
    {
        /// <summary>
        /// Add author to book
        /// </summary>
        /// <param name="author">current link between book and author</param>
        /// <returns>link between book and author</returns>
        BookAuthor AddAuthorToBook(BookAuthor author);

        /// <summary>
        /// Add genre to book
        /// </summary>
        /// <param name="genre">current link between book and genre</param>
        /// <returns>link between book and genre</returns>
        BookGenre AddGenreToBook(BookGenre genre);

        /// <summary>
        /// Change author for book
        /// </summary>
        /// <param name="newAuthor">current link between book and author</param>
        /// <returns>link between book and author</returns>
        BookAuthor ChangeAuthor(BookAuthor newAuthor);

        /// <summary>
        /// Change genre for book
        /// </summary>
        /// <param name="newGenre">current link between book and genre</param>
        /// <returns>link between book and genre</returns>
        BookGenre ChangeGenre(BookGenre newGenre);

        /// <summary>
        /// Delete author from book
        /// </summary>
        /// <param name="oldAuthor">current link between book and author</param>
        void DeleteAuthorFromBook(BookAuthor oldAuthor);

        /// <summary>
        /// Delete genre from book
        /// </summary>
        /// <param name="oldGenre">current link between book and genre</param>
        void DeleteGenreFromBook(BookGenre oldGenre);
    }
}