using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
    public interface IValueContainer
    {

        IEnumerator<IValueContainer> GetEnumerator();
        int GetValue();
    }

    public class SingleValue : IValueContainer
    {
        public int Value;

        public IEnumerator<IValueContainer> GetEnumerator()
        {
            yield return this;
        }

        public int GetValue()
        {
            return Value;
        }
    }

    //public class ManyValues : List<int>, IValueContainer
    //{

    //}

    public static class ExtensionMethods2
    {
        public static int Sum(this List<IValueContainer> containers)
        {

            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i.GetValue();
            return result;
        }
    }
}
