using DiffApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Services
{
    public class DataService: IDataService
    {
        public DataService(IHomeService homeService)
        {
            Home = homeService;
        }

        public IHomeService Home { get; }
    }
}
