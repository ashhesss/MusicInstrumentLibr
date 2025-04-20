using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInstrumentLibr
{
    public class IdNumber
    {
        //поле для номера
        private int number;

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Номер не может быть отрицательным");
                }
                number = value;
            }
        }

        public IdNumber()
        {
            number = 0;
        }

        public IdNumber(int numberParameter)
        {
            Number = numberParameter;
        }

        public override string ToString()
        {
            return "Id: " + number.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is IdNumber other)
            {
                return Number == other.Number; 
            }
            return false;
        }
    }
}
