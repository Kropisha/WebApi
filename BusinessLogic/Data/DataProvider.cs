// <copyright file="DataProvider.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for initialization
    /// </summary>
    public class DataProvider : IDataProvider
    {
        /// <summary>
        /// Initializes books
        /// </summary>
        /// <returns>collection of books</returns>
        public IEnumerable<Book> Books()
        {
            List<Book> books = new List<Book>
            {
            new Book("1984", 1949),
            new Book("Animal farm", 1945),
            new Book("Brave New World", 1932),
            new Book("Pride and Prejudice", 1813),
            new Book("Fahrenheit 451", 1953),
            new Book("Dandelion Wine", 1957),
            new Book("The Lovely Bones", 2002)
            };

            return books;
        }

        /// <summary>
        /// Initializes authors
        /// </summary>
        /// <returns>collection of authors</returns>
        public IEnumerable<Author> Authors()
        {
            List<Author> authors = new List<Author>
                {
                   new Author("George Orwell", 1903),
                   new Author("Aldous Huxley", 1894),
                   new Author("Jane Austen", 1775),
                   new Author("Ray Bradbury", 1920),
                   new Author("Alice Sebold", 1963)
                };

                return authors;        
        }

        /// <summary>
        /// Initializes genres
        /// </summary>
        /// <returns>collection of genres</returns>
        public IEnumerable<Genre> Genres()
        {
            List<Genre> genres = new List<Genre>
            {
            new Genre("Romance"),
            new Genre("Science fiction"),
            new Genre("Drama"),
            new Genre("Adventure")
            };
        
            return genres;
        }

        /// <summary>
        /// Initializes links for book and authors
        /// </summary>
        /// <returns>collection of links</returns>
        public IEnumerable<BookAuthor> BookAuthors()
        {
            List<BookAuthor> bookAuthors = new List<BookAuthor>
            {
                new BookAuthor(1, 1),
                new BookAuthor(2, 1),
                new BookAuthor(3, 2),
                new BookAuthor(4, 3),
                new BookAuthor(5, 4),
                new BookAuthor(6, 4),
                new BookAuthor(7, 5)
            };

            return bookAuthors;
        }

        /// <summary>
        /// Initializes links for book and genres
        /// </summary>
        /// <returns>collection of links</returns>
        public IEnumerable<BookGenre> BookGenres()
        {
            List<BookGenre> bookGenres = new List<BookGenre>
            {
                new BookGenre(1, 1),
                new BookGenre(2, 1),
                new BookGenre(3, 2),
                new BookGenre(4, 3)
            };

            return bookGenres;
        }
    }
}
