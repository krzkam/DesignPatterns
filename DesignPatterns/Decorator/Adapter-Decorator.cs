using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class MyStringBuilder
    {
        private StringBuilder sb = new StringBuilder();
        public static implicit operator MyStringBuilder(string s)
        {
            var msb = new MyStringBuilder();
            msb.sb.Append(s);
            return msb;
        }

        public static MyStringBuilder operator +(MyStringBuilder msb, string s)
        {
            msb.sb.Append(s);
            return msb;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
