// <copyright file="IBook.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Models
{
    /// <summary>
    /// Set the  obvious interface for every book
    /// </summary>
    public interface IBook
    {
        /// <summary>
        /// Gets or sets the book's author
        /// </summary>
        string Author { get; set; }

        /// <summary>
        /// Gets or sets the book's id
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the book's name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the book's year
        /// </summary>
        int Year { get; set; }
    }
}