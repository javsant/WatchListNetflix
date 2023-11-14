using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wathclist_Netflix.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public string Company { get; set; }
        public string Genre { get; set; }
        public int Rating { get; set; }
    }
}