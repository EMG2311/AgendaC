using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Interfaces
{
    internal interface IRepository
    {
        /// <summary>
        /// Guarda el alumno
        /// </summary>
        /// <param name="Student"></param>
        void SaveStudent(Student Student);
        /// <summary>
        /// Actualiza el aluno
        /// </summary>
        /// <param name="Student"></param>
        /// <returns>Devuelve el alumno con las modificaciones</returns>
        Student updateStudent(Student Student);
        /// <summary>
        /// Devuelve un listado de los alumnos activos
        /// </summary>
        /// <returns>Listado de alumnos activos</returns>
        List<Student> ListStudents();
        /// <summary>
        /// Busca el alumno activo que posea ese dni
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Alumno con el dni</returns>
        Student ShowStudent(int dni);
        /// <summary>
        /// Elimina permanentemente un alumno(no virtualmente)
        /// </summary>
        /// <param name="dni"></param>
        /// <returns>Devuelve true si se elimino correctamente</returns>
        bool DeleteStudent(int dni);

    }
}
