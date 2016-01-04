using System;
using TaskRelease.Model;
using SingleTableCRUD;
using TaskRelease.Utility;

namespace TaskRelease.DAL
{
    public class PersonalInfoService
    {
        private Service _service;

        public PersonalInfoService()
        {
            _service = new Service();
        }

        public bool Insert(PersonalInfo personal)
        {
            try
            {
                return _service.Insert(personal);
            }
            catch (Exception ex)
            {
                ex.WriterLog();
                return false;
            }
        }

        public bool Update(PersonalInfo personal)
        {
            try
            {
                return _service.Update(personal);
            }
            catch (Exception ex)
            {
                ex.WriterLog();
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                return _service.Delete<PersonalInfo>(id);
            }
            catch (Exception ex)
            {
                ex.WriterLog();
                return false;
            }
        }


    }
}
                  