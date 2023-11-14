using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Wathclist_Netflix.Models;

namespace Wathclist_Netflix.Controllers
{
    public class LoginController : Controller
    {
        private static MySqlConnection c = new MySqlConnection("DataBase=watchlistnetflixdb;Server=localhost;user=root;password=root;Port=3306");
        private static MySqlDataReader datareader;
        private static Boolean loggedIn = false;

        public ActionResult Index()
        {
            return View();
        }

        public void Connect()
        {
            c.Close();
            c.Open();
        }

        [HttpPost]
        public bool Login(string name, string pass)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM user where username = @n", c);
            MySqlParameter username = query.Parameters.Add("@n", MySqlDbType.String);
            username.Value = name;
            Connect();
            datareader = query.ExecuteReader();

            if (datareader.HasRows)
            {
                if (datareader.Read())
                {
                    if (datareader.GetString(2).Equals(pass))
                    {
                        Session["user"] = datareader.GetString(1);
                        loggedIn = true;
                    }
                }
            }

            return loggedIn;
        }

        [HttpPost]
        public bool LogOut()
        {
            Session["user"] = "";
            loggedIn = false;
            return loggedIn;
        }
    }
}