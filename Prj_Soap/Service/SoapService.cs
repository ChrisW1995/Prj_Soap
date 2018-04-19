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
        IRepository<Category> categoryRepo = new GenericRepository<Category>(new ApplicationDbContext());
        LocalDateTimeService timeService = new LocalDateTimeService();
        ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Back end get all product
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public AdminSoapListViewModel GetList(int page)
        {
            var list = repository.GetList(x => x.Flg == true).OrderByDescending(x => x.UploadTime).ToList().Skip(3 * (page - 1)).Take(3).Select(Mapper.Map<Soap, SoapWithFormattedDate>);
            var total = list.Count();
            var soapListViewModel = new AdminSoapListViewModel
            {
                Soaps = list,
                Total = total
            };
            return soapListViewModel;
        }

        public Soap GetSoap(string id)
        {
            return repository.Get(x => x.Id == id);
        }

        public IEnumerable<SoapListViewModel> GetList()
        {
            var list = repository.GetList(x => x.Flg == true).OrderByDescending(x => x.UploadTime).ToList().Select(Mapper.Map<Soap, SoapListViewModel>);

            return list;
        }

        public IEnumerable<SoapListViewModel> GetNewest4Items()
        {
            var list = repository.GetList(x => x.Flg == true).OrderByDescending(x => x.UploadTime).ToList().Take(4).Select(Mapper.Map<Soap, SoapListViewModel>);

            return list;
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IResult Delete(string id)
        {
            IResult result = new Result();
            try
            {
                var instance = repository.Get(x => x.Id == id);
                instance.Flg = false;
                repository.Update(instance);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.ToString();
            }
            return result;
        }

        public IResult Edit(SoapUploadViewModel model)
        {
            IResult result = new Result();
            try
            {
                var instance = GetSoap(model.Id);
                var imageUrl = "";
                var file = model.ImageFile;
                if (file != null) //there is no new image
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var savePath = HttpContext.Current.Server.MapPath("/Upload/Soap/") + fileName;
                    file.SaveAs(savePath);
                    imageUrl = "/Upload/Soap/" + fileName;
                }
                else
                {
                    imageUrl = instance.ImageUrl;
                }
                Mapper.Map(model, instance);
                instance.ImageUrl = imageUrl;
                repository.Update(instance);
                result.Success = true;

            }
            catch (Exception e)
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
                instance.Flg = true;
                instance.ImageUrl = "/Upload/Soap/" + fileName;
                repository.Create(instance);
                return instance;
            }

            return null;

        }


        public Category AddCategory(string name)
        {
            var instance = new Category();
            try
            {
                instance.CategoryName = name;
                categoryRepo.Create(instance);
            }
            catch (Exception)
            {
               
                throw;
            }
            return instance;
        }

        public IResult DelCategory(int id)
        {
            IResult result = new Result();
            try
            {
                var soapList = repository.GetList(x => x.CategoryId == id).ToList();
                soapList.ForEach(x => x.CategoryId = 0);
                db.SaveChanges();
                var instance = categoryRepo.Get(x => x.Id == id);
                categoryRepo.Delete(instance);
                result.Success = true;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public IEnumerable<Category> GetCategories()
        {
            return categoryRepo.GetList().ToList();
        }
        
    }

}