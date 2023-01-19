using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ContactManager:IContactService
    {
        private IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public List<Contact> GetList()
        {
           return _contactDal.List();
        }

        public List<Contact> GetByIdList(int id)
        {
           return _contactDal.List(x=>x.Id == id);
        }

        public List<Contact> Search(string word)
        {
            return _contactDal.List(x => x.FullName.Contains(word));
        }

        public Contact GetById(int id)
        {
            return _contactDal.GetById(x => x.Id == id);
        }

        public void Add(Contact entity)
        {
            _contactDal.Add(entity);
        }

        public void Update(Contact entity)
        {
            _contactDal.Update(entity);

        }

        public void Delete(Contact entity)
        {
            _contactDal.Delete(entity);

        }
    }
}
