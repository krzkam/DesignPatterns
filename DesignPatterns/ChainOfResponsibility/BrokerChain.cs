using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibility
{
    public class Creature2
    {
        public string Name;
        public int Attack, Defense;

        public Creature2(string name, int attack, int defense)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Attack = attack;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }


    }

    public class CreatureModifier2
    {
        protected Creature2 creature;
        protected CreatureModifier2 next; // linked list

        public CreatureModifier2(Creature2 creature)
        {
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));
        }

        public void Add(CreatureModifier2 cm)
        {
            if (next != null) next.Add(cm);
            else next = cm;
        }

        public virtual void Handle()
        {
            //next?.Handle();
            if (next != null) next.Handle();
        }
    }

    public class DoubleAttackModifier2 : CreatureModifier2
    {
        public DoubleAttackModifier2(Creature2 creature) : base(creature)
        {

        }

        public override void Handle()
        {
            Console.WriteLine($"Doubling {creature.Name}'s attack");
            creature.Attack *= 2;
            base.Handle();
        }
    }

    public class IncreasedDefenseModifier2 : CreatureModifier2
    {
        public IncreasedDefenseModifier2(Creature2 creature) : base(creature)
        {
        }

        public override void Handle()
        {
            Console.WriteLine($"Increasing {creature.Name}'s defense");
            creature.Defense += 3;
            base.Handle();
        }
    }

    public class NoBonusesModifier2 : CreatureModifier2
    {
        public NoBonusesModifier2(Creature2 creature) : base(creature)
        {
        }

        public override void Handle()
        {
            //
        }
    }
}
