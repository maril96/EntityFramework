using System;

namespace DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
           // Esercizi.FetchMovies();

            Movie m = new Movie()
            {
                Titolo="Il signore degli Anelli",
                Genere="Fantasy",
                Durata=350
                
            };
            //Esercizi.InsertMovie(m);
            //Esercizi.DeleteMovie();
            //Esercizi.DeleteMovieDisconnected();
        }
    }
}
