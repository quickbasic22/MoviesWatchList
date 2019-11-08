namespace MoviesWatchList.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesWatchList.Models.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoviesWatchList.Models.MovieContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Movies.AddOrUpdate(
            new Models.Movie { Title = "Star Wars 3", genre = Models.Movie.Genre.ScienceFiction, like = Models.Movie.Like.VeryGood, location = Models.Movie.Location.Blueray, WatchOn = DateTime.Now.AddDays(2400), Note = "Home alone" },
            new Models.Movie { Title = "Star Wars 2", genre = Models.Movie.Genre.ScienceFiction, like = Models.Movie.Like.AbsolutelyHatedIt, location = Models.Movie.Location.Dvd, WatchOn = DateTime.Now.AddDays(4900), Note = "Home alone" },
            new Models.Movie { Title = "Star Wars 1", genre = Models.Movie.Genre.ScienceFiction, like = Models.Movie.Like.VeryGood, location = Models.Movie.Location.Theatre, WatchOn = DateTime.Now.AddDays(-1200), Note = "Theatre alone" });
        }
    }
}
