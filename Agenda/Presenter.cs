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
            Console.WriteLine("||     Elije una opcion             ||");
            Console.WriteLine("||                                  ||");
            Console.WriteLine("||     1. Crear alumno              ||");
            Console.WriteLine("||     2. Mostrar datos del alumno  ||");
            Console.WriteLine("||     3. Editar alumno             ||");
            Console.WriteLine("||     4. Eliminar alumno           ||");
            Console.WriteLine("||     5. Listar alumno             ||");
            Console.WriteLine("||     6. Salir del programa        ||");
            Console.WriteLine("-------------------------------------");
        }
     
        public void ShowMessageCustom(String Message) {
            Console.WriteLine(Message);
        }
        public void DeleteConsole()
        {
            Console.Clear();
        }

        public void ShowStudent(Student Student)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("||      " +"DNI: "+ Student.DNI);
            Console.WriteLine("||      " +"Nombre: "+ Student.Name);
            Console.WriteLine("||      " +"Apellido: " + Student.Surname);
            Console.WriteLine("||      " +"Calle: "+ Student.Street);
            Console.WriteLine("||      " +"Phone: " + Student.Phone);
            Console.WriteLine("||      " + "Cellular: "+ Student.CellularNumber);
            Console.WriteLine("||      " + "Edad: "+ Student.Age);
            Console.WriteLine("||      " + "Fecha de nacimiento: "+ Student.BirthDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("||      " + "Id Facebook:"+ Student.IdFacebook);
            Console.WriteLine("||      " + "Id twitter: "+ Student.IdTwitter);
            Console.WriteLine("||      " +"Id Instagram: " + Student.IdInstagram);
            Console.WriteLine("||      " + "Mail: "+ Student.Mail);

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
