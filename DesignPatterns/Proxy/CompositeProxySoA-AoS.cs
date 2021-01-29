using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Proxy
{
    class Creature2
    {
        public byte Age;
        public int X, Y;
    }

    class Creatures
    {
        private readonly int size;
        private byte[] age;
        private int[] x, y;

        public Creatures(int size)
        {
            this.size = size;
            age = new byte[size];
            x = new int[size];
            y = new int[size];
        }

        public struct CreatureProxy
        {
            private readonly Creatures creatures;
            private readonly int index;

            public CreatureProxy(Creatures cretures, int index)
            {
                this.creatures = cretures;
                this.index = index;
            }

            public ref byte Age => ref creatures.age[index];
            public ref byte X => ref creatures.age[index];
            public ref byte Y => ref creatures.age[index];
        }

        public IEnumerator<CreatureProxy> GetEnumerator()
        {
            for (int pos = 0;pos < size; ++pos)
            {
                yield return new CreatureProxy(this, pos);
            }
        }
    }
}
