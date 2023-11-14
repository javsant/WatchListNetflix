using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wathclist_Netflix.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }

        public List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();

            return genres;
        }
    }
}