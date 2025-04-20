using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInstrumentLibr
{
    public class Guitar : MusicInstrument
    {
        //кол-во струн
        private int stringCount;

        public int StringCount
        {
            get
            {
                return stringCount;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Количество струн не может быть отрицательным");
                }
                stringCount = value;
            }
        }

        //конструктор без параметров
        public Guitar() : base()
        {
            stringCount = 6;
        }

        //конструктор с параметрами
        public Guitar(string name, int id, int strings) : base(name, id)
        {
            StringCount = strings; 
        }

        //конструктор копирования
        public Guitar(Guitar other) : base(other)
        {
            StringCount = other.StringCount;
        }

        public override void Show()
        {
            Console.WriteLine("Имя гитары: " + Name + ", Id: " + Id.ToString() + ", Количество струн: " + StringCount.ToString());
        }

        //переопределение Init для ввода данных о гитаре
        public override void Init()
        {
            base.Init();
            Console.Write("Введите количество струн: ");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                StringCount = 6;
            }
            else
            {
                StringCount = int.Parse(input);
            }
        }

        //переопределение RandomInit для случайной генерации данных гитары
        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            StringCount = random.Next(4, 13);
        }

        public override string ToString()
        {
            return "Имя гитары: " + Name + ", Id: " + Id.ToString() + ", Количество струн: " + StringCount.ToString();
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj) && obj is Guitar other)
            {
                return StringCount == other.StringCount;
            }
            return false;
        }

        //переопределение Clone для глубокого копирования
        public new object Clone()
        {
            Guitar clone = (Guitar)base.Clone();
            return clone;
        }

        //переопределение ShallowCopy для возврата типа Guitar
        public new Guitar ShallowCopy()
        {
            return (Guitar)base.ShallowCopy();
        }
    }
}
