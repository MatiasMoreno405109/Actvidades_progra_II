using proyecto_Practica01_.Data.Implementation;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Services
{
    public class BookService
    {
        private IBookRepository _repository;
        public BookService()
        {
            _repository = new BookRepository();
        }
        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }
        public Book? GetById(int id)
        {
            return _repository.GetById(id);
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool Create(Book book)
        {
            return _repository.Create(book);
        }
    }
}
