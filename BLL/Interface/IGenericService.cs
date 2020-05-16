using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IGenericService<BLModel> where BLModel : class
    {
        BLModel FindById(int id);
        IEnumerable<BLModel> GetAll();
        void Create(BLModel item);
        void Update(BLModel item);
        void Remove(int id);
    }
}
