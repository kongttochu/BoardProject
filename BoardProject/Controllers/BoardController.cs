using BoardProject.Models;
using Newtonsoft.Json;
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

        public ActionResult CreateView()
        {
            return View();
        }

        public ActionResult ReadView()
        {
            return View();
        }

        public ActionResult EditView()
        {
            return View();
        }

        public JsonResult GetList(int offset, int next)
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetList("","", offset, next));
            return Json(jsonData);
        }

        public JsonResult GetCount()
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetCount());
            return Json(jsonData);
        }
    }
}