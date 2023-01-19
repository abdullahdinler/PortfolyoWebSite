using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IPortfolioService
    {
        List<Portfolio> GetList();
        List<Portfolio> GetByIdList(int id);
        Portfolio GetById(int id);
        void Add(Portfolio entity);
        void Update(Portfolio entity);
        void Delete(Portfolio entity);
    }
}
