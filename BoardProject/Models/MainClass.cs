using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardProject.Models
{
    public class MainClass
    {

    }

    public class Board
    {
        //Entity
        public int IDX { get; set; }
        public string TITLE { get; set; }
        public string CONTENTS { get; set; }
        public DateTime REGDATE { get; set; }
        public string REGID { get; set; }
        public DateTime UPDDATE { get; set; }
        public string UPDID { get; set; }
        public int count { get; set; }

        //DTO
        public int SETPAGE { get; set; }
        public string CNT { get; set; }
        public string REGDATESTRING { get; set; }
    }
}