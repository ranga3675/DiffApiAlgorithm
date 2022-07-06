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

		public bool hasBothdata;
		
		public List<Difference> differences;

		public DiffResult()
		{
		}

		public DiffResult(string id, bool equals, bool equalSize, List<Difference> differences, bool hasBothdata)
		{		
			this.id = id;
			this.equals = equals;
			this.equalSize = equalSize;
			this.differences = differences;
			this.hasBothdata = hasBothdata;
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

		public bool isHasBothData()
		{
			return hasBothdata;
		}


		public void setHasBothData(bool hasBothdata)
		{
			this.hasBothdata = hasBothdata;
		}

		public List<Difference> getDifferences()
		{
			return differences;
		}

		public void setDifferences(List<Difference> differences)
		{
			this.differences = differences;
		}
	}
}
