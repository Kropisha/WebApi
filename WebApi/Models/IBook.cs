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
        string Author { get; set; }

        int Id { get; set; }

        string Name { get; set; }

        int Year { get; set; }
    }
}