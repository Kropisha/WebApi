// <copyright file="BookGenre.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An instance of link between book and genre
    /// </summary>
    public class BookGenre
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookGenre"/> class.
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="genreId">genre's id</param>
        public BookGenre(uint bookId, uint genreId)
        {
            this.BookId = bookId;
            this.GenreId = genreId;
        }

        /// <summary>
        /// Gets or sets the book's id
        /// </summary>
        [Required(ErrorMessage = "Every book has id.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint BookId { get; set; }

        /// <summary>
        /// Gets or sets the genre's id
        /// </summary>
        [Required(ErrorMessage = "Every genre has id.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint GenreId { get; set; }
    }
}
