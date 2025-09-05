using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Domain
{
    public class Book
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool Active { get; set; }

        public override string ToString()
        {
            return Code + " - " + Title + " - " + Author + " - $" + Price + " - " + Stock + " - " + Active; 
        }
    }
}
