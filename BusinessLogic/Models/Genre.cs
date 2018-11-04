// <copyright file="Genre.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An instance of genre
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// for automatic id generation
        /// </summary>
        private static uint counter = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Genre"/> class.
        /// </summary>
        /// <param name="name">genre's name</param>
        public Genre(string name)
        {
            this.Name = name;
            this.Id = ++counter;
        }

        /// <summary>
        /// Gets or sets the genre's id
        /// </summary>
        [Required(ErrorMessage = "Every genre has id.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the genre's name
        /// </summary>
        [Required(ErrorMessage = "Every genre has name.")]
        [StringLength(50, ErrorMessage = "Name should be less than 50 characters."), 
            MinLength(3, ErrorMessage = "Name should be more than 3 characters.")]        
        public string Name { get; set; }
    }
}
