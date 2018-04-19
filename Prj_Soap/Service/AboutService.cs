using Prj_Soap.Interface;
using Prj_Soap.Models;
using Prj_Soap.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_Soap.Service
{
    public class AboutService
    {
        private IRepository<About> repository = new GenericRepository<About>(new ApplicationDbContext());

        public About GetAboutSettings()
        {
            var instance = repository.GetList().SingleOrDefault();
            
            return instance;
        }

        public About SaveChange(About model)
        {
            try
            {
                if (model.Id == 0)
                    repository.Create(model);
                else
                {
                    var instance = repository.Get(x => x.Id == model.Id);
                    instance.Address = model.Address;
                    instance.Email = model.Email;
                    instance.PhoneNumber = model.PhoneNumber;
                    instance.Content = model.Content;
                    instance.FacebookUrl = model.FacebookUrl;
                    instance.TwitterUrl = model.TwitterUrl;
                    instance.GoogPlusUrl = model.GoogPlusUrl;
                    repository.Update(instance);
                }
               
            }
            catch (Exception)
            {
                return null;
                throw;
            }
           
            return model;
        }
    }
}