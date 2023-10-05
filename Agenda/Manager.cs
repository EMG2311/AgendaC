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
                    this.CreateAlumno();
                    Presenter.DeleteConsole();
                    break;
                case 2:
                    this.ShowAlumno();
                    Presenter.DeleteConsole();
                    break;
                case 3:
                    this.UpdateAlumno();
                    Presenter.DeleteConsole();
                    break;
                case 4:
                    this.DeleteAlumno();
                    Presenter.DeleteConsole();
                    break;
                case 5:
                    this.ListAlumnos();
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
        private void CreateAlumno()
        {
            try
            {
                Alumno alumno = new Alumno();
                this.UploadAlumnoData(alumno);
                try
                {
                    Repository.SaveAlumno(alumno);
                    Presenter.ShowMessageCustom(":::Se creo el usuario correctamente:::");
                    Presenter.ShowMessageCustom("");
                }
                catch (Exception ex)
                {
                    Presenter.ShowMessageCustom("El alumno ingresado ya existe");
                    Reader.ReadString();
                }

            }
            catch (Exception e)
            {
                Presenter.ShowMessageCustom("Error no controlado");

            }
                


        }
        private Alumno ShowAlumno()
        {
            bool flag = true;
            Presenter.ShowMessageCustom("Ingrese el DNI del estudiante que quiere buscar");
            Alumno alumno = new Alumno();
            Reader.ReadDNI(alumno);
            try
            {
                alumno = Repository.ShowAlumno(alumno.DNI);
                if (alumno == null || alumno.Active==false)
                {
                    Presenter.ShowMessageCustom("No se encontraron datos del alumno");
                    Reader.ReadString();
                    return null;
                }
                else
                {
                    Presenter.ShowStudent(alumno);
                    Presenter.ShowMessageCustom("Presione enter para continuar");
                    Reader.ReadString();
                    return alumno;
                }
            }
            catch(Exception e)
            {
                Presenter.ShowMessageCustom("Error al obtener datos del alumno");
                return null;
            }
            
        }
        private void UpdateAlumno() 
        {
            Alumno alumno = ShowAlumno();
            if(alumno== null)
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
                        alumno.SetName(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 2:
                        Presenter.ShowMessageCustom("Ingrese el apellido nuevo");
                        alumno.SetSurname(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 3:
                        Presenter.ShowMessageCustom("Ingrese la calle nueva");
                        alumno.SetStreet(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 4:
                        Presenter.ShowMessageCustom("Ingrese el telefono fijo nuevo");
                        Reader.ReadPhone(alumno);
                        Presenter.DeleteConsole();
                        break;
                    case 5:
                        Presenter.ShowMessageCustom("Ingrese el celular nuevo");
                        Reader.ReadCellularNumber(alumno);
                        Presenter.DeleteConsole();
                        break;
                    case 6:
                        Presenter.ShowMessageCustom("Ingrese la edad nuevo");
                        Reader.ReadAge(alumno);
                        Presenter.DeleteConsole();
                        break;
                    case 7:
                        Presenter.ShowMessageCustom("Ingrese la nueva fecha de nacimiento");
                        Reader.ReadBirthDate(alumno);
                        Presenter.DeleteConsole();
                        break;
                    case 8:
                        Presenter.ShowMessageCustom("Ingrese el nuevo id facebook");
                        alumno.SetIdFacebook(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 9:
                        Presenter.ShowMessageCustom("Ingrese el nuevo id twitter");
                        alumno.SetIdTwitter(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 10:
                        Presenter.ShowMessageCustom("Ingrese el nuevo id instagram");
                        alumno.SetIdInstagram(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 11:
                        Presenter.ShowMessageCustom("Ingrese el mail nuevo");
                        alumno.SetMail(Reader.ReadString());
                        Presenter.DeleteConsole();
                        break;
                    case 12:
                        flag = false;
                        Presenter.DeleteConsole();
                        try
                        {
                            Repository.updateAlumno(alumno);
                        }catch(Exception e)
                        {
                            Presenter.ShowMessageCustom("Error inesperado al actualizar alumno");
                        }
                        return;
                        


                }
            } while (flag);

        
        }

        private int UpdateOptions()
        {
            int option;
            Presenter.DeleteConsole();
            Presenter.ShowUpdateOptions();
            do
            {
                try
                {
                    option = Reader.ReadInt();
                }
                catch (ArgumentException)
                {
                    option = 12;
                }
                if (!(option>0 && option<13))
                {
                    Presenter.ShowMessageCustom("Opcion incorrecta, ingrese nuevamente");
                }
            }while (!(option>0 && option<13));
            return option;
        }
        private void DeleteAlumno()
        {
            Alumno alumno = ShowAlumno();
            
            if (alumno == null || alumno.Active== false)
            {
                return;
            }
            alumno.SetActive(false);
            try
            {
                Repository.updateAlumno(alumno);
                Presenter.ShowMessageCustom("Alumno eliminado");
            }catch(Exception e)
            {
                Presenter.ShowMessageCustom("Error inesperado al borrar alumno");
            } 

        }
        private void ListAlumnos()
        {
            try
            {
                List<Alumno> alumnos = Repository.ListAlumnos();
                foreach (Alumno alumno in alumnos)
                {
                    Presenter.ShowStudent(alumno);
                    Presenter.ShowMessageCustom("--------------------------------");
                }
                if (alumnos.Count() == 0)
                {
                    Presenter.ShowMessageCustom("No se encontro ningun alumno para listar") -{ };
                }
                Reader.ReadString();
                
            }catch(Exception e)
            {
                Presenter.ShowMessageCustom("Error al listar estudiantes");
                Reader.ReadString();
            }
        }

        /// <summary>
        /// Metodo encargado de pedir y cargar los datos del alumno pasado por parametro
        /// </summary>
        /// <param name="alumno"></param>
        /// <returns></returns>
        private Alumno UploadAlumnoData(Alumno alumno) 
        {
            bool FlagDNI = true;
            bool FlagAge = true;
            bool FlagDate = true;
            bool FlagNum = true;
            Presenter.ShowMessageCustom("::::Creando Alumno::::");
            Presenter.ShowMessageCustom("");
            Presenter.ShowMessageCustom("Ingrese nombre");
            alumno.SetName(Reader.ReadString());
            Presenter.ShowMessageCustom("Ingresa el apellido");
            alumno.SetSurname(Reader.ReadString());
            Presenter.ShowMessageCustom("Ingrese el DNI");
            Reader.ReadDNI(alumno);
            Presenter.ShowMessageCustom("Ingrese la direccion");
            alumno.SetStreet(Reader.ReadString());
            Reader.ReadPhone(alumno);
            Reader.ReadCellularNumber(alumno);
            Reader.ReadAge(alumno);
            Reader.ReadBirthDate(alumno);
            
            Presenter.ShowMessageCustom("Ingrese el IdFacebook");
            alumno.SetIdFacebook(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el idTwitter");
            alumno.SetIdTwitter(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el IdInstagram");
            alumno.SetIdInstagram(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el mail");
            alumno.SetMail(Reader.ReadString());
            Presenter.DeleteConsole();

            alumno.SetActive(true);
            return alumno;
        }

     }
        
     

      
    }

