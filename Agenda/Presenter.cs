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
    }
}
