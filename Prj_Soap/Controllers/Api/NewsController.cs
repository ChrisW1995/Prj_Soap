using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prj_Soap.Models.DTO;
using AutoMapper;
using Prj_Soap.Service;
using Prj_Soap.Models;

namespace Prj_Soap.Controllers.Api
{
    public class NewsController : ApiController
    {
        LocalDateTimeService timeService = new LocalDateTimeService();
        NewsService newsService = new NewsService();

        public IHttpActionResult GetNews(string id)
        {
            var news = newsService.GetNews(id);
            if (news != null)
                return Ok(news);
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Create(CreateNewsDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var instance = Mapper.Map<CreateNewsDTO, News>(dto);
            instance.AddTime = timeService.GetLocalDateTime(LocalDateTimeService.CHINA_STANDARD_TIME);
            var result = newsService.CreateNews(instance);
            if (!result.Success)
                return BadRequest(result.Message.ToString());
            return Created(new Uri(Request.RequestUri + "/" + instance.Id), instance);
        }
    }
}
