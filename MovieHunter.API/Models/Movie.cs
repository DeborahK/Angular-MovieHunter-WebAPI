using System;
using System.Collections.Generic;

namespace MovieHunter.API.Models
{
    public class Movie
    {
        public string description { get; set; }
        public string director { get; set; }
        public string imdbLink { get; set; }
        public string imageUrl { get; set; }
        public List<Actor> keyActors { get; set; }
        public int movieId { get; set; }
        public string mpaa { get; set; }
        public DateTime releaseDate { get; set; }
        public string title { get; set; }

    }
}