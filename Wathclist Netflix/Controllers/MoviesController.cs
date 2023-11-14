using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Wathclist_Netflix.Models;

namespace Wathclist_Netflix.Controllers
{
    public class MoviesController : Controller
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
            var movies = GetAllMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetAllMovies()
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM movie", c);
            List<Movie> movies = new List<Movie>();
            Connect();
            datareader = query.ExecuteReader();
            while (datareader.Read())
            {
                movies.Add(new Movie
                {
                    Title = datareader.GetString("Title"),
                    Descr = datareader.GetString("Descr"),
                    Company = getCompanyById(datareader.GetInt32("CompanyId")),
                    Genre = getGenryById(datareader.GetInt32("GenreId")),
                    Rating = datareader.GetInt32("Rating"),
                    Length = datareader.GetInt32("Length")
                });
            }
            return movies;
        }

        private String getCompanyById(int id)
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

        private String getGenryById(int id)
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

        public ActionResult Details(int? id)
        {

            MySqlCommand query = new MySqlCommand("SELECT * FROM movie where id = @idMovie", c);

            MySqlParameter idMovie = query.Parameters.Add("@idMovie", MySqlDbType.String);
            idMovie.Value = id;

            Connect();
            datareader = query.ExecuteReader();

            Movie m = new Movie();

            while (datareader.Read())
            {
                m.Title = datareader.GetString(1);
                m.Descr = datareader.GetString(2);
                m.Company = datareader.GetString(3);
                m.Genre = datareader.GetString(5);
                m.Rating = datareader.GetInt32(6);
                m.Length = datareader.GetInt32(7);

            }

            return View(m);
        }
    }
}