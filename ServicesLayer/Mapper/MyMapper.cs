using AutoMapper;
using DataAccessLayer.Models;
using ServicesLayer.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Mapper
{
    public  class MyMapper:Profile
    {
        public MyMapper()
        {
            CreateMap<Users, UserRequestDTO>().ReverseMap();
            CreateMap<Products, ProductRequestDTO>().ReverseMap();
            CreateMap<Products,ProductReturnerDTO>().ReverseMap();

        }
    }
}
