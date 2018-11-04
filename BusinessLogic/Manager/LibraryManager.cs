// <copyright file="LibraryManager.cs" company=MyCompany">
// Copyright (c) MyCompany. All rights reserved.
// </copyright>
// <author>Yuliia Kropyvna</author>
namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for managing
    /// </summary>
    public class LibraryManager : ILibraryManager
    {
        #region Definition
        /// <summary>
        /// List of books
        /// </summary>
        private List<Book> books;

        /// <summary>
        /// List of authors
        /// </summary>
        private List<Author> authors;

        /// <summary>
        /// List of genres
        /// </summary>
        private List<Genre> genres;

        /// <summary>
        /// List of book and authors
        /// </summary>
        private List<BookAuthor> bookAuthors;

        /// <summary>
        /// List with book and genres
        /// </summary>
        private List<BookGenre> bookGenres;

        /// <summary>
        /// An instance of data provider
        /// </summary>
      //  private IDataProvider dataProvider; //= new DataProvider();
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryManager"/> class.
        /// </summary>
        public LibraryManager(IDataProvider dataProvider)
        {
            //dataProvider = data;
            this.authors = (List<Author>)dataProvider.Authors();
            this.books = (List<Book>)dataProvider.Books();
            this.genres = (List<Genre>)dataProvider.Genres();
            this.bookAuthors = (List<BookAuthor>)dataProvider.BookAuthors();
            this.bookGenres = (List<BookGenre>)dataProvider.BookGenres();
        }

        #region Adding
        /// <summary>
        /// Add new author
        /// </summary>
        /// <param name="author">author's instance</param>
        /// <returns>the result of an action</returns>
        public Author AddAuthor(Author author)
        {
            if (this.authors.Exists(a => a.Id == author.Id))
            {
                throw new ArgumentException("This id belongs to another author.");
            }

            this.authors.Add(author);

            return author;
        }

        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book">book's instance</param>
        /// <returns>the result of an action</returns>
        public Book AddBook(Book book)
        {
            if (this.books.Exists(b => b.Id == book.Id))
            {
                throw new ArgumentException("This id belongs to another author.");
            }

            this.books.Add(book);

            return book;
        }

        /// <summary>
        /// Add author to book
        /// </summary>
        /// <param name="author">current link between book and author</param>
        /// <returns>link between book and author</returns>
        public BookAuthor AddAuthorToBook(BookAuthor author)
        {
            if (this.bookAuthors.Exists(ba => ba == author))
            {
                throw new ArgumentException("This id belongs to another book.");
            }

            this.bookAuthors.Add(author);

            return author;
        }

        /// <summary>
        /// Add genre to book
        /// </summary>
        /// <param name="genre">current link between book and genre</param>
        /// <returns>link between book and genre</returns>
        public BookGenre AddGenreToBook(BookGenre genre)
        {
            if (this.bookGenres.Exists(bg => bg == genre))
            {
                throw new ArgumentException("This id belongs to another book.");
            }

            this.bookGenres.Add(genre);

            return genre;
        }

        /// <summary>
        /// Add new genre
        /// </summary>
        /// <param name="genre">genre's instance</param>
        /// <returns>the result of an action</returns>
        public Genre AddGenre(Genre genre)
        {
            if (this.genres.Exists(g => g.Id == genre.Id))
            {
                throw new ArgumentException("This id belongs to another author.");
            }

            this.genres.Add(genre);

            return genre;
        }

        #endregion

        #region Getting
        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        public IEnumerable<Book> GetBooks()
        {
            return this.books;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns>book collection</returns>
        public IEnumerable<Author> GetAuthors()
        {            
            return this.authors;
        }

        /// <summary>
        /// Get book by id
        /// </summary>
        /// <param name="id">book's id</param>
        /// <returns>current book</returns>
        public Book GetBook(uint id)
        {
            if (!this.books.Exists(b => b.Id == id))
            {
                throw new ArgumentException("No book with this id");
            }

            return this.books.Find(b => b.Id == id);
        }

        /// <summary>
        /// Get author by id
        /// </summary>
        /// <param name="id">author's id</param>
        /// <returns>current author</returns>
        public Author GetAuthor(uint id)
        {
            if (!this.authors.Exists(b => b.Id == id))
            {
                throw new ArgumentException("No author with this id");
            }

            return this.authors.Find(a => a.Id == id);
        }

        /// <summary>
        /// Get all genres
        /// </summary>
        /// <returns>genres collection</returns>
        public IEnumerable<Genre> GetGenres()
        {
            return this.genres;
        }

        /// <summary>
        /// Get genre by id
        /// </summary>
        /// <param name="id">genre's id</param>
        /// <returns>current genre</returns>
        public Genre GetGenre(uint id)
        {
            if (!this.genres.Exists(g => g.Id == id))
            {
                throw new ArgumentException("No genre with this id");
            }

            return this.genres.Find(g => g.Id == id);
        }
        #endregion

        #region Changing
        /// <summary>
        /// Change book's values
        /// </summary>
        /// <param name="id">book's id</param>
        /// <param name="newBook">current book</param>
        /// <returns>a book instance</returns>
        public Book UpdateBook(uint id, Book newBook)
        {
            if (!this.books.Exists(b => b.Id == id))
            {
                throw new ArgumentException("No book with this id");
            }

            foreach (var book in books)
            {
                if (book.Id == id)
                {
                    book.Name = newBook.Name;
                    book.Year = newBook.Year;
                }
            }

            return this.books.Where(b => b.Id == id).Single();
        }

        /// <summary>
        /// Change author's values
        /// </summary>
        /// <param name="id">author's id</param>
        /// <param name="newAuthor">current author</param>
        /// <returns>an author instance</returns>
        public Author UpdateAuthor(uint id, Author newAuthor)
        {
            if (!this.authors.Exists(b => b.Id == id))
            {
                throw new ArgumentException("No book with this id.");
            }
            foreach (var author in authors)
            {
                if(author.Id == id)
                {
                    author.Name = newAuthor.Name;
                    author.BirthYear = newAuthor.BirthYear;
                }
            }

            return this.authors.Where(a => a.Id == id).Single();
        }

        /// <summary>
        /// Change author for book
        /// </summary>
        /// <param name="newAuthor">current link between book and author</param>
        /// <returns>link between book and author</returns>
        public BookAuthor ChangeAuthor(BookAuthor newAuthor)
        {
            if (!this.bookAuthors.Exists(ba => ba.BookId == newAuthor.BookId))
            {
                throw new ArgumentException("No book with this id.");
            }

            foreach (var author in bookAuthors)
            {
                if (author.BookId == newAuthor.BookId)
                {
                    author.AuthorId = newAuthor.AuthorId;
                }
            }

            return this.bookAuthors.Where(ba => ba.BookId == newAuthor.BookId).Single();
        }

        /// <summary>
        /// Change genre for book
        /// </summary>
        /// <param name="newGenre">current link between book and genre</param>
        /// <returns>link between book and genre</returns>
        public BookGenre ChangeGenre(BookGenre newGenre)
        {
            if (!this.bookGenres.Exists(bg => bg.BookId == newGenre.BookId))
            {
                throw new ArgumentException("No book with this id.");
            }

            foreach (var book in bookGenres)
            {
                if (book.BookId == newGenre.BookId)
                {
                    book.GenreId = newGenre.GenreId;
                }
            }

            return this.bookGenres.Where(bg => bg.BookId == newGenre.BookId).Single();
        }
        #endregion

        #region Deleting
        /// <summary>
        /// Remove book
        /// </summary>
        /// <param name="id">book's id</param>
        public void DeleteBook(uint id)
        {
            if (!this.books.Exists(b => b.Id == id))
            {
                throw new ArgumentException("No book with this id.");
            }

            this.books.Remove(this.books.Find(b => b.Id == id));
        }

        /// <summary>
        /// Remove author
        /// </summary>
        /// <param name="id">author's id</param>
        public void DeleteAuthor(uint id)
        {
            if (!this.authors.Exists(b => b.Id == id))
            {
                throw new ArgumentException("No author with this id.");
            }

            this.authors.Remove(this.authors.Find(b => b.Id == id));
        }

        /// <summary>
        /// Remove genre
        /// </summary>
        /// <param name="id">genre's id</param>
        public void DeleteGenre(uint id)
        {
            if (!this.genres.Exists(g => g.Id == id))
            {
                throw new ArgumentException("No genre with this id.");
            }

            this.genres.Remove(this.genres.Find(b => b.Id == id));
        }

        /// <summary>
        /// Delete author from book
        /// </summary>
        /// <param name="oldAuthor">current link between book and author</param>
        public void DeleteAuthorFromBook(BookAuthor oldAuthor)
        {
            if (!this.bookAuthors.Exists(ba => ba.BookId == oldAuthor.BookId) 
                && !this.bookGenres.Exists(bg => bg.GenreId == oldAuthor.AuthorId))
            {
                throw new ArgumentException("No pair with this id.");
            }

            this.bookAuthors.Remove(this.bookAuthors.Find(ba => ba.AuthorId == oldAuthor.AuthorId));
        }

        /// <summary>
        /// Delete genre from book
        /// </summary>
        /// <param name="oldGenre">current link between book and genre</param>
        public void DeleteGenreFromBook(BookGenre oldGenre)
        {
            if (!this.bookGenres.Exists(bg => bg.BookId == oldGenre.BookId) 
                && !this.bookGenres.Exists(bg => bg.GenreId == oldGenre.GenreId))
            {
                throw new ArgumentException("No pair with this id.");
            }

            this.bookGenres.Remove(this.bookGenres.Find(ba => ba.GenreId == oldGenre.GenreId));
        }
        #endregion
    }
}
