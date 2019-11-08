using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MoviesWatchList.Models;

namespace MoviesWatchList.Controllers
{
    public class MoviesController : Controller
    {
        
        private MovieContext db = new MovieContext();
        private object movies;

        // GET: Movies
        public ActionResult Index(int? Title, string Search)
        { 
            switch (Title)
            {
                case 1:
                    int movie = Int32.Parse(Search);
                    movies = db.Movies.Where(t => t.MovieId == movie);
                    break;
                case 2:
                    movies = db.Movies.Where(t => t.Title == Search);
                    break;
                case 3:
                    if (Search == "AbsolutelyHatedIt")
                        movies = db.Movies.Where(t => t.like == Movie.Like.AbsolutelyHatedIt);
                    else if (Search == "Good")
                        movies = db.Movies.Where(t => t.like == Movie.Like.Good);
                    else if (Search == "HatedIt")
                        movies = db.Movies.Where(t => t.like == Movie.Like.HatedIt);
                    else if (Search == "LovedIt")
                        movies = db.Movies.Where(t => t.like == Movie.Like.LovedIt);
                    else if (Search == "VeryGood")
                        movies = db.Movies.Where(t => t.like == Movie.Like.VeryGood);
                    break;                    

                case 4:
                    if (Search == "Blueray")
                    movies = db.Movies.Where(t => t.location == Movie.Location.Blueray);
                    if (Search == "Dvd")
                        movies = db.Movies.Where(t => t.location == Movie.Location.Dvd);
                    if (Search == "Internet")
                        movies = db.Movies.Where(t => t.location == Movie.Location.Internet);
                    if (Search == "Theatre")
                        movies = db.Movies.Where(t => t.location == Movie.Location.Theatre);
                    break;
       
                case 5:
                    DateTime dt = DateTime.Parse(Search);
                    movies = db.Movies.Where(t => t.WatchOn == dt);
                    break;
                case 6:
                    if (Search == "Action")
                    movies = db.Movies.Where(t => t.genre == Movie.Genre.Action);
                    if (Search == "Adventure")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Adventure);
                    if (Search == "Animation")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Animation);
                    if (Search == "Comedy")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Comedy);
                    if (Search == "Drama")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Drama);
                    if (Search == "Fantasy")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Fantasy);
                    if (Search == "Horror")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Horror);
                    if (Search == "Mystery")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Mystery);
                    if (Search == "ScienceFiction")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.ScienceFiction);
                    if (Search == "Thriller")
                        movies = db.Movies.Where(t => t.genre == Movie.Genre.Thriller);
                    break;

                case 7:
                    movies = db.Movies.Where(t => t.Note == Search);
                    break;
                default:
                    movies = db.Movies;
                    break;
            }
            return View(movies);
        }

        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Title,like,genre,WatchOn,location,Note")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Title,like,genre,WatchOn,location,Note")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            base.Dispose(disposing);
            }
        }

        
    }
}   