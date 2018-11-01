// <copyright file="LibraryManager.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Library
{
    using System;
    using System.Collections.Generic;
    using WebApi.Models;

    public class LibraryManager : ILibraryManager
    {
        private List<Book> books = new List<Book>();
        private List<Author> authors = new List<Author>();

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

        public Author AddAuthor(Author author)
        {
            this.authors.Add(author);
            return author;
        }

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

        public void UpdateAuthor(int id, Author author)
        {
            Author currentAuthor = this.authors[id - 1];
            if (currentAuthor != null)
            {
                currentAuthor.Name = author.Name;
                currentAuthor.BirthYear = author.BirthYear;
            }
        }

        public void DeleteBook(int id)
        {
            Book currentBook = this.books[id - 1];
            if (currentBook != null)
            {
                this.books.Remove(currentBook);
            }
        }

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
