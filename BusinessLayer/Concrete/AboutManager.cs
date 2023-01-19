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
    public class AboutManager:IAboutService
    {
        private IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(x=>x.Id == id);
        }

        public List<About> GetByIdList(int id)
        {
            return _aboutDal.List(x => x.Id == id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
