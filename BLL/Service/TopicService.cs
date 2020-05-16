using AutoMapper;
using BLL.Interface;
using BLL.ModelBL;
using DAL.Entity;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class TopicService : GenericService<TopicBL, Topic>, ITopicService
    {
        private readonly IMapper _mapper;
        public TopicService(IGenericRepository<Topic> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override TopicBL Map(Topic model)
        {
            return _mapper.Map<TopicBL>(model);
        }
        public override Topic Map(TopicBL model)
        {
            return _mapper.Map<Topic>(model);
        }
        public override IEnumerable<TopicBL> Map(IList<Topic> entitiesList)
        {
            return _mapper.Map<IEnumerable<TopicBL>>(entitiesList);
        }
        public override IEnumerable<Topic> Map(IList<TopicBL> entitiesList)
        {
            return _mapper.Map<IEnumerable<Topic>>(entitiesList);
        }
    }
}
