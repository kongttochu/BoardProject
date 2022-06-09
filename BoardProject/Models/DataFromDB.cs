using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardProject.Models
{
    public class DataFromDB
    {
        public List<Board> GetList(string colum, string param, int offset, int next)
        {
            List<Board> list = new List<Board>();
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETSEARCH '{0}', '{1}', {2}, {3}"
                , colum, param, offset, next);
            var data = dbconn.ConnectDB(queryString);

            DateTime dt = DateTime.Now;
            while (data.Read())
            {
                list.Add(new Board
                {
                    IDX = (int)data["IDX"],
                    TITLE = data["TITLE"].ToString(),
                    CONTENTS = data["CONTENTS"].ToString(),
                    REGDATE = DateTime.TryParse(data["REGDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    REGID = data["REGID"].ToString(),
                    UPDDATE = DateTime.TryParse(data["UPDDATE"].ToString(), out dt) ? dt : DateTime.Now,
                    UPDID = data["UPDID"].ToString()
                });
            }
            return list;
        }

        public string GetCount()
        {
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETCOUNT");
            var data = dbconn.ConnectDB(queryString);
            int count = -1;
            while (data.Read())
            {
                count = (int)data["COUNT"];
            }
            return string.Format("{{count : {0}}}", count);
        }

        public Board GetOneBoard(int id)
        {
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_GETCONTENTS {0}", id);
            var data = dbconn.ConnectDB(queryString);
            Board board = new Board();
            while (data.Read())
            {
                board.TITLE = data["TITLE"].ToString();
                board.CONTENTS = data["CONTENTS"].ToString();
            }
            return board;
        }

        public void InsertBoard(string title, string contents)
        {
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_INSERTCONTENTS \'{0}\', \'{1}\'"
                                                                        , title, contents);
            var data = dbconn.ConnectDB(queryString);
        }

        public void UpdateBoard(int id, string title, string contents)
        {
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_UPDATECONTENTS {0}, \'{1}\', \'{2}\'"
                                                                        , id, title, contents);
            var data = dbconn.ConnectDB(queryString);
        }

        public void DeleteBoard(int id)
        {
            dbconn dbconn = new dbconn();
            string queryString = string.Format("EXEC USP_UNUSECONTENTS {0}", id);
            var data = dbconn.ConnectDB(queryString);
        }
    }
}