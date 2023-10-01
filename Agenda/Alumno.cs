using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Agenda
{
    internal class Alumno
    {
        private int DNI { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Street { get; set; }
        private int Phone { get; set; }
        private int CellularNumber { get; set; }
        private int Age { get; set; }
        private DateTime BirthDate{ get; set; }
        private string IdFacebook { get; set; }
        private string IdTwitter { get; set; }
        private string IdInstagram { get; set; }
        private string Mail { get; set; }
        private bool Active { get; set; }

        public Alumno(){
            Active = true;
        }
        public Alumno(int DNI, string Name, string Surname,string Street,int Phone,int CellularPhone, int Age ,DateTime BirthDate, string IdFacebook, string IdTwitter, string IdInstagram, string Mail)
        {
            this.DNI = DNI;
            this.Name = Name;
            this.Surname = Surname;
            this.Street = Street;
            this.Phone =Phone;
            this.CellularNumber = CellularPhone;
            this.BirthDate = BirthDate;
            this.Age = Age;
            this.IdFacebook = IdFacebook;
            this.IdTwitter = IdTwitter;
            this.IdInstagram = IdInstagram;
            this.Mail = Mail;
            Active = true;

        }

        public void SetDni(int dni) 
        {
            if (dni.ToString().Length !=8) //valido que el dni ingresado sea valido
            {
                 throw new ArgumentException();
            }
            else
            {
                this.DNI = dni;
            }
        }

        public int GetDNI()
        {
            return this.DNI;
        }
        public void SetName(String Name)
        {
            this.Name=Name;
        }
        public string GetName()
        {
            return this.Name;
        }
        public void SetSurname(string Name)
        {
            this.Name = Name;
        }
        public string GetSurname()
        {
            return this.Surname;
        }
        public void SetStreet(String Street)
        {
            this.Street = Street;
        }
        public String GetStreet()
        {
            return this.Street;
        }
        public void SetPhone(int Phone)
        {
            this.Phone = Phone;
        }
        public int GetPhone()
        { return this.Phone;}
        public void SetCellularNumber(int Number)
        {
            this.CellularNumber = Number;
        }
        public int GetCellularNumber()
        {
           return this.CellularNumber;
        }
        public void SetAge(int Edad)
        {
            if (Edad >= 0 && Edad <= 150) //valido que la edad se encuentre entre 0 y 150
            {
                this.Age = Edad;
            }
            else
            {
                throw new ArgumentException();
            }

        }
        public int GetAge()
        {
            return this.Age;
        }
        public void SetBirthDate(DateTime BirthDate)
        {
            DateTime FechaMin = DateTime.Now;
            DateTime FechaMax = FechaMin.AddYears(-150); //valido que la fecha de nacimiento tambien este entre 150 años antes y 0 años antes igual que la edad
            if(BirthDate>= FechaMax && BirthDate <= FechaMin)
            {
                this.BirthDate = BirthDate;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public DateTime GetDateTime()
        {
            return this.BirthDate;
        }
        public void SetIdFacebook(string IdFacebook)
        {
            this.IdFacebook = IdFacebook;
        }
        public string GetIdFacebook()
        {
            return this.IdFacebook;
        }
        public void SetIdTwitter(string IdTwitter)
        {
            this.IdTwitter = IdTwitter;
        }
        public string GetIdTwitter()
        {
            return this.IdTwitter;
        }
        public void SetIdInstagram(string IdInstagram)
        {
           this.IdInstagram= IdInstagram;
        }
        public string GetIdInstagram()
        {
            return this.IdInstagram;
        }
        public void SetMail(string Mail)
        {
            this.Mail = Mail;
        }
        public string GetMail()
        {
            return this.Mail;
        }
        public void SetActive(bool Active)
        {
            this.Active = Active;
        }
        public bool GetActive() {
            return this.Active;
        }




    }
}
