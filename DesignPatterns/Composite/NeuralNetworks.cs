using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Composite
{
    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;
            foreach (var from in self)
                foreach (var to in other)
                {
                        from.Out.Add(to);
                        to.In.Add(from);
                }
    
        }
    }
    public class Neuron : IEnumerable<Neuron>
    {
        public float Value;
        public List<Neuron> In, Out;

        //public void ConnectTo(Neuron other)
        //{
        //    Out.Add(other);
        //    other.In.Add(this);
        //}

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {

    }
}
