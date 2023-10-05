using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Presenter
    {
        public void PresentOptions()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("||     Elije una opcion            ||");
            Console.WriteLine("||                                 ||");
            Console.WriteLine("||     1. Crear alumno             ||");
            Console.WriteLine("||     2. Mostrar datos del alumno ||");
            Console.WriteLine("||     3. Editar alumno            ||");
            Console.WriteLine("||     4. Eliminar alumno          ||");
            Console.WriteLine("||     5. Listar alumnos           ||");
            Console.WriteLine("||     6. Salir del programa       ||");
            Console.WriteLine("-------------------------------------"); ;
        }
        public void IncorrectOption()
        {
            Console.WriteLine("Se ingreso una opcion incorrecta");
        }
        public void ShowMessageCustom(String Message) {
            Console.WriteLine(Message);
        }
        public void DeleteConsole()
        {
            Console.Clear();
        }

        public void ShowStudent(Alumno alumno)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("||      " +"DNI: "+ alumno.DNI);
            Console.WriteLine("||      " +"Nombre: "+ alumno.Name);
            Console.WriteLine("||      " +"Apellido: " + alumno.Surname);
            Console.WriteLine("||      " +"Calle: "+ alumno.Street);
            Console.WriteLine("||      " +"Phone: " + alumno.Phone);
            Console.WriteLine("||      " + "Cellular: "+ alumno.CellularNumber);
            Console.WriteLine("||      " + "Edad: "+ alumno.Age);
            Console.WriteLine("||      " + "Fecha de nacimiento: "+ alumno.BirthDate);
            Console.WriteLine("||      " + "Id Facebook:"+ alumno.IdFacebook);
            Console.WriteLine("||      " + "Id twitter: "+ alumno.IdTwitter);
            Console.WriteLine("||      " +"Id Instagram: " + alumno.IdInstagram);
            Console.WriteLine("||      " + "Mail: "+ alumno.Mail);

        }
        public void ShowUpdateOptions()
        {
            Console.WriteLine("||¿Que desea actualizar del alumno?||");
            Console.WriteLine("||                                 ||");
            Console.WriteLine("||     1. Nombre                   ||");
            Console.WriteLine("||     2. Apellido                 ||");
            Console.WriteLine("||     3. Calle                    ||");
            Console.WriteLine("||     4. Telefono                 ||");
            Console.WriteLine("||     5. Celular                  ||");
            Console.WriteLine("||     6. Edad                     ||");
            Console.WriteLine("||     7. Fecha de nacimiento      ||");
            Console.WriteLine("||     8. IdFacebook               ||");
            Console.WriteLine("||     9. IdTwitter                ||");
            Console.WriteLine("||     10. IdInstagram             ||");
            Console.WriteLine("||     11. Mail                    ||");
            Console.WriteLine("||     12. Dejar de actualizar     ||");
            Console.WriteLine("-------------------------------------"); ;

        }
    }
}
