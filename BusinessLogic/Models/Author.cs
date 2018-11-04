// <copyright file="Author.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An instance of author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// for automatic id generation
        /// </summary>
        private static uint counter = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        public Author()
        {
            this.Id = 0;
            this.Name = "test";
            this.BirthYear = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        /// <param name="name">an author's full name</param>
        /// <param name="birthYear">an author's birth year</param>
        public Author(string name, uint birthYear)
        {
            this.Id = ++counter;
            this.Name = name;
            this.BirthYear = birthYear;
        }

        /// <summary>
        /// Gets or sets author's id
        /// </summary>
        [Required(ErrorMessage = "Every author has id.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets author's name
        /// </summary>
        [Required(ErrorMessage = "Every author has name.")]
        [StringLength(60, ErrorMessage = "Name should be less than 60 characters."),
            MinLength(4, ErrorMessage = "Name should be more than 4 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets author's birth year
        /// </summary>
        [Required(ErrorMessage = "Every author has year of birth.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint BirthYear { get; set; }
    }
}
