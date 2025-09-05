using Microsoft.Data.SqlClient;
using proyecto_Practica01_.Data.Helper;
using proyecto_Practica01_.Data.Interfaces;
using proyecto_Practica01_.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data.Implementation
{
    public class BookRepository : IBookRepository
    {

        public bool Create(Book book)
        {
            bool result;

            List<SpParameter> parameters = new List<SpParameter>()
            {
                new SpParameter("@titulo",book.Title),
                new SpParameter("@autor",book.Author),
                new SpParameter("@precio",book.Price),
                new SpParameter("@activo",book.Active),
                new SpParameter("@stock",book.Stock)
            };
            result = DataHelper.GetInstance().ExecuteSpDml("SP_CREAR_LIBRO", parameters);

            return result;
        }

        public bool Delete(int code)
        {
            List<SpParameter> parameters = new List<SpParameter>()
            {
                new SpParameter("@codigo", code)
            };

            return DataHelper.GetInstance().ExecuteSpDml("SP_REGISTRAR_BAJA_LIBRO", parameters);
        }

        public List<Book> GetAll()
        {
            //TRAER REGISTROS DE LA BD.
            var dt = DataHelper.GetInstance().ExecuteSpQuery("SP_RECUPERAR_LIBROS");
            return MapBook(dt);
        }
        //MAPEAR LISTA DE LIBROS
        private List<Book> MapBook(DataTable dt)
        {
            List<Book> lstBooks = new List<Book>();
            foreach (DataRow fila in dt.Rows)
            {
                Book oBook = new Book();
                oBook.Code = (int)fila[0];
                oBook.Title = fila[1].ToString();
                oBook.Author = fila[2].ToString();
                oBook.Price = (decimal)fila[3];
                oBook.Active = (bool)fila[4];
                oBook.Stock = (int)fila[5];
                lstBooks.Add(oBook);
            }
            return lstBooks;
        }

        public Book? GetById(int code)
        {
            List<SpParameter> parameters = new List<SpParameter>()
            {
                new SpParameter("@codigo",code)
            };

            var dt = DataHelper.GetInstance().ExecuteSpQuery("SP_RECUPERAR_LIBRO_POR_CODIGO", parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                return MapBookById(dt);
            }
            return null;
        }
        //MAPEAR LIBRO POR ID
        private Book MapBookById(DataTable dt)
        {
            Book b = new Book()
            {
                Code = (int)dt.Rows[0]["cod_libro"],
                Title = (string)dt.Rows[0]["titulo"],
                Author = (string)dt.Rows[0]["autor"],
                Price = (decimal)dt.Rows[0]["precio"],
                Active = (bool)dt.Rows[0]["activo"],
                Stock = (int)dt.Rows[0]["stock"]
            };
            return b;
        }
    }
}

