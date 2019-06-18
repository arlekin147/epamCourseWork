using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Repositories
{
    public interface ITwoKeysRepository<T>
    {
        IEnumerable<T> GetList();
        T Get(int firstId, int secondId);
        IEnumerable<T> GetAllByFirstId(int firstId);
        IEnumerable<T> GetAllBySecondId(int secondId);
        void Create(T item);
        void Update(T item);
        void Delete(int firstId, int secondId);
    }
}
