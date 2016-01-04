using TaskRelease.DAL;
using TaskRelease.Model;

namespace TaskRelease.BLL
{
    public class PersonCategoryManager
    {
        private PersonCategoryService _service;
        public PersonCategoryManager()
        {
            _service = new PersonCategoryService();
        }

        public bool Insert(PersonCategory category)
        {
            return _service.Insert(category);
        }

        public bool Update(PersonCategory category)
        {
            return _service.Update(category);
        }

        public bool Delete(string id)
        {
            return _service.Delete(id);
        }

        public PersonCategory GetCategoryById(string id)
        {
            return _service.GetCategoryById(id);
        }

    }
}
