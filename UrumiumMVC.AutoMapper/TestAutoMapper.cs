using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.AutoMapper
{
    public class TestAutoMapper:Profile
    {
        public TestAutoMapper()
        {
            //CreateMap<City, CityViewModel>().ForMember(d => d.Name, m => m.MapFrom(s => s.Id.ToString() + " " + s.Name.ToString()));
        }
    }
}
