using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IOpinionService
    {
        List<Opinion> GetList();
        List<Opinion> GetByIdList(int id);
        Opinion GetById(int id);
        void Add(Opinion entity);
        void Update(Opinion entity);
        void Delete(Opinion entity);
    }
}