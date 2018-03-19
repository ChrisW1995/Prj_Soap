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

            CreateMap<EditProfileViewModel, Customers>();
            CreateMap<Customers, EditProfileViewModel>();

            CreateMap<EditAccountViewModel, Customers>();
            CreateMap<Customers, EditAccountViewModel>();

            CreateMap<SoapUploadViewModel, Soap>();
            CreateMap<Soap, SoapUploadViewModel>();

            CreateMap<SoapWithFormattedDate, Soap>();
            CreateMap<Soap, SoapWithFormattedDate>();

            CreateMap<SoapListViewModel, Soap>();
            CreateMap<Soap, SoapListViewModel>();

            CreateMap<AdminSoapListViewModel, Soap>();
            CreateMap<Soap, AdminSoapListViewModel>();
        }
    }
}