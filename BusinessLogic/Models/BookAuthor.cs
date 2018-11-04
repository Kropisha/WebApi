// <copyright file="BookAuthor.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// An instance of link between book and author
    /// </summary>
    public class BookAuthor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookAuthor"/> class.
        /// </summary>
        /// <param name="bookId">book's id</param>
        /// <param name="authorId">author's id</param>
        public BookAuthor(uint bookId, uint authorId)
        {
            this.BookId = bookId;
            this.AuthorId = authorId;
        }

        /// <summary>
        /// Gets or sets the book's id
        /// </summary>
        [Required(ErrorMessage = "Every book has id.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint BookId { get; set; }

        /// <summary>
        /// Gets or sets the author's id
        /// </summary>
        [Required(ErrorMessage = "Every author has id.")]
        [Range(1, uint.MaxValue, ErrorMessage = "It should be a positive natural number.")]
        public uint AuthorId { get; set; }
    }
}
