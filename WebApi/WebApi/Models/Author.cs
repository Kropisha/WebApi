// <copyright file="Author.cs" company="My Company Name">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Author
    {
        public Author(int id, string name, int birthYear)
        {
            this.Id = id;
            this.Name = name;
            this.BirthYear = birthYear;
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int BirthYear { get; set; }
    }
}
