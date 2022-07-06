using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Interfaces
{
    public interface IDataService
    {
        IHomeService Home { get; }
    }
}
