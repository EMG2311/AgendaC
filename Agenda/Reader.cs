using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Reader
    {
        public string ReadString()
        {
            return Console.ReadLine();
        }
        public int ReadInt()
        {
            bool IsNumber = false;
            int Number=0;

            IsNumber = int.TryParse(Console.ReadLine(), out Number);
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
    }
}
