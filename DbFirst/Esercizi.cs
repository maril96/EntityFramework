using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DbFirst
{
    public class Esercizi
    {
        //lettura film
        public static void FetchMovies()
        {
            //inizializzo il Context
            using(var cxt = new CinemaDbContext())
            {
                //Scrivo una query Linq
                var films =
                    from m in cxt.Movies //Come "lista" abbiamo il DbSet ora, che sta nel DbContext
                    select m;

                
                foreach (var film in films)
                {
                    //ovviamente potremmo direttamente scrivere foreach(var film in cxt.Movies)
                    //Però si possono fare tranquillamente le query Linq.

                    Console.WriteLine($"ID: {film.Id}, Titolo: {film.Titolo}");
                }
            }
        }

        //aggiungere un film
        public static void InsertMovie(Movie m)
        {
            using (var ctx= new CinemaDbContext())
            {
                ctx.Movies.Add(m); //Se faccio solo ctx.Add(m) mi inserisce m in una tabella di Movie, in questo caso okay,
                //Ma in generale potrei avere più tabelle di Movie
                ctx.SaveChanges();
            }
            Esercizi.FetchMovies();
            
        }

        //eliminare un film
        //Modalità connessa
        public static void DeleteMovie()
        {
            using (var ctx=new CinemaDbContext())
            {
                var f = ctx.Movies.Find(9);
                Console.WriteLine("Sto eliminando il film {0}", f.Titolo);

                ctx.Movies.Remove(f);
                ctx.SaveChanges();
            }
            Esercizi.FetchMovies();
        }
        //Modalità Disconnessa
        public static void DeleteMovieDisconnected()
        {
            var f = new Movie();
            using (var ctx = new CinemaDbContext())
            {
                f = ctx.Movies.Find(8);
            }
            //Qui in mezzo potrei fare qualsiasi cosa.

            using (var ctx = new CinemaDbContext())
            {
                ctx.Entry<Movie>(f).State = EntityState.Deleted;
                ctx.SaveChanges();
            }

            Esercizi.FetchMovies();
        }

    }
}
