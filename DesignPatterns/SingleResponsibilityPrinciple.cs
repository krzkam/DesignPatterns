using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DesignPatterns
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }
    //Whole point of Single Responsibility Principle is that one, typical class is responsible for one thing and has one reason to change. 
    //Don't put all responsibility to one class
    class SingleResponsibilityPrinciple 
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Entry 1");
            j.AddEntry("Entry 2");
            Console.WriteLine(j);

            //var p = new Persistence();
            //var filename = @"c:\temp\journal.txt";
            //p.SaveToFile(j, filename, true);
            //Process.Start(filename);

            Console.ReadKey();
        }
    }
}
