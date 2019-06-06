using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Challenge_Winner_Validity.Models;
using static Challenge_Winner_Validity.Models.Board;

namespace Challenge_Winner_Validity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            State[,] newBoard = new State[6,7];

            return View();
        }

       
    }
}