using AutoMapper;
using Prj_Soap.Areas.Admin.Models;
using Prj_Soap.Interface;
using Prj_Soap.Models;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Prj_Soap.Service
{
    public class SoapService
    {
        IRepository<Soap> repository = new GenericRepository<Soap>(new ApplicationDbContext());
        LocalDateTimeService timeService = new LocalDateTimeService();

        public AdminSoapListViewModel GetList(int page)
        {
            var list = repository.GetList().OrderByDescending(x => x.UploadTime).ToList().Skip(3 * (page-1)).Take(3).Select(Mapper.Map<Soap, SoapWithFormattedDate>);
            var total = repository.GetList().Count();
            var soapListViewModel = new AdminSoapListViewModel
            {
                Soaps = list,
                Total = total
            };
            return soapListViewModel;
        }

        public IEnumerable<SoapListViewModel> GetList()
        {
            var list = repository.GetList().OrderByDescending(x => x.UploadTime).ToList().Select(Mapper.Map<Soap, SoapListViewModel>);

            return list;
        }

        public IEnumerable<SoapListViewModel> GetNewest4Items()
        {
            var list = repository.GetList().OrderByDescending(x => x.UploadTime).ToList().Take(4).Select(Mapper.Map<Soap, SoapListViewModel>);

            return list;
        }

        public IResult Delete(string id)
        {
            IResult result = new Result();
            try
            {
                var instance = repository.Get(x => x.Id == id);
                var filePath = HttpContext.Current.Server.MapPath("~"+instance.ImageUrl);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                repository.Delete(instance);           
                result.Success = true;
            }
            catch(Exception e)
            {
                result.Message = e.ToString();
            }
            return result;
        }

        public Soap SaveItem(SoapUploadViewModel model, string serverPath)
        {
            var file = model.ImageFile;
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var fileNameNoExtention = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = serverPath + fileName;
                file.SaveAs(filePath);

                var instance = Mapper.Map<SoapUploadViewModel, Soap>(model);
                instance.Id = Guid.NewGuid().ToString("N").Substring(0, 15);
                instance.UploadTime = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
                instance.ImageUrl = "/Upload/Soap/" + fileName;
                repository.Create(instance);
                return instance;
            }        
          
            return null;
                
        }
    }
}