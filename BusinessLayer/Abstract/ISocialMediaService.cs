using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ISocialMediaService
    {
        List<SocialMedia> GetList();
        List<SocialMedia> GetByIdList(int id);
        SocialMedia GetById(int id);
        void Add(SocialMedia entity);
        void Update(SocialMedia entity);
        void Delete(SocialMedia entity);
    }
}
