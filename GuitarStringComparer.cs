using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInstrumentLibr
{
    public class GuitarStringComparer : IComparer
    {
        //реализация Compare для сортировки по количеству струн
        public int Compare(object x, object y)
        {
            //являются ли оба объекта гитарами?
            int stringsX = 0;
            int stringsY = 0;

            if (x is Guitar)
            {
                stringsX = ((Guitar)x).StringCount;
            }
            else if (x is ElectricGuitar)
            {
                stringsX = ((ElectricGuitar)x).StringCount;
            }
            else
            {
                throw new ArgumentException("Первый объект не является Гитарой или Электрогитарой");
            }

            if (y is Guitar)
            {
                stringsY = ((Guitar)y).StringCount;
            }
            else if (y is ElectricGuitar)
            {
                stringsY = ((ElectricGuitar)y).StringCount;
            }
            else
            {
                throw new ArgumentException("Второй объект не является Гитарой или Электрогитарой");
            }

            return stringsX.CompareTo(stringsY);
        }
    }
}
