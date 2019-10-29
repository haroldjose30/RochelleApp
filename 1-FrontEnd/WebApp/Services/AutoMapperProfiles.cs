using System;
using AutoMapper;
using Domain.Generals;
using WebApp.Models;

namespace WebApp.Services
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();
        }
    }
}
