using DiffApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Interfaces
{
    public interface IHomeService
    {
        Task<bool> AddRight(string id, string base64Data);

        Task<bool> AddLeft(string id, string base64Data);

        Task<DiffResult> GetData(string id);
    }
}
