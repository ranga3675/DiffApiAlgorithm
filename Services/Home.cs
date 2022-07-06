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
    public class Home : IHomeService
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
            return await Task.Run(() => true);
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
            return await Task.Run(() => true);
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
            var differences = new List<Difference>();
            bool hasBothData = false;
            if (d != null)
            {

                byte[] firstBytes = Convert.FromBase64String(d.getLeft());
                byte[] secondBytes = Convert.FromBase64String(d.getRight());

                var leftData = Encoding.UTF8.GetString(firstBytes);
                var rightData = Encoding.UTF8.GetString(secondBytes);

                equalSize = firstBytes.Length == secondBytes.Length;

                if(!string.IsNullOrWhiteSpace(leftData) && !string.IsNullOrWhiteSpace(rightData))
                {
                    hasBothData = true;
                }

                if (equalSize)
                {
                    equals = Enumerable.SequenceEqual(firstBytes, secondBytes);
                }


                if (!equals && equalSize)
                {
                    var offset = 0;
                    var length = 0;
                    var left = leftData;
                    var right = rightData;
                    for (var index = 0; index < left.Length; index++)
                    {
                        var areEqualChars = left[index] == right[index];
                        var isLengthZero = length == 0;

                        if (areEqualChars && isLengthZero) continue;

                        if (!areEqualChars && isLengthZero)
                        {
                            offset = index;
                            length++;
                        }

                        else if (!areEqualChars && !isLengthZero)
                        {
                            length++;
                        }

                        else
                        {
                            differences.Add(new Difference(offset, length));
                            offset = 0;
                            length = 0;
                        }
                    }
                    //if there is a pending difference, because the different is at the end of the strings
                    if (length > 0) differences.Add(new Difference(offset, length));

                    //byte different = 0;
                    //for (int index = 0; index < firstBytes.Length; index++)
                    //{
                    //	int totalDiffBits = 0;
                    //	different = (byte)(firstBytes[index] ^ secondBytes[index]);
                    //	if (different != 0)
                    //	{
                    //		while (different != 0)
                    //		{
                    //			totalDiffBits++;
                    //			different &= (byte)(different - 1);
                    //		}
                    //		differences.Add(new ByteDiff(index, totalDiffBits));
                    //	}
                    //}
                }
            }

            return await Task.Run(() => new DiffResult(id, equals, equalSize, differences, hasBothData));

        }
    }
}
