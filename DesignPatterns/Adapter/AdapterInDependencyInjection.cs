using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Adapter
{
    public interface ICommand
    {
        void Execute();
    }

    class SaveCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Saving a file");
        }
    }

    class OpenCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Opening a file");
        }
    }

    public class Button
    {
        private ICommand command;
        private string name;

        public Button(ICommand command, string name)
        {
            if (command == null)
            {
                throw new ArgumentNullException(paramName: nameof(command));
            }
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            this.command = command;
            this.name = name;
        }
        public void Click()
        {
            command.Execute();
        }
        public void PrintMe()
        {
            Console.WriteLine($"Im a button called {name}");
        }
    }

    public class Editor
    {
        private IEnumerable<Button> buttons;
        public IEnumerable<Button> Buttons
        {
            get
            {
                return buttons;
            }
        }

        public Editor(IEnumerable<Button> buttons)
        {
            if (buttons == null)
            {
                throw new ArgumentNullException(paramName: nameof(buttons));
            }
            this.buttons = buttons;
        }

        public void ClickAll()
        {
            foreach (var btn in buttons)
            {
                btn.Click();
            }
        }
    }
}
