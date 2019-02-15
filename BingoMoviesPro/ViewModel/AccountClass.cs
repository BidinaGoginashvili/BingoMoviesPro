using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BingoMoviesPro.Models;
namespace BingoMoviesPro.ViewModel
{
    public class AccountClass
    {
        public RegisterViewModel Register { get; set; }
        public LoginViewModel Login { get; set; }
        public IEnumerable<MovieMain>Movies { get; set;}
        public IEnumerable<MovieComments> Comments { get; set; }
        public MovieComments comments { get; set; }
        public WantToWatch wantwatch { get; set; }
        public IEnumerable<WantToWatch> WT{ get; set; }
        public IEnumerable<MovieCollection> Collection { get; set; }
        public IEnumerable<MovieActor> MA{ get; set; }
        public IEnumerable<Actors> Act{get; set;}
        public IEnumerable<UserSignUp> UserSignUp { get; set; }
        public IEnumerable<Slider> slider { get; set; }
    }
}