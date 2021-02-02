using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibility
{
    public class Game
    {
        public event EventHandler<Query> Queries;

        public void PerformQuery(object sender, Query q)
        {
            Queries?.Invoke(sender, q);
        }
    }

    public class Creature2
    {
        private Game game;
        public string Name;
        private int attack, defense;

        public Creature2(Game game, string name, int attack, int defense)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.attack = attack;
            this.defense = defense;
        }

        public int Attack
        {
            get
            {
                var q = new Query(Name, Query.Argument.Attack, attack);
                game.PerformQuery(this, q); //q.Value
                return q.Value;
            }
        }

        public int Defense
        {
            get
            {
                var q = new Query(Name, Query.Argument.Defense, defense);
                game.PerformQuery(this, q); //q.Value
                return q.Value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
        }
    }

    public class Query
    {
        public string CreatureName;

        public enum Argument
        {
            Attack, Defense
        }

        public Argument WhatToQuery;

        public int Value;

        public Query(string creatureName, Argument whatToQuery, int value)
        {
            CreatureName = creatureName ?? throw new ArgumentNullException(nameof(creatureName));
            WhatToQuery = whatToQuery;
            Value = value;
        }
    }

    public abstract class CreatureModifier2 : IDisposable
    {
        protected Game game;
        protected Creature2 creature;

        protected CreatureModifier2(Game game, Creature2 creature)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.creature = creature ?? throw new ArgumentNullException(nameof(creature));

            game.Queries += Handle;
        }

        protected abstract void Handle(object sender, Query q);

        public void Dispose()
        {
            game.Queries -= Handle;
        }
    }

    public class DoubleAttackModifier2 : CreatureModifier2
    {
        public DoubleAttackModifier2(Game game, Creature2 creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
            if (q.CreatureName == creature.Name
                && q.WhatToQuery == Query.Argument.Attack)
            {
                q.Value *= 2;
            }
        }
    }

    public class IncreaseDefenseModifier : CreatureModifier2
    {
        public IncreaseDefenseModifier(Game game, Creature2 creature) : base(game, creature)
        {
        }

        protected override void Handle(object sender, Query q)
        {
            if (q.CreatureName == creature.Name
                && q.WhatToQuery == Query.Argument.Defense)
            {
                q.Value += 2;
            }
        }
    }

}
