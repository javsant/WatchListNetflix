using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wathclist_Netflix.Controllers
{
    public class SignInController : Controller
    {

        private static MySqlConnection c = new MySqlConnection("DataBase=watchlistnetflixdb;Server=localhost;user=root;password=root;Port=3306");
        private static MySqlDataReader datareader;
        private static Boolean exists = false;

        public void Connect()
        {
            c.Close();
            c.Open();
        }

        public bool CheckUser(string name)
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
                    if (datareader.GetString(1).Equals(name))
                    {
                        exists = true;
                    }
                }
            }
            datareader.Close();
            return exists;
        }

        [HttpPost]
        public bool SignIn(string name, string pass)
        {
            bool singnedIn = false;
            MySqlCommand query = new MySqlCommand("INSERT INTO user(Username, Pass) VALUES(@usname, @passw)", c);

            MySqlParameter usname = query.Parameters.Add("@usname", MySqlDbType.String);
            MySqlParameter passwd= query.Parameters.Add("@passw", MySqlDbType.String);

            usname.Value = name;
            passwd.Value = pass;
            Connect();
            if (CheckUser(name) != true)
            {                
                query.ExecuteNonQuery();
                Session["user"] = name;
                singnedIn = true;
            }

            return singnedIn;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}