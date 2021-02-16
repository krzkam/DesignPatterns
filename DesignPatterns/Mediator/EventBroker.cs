using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Autofac;


namespace DesignPatterns.Mediator
{

    public class Actor
    {
        protected EventBroker broker;

        public Actor(EventBroker broker)
        {
            this.broker = broker ?? throw new ArgumentNullException(nameof(broker));
        }
    }

    public class FootbalPlayer : Actor
    {
        public FootbalPlayer(EventBroker broker, string name) : base(broker)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            broker.OfType<PlayerScoredEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(
                    ps => Console.WriteLine($"{name}: Nicely done, {ps.Name}! It's your {ps.GoalsScored}")
                );

            broker.OfType<PlayerSentOffEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(
                    ps => Console.WriteLine($"{name}: see you {ps.Name}")
                );
        }

        public string Name { get; set; }
        public int GoalsScored { get; set; } = 0;

        public void Score()
        {
            GoalsScored++;
            broker.Publish(new PlayerScoredEvent { Name = Name, GoalsScored = GoalsScored });
        }

        public void AssautlReferee()
        {
            broker.Publish(new PlayerSentOffEvent { Name = Name, Reason = "violence" });
        }
    }

    public class FootbalCoach : Actor
    {
        public FootbalCoach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>()
                .Subscribe(pe =>
                {
                    if (pe.GoalsScored<3)
                        Console.WriteLine($"Coach: well done, {pe.Name}!");
                });
            broker.OfType<PlayerSentOffEvent>()
                .Subscribe(pe =>
                {
                    if (pe.Reason == "violence")
                        Console.WriteLine($"Coach: how could you, {pe.Name}!");
                });
        }
    }

    public class PlayerEvent
    {
        public string Name { get; set; }
    }

    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }

    public class EventBroker : IObservable<PlayerEvent>
    {
        private Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();

        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
            return  subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent pe)
        {
            subscriptions.OnNext(pe);
        }
    }

    public class PlayerSentOffEvent : PlayerEvent
    {
        public string Reason { get; set; }
    }
}
