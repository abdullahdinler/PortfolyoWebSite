using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        List<Contact> GetByIdList(int id);
        List<Contact> Search(string word);
        Contact GetById(int id);
        void Add(Contact entity);
        void Update(Contact entity);
        void Delete(Contact entity);
    }
}
