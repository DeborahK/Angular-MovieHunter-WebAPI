using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieHunter.API.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/movies
        public IEnumerable<Models.Movie> Get()
        {
            var movies = new Models.MovieRepository();
            return movies.Retrieve();
        }

        // GET api/movies/title
        public IEnumerable<Models.Movie> Get(string title)
        {
            var movies = new Models.MovieRepository();
            var movieList = movies.Retrieve();
            var filteredList = movieList.Where(t => t.title.Contains(title));
            return filteredList;
        }

        // GET api/movies/5
        public Models.Movie Get(int id)
        {
            var movies = new Models.MovieRepository();
            var movieList = movies.Retrieve();
            var movie = movieList.FirstOrDefault(t => t.movieId==id);

            var actors = new Models.ActorRepository();
            var actorList = actors.Retrieve();

            var populatedActorList = new List<Models.Actor>();
            foreach (var item in movie.keyActors)
            {
                var actor = actorList.FirstOrDefault(a => a.actorId == item.actorId);
                populatedActorList.Add(actor);
            }
            movie.keyActors = populatedActorList;

            return movie;
        }

        // POST api/movies
        public void Post([FromBody]string value)
        {
        }

        // PUT api/movies/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/movies/5
        public void Delete(int id)
        {
        }
    }
}
