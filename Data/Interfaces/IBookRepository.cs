using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(int codigo);
        bool Create(Book libro);
        bool Delete(int codigo);
    }
}
