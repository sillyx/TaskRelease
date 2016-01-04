using System;
using System.Data.SqlClient;
using TaskRelease.Model;
using SingleTableCRUD;
using TaskRelease.Utility;


namespace TaskRelease.DAL
{
    public class PersonCategoryService
    {
        private Service _service;
        public PersonCategoryService()
        {
            _service = new Service();
        }

        public bool Insert(PersonCategory category)
        {
            try
            {
                return _service.Insert(category);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL", "PersonCategoryService", "Insert");
                return false;
            }

        }

        public bool Update(PersonCategory category)
        {
            try
            {
                return _service.Update(category);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL", "PersonCategoryService", "Update");
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                return _service.Delete<PersonCategory>(id);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL", "PersonCategoryService", "Delete");
                return false;
            }
        }

        public PersonCategory GetCategoryById(string id)
        {
            const string sql = @"SELECT [Id],[Name] FROM [PersonCategory] where Id=@Id";
            var parm = new[]
                {
                    new SqlParameter("@Id",id)
                };
            try
            {
                var ds = SqlDBHelper.Query(sql, parm);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return DataTableHelper.ToEntity<PersonCategory>(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                ex.WriterLog("TaskRelease.DAL.dll", "MemberService", "GetCategoryById");
                return null;
            }
        }

    }
}
