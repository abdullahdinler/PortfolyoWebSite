using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISkillService
    {
        List<Skill> GetList();
        List<Skill> GetByIdList(int id);
        Skill GetById(int id);
        void Add(Skill entity);
        void Update(Skill entity);
        void Delete(Skill entity);
    }
}
