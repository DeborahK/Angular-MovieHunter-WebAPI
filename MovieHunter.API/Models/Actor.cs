using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieHunter.API.Models
{
    public class Actor
    {
        public int actorId { get; set; }
        public DateTime birthDate { get; set; }
        public string country { get; set; }
        public string imdbLink { get; set; }
        public List<Movie> keyMovies { get; set; }
        public string name { get; set; }

    }
}
