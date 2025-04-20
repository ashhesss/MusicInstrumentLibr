using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInstrumentLibr
{
    public class InstrumentRequests
    {
        //статический метод для создания инструмента на основе ввода пользователя
        public static MusicInstrument CreateInstrumentFromInput()
        {
            //спрашиваем тип инструмента у пользователя
            Console.Write("Введите тип инструмента (Гитара/Электрогитара/Пианино): ");
            string typeInput = Console.ReadLine();

            //создаем объект в зависимости от введенного типа
            if (typeInput == "Гитара")
            {
                Guitar guitar = new Guitar();
                guitar.Init();
                return guitar;
            }
            else if (typeInput == "Электрогитара")
            {
                ElectricGuitar electricGuitar = new ElectricGuitar();
                electricGuitar.Init();
                return electricGuitar;
            }
            else if (typeInput == "Пианино")
            {
                Piano piano = new Piano();
                piano.Init();
                return piano;
            }
            else
            {
                throw new Exception("Неверный тип инструмента. Введите Гитара/Электрогитара/Пианино");
            }
        }

        public static MusicInstrument CreateRandomInstrument()
        {
            Random rnd = new Random();
            int type = rnd.Next(1, 4); // 1: Guitar, 2: ElectricGuitar, 3: Piano
            MusicInstrument instrument;

            switch (type)
            {
                case 1:
                    instrument = new Guitar();
                    break;
                case 2:
                    instrument = new ElectricGuitar();
                    break;
                case 3:
                    instrument = new Piano();
                    break;
                default: // На всякий случай
                    instrument = new MusicInstrument();
                    break;
            }
            instrument.RandomInit();
            return instrument;
        }

        //статический метод для вычисления среднего количества струн всех гитар
        public static double GetAverageGuitarStrings(MusicInstrument[] instruments)
        {
            //переменные для суммы струн и количества гитар
            int totalStrings = 0;
            int guitarCount = 0;

            //цикл foreach для обхода массива
            foreach (MusicInstrument instrument in instruments)
            {
                //проверка типа с помощью оператора is
                if (instrument is Guitar)
                {
                    //приведение типа с помощью as
                    Guitar guitar = instrument as Guitar;
                    if (guitar != null) //проверка успешности приведения
                    {
                        totalStrings = totalStrings + guitar.StringCount;
                        guitarCount = guitarCount + 1;
                    }
                }
            }

            //возвращаем среднее или 0, если гитар нет
            if (guitarCount > 0)
            {
                return (double)totalStrings / guitarCount;
            }
            return 0;
        }

        ///статический метод для подсчета суммы количества струн всех электрогитар с фиксированным источником питания
        public static int GetFixedPowerElectricGuitars(MusicInstrument[] instruments)
        {
            //переменная для суммы количества струн
            int totalStrings = 0;

            //цикл foreach для обхода массива
            foreach (MusicInstrument instrument in instruments)
            {
                //проверка типа с помощью is
                if (instrument is ElectricGuitar)
                {
                    //приведение типа с помощью as
                    ElectricGuitar electricGuitar = instrument as ElectricGuitar;
                    if (electricGuitar != null && electricGuitar.PowerSource == "Фиксированный источник питания")
                    {
                        totalStrings = totalStrings + electricGuitar.StringCount;
                    }
                }
            }

            return totalStrings;
        }

        //статический метод для поиска максимального количества клавиш у фортепиано с октавной раскладкой
        public static int GetMaxOctavePianoKeys(MusicInstrument[] instruments)
        {
            //переменная для хранения максимального количества клавиш
            int maxKeys = 0;

            foreach (MusicInstrument instrument in instruments)
            {
                //проверка типа с помощью typeof и сравнение с типом объекта
                if (instrument.GetType() == typeof(Piano))
                {
                    //приведение типа напрямую, так как тип уже проверен
                    Piano piano = (Piano)instrument;
                    if (piano.KeyLayout == "Октавная")
                    {
                        if (piano.KeyCount > maxKeys)
                        {
                            maxKeys = piano.KeyCount;
                        }
                    }
                }
            }

            //возвращаем максимальное значение или 0, если подходящих фортепиано нет
            return maxKeys;
        }
    }

}
