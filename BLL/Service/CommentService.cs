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
    public class CommentService : GenericService<CommentBL, Comment>, ICommentService
    {
        private readonly IMapper _mapper;
        public CommentService(IGenericRepository<Comment> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public override CommentBL Map(Comment model)
        {
            return _mapper.Map<CommentBL>(model);
        }
        public override Comment Map(CommentBL model)
        {
            return _mapper.Map<Comment>(model);
        }
        public override IEnumerable<CommentBL> Map(IList<Comment> entitiesList)
        {
            return _mapper.Map<IEnumerable<CommentBL>>(entitiesList);
        }
        public override IEnumerable<Comment> Map(IList<CommentBL> entitiesList)
        {
            return _mapper.Map<IEnumerable<Comment>>(entitiesList);
        }
    }
}
