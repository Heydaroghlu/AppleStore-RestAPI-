using Apple.Core.Entities;
using Apple.Service.DTOs.CategoryDTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple.Service.AppProfiles
{
    public class AppProfile:Profile
    {
        public AppProfile()
        {
            CreateMap<Category, CategoryGetDTO>();
        }
    }
}
