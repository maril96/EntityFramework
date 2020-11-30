using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst
{
    public partial class Actor
    {
        public Actor()
        {
            Casts = new HashSet<Cast>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public decimal Cachet { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }
    }
}
