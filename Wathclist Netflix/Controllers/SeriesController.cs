using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wathclist_Netflix.Models;

namespace Wathclist_Netflix.Controllers
{
    public class SeriesController : Controller
    {
        private static MySqlConnection c = new MySqlConnection("DataBase=watchlistnetflixdb;Server=localhost;user=root;password=root;Port=3306");
        private static MySqlDataReader datareader;

        public void Connect()
        {
            c.Close();
            c.Open();
        }
        public ActionResult Index()
        {
            var series = GetAllSeries();

            return View(series);
        }

        private IEnumerable<Serie> GetAllSeries()
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM Serie", c);
            List<Serie> series = new List<Serie>();
            Connect();
            datareader = query.ExecuteReader();
            while (datareader.Read())
            {
                series.Add(new Serie
                {
                    Id = datareader.GetInt32("Id"),
                    Title = datareader.GetString("Title"),
                    Descr = datareader.GetString("Descr"),
                    Company = getCompanyById(datareader.GetInt64("CompanyId")),
                    Genre = getGenryById(datareader.GetInt64("GenreId")),
                    Rating = datareader.GetInt32("Rating"),
                    Seasons = datareader.GetInt32("Seasons"),
                    Chapters = datareader.GetInt32("Chapters")
                });
            }
            return series;
        }

        public ActionResult SerieDetails(int? id)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM Serie where id = @idSerie", c);

            MySqlParameter idSerie = query.Parameters.Add("@idSerie", MySqlDbType.String);
            idSerie.Value = id;

            Connect();
            datareader = query.ExecuteReader();

            Serie s = new Serie();

            while (datareader.Read())
            {
                s.Title = datareader.GetString(1);
                s.Descr = datareader.GetString(2);
                s.Company = datareader.GetString(3);
                s.Genre = datareader.GetString(5);
                s.Rating = datareader.GetInt32(6);
                s.Seasons = datareader.GetInt32(7);
                s.Chapters = datareader.GetInt32(8);
            }

            return View(s);
        }

        private String getCompanyById(long id)
        {
            String company = "";
            MySqlCommand query = new MySqlCommand("SELECT company_name FROM company where id = @idCompany", c);
            MySqlParameter idCompany = query.Parameters.Add("@idCompany", MySqlDbType.String);
            idCompany.Value = id;
            Connect();
            datareader = query.ExecuteReader();
            if (datareader.HasRows)
            {
                if (datareader.Read())
                {
                    company = datareader.GetString(0);
                }
            }
            return company;
        }

        private String getGenryById(long id)
        {
            String gemre = "";
            MySqlCommand query = new MySqlCommand("SELECT genre_name FROM genre where id = @idGenre", c);
            MySqlParameter idGenre = query.Parameters.Add("@idGenre", MySqlDbType.String);
            idGenre.Value = id;
            Connect();
            datareader = query.ExecuteReader();
            if (datareader.HasRows)
            {
                if (datareader.Read())
                {
                    gemre = datareader.GetString(0);
                }
            }
            return gemre;
        }
    }
}