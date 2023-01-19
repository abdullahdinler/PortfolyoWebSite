using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class EducationManager:IEducationService
    {
        private IEducationDal _educationDal;

        public EducationManager(IEducationDal educationDal)
        {
            _educationDal = educationDal;
        }

        public List<Education> GetList()
        {
            return _educationDal.List();
        }

        public List<Education> GetByIdList(int id)
        {
            return _educationDal.List(x=>x.Id == id);
        }

        public Education GetById(int id)
        {
            return _educationDal.GetById(x => x.Id == id);
        }

        public void Add(Education entity)
        {
            _educationDal.Add(entity);
        }

        public void Update(Education entity)
        {
            _educationDal.Update(entity);
        }

        public void Delete(Education entity)
        {
            _educationDal.Delete(entity);
        }
    }
}
