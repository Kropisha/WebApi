// <copyright file="Book.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="name">book's name</param>
        /// <param name="authorId">an author's id</param>
        /// <param name="year">the year of publishing</param>
        public Book(int id, string name, int authorId, int year)
        {
            this.Id = id;
            this.Name = name;
            this.AuthorId = authorId;
            this.Year = year;
        }

        /// <summary>
        /// Gets or sets the book's id
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the book's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the book's author
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the book's year
        /// </summary>
        public int Year { get; set; }
    }
}
