using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Models
{
    public class DiffResult
    {	
		public string id;
		
		public bool equals;
	
		public bool equalSize;
		
		public List<ByteDiff> differences;

		public DiffResult()
		{
		}

		public DiffResult(string id, bool equals, bool equalSize, List<ByteDiff> differences)
		{		
			this.id = id;
			this.equals = equals;
			this.equalSize = equalSize;
			this.differences = differences;
		}

		public string getId()
		{
			return id;
		}

		public void setId(string id)
		{
			this.id = id;
		}

		public bool isEquals()
		{
			return equals;
		}

		public void setEquals(bool equals)
		{
			this.equals = equals;
		}

		public bool isEqualSize()
		{
			return equalSize;
		}


		public void setEqualSize(bool equalSize)
		{
			this.equalSize = equalSize;
		}

		public List<ByteDiff> getDifferences()
		{
			return differences;
		}

		public void setDifferences(List<ByteDiff> differences)
		{
			this.differences = differences;
		}
	}
}
