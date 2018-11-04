// <copyright file="Book.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An instance of book
    /// </summary>
    public class Book
    {
        /// <summary>
        /// for automatic id generation
        /// </summary>
        private static uint counter = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class
        /// </summary>
        /// <param name="name">book's name</param>
        /// <param name="year">the year of publishing</param>
        public Book(string name, uint year)
        {
            this.Id = ++counter;
            this.Name = name;
            this.Year = year;
        }

        /// <summary>
        /// Gets or sets the book's id
        /// </summary>
        [Required(ErrorMessage = "Every book has id.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the book's name
        /// </summary>
        [Required(ErrorMessage = "Every book has name.")]
        [StringLength(50, ErrorMessage = "Name should be less than 50 characters."), 
            MinLength(3, ErrorMessage = "Name should be more than 3 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the book's year
        /// </summary>
        [Required(ErrorMessage = "Every book has year of publishing.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint Year { get; set; }
    }
}
