using AutoMapper;
using BLL;
using BLL.Interface;
using BLL.Service;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Periodicals_Catalog_MVC.App_Start
{
    public class LightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLightInjectConfiguration.Configuration(container);

            container.Register<ICommentService, CommentService>();
            container.Register<IPeriodicalService, PeriodicalService>();
            container.Register<ITopicService, TopicService>();

            container.EnableMvc();
        }
    }
}