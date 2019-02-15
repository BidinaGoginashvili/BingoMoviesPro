using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BingoMoviesPro.Models;
using BingoMoviesPro.ViewModel;
using Microsoft.AspNet.Identity;

namespace BingoMoviesPro.Controllers
{
    [Authorize]
    [Authorize(Roles = "User")]
    public class Manage2Controller : Controller
    {
        // GET: Manage2
        private ApplicationDbContext _context;
        public Manage2Controller()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult ManageProfile(UserSignUp userSignUp, string Id)
        {
            Id = User.Identity.GetUserId();
            int myid = (int)Session["MyId"];
            var customerInDb = _context.UserSignUps.Single(x => x.ApplicationUserId == Id);
            customerInDb.FirstName = userSignUp.FirstName;
            customerInDb.LastName = userSignUp.LastName;
            if (ModelState.IsValid)
            {
                customerInDb.ProfileImage = userSignUp.ProfileImage;
                _context.SaveChanges();
            }
            int idofuser = customerInDb.Id;
            return RedirectToAction("UserPage", "Manage2", new { id = myid });
        }
        public ActionResult UserPage(int id)
        {
            var listmovies = _context.MovieMains.ToList();
            var UserId = User.Identity.GetUserId();
            var customerInDb = _context.UserSignUps.Single(x => x.ApplicationUserId == UserId);
            int myid = customerInDb.Id;
            ViewBag.Name = customerInDb.FirstName;
            ViewBag.LastName = customerInDb.LastName;
            ViewBag.ProfileImagePath = customerInDb.ProfileImage;
            ViewBag.UserID = myid;
            var Reg = new RegisterViewModel();
            var Log = new LoginViewModel();
            var usu = _context.UserSignUps.ToList();
            var MoviesAc = _context.MovieActors.ToList();
            var Ac = _context.Actorses.ToList();
            var listofwatch = _context.WantToWatchMovie.ToList();
            var listofcollection = _context.MovieListCollections.ToList();
            var viewModel = new AccountClass()
            {
                Act = Ac,
                MA = MoviesAc,
                Register = Reg,
                Login = Log,
                UserSignUp = usu,
                Movies = listmovies,
                WT = listofwatch,
                Collection = listofcollection
            };
            return View(viewModel);
        }
    }
}