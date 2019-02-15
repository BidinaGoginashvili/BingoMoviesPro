using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BingoMoviesPro.Models;
namespace BingoMoviesPro.ViewModel
{
    public class ProfileViewModel
    {
        public IndexViewModel IndexViewModel { get; set; }
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }
        public IEnumerable<UserSignUp> UserSignUp { get; set; }
        public MovieMain MovieMains { get; set; }
        public Actors MovieActors { get; set; }
        public MovieActor ManyActor { get; set; }
        public IEnumerable<Slider> slider { get; set; }
        public Slider slide { get; set; }
    }
}