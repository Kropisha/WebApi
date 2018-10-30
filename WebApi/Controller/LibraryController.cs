// <copyright file="LibraryController.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Controller
{
    using System.Collections.Generic;
    using System.Web.Http;
    using WebApi.Library;
    using WebApi.Models;
    [Route("api/[controller]")]

    public class LibraryController : ApiController
    {
        private BooksSet _books = new BooksSet();

        [Route("api/library")]
        [HttpGet]
        public IEnumerable<Book> GetAll()
        {
             return _books.GetBooks();
        }

        [Route("api/library/{id}")]
        [HttpGet]
        public Book GetById(int id)
        {
            return _books.GetBook(id);
        }

        [Route("api/library/create/{book}")]
        [HttpPost]
        public void CreateBook(Book book)
        {
          _books.CreateBook(book);   
        }

        [Route("api/library/edit/{id},{book}")]
        [HttpPut]
        public void EditBook(int id, Book book)
        {
            _books.EditBook(id, book);
        }

        [Route("api/library/delete/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            _books.DeleteBook(id);
        }
    }
}
