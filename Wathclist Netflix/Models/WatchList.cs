using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wathclist_Netflix.Models
{
    public class WatchList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public List<Content> contents { get; set; }

        public List<Content> GetContents()
        {
            return contents;
        }
    }
}