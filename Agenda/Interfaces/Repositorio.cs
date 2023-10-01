using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Interfaces
{
    internal interface Repositorio
    {
        void SaveAlumno();
        void updateAlumno(Alumno alumno);
        List<Alumno> ListAlumnos();
        Alumno ShowAlumno();
        Alumno DeleteAlumno();

    }
}
