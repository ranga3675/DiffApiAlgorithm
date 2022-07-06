using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiffApi.Models
{
    public class Diff
    {
		private string id;
		
		private string left;
	
		private string right;
	
		public Diff(string id, string left, string right)
		{
			this.id = id;
			this.left = left;
			this.right = right;
		}
		
		public Diff()
		{
		}

		public string getId()
		{
			return id;
		}
	
		public void setId(string id)
		{
			this.id = id;
		}

		public string getLeft()
		{
			return left;
		}
	
		public void setLeft(string left)
		{
			this.left = left;
		}

		public string getRight()
		{
			return right;
		}

		public void setRight(string right)
		{
			this.right = right;
		}
	}
}
