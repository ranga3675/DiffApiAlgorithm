using DiffApi.Interfaces;
using DiffApi.Models;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffApi.Services
{
    public class Home: IHomeService
    {
		//Declaration of Collection to store data in memory
        private static List<Diff> diffs = new List<Diff>();

		//Method to add leftside values
		public async Task<bool> AddLeft(string id, string left)
		{
			Diff d = GetDiff(id);
			if (d != null)
			{			
				d.setLeft(left);
			}
			else
			{				
				d = new Diff(id, left, "");
				diffs.Add(d);
			}
			return true;
		}

		//Method to add right side values
		public async Task<bool> AddRight(string id, string right)
		{
			Diff d = GetDiff(id);
			if (d != null)
			{			
				d.setRight(right);
			}
			else
			{		
				d = new Diff(id, "", right);
				diffs.Add(d);
			}
			return true;
		}

		private Diff GetDiff(string id)
		{
			for (int i = 0; i < diffs.Count; i++)
			{
				Diff d = diffs[i];
				if (d.getId().Equals(id))
				{					
					return d;
				}
			}		
			return null;
		}

		//Method to compare the right and left side values
		public async Task<DiffResult> GetData(string id)
		{	

			Diff d = GetDiff(id);
			bool equals = false;
			bool equalSize = false;
			List<ByteDiff> differences = new List<ByteDiff>();

			if (d != null)
			{

				byte[] firstBytes = Convert.FromBase64String(d.getLeft());
				byte[] secondBytes = Convert.FromBase64String(d.getRight());

				var data1 = Encoding.UTF8.GetString(firstBytes);
				var data2 = Encoding.UTF8.GetString(secondBytes);

				//Verify if data have same size.
				equalSize = firstBytes.Length == secondBytes.Length;

				if (equalSize)
				{
					//Data have same size, maybe they are equal.
					equals = Enumerable.SequenceEqual(firstBytes, secondBytes);
				}

				//If not equals, but data have same size,
				//provide insight in where the diffs are.
				if (!equals && equalSize)
				{
					byte different = 0;
					
					for (int index = 0; index < firstBytes.Length; index++)
					{
						int totalDiffBits = 0;
						different = (byte)(firstBytes[index] ^ secondBytes[index]);
						if (different != 0)
						{
							while (different != 0)
							{
								totalDiffBits++;
								different &= (byte)(different - 1);
							}
							differences.Add(new ByteDiff(index, totalDiffBits));
						}
					}
				}
			}	

			return new DiffResult(id, equals, equalSize, differences);
		
		}

	}
}
