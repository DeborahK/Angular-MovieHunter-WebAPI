using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MovieHunter.API.Models
{
    public class MovieRepository
    {
        public List<Movie> MovieList { get; set; }

        public List<Movie> Retrieve()
        {
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            filePath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"App_Data\movies.json");
            var json = System.IO.File.ReadAllText(filePath);
            var movies = JsonConvert.DeserializeObject<MovieRepository>(json);

            return movies.MovieList;
        }
    }
}