using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Torito.Models.Twitter;

namespace Torito.Models.Utils.Comparers
{
    public class TweetEqualityComparerById : IEqualityComparer<Tweet>
    {
        public bool Equals(Tweet x, Tweet y)
        {
            if (x is null && y is null)
            {
                return true;
            }
            else if (x is null || y is null)
            {
                return false;
            }
            return (x.Id == y.Id);                
        }

        public int GetHashCode([DisallowNull] Tweet obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
