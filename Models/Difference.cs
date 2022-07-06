using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Models
{
    public class Difference
    {
     
            public int Offset { get; set; }
    
            public int Length { get; set; }

            public Difference(int offset, int length)
            {
                this.Offset = offset;
                this.Length = length;
            }
        
    }
}
