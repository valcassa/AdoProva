using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoProva
{
    interface IDBManager<T>
    {
        public List<T> Fetch();
        public T Get();
        public void Insert(T);
        public void Delete(T);

        public void Update(T);

    }
}
