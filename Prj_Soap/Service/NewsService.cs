using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Prj_Soap.Interface;
using Prj_Soap.Models;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Repository;

namespace Prj_Soap.Service
{
    public class NewsService
    {
        IRepository<News> repository = new GenericRepository<News>(new ApplicationDbContext());

        public IResult CreateNews(News news)
        {
            IResult result = new Result();
            try
            {
                LocalDateTimeService timeService = new LocalDateTimeService();
                news.AddTime = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
                repository.Create(news);

                result.Success = true;
                return result;
            }
            catch (Exception e)
            {
                result.Message = e.ToString();
                return result;
            }
        }

        public IResult UpdateNews(UpdateNewsViewModel vm)
        {
            IResult result = new Result();
            try
            {              
                var instance = repository.Get(i => i.Id == vm.Id);
                instance.Title = vm.Title;
                instance.Content = vm.Content;
                repository.Update(instance);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.ToString();
                throw;
            }

            return result;
        }
        public IEnumerable<NewsListViewModel> GetNewsList()
        {
            var list = repository.GetList().ToList().Select(Mapper.Map<News, NewsListViewModel>).OrderByDescending(t => t.AddTime);
            return list;
        }

        public News GetNews(int id)
        {
            return repository.Get(i => i.Id == id);
        }
    }
}