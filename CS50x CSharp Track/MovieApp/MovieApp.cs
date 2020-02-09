using System;
using System.Collections.Generic;

namespace MovieApp
{
    class Movie {
        public string title { get; set; }

        public decimal rating { get; set; }

        public void tellMeAboutIt() {
            Console.WriteLine("Title: " + this.title + " Rating: " + this.rating );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> myMoviesList = new List<Movie>();

            Movie _TheFastandtheFurious = new Movie();
            Movie _BeautyandtheBeast = new Movie();

            _BeautyandtheBeast.title = "Beauty and the Beast";
            _TheFastandtheFurious.title = "The Fast and the Furious";

            _BeautyandtheBeast.rating = 9.5m;
            _TheFastandtheFurious.rating = 8.5m;

            myMoviesList.Add(_BeautyandtheBeast);
            myMoviesList.Add(_TheFastandtheFurious);

            foreach ( Movie movie in myMoviesList ) 
            {
                movie.tellMeAboutIt();
            }
        }
    }
}
