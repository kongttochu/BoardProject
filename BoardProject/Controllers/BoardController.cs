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

        [HttpPost]
        public ActionResult CreateProcess(string title, string contents)
        {
            DataFromDB data = new DataFromDB();
            data.InsertBoard(title, contents);
            for (int i = 0; i < 120; i++)
            {
                data.InsertBoard(string.Format("제목 {0}", i), string.Format("내용 {0}", i));
            }
            return RedirectToAction("BoardView");
        }

        public ActionResult ReadView(int board_id)
        {
            ViewBag.board_id = board_id;
            return View();
        }

        public JsonResult GetOneBoard(int id)
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetOneBoard(id));
            return Json(jsonData);
        }

        public ActionResult EditView(int board_id)
        {
            ViewBag.board_id = board_id;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProcess(int board_id, string title, string contents)
        {
            DataFromDB data = new DataFromDB();
            data.UpdateBoard(board_id, title, contents);
            return RedirectToAction("BoardView");
        }

        public ActionResult DeleteView(int board_id)
        {
            DataFromDB data = new DataFromDB();
            data.DeleteBoard(board_id);
            return RedirectToAction("BoardView");
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