using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Interfaces
{
    internal interface IRepository
    {
        void SaveAlumno(Alumno alumno);
        Alumno updateAlumno(Alumno alumno);
        List<Alumno> ListAlumnos();
        Alumno ShowAlumno(int dni);
        bool DeleteAlumno(int dni);

    }
}
