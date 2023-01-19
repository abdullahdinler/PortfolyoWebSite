using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IEducationService
    {
        List<Education> GetList();
        List<Education> GetByIdList(int id);
        Education GetById(int id);
        void Add(Education entity);
        void Update(Education entity);
        void Delete(Education entity);
    }
}
