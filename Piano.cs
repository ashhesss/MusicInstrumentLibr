using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInstrumentLibr
{
    public class Piano : MusicInstrument
    {
        
        private string keyLayout;
        private int keyCount;
        public string KeyLayout
        {
            get
            {
                return keyLayout;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) ||
                    (value != "Октавная" && value != "Шкальная" && value != "Дигитальная"))
                {
                    throw new Exception("Раскладка клавиш должна быть одной из таких: Октавная, Шкальная, Дигитальная.");
                }
                keyLayout = value;
            }
        }

        public int KeyCount
        {
            get
            {
                return keyCount;
            }
            set
            {
                if (value < 0 || value > 88)
                {
                    throw new Exception("Количество клавиш не может быть отрицательным или больше 88.");
                }
                keyCount = value;
            }
        }

        //конструктор без параметров
        public Piano() : base()
        {
            keyLayout = "Октавная"; 
            keyCount = 88;
        }

        //конструктор с параметрами
        public Piano(string name, int id, string layout, int keys) : base(name, id)
        {
            KeyLayout = layout; 
            KeyCount = keys;    
        }

        //конструктор копирования
        public Piano(Piano other) : base(other)
        {
            KeyLayout = other.KeyLayout;
            KeyCount = other.KeyCount;   
        }

        //переопределение Show для отображения информации о фортепиано
        public override void Show()
        {
            Console.WriteLine("Имя пианино: " + Name + ", Id: " + Id.ToString() + ", Раскладка: " + KeyLayout + ", Кол-во клавиш: " + KeyCount.ToString());
        }

        //переопределение Init для ввода данных о фортепиано
        public override void Init()
        {
            base.Init();
            Console.Write("Укажите раскладку клавиш (Октавная/Шкальная/Дигитальная): ");
            KeyLayout = Console.ReadLine(); 
            Console.Write("Укажите количество клавиш: ");
            string keyInput = Console.ReadLine();
            if (string.IsNullOrEmpty(keyInput))
            {
                KeyCount = 88;
            }
            else
            {
                KeyCount = int.Parse(keyInput); 
            }
        }

        //переопределение RandomInit для случайной генерации данных фортепиано
        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            string[] layouts = { "Октавная", "Шкальная", "Дигитальная" };
            KeyLayout = layouts[random.Next(0, 3)]; 
            KeyCount = random.Next(20, 89);  
        }

        //переопределение ToString для вывода информации о фортепиано
        public override string ToString()
        {
            return "Имя пианино " + Name + ", Id: " + Id.ToString() + ", Раскладка клавиш: " + KeyLayout + ", Кол-во клавиш: " + KeyCount.ToString();
        }

        //переопределение Equals для сравнения фортепиано
        public override bool Equals(object obj)
        {
            if (base.Equals(obj) && obj is Piano other)
            {
                return KeyLayout == other.KeyLayout && KeyCount == other.KeyCount;
            }
            return false;
        }

        //переопределение Clone для глубокого копирования
        public new object Clone()
        {
            Piano clone = (Piano)base.Clone();
            return clone;
        }

        //переопределение ShallowCopy для возврата типа Piano
        public new Piano ShallowCopy()
        {
            return (Piano)base.ShallowCopy();
        }
    }
}
