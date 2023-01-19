using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IServiceService
    {
        List<Service> GetList();
        List<Service> GetByIdList(int id);
        Service GetById(int id);
        void Add(Service entity);
        void Update(Service entity);
        void Delete(Service entity);
    }
}
