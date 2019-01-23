using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Repository
{
    public interface IStudent<T>
    {
        List<T> GetAll();
    }
}
