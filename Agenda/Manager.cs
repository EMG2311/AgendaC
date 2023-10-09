using Agenda.Interfaces;
using Agenda.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Manager
    {
        private Presenter Presenter = new Presenter();
        private Reader Reader = new Reader();
        private int Option=0;
        private bool FlagProgram = true;
        private Repository.Repository Repository = new Repository.Repository();

        
        public Manager()
        {
            do
            {
                this.StartProgram();
            } while (FlagProgram);
         }

        private void StartProgram()
        {
            this.Options();

            switch (Option)
            {
                case 1:
                    this.CreateStudent();
                    Presenter.DeleteConsole();
                    break;
                case 2:
                    this.ShowStudent();
                    Presenter.DeleteConsole();
                    break;
                case 3:
                    this.UpdateStudent();
                    Presenter.DeleteConsole();
                    break;
                case 4:
                    this.DeleteStudent();
                    Presenter.DeleteConsole();
                    break;
                case 5:
                    this.ListStudents();
                    Presenter.DeleteConsole();
                    break;
                case 6:
                    this.FlagProgram = false;
                    Presenter.ShowMessageCustom("Programa terminado, hasta luego");
                    break;
            }

        }

        private void Options()
        {
           
            bool flagOption = true;
            do
            {
                Presenter.PresentOptions();
                try
                {
                    Option = Reader.ReadInt();
                    flagOption = false;
                }
                catch (ArgumentException) {
                    Presenter.DeleteConsole();
                    Presenter.ShowMessageCustom("No se ingreso una opcion correcta");
                }
                if (Option < 1 || Option > 6)
                {
                    Presenter.IncorrectOption();
                }
            } while (Option < 1 || Option > 6);
        }

        private void CreateStudent()
        {
            try
            {
                Student Student = new Student();
                this.UploadStudentData(Student);
                try
                {
                    Repository.SaveStudent(Student);
                    Presenter.ShowMessageCustom(":::Se creo el usuario correctamente:::");
                    Presenter.ShowMessageCustom("");
                }
                catch (Exception ex)
                {
                    Presenter.ShowMessageCustom("El Student ingresado ya existe");
                    Reader.ReadString();
                }

            }
            catch (Exception e)
            {
                Presenter.ShowMessageCustom("Error no controlado");

            }
                


        }
        private Student ShowStudent()
        {
            bool flag = true;
            Presenter.ShowMessageCustom("Ingrese el DNI del estudiante");
            Student Student = new Student();
            Reader.ReadDNI(Student);
            try
            {
                Student = Repository.ShowStudent(Student.DNI);
                if (Student == null || Student.Active==false)
                {
                    Presenter.ShowMessageCustom("No se encontraron datos del alumno");
                    Reader.ReadString();
                    return null;
                }
                else
                {
                    Presenter.ShowStudent(Student);
                    Presenter.ShowMessageCustom("Presione enter para continuar");
                    Reader.ReadString();
                    return Student;
                }
            }
            catch(Exception e)
            {
                Presenter.ShowMessageCustom("Error al obtener datos del alumno");
                return null;
            }
            
        }
        private void UpdateStudent() 
        {
            Student Student = ShowStudent();
            if(Student== null)
            {
                return;
            }

            bool flag = true;
            do
            {
                switch (UpdateOptions())
                {
                    case 1:
                        Presenter.ShowMessageCustom("Ingrese el nombre nuevo");
                        Student.SetName(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 2:
                        Presenter.ShowMessageCustom("Ingrese el apellido nuevo");
                        Student.SetSurname(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 3:
                        Presenter.ShowMessageCustom("Ingrese la calle nueva");
                        Student.SetStreet(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 4:
                        Presenter.ShowMessageCustom("Ingrese el telefono fijo nuevo");
                        Reader.ReadCellularNumberPhone(Student);
                        Presenter.DeleteConsole();
                        break;
                    case 5:
                        Presenter.ShowMessageCustom("Ingrese el celular nuevo");
                        Reader.ReadCellularNumberPhone(Student);
                        Presenter.DeleteConsole();
                        break;
                    case 6:
                        Presenter.ShowMessageCustom("Ingrese la edad nuevo");
                        Reader.ReadAge(Student);
                        Presenter.DeleteConsole();
                        break;
                    case 7:
                        Presenter.ShowMessageCustom("Ingrese la nueva fecha de nacimiento");
                        Reader.ReadBirthDate(Student);
                        Presenter.DeleteConsole();
                        break;
                    case 8:
                        Presenter.ShowMessageCustom("Ingrese el nuevo id facebook");
                        Student.SetIdFacebook(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 9:
                        Presenter.ShowMessageCustom("Ingrese el nuevo id twitter");
                        Student.SetIdTwitter(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 10:
                        Presenter.ShowMessageCustom("Ingrese el nuevo id instagram");
                        Student.SetIdInstagram(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 11:
                        Presenter.ShowMessageCustom("Ingrese el mail nuevo");
                        Student.SetMail(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 12:
                        flag = false;
                        Presenter.DeleteConsole();
                        try
                        {
                            Repository.updateStudent(Student);
                        }catch(Exception e)
                        {
                            Presenter.ShowMessageCustom("Error inesperado al actualizar alumno");
                        }
                        return;
                    default :
                        flag = true;
                        break;

                }
            } while (flag);

        
        }

        private int UpdateOptions()
        {
            int option=0;
            Presenter.DeleteConsole();
            Presenter.ShowUpdateOptions();
            do
            {
                try
                {
                    option = Reader.ReadInt();
                    if (!(option > 0 && option < 13))
                    {
                        throw new ArgumentException();
                    }
                }
                catch (ArgumentException)
                {
                    Presenter.ShowMessageCustom("Opcion incorrecta, ingrese nuevamente");
                }
               
            }while (!(option>0 && option<13));
            return option;
        }
        private void DeleteStudent()
        {
            Student Student = ShowStudent();
            
            if (Student == null || Student.Active== false)
            {
                return;
            }
            Student.SetActive(false);
            try
            {
                Presenter.ShowMessageCustom("Eliminando alumno: ");
                Repository.updateStudent(Student);
                Presenter.ShowMessageCustom("alumno eliminado");
            }catch(Exception e)
            {
                Presenter.ShowMessageCustom("Error inesperado al borrar alumno");
            } 

        }
        private void ListStudents()
        {
            try
            {
                List<Student> Students = Repository.ListStudents();
                foreach (Student Student in Students)
                {
                    Presenter.ShowStudent(Student);
                    Presenter.ShowMessageCustom("--------------------------------");
                }
                if (Students.Count() == 0)
                {
                    Presenter.ShowMessageCustom("No se encontro ningun alumno para listar");
                }
                Reader.ReadString();
                
            }catch(Exception e)
            {
                Presenter.ShowMessageCustom("Error al listar estudiantes");
                Reader.ReadString();
            }
        }

        /// <summary>
        /// Metodo encargado de pedir y cargar los datos del Student pasado por parametro
        /// </summary>
        /// <param name="Student"></param>
        /// <returns></returns>
        private Student UploadStudentData(Student Student) 
        {
            bool FlagDNI = true;
            bool FlagAge = true;
            bool FlagDate = true;
            bool FlagNum = true;
            Presenter.ShowMessageCustom("::::Creando alumno::::");
            Presenter.ShowMessageCustom("");
            Presenter.ShowMessageCustom("Ingrese nombre");
            Student.SetName(Reader.ReadString());
            Presenter.ShowMessageCustom("Ingresa el apellido");
            Student.SetSurname(Reader.ReadString());
            Presenter.ShowMessageCustom("Ingrese el DNI");
            Reader.ReadDNI(Student);
            Presenter.ShowMessageCustom("Ingrese la direccion");
            Student.SetStreet(Reader.ReadString());
            Reader.ReadCellularNumberPhone(Student);
            Reader.ReadCellularNumberPhone(Student);
            Reader.ReadAge(Student);
            Reader.ReadBirthDate(Student);
            
            Presenter.ShowMessageCustom("Ingrese el IdFacebook");
            Student.SetIdFacebook(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el idTwitter");
            Student.SetIdTwitter(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el IdInstagram");
            Student.SetIdInstagram(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el mail");
            Student.SetMail(Reader.ReadString());
            Presenter.DeleteConsole();

            Student.SetActive(true);
            return Student;
        }

     }
        
     

      
    }

