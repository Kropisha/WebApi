// <copyright file="Author.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An instance of author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class
        /// </summary>
        /// <param name="id">an author's id</param>
        /// <param name="name">an author's full name</param>
        /// <param name="birthYear">an author's birth year</param>
        public Author(int id, string name, int birthYear)
        {
            this.Id = id;
            this.Name = name;
            this.BirthYear = birthYear;
        }

        /// <summary>
        /// Gets or sets author's id
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets author's name
        /// </summary>
        [StringLength(60)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets author's birth year
        /// </summary>
        public int BirthYear { get; set; }
    }
}
