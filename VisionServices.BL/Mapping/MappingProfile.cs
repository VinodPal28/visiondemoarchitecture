using AutoMapper;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionServices.Data;

namespace VisionServices.BL.Mapping
{
    public class MappingProfile : Profile
    {


        public MappingProfile()
        {
            CreateMap<List<BookDetail>, List<BookDTO>>();
        }

    }
}
