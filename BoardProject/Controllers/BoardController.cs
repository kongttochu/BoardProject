using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoardProject.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult BoardView()
        {
            return View();
        }
    }
}