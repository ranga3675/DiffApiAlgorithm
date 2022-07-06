using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Models
{
    public class EncodedBase64Data
    {
		public string base64Data;
	
		public EncodedBase64Data()
		{
		}

		public EncodedBase64Data(string base64Data)
		{
			this.base64Data = base64Data;
		}

		public string getBase64Data()
		{
			return base64Data;
		}

		public void setBase64Data(string base64Data)
		{
			this.base64Data = base64Data;
		}
	}
}
