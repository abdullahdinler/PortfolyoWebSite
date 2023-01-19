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
    public class OpinionManager:IOpinionService
    {
        private IOpinionDal _opinionDal;

        public OpinionManager(IOpinionDal opinionDal)
        {
            _opinionDal = opinionDal;
        }

        public List<Opinion> GetList()
        {
            return _opinionDal.List();
        }

        public List<Opinion> GetByIdList(int id)
        {
            return _opinionDal.List(x=>x.Id == id);
        }

        public Opinion GetById(int id)
        {
            return _opinionDal.GetById(x => x.Id == id);
        }

        public void Add(Opinion entity)
        {
            _opinionDal.Add(entity);
        }

        public void Update(Opinion entity)
        {
            _opinionDal.Update(entity);
        }

        public void Delete(Opinion entity)
        {
            _opinionDal.Delete(entity);
        }
    }
}
