using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Servises
{
    public interface ITwoIdServise<T>
    {
        IEnumerable<T> GetList();
        T Get(int id);
        void Create(T t);
        void Delete(int id);
        void Update(T t);
    }
}
