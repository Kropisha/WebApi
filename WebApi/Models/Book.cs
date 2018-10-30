// <copyright file="Book.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Models
{
    /// <summary>
    /// Set the  obvious interface for every book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="name">book's name</param>
        /// <param name="author">an author</param>
        /// <param name="year">the year of publishing</param>
        public Book(int id, string name, string author, int year)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.Year = year;
        }

        /// <summary>
        /// Gets or sets the book's id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the book's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the book's author
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the book's year
        /// </summary>
        public int Year { get; set; }
    }
}