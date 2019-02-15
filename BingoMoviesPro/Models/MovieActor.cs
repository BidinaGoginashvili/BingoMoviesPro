using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoMoviesPro.Models
{
    public class MovieActor
    {
        public int Id { get; set; }

        public MovieMain MovieMain { get; set; }
        public int MovieMainId { get; set; }

        public Actors MovieActors { get; set; }
        public int ActorsId { get; set; }
    }
}