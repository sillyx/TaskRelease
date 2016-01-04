using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SingleTableCRUD;

namespace TaskRelease.Model.ViewObject
{
    public class Comment
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Replayer { get; set; }
        public string CommentDate { get; set; }
        public string Content { get; set; }
        public string QuestionId { get; set; }
        //子级评论
        public Lazy<List<Model.Comment>> Comments
        {
            get
            {
                return new Lazy<List<Model.Comment>>(GetComments);
            }
        }
        public List<Model.Comment> GetComments()
        {
            var sqlString = new StringBuilder();
            sqlString.Append("with tb  as ");
            sqlString.Append("( ");
            sqlString.AppendFormat("select t1.* from Comment t1 where t1.ParentId='{0}' ", this.ParentId);
            sqlString.Append(" ");
            sqlString.Append("union all ");
            sqlString.Append(" ");
            sqlString.Append("select t2.* from Comment t2 inner join  tb ");
            sqlString.Append("on t2.ID=tb.PID) ");
            sqlString.Append("select * from tb ");
            var list = new List<Model.Comment>();
            try
            {
                using (var dataReader = SqlDBHelper.ExecuteReader(sqlString.ToString()))
                {
                    while (dataReader.Read())
                    {
                        var commnet = new Model.Comment
                        {
                            Id = dataReader["Id"].ToString(),
                            ParentId = dataReader["ParentId"].ToString(),
                            Replayer = dataReader["Replayer"].ToString(),
                            CommentDate = dataReader["CommnetDate"].ToString(),
                            Content = dataReader["Content"].ToString(),
                            QuestionId = dataReader["QuestionId"].ToString()
                        };
                        list.Add(commnet);
                    }
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
