using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IExperienceService
    {
        List<Experience> GetList();
        List<Experience> GetByIdList(int id);
        Experience GetById(int id);
        void Add(Experience entity);
        void Update(Experience entity);
        void Delete(Experience entity);
    }
}
