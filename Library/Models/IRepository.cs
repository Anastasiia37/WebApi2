using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public interface IRepository
    {
        IList<Book> GetAll();
        Book GetById(int id);
        void DeleteBook(int id);
        void Add(Book book);
        void Update(int id, string author);
    }
}
