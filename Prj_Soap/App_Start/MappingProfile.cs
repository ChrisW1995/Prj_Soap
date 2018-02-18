using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Prj_Soap.Models;
using Prj_Soap.Models.DTO;
using Prj_Soap.Models.ViewModels;
using Prj_Soap.Areas.Admin.Models;

namespace Prj_Soap.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<News, CreateNewsDTO>();
            CreateMap<CreateNewsDTO, News>();

            CreateMap<RegisterViewModel, Customers>();
            CreateMap<Customers, RegisterViewModel>();

            CreateMap<SoapUploadViewModel, Soap>();
            CreateMap<Soap, SoapUploadViewModel>();

            CreateMap<SoapWithFormattedDate, Soap>();
            CreateMap<Soap, SoapWithFormattedDate>();

            CreateMap<NewestSoapViewModel, Soap>();
            CreateMap<Soap, NewestSoapViewModel>();
        }
    }
}