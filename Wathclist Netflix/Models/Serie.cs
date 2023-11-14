using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wathclist_Netflix.Models
{
    public class Serie : Content
    {
        public int Seasons { get; set; }
        public int Chapters { get; set; }
    }
}