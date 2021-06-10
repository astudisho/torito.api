using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClient.Utils
{
    public static class Constants
    {
        public static class GMaps
        {
        }

        public static class Twitter
        {
            private static Func<string, string, string> AggregateOr = (x, y) => $"{x} OR {y}";
            private static readonly string[] ToritoIcons = {"🍷", "🍸", "🍹", "🍺", "🍻" ,"🍾", "🚔", "👮","🚓"};
            private static readonly string[] ToritoHashTags = { "#Toritojalisco", "#AlcoholimetroGDL", "#ToritoGDL", "#AntiToritoGDL", "#CurvaGDL" };
            public static readonly string ToritoQuery = $"from:damplin ({ToritoIcons.Aggregate((x,y) => x + y)}) OR ({ToritoHashTags.Aggregate(AggregateOr)})";
        }
    }
}
