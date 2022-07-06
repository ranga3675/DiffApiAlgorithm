using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Models
{
    public class ByteDiff
    {
	
		private int byteIndex;
	
		private int numberOfDifferentBits;

		public ByteDiff()
		{
		}

		public ByteDiff(int byteIndex, int numberOfDifferentBits)
		{	
			this.byteIndex = byteIndex;
			this.numberOfDifferentBits = numberOfDifferentBits;
		}
	
		public int getByteIndex()
		{
			return byteIndex;
		}

		public void setByteIndex(int byteIndex)
		{
			this.byteIndex = byteIndex;
		}

		public int getNumberOfDifferentBits()
		{
			return numberOfDifferentBits;
		}

		public void setNumberOfDifferentBits(int numberOfDifferentBits)
		{
			this.numberOfDifferentBits = numberOfDifferentBits;
		}
	}
}
