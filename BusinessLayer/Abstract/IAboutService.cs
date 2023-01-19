using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        List<About> GetByIdList(int id);
        About GetById(int id);
        void Add(About entity);
        void Update(About entity);
        void Delete(About entity);
    }
}
