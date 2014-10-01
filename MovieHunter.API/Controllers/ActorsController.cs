using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieHunter.API.Controllers
{
    public class ActorsController : ApiController
    {
        // GET api/actors
        public IEnumerable<Models.Actor> Get()
        {
            var actors = new Models.ActorRepository();
            return actors.Retrieve();
        }

        // GET api/actors/title
        public IEnumerable<Models.Actor> Get(string name)
        {
            var actors = new Models.ActorRepository();
            var actorList = actors.Retrieve();
            var filteredList = actorList.Where(t => t.name.Contains(name));
            return filteredList;
        }

        // GET api/actors/5
        public Models.Actor Get(int id)
        {
            var actors = new Models.ActorRepository();
            var actorList = actors.Retrieve();
            var actor = actorList.FirstOrDefault(t => t.actorId == id);

            var movies = new Models.MovieRepository();
            var movieList = movies.Retrieve();

            var keyMovies = movieList.SelectMany(m => m.keyActors.Where(a => a.actorId == actor.actorId),
                                (m,a)=>m);
            actor.keyMovies = keyMovies.ToList();
            
            return actor;
        }

        // POST api/actors
        public void Post([FromBody]string value)
        {
        }

        // PUT api/actors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/actors/5
        public void Delete(int id)
        {
        }

    }
}
