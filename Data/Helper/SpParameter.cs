using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_Practica01_.Data.Helper
{
    public class SpParameter
    {
        public string Name { get; set; }
        public object Valor { get; set; }
        public SpParameter(string name, object valor)
        {
            Name = name;
            Valor = valor;
        }
    }
}
