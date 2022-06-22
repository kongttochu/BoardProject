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
        //    ViewBag.CreView = "/Board/CreateView";
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

        public JsonResult GetList(int setPage, int pageSize, string colum, string param, string order, string isDesc)
        {
            Board abc = new Board();
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetList(setPage, pageSize, colum, param, order, isDesc));
            return Json(jsonData);
        }

        public JsonResult GetCount(string colum, string param)
        {
            DataFromDB data = new DataFromDB();
            string jsonData = JsonConvert.SerializeObject(data.GetCount(colum, param));
            return Json(jsonData);
        }
    }
}