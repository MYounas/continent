﻿using AutoMapper;
using continent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace continent.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<country, countryViewModel>();
            Mapper.CreateMap<countryViewModel, country>();
            Mapper.CreateMap<city, cityViewModel>();
            Mapper.CreateMap<cityViewModel, city>();
            Mapper.CreateMap<area, areaViewModel>();
            Mapper.CreateMap<areaViewModel, area>();
        }
    }
}