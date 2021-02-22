using System;
 
using System.Threading;
using System.Windows;
 

namespace DesignPatterns.Observer
{
    public class Button
    {
        public event EventHandler Cliked;
        public void Fire()
        {
            Cliked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            //button.Cliked += ButtonOnCliked;
            WeakEventManager<Button, EventArgs>
                .AddHandler(button,"Clicked", ButtonOnClicked);
        }

        private void ButtonOnClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked (window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }
 
}
