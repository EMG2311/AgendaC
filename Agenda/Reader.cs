using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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

        public void ReadDNI(Student Student)
        {
            bool flag = true;
            do
            {
                try
                {
                    Student.SetDni(this.ReadInt());
                    flag = false;
                }
                catch (ArgumentException)
                {
                    Presenter.ShowMessageCustom("DNI invalido");
                }
            } while (flag);
        }

        public void ReadAge(Student Student)
        {
            bool flag = true;
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese la edad");
                    Student.SetAge(this.ReadInt());
                    flag = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("La edad ingresada es incorrecta");
                }
            } while (flag);
        }

 
        /// <summary>
        /// Metodo que lee y valida que el numero sea de celular o de telefono fijo
        /// </summary>
        /// <param name="Student"></param>
        public void ReadCellularNumberPhone(Student Student, int option)
        {
            string PhoneCellular=string.Empty;
            if (option == 0)
            {
                PhoneCellular = "telefono fijo";
            }
            else if (option == 1)
            {
                PhoneCellular = "celular";
            }
            bool FlagNum = true;
            string number;
            Regex regex = new Regex("\\A[0-9]{7,10}\\z");
            Match match;
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese el numero de "+ PhoneCellular);
                    number = this.ReadString();
                    match = regex.Match(number);
                    if (!match.Success)
                    {
                        throw new ArgumentException();
                    } 
                    Student.SetCellularNumber(number);
                    FlagNum = false;
                }
                catch (ArgumentException a)
                {
                    Presenter.ShowMessageCustom("No se ingreso un numero correcto");

                }
            } while (FlagNum);
        }

        public void ReadBirthDate(Student Student)
        {
            bool FlagDate = true;
            do
            {
                try
                {
                    Presenter.ShowMessageCustom("Ingrese la fecha de nacimiento");
                    Student.SetBirthDate(this.ReadDate());
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
