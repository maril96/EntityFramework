using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst
{
    public partial class Prenotazione
    {
        public int ProgrammazioneId { get; set; }
        public int NumeroPosti { get; set; }
        public string Mail { get; set; }
        public int Id { get; set; }

        public virtual Programmazione Programmazione { get; set; }
    }
}
