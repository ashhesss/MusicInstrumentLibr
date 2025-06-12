using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInstrumentLibr
{
    public class Musician
    {
        public string MusicianName { get; set; } // Имя музыканта
        public int InstrumentId { get; set; } // ID инструмента, на котором играет музыкант

        public Musician(string name, int instrumentId)
        {
            MusicianName = name;
            InstrumentId = instrumentId;
        }

        public override string ToString()
        {
            return $"Музыкант: {MusicianName}, ID инструмента: {InstrumentId}";
        }
    }
}
