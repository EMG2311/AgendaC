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
                    break;
                case 2:
                    this.ShowAlumno();
                    break;
                case 3: 
                    this.UpdateAlumno();
                    break;
                case 4:
                    this.DeleteAlumno();
                    break;
                case 5:
                    this.ListAlumnos();
                    break;
                case 6:
                    this.FlagProgram = false;
                    Presenter.ShowMessageCustom("Programa terminado, hasta luego");
                    break;
            }

        }

        private void Options()
        {
            do
            {
                Presenter.PresentOptions();
                Option = Reader.ReadInt();
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

            }catch(Exception e)
            {
                Presenter.ShowMessageCustom("Error no controlado");

            }
                


        }
        private void ShowAlumno()
        {

        }
        private void UpdateAlumno() 
        {
        
        
        }
        private void DeleteAlumno()
        {

        }
        private void ListAlumnos()
        {

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
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese el DNI");
                    alumno.SetDni(Reader.ReadInt());
                    FlagDNI = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("El DNI ingresado es invalido");
                }
            } while (FlagDNI);
            Presenter.ShowMessageCustom("Ingrese la direccion");
            alumno.SetStreet(Reader.ReadString());
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese el numero de telefono fijo");
                    alumno.SetPhone(Reader.ReadInt());
                    FlagNum = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("No se ingreso un numero correcto");
                    
                }
            } while (FlagNum);
            FlagNum = true;
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese el numero de celular");
                    alumno.SetCellularNumber(Reader.ReadInt());
                    FlagNum = false;
                }
                catch(ArgumentException a)
                {
                    Presenter.ShowMessageCustom("No se ingreso un numero correcto");
                    
                }
            } while (FlagNum);
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese la edad");
                    alumno.SetAge(Reader.ReadInt());
                    FlagAge = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("La edad ingresada es incorrecta");
                }
            } while (FlagAge);
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese la fecha de nacimiento");
                    alumno.SetBirthDate(Reader.ReadDate());
                    FlagDate = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("La fecha ingresada no es valida");
                }
            } while (FlagDate);
            Presenter.ShowMessageCustom("Ingrese el IdFacebook");
            alumno.SetIdFacebook(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el idTwitter");
            alumno.SetIdTwitter(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el IdInstagram");
            alumno.SetIdInstagram(Reader.ReadString());

            Presenter.ShowMessageCustom("Ingrese el mail");
            alumno.SetMail(Reader.ReadString());
            Presenter.DeleteConsole();
            Presenter.ShowMessageCustom(":::Se creo el usuario correctamente:::");
            Presenter.ShowMessageCustom("");
            return alumno;
        }

     }
        
     

      
    }

