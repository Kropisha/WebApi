// <copyright file="LibraryManager.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Library
{
    using System;
    using System.Collections.Generic;
    using WebApi.Models;

    /// <summary>
    /// Class for implementing interface
    /// </summary>
    public class LibraryManager : ILibraryManager
    {
        /// <summary>
        /// List of books
        /// </summary>
        private List<Book> books = new List<Book>();

        /// <summary>
        /// List of authors
        /// </summary>
        private List<Author> authors = new List<Author>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryManager"/> class.
        /// </summary>
        public LibraryManager()
        {
            this.authors.Add(new Author(1, "George Orwell", 1903));
            this.authors.Add(new Author(2, "Aldous Huxley", 1894));
            this.authors.Add(new Author(3, "Jane Austen", 1775));
            this.authors.Add(new Author(4, "Ray Bradbury", 1920));
            this.authors.Add(new Author(5, "Alice Sebold", 1963));

            this.books.Add(new Book(1, "1984", 1, 1949));
            this.books.Add(new Book(2, "Animal farm", 1, 1945));
            this.books.Add(new Book(3, "Brave New World", 2, 1932));
            this.books.Add(new Book(4, "Pride and Prejudice", 3, 1813));
            this.books.Add(new Book(5, "Fahrenheit 451", 4, 1953));
            this.books.Add(new Book(6, "Dandelion Wine", 4, 1957));
            this.books.Add(new Book(7, "The Lovely Bones", 5, 2002));
        }

        /// <summary>
        /// Add new author
        /// </summary>
        /// <param name="author">author's instance</param>
        /// <returns>the result of an action</returns>
        public Author AddAuthor(Author author)
        {
            this.authors.Add(author);
            return author;
        }

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">book's instance</param>
        /// <returns>the result of an action</returns>
        public Book AddBook(Book book)
        {
            this.books.Add(book);
            return book;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        public IEnumerable<Book> GetBooks()
        {
            return this.books;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return this.authors;
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>current book</returns>
        public Book GetBook(int id)
        {
            if (this.books[id - 1].Id == id)
            {
                return this.books[id - 1];
            }
            else
            {
                throw new ArgumentException("No book with this id");
            }
        }

        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>current author</returns>
        public Author GetAuthor(int id)
        {
            if (this.authors[id - 1].Id == id)
            {
                return this.authors[id - 1];
            }
            else
            {
                throw new ArgumentException("No author with this id");
            }
        }

        /// <summary>
        /// Change book's values
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="book">current book</param>
        public void UpdateBook(int id, Book book)
        {
            Book currentBook = this.books[id - 1];
            if (currentBook != null)
            {
                currentBook.Name = book.Name;
                currentBook.Year = book.Year;
                currentBook.AuthorId = book.AuthorId;
            }
        }

        /// <summary>
        /// Change author's values
        /// </summary>
        /// <param name="id">author's id</param>
        /// <param name="author">current author</param>
        public void UpdateAuthor(int id, Author author)
        {
            Author currentAuthor = this.authors[id - 1];
            if (currentAuthor != null)
            {
                currentAuthor.Name = author.Name;
                currentAuthor.BirthYear = author.BirthYear;
            }
        }

        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="id">book's id</param>
        public void DeleteBook(int id)
        {
            Book currentBook = this.books[id - 1];
            if (currentBook != null)
            {
                this.books.Remove(currentBook);
            }
        }

        /// <summary>
        /// Remove author
        /// </summary>
        /// <param name="id">author's id</param>
        public void DeleteAuthor(int id)
        {
            Author currentAuthor = this.authors[id - 1];
            if (currentAuthor != null)
            {
                this.authors.Remove(currentAuthor);
            }
        }
    }
}
