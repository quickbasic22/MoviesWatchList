using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesWatchList.Models
{
    public class MovieContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
        public virtual DbSet<Movie> Movies { get; set; }
    }

}