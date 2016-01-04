using System;
using System.Collections.Generic;
using SingleTableCRUD;
using TaskRelease.Model;
using TaskRelease.Utility;
using v = TaskRelease.Model.ViewObject;

namespace TaskRelease.BLL
{
    public class QuestionService
    {
        private Service _service;
        private DAL.QuestionService _qService;
        public QuestionService()
        {
            _service = new Service();
            _qService = new DAL.QuestionService();
        }

        //添加问题
        public bool AddQuestion(Question q)
        {
            try
            {
                return _service.Insert<Question>(q);
            }
            catch (Exception e)
            {
                e.WriterLog();
                return false;
            }
        }
        //删除问题(多个Question时Id用逗号隔开)
        public bool DeleteQuestions(string qIds)
        {
            try
            {
                return _service.Delete<Question>(qIds);
            }
            catch (Exception e)
            {
                e.WriterLog();
                return false;
            }
        }
        //修改问题
        public bool ModifyOne(Question q)
        {
            try
            {
                return _service.Update<Question>(q);
            }
            catch (Exception e)
            {
                e.WriterLog();
                return false;
            }
        }
        //查找问题列表
        public List<Question> GetQuestions(int? page, int? size)
        {
            int currentPage = page ?? 1;
            int currentSize = size ?? Extensions.GetAppsettingKey("questionPageSize").ToInt();
            return _qService.GetQuestions(currentPage, currentSize);
        }

        //查找单个问题,同时查找所有评论
        public v.Question GetOne(string qId)
        {
            return _qService.GetOne(qId);
        }
    }
}
