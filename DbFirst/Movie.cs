using System;
using System.Collections.Generic;

#nullable disable

namespace DbFirst
{
    public partial class Movie
    {
        public Movie()
        {
            Casts = new HashSet<Cast>();
            Programmaziones = new HashSet<Programmazione>();
        //ogni volta che genero un Movie mi crea degli HashSet di Cast e Programmazione.
        //Un HashSet è una classe che rappresenta una sorta di lista (eredita da ICollection, IEnumerable),
        //che non può essere ordinata (non c'è un metodo Sort) e non può avere duplicati: le singole istanze contenute nella
        //lista devono essere differenti tra loro.
        }

        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Genere { get; set; }
        public int? Durata { get; set; }
        //per ogni campo viene creata una proprietà. Il ? mi dice che tale proprietà può essere nulla
        
        
        //Navigation Properties:
        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<Programmazione> Programmaziones { get; set; }
        //poichè un film può avere più programmazioni bisogna implementare la relazione 1:N, definendo come proprietà
        //una lista di programmazioni. Nel concreto, quando istanzio un Movie lui mi definisce Programmaziones come un HashSet, che è una classe
        //che implementa ICollection, quindi posso usarla, cioè posso definire Programmaziones come HashSet.

        //Viene usato l'HashSet perché gli oggetti contenuti negli HashSet non possono essere duplicati e non si può creare un ordinamento.
        //Se facessimo Code-First potremmo scegliere che classe effettiva utilizzare


    }
}
