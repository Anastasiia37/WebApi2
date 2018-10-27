using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BookRepository : IRepository
    {
        public List<Book> Books = new List<Book>();

        private static BookRepository instance;

        private BookRepository()
        {
            Books.Add(new Book { Id = 1, Name = "Война и мир", Author = "Л. Толстой", Year = 1863 });
            Books.Add(new Book { Id = 2, Name = "Отцы и дети", Author = "И. Тургенев", Year = 1862 });
            Books.Add(new Book { Id = 3, Name = "Чайка", Author = "А. Чехов", Year = 1896 });
        }
        
        public static BookRepository getInstance()
        {
            if (instance == null)
                instance = new BookRepository();
            return instance;
        }

        public IList<Book> GetAll()
        {
            return Books;
        }

        public Book GetById(int id)
        {
            foreach (Book book in Books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }

            return null;
        }

        public void DeleteBook(int id)
        {
            foreach (Book book in Books)
            {
                if (book.Id == id)
                {
                    Books.Remove(book);
                    break;
                }
            }

            return;        
        }

        public void Add(Book book)
        {
            Books.Add(book);
            return;
        }

        public void Update(int id, string author)
        {
            foreach (Book book in Books)
            {
                if (book.Id == id)
                {
                    book.Author = author;
                    break;
                }
            }
            return;
        }
    }
}
