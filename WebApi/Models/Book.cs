// <copyright file="Book.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Models
{
    public class Book : IBook
    {
        public Book(int id, string name, string author, int year)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.Year = year;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }
    }
}