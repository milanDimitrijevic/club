using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clubv1._3.Domain.Interfaces
{
    public interface IService
    {
        void GetAll();
        void GetById(Guid id);
        void UpdateById(Guid id);
        void DeleteById(Guid id);
    }
}
