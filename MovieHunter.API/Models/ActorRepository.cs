using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace MovieHunter.API.Models
{
    public class ActorRepository
    {
        public List<Actor> ActorList { get; set; }

        public List<Actor> Retrieve()
        {
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            filePath = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"App_Data\actors.json");
            var json = System.IO.File.ReadAllText(filePath);
            var actors = JsonConvert.DeserializeObject<ActorRepository>(json);

            return actors.ActorList;
        }
    }
}