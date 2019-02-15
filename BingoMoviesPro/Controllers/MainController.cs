using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using BingoMoviesPro.Models;
using BingoMoviesPro.ViewModel;
using Microsoft.AspNet.Identity;
namespace BingoMoviesPro.Controllers
{
    public class MainController : Controller
    {
        private ApplicationDbContext _context;
        public MainController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult MainPage()
        {
            var listmovies = _context.MovieMains.ToList();
            var Reg = new RegisterViewModel();
            var Log = new LoginViewModel();
            var userId = User.Identity.GetUserId();
            var Slider = _context.Sliders.ToList();
            if (Request.IsAuthenticated)
            {
                var customerInDb1 = _context.UserSignUps.Single(x => x.ApplicationUserId == userId);
                int myid = customerInDb1.Id;
                ViewBag.mine = myid;
            }
            var viewModel = new AccountClass()
            {
                Register = Reg,
                Login = Log,
                Movies = listmovies,
                slider = Slider
            };
            return View(viewModel);
        }
        public ActionResult Movies()
        {
            var listmovies = _context.MovieMains.ToList();
            var Reg = new RegisterViewModel();
            var Log = new LoginViewModel();
            var userId = User.Identity.GetUserId();
            var Slider = _context.Sliders.ToList();
            if (Request.IsAuthenticated)
            {
                var customerInDb1 = _context.UserSignUps.Single(x => x.ApplicationUserId == userId);
                int myid = customerInDb1.Id;
                ViewBag.mine = myid;
            }
            var viewModel = new AccountClass()
            {
                Register = Reg,
                Login = Log,
                Movies = listmovies,
                slider = Slider
            };
            return View(viewModel);
        }

        public ActionResult Details(int? id, string Comment)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("MainPage");
            }
            var listmovies = _context.MovieMains.ToList();
            var MoviesAc = _context.MovieActors.ToList();
            var users = _context.UserSignUps.ToList();
            var Ac = _context.Actorses.ToList();
            var Reg = new RegisterViewModel();
            var Log = new LoginViewModel();
            var commentAdd = new MovieComments();
            var comlist = _context.MovieCommentses.ToList();
            var userId = User.Identity.GetUserId();
            if (Request.IsAuthenticated)
            {
                var customerInDb1 = _context.UserSignUps.Single(x => x.ApplicationUserId == userId);
                int myid = customerInDb1.Id;
                ViewBag.mineid = myid;
                ViewBag.ProfileImage = customerInDb1.ProfileImage;
                Session["MyId"] = myid;
            }
            ViewBag.Idofmovie = id;
            int movid = Convert.ToInt32(id);
            Session["MovieId"] = movid;
            var viewModel = new AccountClass()
            {
                Act = Ac,
                MA = MoviesAc,
                Register = Reg,
                Login = Log,
                Movies = listmovies,
                Comments = comlist,
                UserSignUp = users,
                comments = commentAdd
            };
            return View(viewModel);
        }
        public ActionResult Actor(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("MainPage");
            }
            var listmovies = _context.MovieMains.ToList();
            var MoviesAc = _context.MovieActors.ToList();
            var Ac = _context.Actorses.ToList();
            var Reg = new RegisterViewModel();
            var Log = new LoginViewModel();
            var viewModel = new AccountClass()
            {
                Act = Ac,
                MA = MoviesAc,
                Register = Reg,
                Login = Log,
                Movies = listmovies
            };
            ViewBag.Idofactor = id;
            return View(viewModel);
        }

        public ActionResult EditMovie(MovieMain movieMain)
        {
            int idofmovie = (int)Session["MovieId"];
            var movieDb = _context.MovieMains.Single(x => x.Id == idofmovie);
            movieDb.MovieTitleKa = movieMain.MovieTitleKa;
            movieDb.MovieTitleEng = movieMain.MovieTitleEng;
            movieDb.DirectorFullName = movieMain.DirectorFullName;
            movieDb.MovieImgpath = movieMain.MovieImgpath;
            movieDb.MovieVdpath = movieMain.MovieVdpath;
            movieDb.MovieLength = movieMain.MovieLength;
            movieDb.MovieImdb = movieMain.MovieImdb;
            movieDb.budget = movieMain.budget;
            movieDb.ReleaseDate = movieMain.ReleaseDate;
            movieDb.Description = movieMain.Description;
            _context.SaveChanges();
            return RedirectToAction("Details", "Main", new { id = idofmovie });
        }
        public ActionResult DeleteMovie()
        {
            int idofmovie = (int)Session["MovieId"];
            MovieMain movieMain = _context.MovieMains.Find(idofmovie);
            if (movieMain == null)
            {
                return HttpNotFound();
            }
            _context.MovieMains.Remove(movieMain);
            _context.SaveChanges();
            return RedirectToAction("MainPage", "Main");
        }
        public ActionResult WatchLater(WantToWatch wtw)
        {
            int myid = (int)Session["MyId"];
            int idofmovie = (int)Session["MovieId"];
            var IsAddedInWatchList = _context.WantToWatchMovie.SingleOrDefault(X => X.MovieId == idofmovie && X.UserId == myid);
            if (IsAddedInWatchList == null)
            {
                wtw.MovieId = idofmovie;
                wtw.UserId = myid;
                _context.WantToWatchMovie.Add(wtw);
                _context.SaveChanges();
                return RedirectToAction("Details", "Main", new { id = idofmovie });
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult AddToCollection(MovieCollection MC)
        {
            int myid = (int)Session["MyId"];
            int idofmovie = (int)Session["MovieId"];
            var IsAddedToCollection = _context.MovieListCollections.SingleOrDefault(X => X.MovieId == idofmovie && X.UserId == myid);
            if (IsAddedToCollection == null)
            {
                MC.MovieId = idofmovie;
                MC.UserId = myid;
                _context.MovieListCollections.Add(MC);
                _context.SaveChanges();
                return RedirectToAction("Details", "Main", new { id = idofmovie });
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult AddComment(MovieComments comments)
        {
            int myid = (int)Session["MyId"];
            int idofmovie = (int)Session["MovieId"];
            comments.ApplicationUserId = myid;
            comments.MovieMainId = idofmovie;
            if (ModelState.IsValid)
            {
                _context.MovieCommentses.Add(comments);
                _context.SaveChanges();
            }
            return RedirectToAction("Details", "Main", new { id = idofmovie });
        }

        public ActionResult EditComment(int Id, MovieComments comments)
        {
            int idofmovie = (int)Session["MovieId"];
            var commentEdit = _context.MovieCommentses.Single(x => x.Id == Id);
            if (ModelState.IsValid)
            {
                commentEdit.Comment = comments.Comment;
                _context.SaveChanges();
            }
            return RedirectToAction("Details", "Main", new { id = idofmovie });
        }

        public ActionResult DeleteComment(int Id)
        {
            MovieComments movieComments = _context.MovieCommentses.Find(Id);
            int idofmovie = (int)Session["MovieId"];
            if (movieComments == null)
            {
                return HttpNotFound();
            }

            _context.MovieCommentses.Remove(movieComments);
            _context.SaveChanges();
            return RedirectToAction("Details", "Main", new { id = idofmovie });
        }

    }
}