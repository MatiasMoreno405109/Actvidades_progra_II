using proyecto_Practica01_.Domain;
using proyecto_Practica01_.Services;

BookService oService = new BookService();

Console.WriteLine("Obtener todos los libros:");

List<Book> lst = oService.GetAll();

if(lst.Count > 0)
{
    foreach (Book b in lst)
    {
        Console.WriteLine(b);
    }
}
else
{
    Console.WriteLine("No hay libros.");
}

//TRAER LIBRO POR ID

Console.WriteLine("Obtener libro por ID:");

Book? oBook1 = oService.GetById(3);

if(oBook1 != null)
{
    Console.WriteLine(oBook1);
}
else
{
    Console.WriteLine("No hay libros con ese codigo");
}


//BAJA LOGICA

Console.WriteLine("DAR DE BAJA UN LIBRO:");

bool result = oService.Delete(1);
if (result)
{
    Console.WriteLine("Se ha dado de baja el libro con código = 1");
}
else
{
    Console.WriteLine("No hay libros con ese código");
}

//CREAR LIBRO
Console.WriteLine("Crear Libro:");

Book oB = new Book();
oB.Title = "El sorprendente hombre araña";
oB.Author = "Stan Lee";
oB.Price = 10500;
oB.Active = true;
oB.Stock = 10;

bool resultCreate = oService.Create(oB);

if (resultCreate)
{
    Console.WriteLine("Se registro el libro con éxito!.");
}
else
{
    Console.WriteLine("No se ha podido registrar el libro.");
}