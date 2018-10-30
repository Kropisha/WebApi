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

    public class BooksSet
    {
        private List<Book> library = new List<Book>();

        public BooksSet()
        {
            this.library.Add(new Book(00001, "1984", "George Orwell", 1949));
            this.library.Add(new Book(00002, "Brave New World", "Aldous Huxley", 1932));
            this.library.Add(new Book(00003, "Pride and Prejudice", " Jane Austen", 1813));
            this.library.Add(new Book(00004, "Fahrenheit 451", "Ray Bradbury", 1953));
            this.library.Add(new Book(00005, "The Lovely Bones", "Alice Sebold", 2002));
        }

        public IEnumerable<Book> GetBooks()
        {
            return this.library;
        }

        public Book GetBook(int id)
        {
            Book book = this.library.ElementAt(id); // Find
            return book;
        }

        [HttpPost]
        public void CreateBook([FromBody]Book book)
        {
            this.library.Add(book);
        }

        [HttpPut]
        public void EditBook(int id, [FromBody]Book book)
        {
            if (id == book.Id)
            {
                this.library.Remove(this.library[id]);
                this.library.Insert(id, book);
            }
        }

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