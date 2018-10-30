// <copyright file="BooksSet.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Library
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using WebApi.Models;

    /// <summary>
    /// Class for set of books
    /// </summary>
    public class BooksSet
    {
        /// <summary>
        /// list of books
        /// </summary>
        private List<Book> library = new List<Book>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksSet"/> class
        /// </summary>
        public BooksSet()
        {
            this.library.Add(new Book(00001, "1984", "George Orwell", 1949));
            this.library.Add(new Book(00002, "Brave New World", "Aldous Huxley", 1932));
            this.library.Add(new Book(00003, "Pride and Prejudice", " Jane Austen", 1813));
            this.library.Add(new Book(00004, "Fahrenheit 451", "Ray Bradbury", 1953));
            this.library.Add(new Book(00005, "The Lovely Bones", "Alice Sebold", 2002));
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        public IEnumerable<Book> GetBooks()
        {
            return this.library;
        }

        /// <summary>
        /// Get one book
        /// </summary>
        /// <param name="id">book`s id</param>
        /// <returns>one book</returns>
        public Book GetBook(int id)
        {
            Book book = this.library.ElementAt(id); // Find
            return book;
        }

        /// <summary>
        /// For creating books
        /// </summary>
        /// <param name="book">book instance</param>
        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            this.library.Add(book);
        }

        /// <summary>
        /// Edit exist book
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">book's instance</param>
        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                this.library.Remove(this.library[id]);
                this.library.Insert(id, book);
            }
        }

        /// <summary>
        /// Delete one book
        /// </summary>
        /// <param name="id">book's id</param>
        [HttpDelete]
        public void DeleteBook(int id)
        {
            Book book = this.library[id];
            
            if (book != null)
            {
                this.library.Remove(this.library[id]);
            }
        }
    }
}