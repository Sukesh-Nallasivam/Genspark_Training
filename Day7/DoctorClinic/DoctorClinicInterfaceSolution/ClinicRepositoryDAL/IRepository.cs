using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDALLibrary
{
    public interface IRepository<Key,Class> where Class : class
    {
        List<Class> GetAll();
        Class Get(Key key);
        Class Add(Class item);
        Class Update(Class item);
        Class Delete(int key);
    }
}
