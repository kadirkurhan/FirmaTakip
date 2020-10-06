using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Interfaces
{
    public interface IGenericRepository<T> where T:class,new()
    {
        public void Add(T tablo);
        public void Update(T tablo);
        public void Delete(T tablo);
        public List<T> GetAll();
        public T GetwithId(int id);

    }
}
