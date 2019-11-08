using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesWatchList.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        [UIHint("Enum-checkbox")]
        public Like like { get; set; }
        [UIHint("Enum-radio")]
        public Genre genre { get; set; }
        public DateTime WatchOn { get; set; }
        [UIHint("DropDownList")]
        public Location location { get; set; }
        [UIHint("MultilineText")]
        public string Note { get; set; }

        public enum Genre
        {
            Animation,
            Action,
            Adventure,
            Comedy,
            Drama,
            Fantasy,
            Horror,
            Mystery,
            ScienceFiction,
            Thriller            
        }

        public enum Location
        {
            Dvd,
            Blueray,
            Internet,
            Theatre
        }

        public enum Like
        {
            LovedIt,
            VeryGood,
            Good,
            HatedIt,
            AbsolutelyHatedIt
        }
    }
}