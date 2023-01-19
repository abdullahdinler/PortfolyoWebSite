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
    public class ExperienceManager:IExperienceService
    {
        private IExperienceDal _experienceDal;

        public ExperienceManager(IExperienceDal experienceDal)
        {
            _experienceDal = experienceDal;
        }

        public List<Experience> GetList()
        {
            return _experienceDal.List();
        }

        public List<Experience> GetByIdList(int id)
        {
            return _experienceDal.List(x=>x.Id == id);
        }

        public Experience GetById(int id)
        {
            return _experienceDal.GetById(x => x.Id == id);
        }

        public void Add(Experience entity)
        {
            _experienceDal.Add(entity);
        }

        public void Update(Experience entity)
        {
            _experienceDal.Update(entity);
        }

        public void Delete(Experience entity)
        {
            _experienceDal.Delete(entity);
        }
    }
}
