using System;
using System.Collections.Generic;

namespace MovieApp
{
    class Movie {
        public string title { get; set; }

        public decimal userRating { get; set; }

        public TimeSpan runTime { get; set; }

        public DateTime releaseDate { get; set; }

        public string rated { get; set; }

        public void tellMeAboutIt() {
            Console.WriteLine("Title: " + this.title + "\nReleased: " + this.releaseDate.Year + ", Rated: " + this.rated +
             "\nRun Time: " + this.runTime.ToString() + ", User Rating: " + this.userRating + "\n" );
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> myMoviesList = new List<Movie>();

            Movie _TheFastandtheFurious = new Movie();
            Movie _BeautyandtheBeast = new Movie();

            //Titles
            _BeautyandtheBeast.title = "Beauty and the Beast";
            _TheFastandtheFurious.title = "The Fast and the Furious";

            //User Ratings
            _BeautyandtheBeast.userRating = 9.5m;
            _TheFastandtheFurious.userRating = 8.5m;

            //Rated
            _BeautyandtheBeast.rated = "G";
            _TheFastandtheFurious.rated = "PG13";

            //Run Time
            TimeSpan batbts = new TimeSpan(1, 24, 33);
            TimeSpan tfatfts = new TimeSpan(1, 46, 33);

            _BeautyandtheBeast.runTime = batbts;
            _TheFastandtheFurious.runTime = tfatfts;

            //Release Date
            DateTime batbrd = new DateTime(1991, 1, 1);
            DateTime tfatfrd = new DateTime(2001, 1 , 1);

            _BeautyandtheBeast.releaseDate = batbrd;
            _TheFastandtheFurious.releaseDate = tfatfrd;

            myMoviesList.Add(_BeautyandtheBeast);
            myMoviesList.Add(_TheFastandtheFurious);

            foreach ( Movie movie in myMoviesList ) 
            {
                movie.tellMeAboutIt();
            }
        }
    }
}