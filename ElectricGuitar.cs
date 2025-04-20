using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInstrumentLibr
{
    public class ElectricGuitar : Guitar
    {

        private string powerSource;

        public string PowerSource
        {
            get
            {
                return powerSource;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (value != "Батарейки" && value != "Аккумулятор" && value != "Фиксированный источник питания" && value != "USB"))
                {
                    throw new Exception("Источник питания должен быть одним из таких: Батарейки, Аккумулятор, Фиксированный источник питания, USB");
                }
                powerSource = value;
            }
        }

        //конструктор без параметров
        public ElectricGuitar() : base()
        {
            powerSource = "Батарейки";
        }

        //конструктор с параметрами
        public ElectricGuitar(string name, int id, int strings, string power) : base(name, id, strings)
        {
            PowerSource = power;
        }

        //конструктор копирования
        public ElectricGuitar(ElectricGuitar other) : base(other)
        {
            PowerSource = other.PowerSource; // Используется свойство с проверкой
        }

        //переопределение Show для отображения информации об электрогитаре
        public override void Show()
        {
            Console.WriteLine("Имя электрогитары: " + Name + ", Id: " + Id.ToString() + ", Кол-во струн: " + StringCount.ToString() + ", Источник питания: " + PowerSource);
        }

        //переопределение Init для ввода данных об электрогитаре
        public override void Init()
        {
            base.Init();
            Console.Write("Укажите источник питания (Батарейки, Аккумуляторы, Фиксированный источник питания, USB): ");
            PowerSource = Console.ReadLine();
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            string[] powerSources = { "Батарейки", "Аккумулятор", "Фиксированный источник питания", "USB" };
            PowerSource = powerSources[random.Next(0, 4)]; 
        }

        //переопределение ToString для вывода информации об электрогитаре
        public override string ToString()
        {
            return "Имя электрогитары: " + Name + ", Id: " + Id.ToString() + ", Кол-во струн: " + StringCount.ToString() + ", Источник питания: " + PowerSource;
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj) && obj is ElectricGuitar other)
            {
                return PowerSource == other.PowerSource;
            }
            return false;
        }

        //переопределение Clone для глубокого копирования
        public new object Clone()
        {
            ElectricGuitar clone = (ElectricGuitar)base.Clone();
            return clone;
        }

        //переопределение ShallowCopy для возврата типа ElectricGuitar
        public new ElectricGuitar ShallowCopy()
        {
            return (ElectricGuitar)base.ShallowCopy();
        }
    }
}
