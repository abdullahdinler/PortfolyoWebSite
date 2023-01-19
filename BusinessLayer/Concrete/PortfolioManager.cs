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
    public class PortfolioManager:IPortfolioService
    {
        private IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public List<Portfolio> GetList()
        {
           return _portfolioDal.List();
        }

        public List<Portfolio> GetByIdList(int id)
        {
            return _portfolioDal.List(x=>x.Id == id);
        }

        public Portfolio GetById(int id)
        {
            return _portfolioDal.GetById(x => x.Id == id);
        }

        public void Add(Portfolio entity)
        {
            _portfolioDal.Add(entity);
        }

        public void Update(Portfolio entity)
        {
            _portfolioDal.Update(entity);
        }

        public void Delete(Portfolio entity)
        {
            _portfolioDal.Delete(entity);
        }
    }
}
