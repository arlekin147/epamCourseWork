using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Servises
{
    public interface ITwoIdService<T>
    {
        IEnumerable<T> GetList();
        T Get(int firstId, int secondId);
        IEnumerable<T> GetAllByFirstId(int firstId);
        IEnumerable<T> GetAllBySecondId(int secondId);
        void Create(T t);
        void Delete(int firstId, int secondId);
        void Update(T t);
    }
}
