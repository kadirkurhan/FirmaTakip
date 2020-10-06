using FirmaTakip.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaTakip.Repositories
{
     public class GenericRepository<T> where T : class, new()
        {
            public void Add(T tablo)
            {
                using var context = new FirmaTakipContext();
                context.Set<T>().Add(tablo);
                context.SaveChanges();
            }
            public void Update(T tablo)
            {
                using var context = new FirmaTakipContext();
                context.Set<T>().Update(tablo);
                context.SaveChanges();
            }
            public void Delete(T tablo)
            {
                using var context = new FirmaTakipContext();
                context.Set<T>().Remove(tablo);
                context.SaveChanges();
            }
            public List<T> GetAll()
            {
                using var context = new FirmaTakipContext();
                return context.Set<T>().ToList();
            }
            public T GetwithId(int id)
            {
                using var context = new FirmaTakipContext();
                return context.Set<T>().Find(id);
            }
      }
}

