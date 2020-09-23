using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPlastic.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string pKey { get; set; }
        public string pIV { get; set; }
        public string Address { get; set; }
        public int idProfile { get; set; }
    }

    public class Article
    {
        public int idArticle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
    }

    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}