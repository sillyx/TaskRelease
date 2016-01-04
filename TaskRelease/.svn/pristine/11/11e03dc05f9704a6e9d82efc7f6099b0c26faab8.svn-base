using System;
using TaskRelease.Model;
using TaskRelease.Utility;
using SingleTableCRUD;
using System.Data.SqlClient;
using v = TaskRelease.Model.ViewObject;
using System.Text;
using System.Collections.Generic;

namespace TaskRelease.DAL
{
    public class QuestionService
    {
        private Service _service;
        public QuestionService()
        {
            _service = new Service();
        }
        //查找问题列表
        public List<Question> GetQuestions(int page, int size)
        {
            var sqlString = new StringBuilder();
            sqlString.AppendFormat("select top {0} q.Id as qId,q.Content as qContent,q.Asker as qAsker,q.AuditState as qAuditState,q.CreateDate as qCreateDate from Question q ", size);
            sqlString.AppendFormat("where q.Id not in(select top {1} Id from Question order by CreateDate desc) ", (page - 1) * size);
            sqlString.Append("order by CreateDate desc ");
            var qList = new List<Question>();
            try
            {
                using (var dataReader = SqlDBHelper.ExecuteReader(sqlString.ToString()))
                {
                    while (dataReader.Read())
                    {
                        var q = new Question
                        {
                            Id = dataReader["qId"].ToSafeTrim(),
                            Asker = dataReader["qAsker"].ToSafeTrim(),
                            Content = dataReader["qContent"].ToSafeTrim(),
                            CreateDate = dataReader["qCreateDate"].ToSafeTrim()
                        };
                        qList.Add(q);
                    }
                }
                return qList;
            }
            catch (Exception e)
            {
                e.WriterLog();
                return null;
            }
        }

        //查找单个问题,同时查找所有评论
        public v.Question GetOne(string qId)
        {
            var sqlString = new StringBuilder(); 
            try
            {
                var question = _service.SerarchList<Question>(string.Format("Id='{0}'", qId));
                var comments = _service.SerarchList<Comment>(string.Format("QuestionId='{0}' and ParentId is null", qId));
                var dt = SqlDBHelper.Query(sqlString.ToString());
                v.Question q = new v.Question();
                q.Comments = new List<v.Comment>(); 
                question.ForEach(e =>
                {
                    q.Id = e.Id;
                    q.Asker = e.Asker;
                    q.AuditState = e.AuditState;
                    q.Content = e.Content;
                    q.CreateDate = e.CreateDate;
                });
                comments.ForEach(e =>
                {
                    var c = new v.Comment();
                    c.Id = e.Id;
                    c.ParentId = e.ParentId;
                    c.QuestionId = e.QuestionId;
                    c.Content = e.Content;
                    c.Replayer = e.Replayer;
                    c.CommentDate = e.CommentDate;
                });
                return q;
            }
            catch (Exception e)
            {
                e.WriterLog();
                return null;
            }
        }
    }
}
