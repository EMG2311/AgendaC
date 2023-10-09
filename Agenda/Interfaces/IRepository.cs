using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Interfaces
{
    internal interface IRepository
    {
        void SaveStudent(Student Student);
        Student updateStudent(Student Student);
        List<Student> ListStudents();
        Student ShowStudent(int dni);
        bool DeleteStudent(int dni);

    }
}
