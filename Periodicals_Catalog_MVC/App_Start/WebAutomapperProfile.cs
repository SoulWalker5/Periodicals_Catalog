using AutoMapper;
using BLL.ModelBL;
using Periodicals_Catalog_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Periodicals_Catalog_MVC.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<TopicModel, TopicBL>().ReverseMap();
            CreateMap<PeriodicalModel, PeriodicalBL>().ForMember(x => x.Topic, y => y.MapFrom(x => x.Topic)).ReverseMap();
            CreateMap<CommentModel, CommentBL>().ForMember(x => x.Periodical, y => y.MapFrom(x => x.Periodical)).ReverseMap();
        }
    }
}