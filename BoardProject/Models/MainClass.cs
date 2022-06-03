using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardProject.Models
{
    public class MainClass
    {
    }

    public class Board_Contents_Info
    {
        public int IDX { get; set; }
        public int CONTENTS_IDX { get; set; }
        public string CONTENTS_TITLE { get; set; }
        public DateTime CONTENTS_REGDATE { get; set; }
        public string CONTENTS_REGID { get; set; }
        public DateTime CONTENTS_UPDDATE { get; set; }
        public string CONTENTS_UPDID { get; set; }
        public bool ISUSE { get; set; }
    }

    public class Board_Contents_Detail
    {
        public int IDX { get; set; }
        public string CONTENTS_TEXT { get; set; }
        public bool ISUSE { get; set; }
    }
}