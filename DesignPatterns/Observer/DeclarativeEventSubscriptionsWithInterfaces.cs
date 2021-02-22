using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public interface IEvent { }

    public interface ISend<TEvent> where TEvent : IEvent
    {
        event EventHandler<TEvent> Sender;
    }

    public interface IHandle<TEvent> where TEvent : IEvent
    {
        void Handle(object sender, TEvent args);
    }

    public class ButtonPressedEvent : IEvent
    {
        public int NumberOfClicks;
    }

    public class Button3 : ISend<ButtonPressedEvent>
    {
        public event EventHandler<ButtonPressedEvent> Sender;

        public void Fire(int clicks)
        {
            Sender?.Invoke(this, new ButtonPressedEvent
            {
                NumberOfClicks = clicks
            });
        }
    }

    public class Logging : IHandle<ButtonPressedEvent>
    {
        public void Handle(object sender, ButtonPressedEvent args)
        {
            Console.WriteLine(
              $"Button clicked {args.NumberOfClicks} times");
        }
    }
}
