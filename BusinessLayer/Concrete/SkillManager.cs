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
    public class SkillManager:ISkillService
    {
        private ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }

        public List<Skill> GetByIdList(int id)
        {
            return _skillDal.List(x => x.Id == id);
        }

        public Skill GetById(int id)
        {
            return _skillDal.GetById(x => x.Id == id);
        }

        public void Add(Skill entity)
        {
            _skillDal.Add(entity);
        }

        public void Update(Skill entity)
        {
            _skillDal.Update(entity);
        }

        public void Delete(Skill entity)
        {
            _skillDal.Delete(entity);
        }
    }
}
