using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Reader
    {
        private Presenter Presenter=new Presenter();
        public string ReadString()
        {
            return Console.ReadLine();
        }
        public int ReadInt()
        {
            bool IsNumber = false;
            int Number;

            IsNumber = int.TryParse(Console.ReadLine(), out Number);
                if (IsNumber == false)
                {
                    throw new ArgumentException();
                
                }

            return Number;
        }
        public long ReadLong()
        {
            bool IsNumber = false;
            long Number;

            IsNumber = long.TryParse(Console.ReadLine(), out Number);
            if (IsNumber == false)
            {
                throw new ArgumentException();

            }

            return Number;
        }
        public DateTime ReadDate() 
        {
            bool IsDate = false;
            DateTime Date = new DateTime();

            IsDate = DateTime.TryParse(Console.ReadLine(), out Date);
                if (IsDate == false)
                {
                    throw new ArgumentException();
                }

            return Date;
        }

        public void ReadDNI(Alumno alumno)
        {
            bool flag = true;
            do
            {
                try
                {
                    alumno.SetDni(this.ReadInt());
                    flag = false;
                }
                catch (ArgumentException)
                {
                    Presenter.ShowMessageCustom("DNI invalido");
                }
            } while (flag);
        }

        public void ReadAge(Alumno alumno)
        {
            bool flag = true;
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese la edad");
                    alumno.SetAge(this.ReadInt());
                    flag = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("La edad ingresada es incorrecta");
                }
            } while (flag);
        }

        public void ReadPhone(Alumno alumno)
        {
            bool FlagNum = true;
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese el numero de telefono fijo");
                    alumno.SetPhone(this.ReadInt());
                    FlagNum = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("No se ingreso un numero correcto");

                }
            } while (FlagNum);
        }

        public void ReadCellularNumber(Alumno alumno)
        {
            bool FlagNum = true;

            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese el numero de celular");
                    alumno.SetCellularNumber(this.ReadInt());
                    FlagNum = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("No se ingreso un numero correcto");

                }
            } while (FlagNum);
        }

        public void ReadBirthDate(Alumno alumno)
        {
            bool FlagDate = true;
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese la fecha de nacimiento");
                    alumno.SetBirthDate(this.ReadDate());
                    FlagDate = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("La fecha ingresada no es valida");
                }
            } while (FlagDate);
        }


    }
}
