using AutoMapper;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Mapper.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personel, PersonelDTO>();
            CreateMap<PersonelDTO, Personel>();
        }
    }
}
