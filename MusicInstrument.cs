using System.Security.Cryptography;

namespace MusicInstrumentLibr
{
    public class MusicInstrument: IComparable, ICloneable, IInit
    {
        private string name;
        private IdNumber id;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Имя не может быть пустым");
                }
                name = value;
            }
        }

        public IdNumber Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Id не может быть пустым.");
                }
                id = value;
            }
        }

        //конструктор без параметров
        public MusicInstrument()
        {
            name = "NoName";
            id = new IdNumber();
        }

        //конструктор с параметрами
        public MusicInstrument(string nameParameter, int idParameter)
        {
            Name = nameParameter;
            Id = new IdNumber(idParameter);
        }

        //конструктор копирования
        public MusicInstrument(MusicInstrument other)
        {
            Name = other.Name;
            Id = new IdNumber(other.Id.Number); //глубокое копирование Id
        }

        public virtual void Show()
        {
            Console.WriteLine("Имя музыкального инструмента: " + Name + ", Id: " + Id.ToString());
        }

        //метод для ввода данных с клавиатуры
        public virtual void Init()
        {
            Console.Write("Укажите имя инструмента: ");
            Name = Console.ReadLine();
            Console.Write("Укажите Id инструмента: ");
            string idInput = Console.ReadLine();
            if (string.IsNullOrEmpty(idInput))
            {
                Id = new IdNumber(0);
            }
            else
            {
                Id = new IdNumber(int.Parse(idInput));
            }
        }

        //метод для случайной генерации данных
        public virtual void RandomInit()
        {
            Random random = new Random();
            Name = "Инструмент" + random.Next(1, 100).ToString();
            Id = new IdNumber(random.Next(0, 1000));
        }

        //переопределение ToString для вывода информации об объекте
        public override string ToString()
        {
            return "Имя музыкального инструмента: " + Name + ", Id: " + Id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is MusicInstrument other)
            {
                return Name == other.Name && Id.Number == other.Id.Number;
            }
            return false;
        }

        //реализация IComparable для сортировки по имени
        public int CompareTo(object obj)
        {
            if (obj is MusicInstrument other)
            {
                return Name.CompareTo(other.Name);
            }
            throw new ArgumentException("Объект не относится к MusicInstrument");
        }

        //реализация ICloneable для глубокого копирования
        public object Clone()
        {
            MusicInstrument clone = (MusicInstrument)MemberwiseClone();
            clone.Id = new IdNumber(Id.Number); //глубокое копирование ссылочного поля
            return clone;
        }

        //метод для поверхностного копирования
        public MusicInstrument ShallowCopy()
        {
            return (MusicInstrument)MemberwiseClone();
        }
    }
}
