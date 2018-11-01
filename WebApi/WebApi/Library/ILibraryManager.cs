// <copyright file="ILibraryManager.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Library
{
    using System.Collections.Generic;
    using WebApi.Models;

    public interface ILibraryManager
    {
        Author AddAuthor(Author author);

        Book AddBook(Book book);

        void DeleteAuthor(int id);

        void DeleteBook(int id);

        Author GetAuthor(int id);

        IEnumerable<Author> GetAuthors();

        Book GetBook(int id);

        IEnumerable<Book> GetBooks();

        void UpdateAuthor(int id, Author author);

        void UpdateBook(int id, Book book);
    }
}
