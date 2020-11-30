using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst
{
    public partial class Sale
    {
        public Sale()
        {
            Programmaziones = new HashSet<Programmazione>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Posti { get; set; }

        public virtual ICollection<Programmazione> Programmaziones { get; set; }
    }
}
