using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wathclist_Netflix.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();

            return companies;
        }
    }
}