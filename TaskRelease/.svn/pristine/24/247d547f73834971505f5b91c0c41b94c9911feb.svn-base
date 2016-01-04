using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SingleTableCRUD;
using TaskRelease.Model;
using TaskRelease.Utility;

namespace TaskRelease.BLL
{
    public class ProjectCategoryService
    {
        private Service _service;
        public ProjectCategoryService()
        {
            _service = new Service();
        }
        public bool AddOne(ProjectCategory pCategory)
        {
            return _service.Insert<ProjectCategory>(pCategory);
        }

        public bool RemoveCategory(string cIds)
        {
            return _service.Delete<ProjectCategory>(cIds);
        }

        public bool ModifyOne(ProjectCategory pCategory)
        {
            return _service.Update<ProjectCategory>(pCategory);
        }

        public List<ProjectCategory> GetCategoryList(int? page, int? size)
        {
            int currentPage = page ?? 1;
            int currentSize = size ?? Extensions.GetAppsettingKey("pCategoryPageSize").ToInt();
            var categoryList = _service.SerarchList<ProjectCategory>();
            return categoryList.Skip(currentSize * (currentPage - 1)).Take(currentSize).ToList();
        }
    }
}
