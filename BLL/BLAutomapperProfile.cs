using AutoMapper;
using BLL.ModelBL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLAutomapperProfile : Profile
    {
        public BLAutomapperProfile()
        {
            CreateMap<TopicBL, Topic>().ReverseMap();
            CreateMap<PeriodicalBL, Periodical>().ForMember(x => x.Topic, y => y.MapFrom(x => x.Topic)).ReverseMap();
        }
    }
}
