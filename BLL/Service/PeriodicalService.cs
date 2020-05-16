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
    public class PeriodicalService : GenericService<PeriodicalBL, Periodical>, IPeriodicalService
    {
        private readonly IMapper _mapper;
        public PeriodicalService(IGenericRepository<Periodical> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override PeriodicalBL Map(Periodical model)
        {
            return _mapper.Map<PeriodicalBL>(model);
        }
        public override Periodical Map(PeriodicalBL model)
        {
            return _mapper.Map<Periodical>(model);
        }
        public override IEnumerable<PeriodicalBL> Map(IList<Periodical> entitiesList)
        {
            return _mapper.Map<IEnumerable<PeriodicalBL>>(entitiesList);
        }
        public override IEnumerable<Periodical> Map(IList<PeriodicalBL> entitiesList)
        {
            return _mapper.Map<IEnumerable<Periodical>>(entitiesList);
        }
    }
}
