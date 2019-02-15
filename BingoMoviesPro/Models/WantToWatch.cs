using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoMoviesPro.Models
{
    public class WantToWatch
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
    }
}