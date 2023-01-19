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
    public class ServiceManager:IServiceService
    {
        private IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public List<Service> GetList()
        {
            return _serviceDal.List();
        }

        public List<Service> GetByIdList(int id)
        {
            return _serviceDal.List(x=>x.Id == id);
        }

        public Service GetById(int id)
        {
            return _serviceDal.GetById(x => x.Id == id);
        }

        public void Add(Service entity)
        {
            _serviceDal.Add(entity);
        }

        public void Update(Service entity)
        {
            _serviceDal.Update(entity);
        }

        public void Delete(Service entity)
        {
            _serviceDal.Delete(entity);
        }
    }
}
