using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Helpers.Validation
{
    public interface IResourceItem
    {
        string Key { get; set; }

        string Message { get; set; }
        
        IList<string> Params { get; set; }
    }
}
