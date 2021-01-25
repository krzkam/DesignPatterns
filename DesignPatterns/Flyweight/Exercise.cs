using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Flyweight
{
    public class Sentence
    {
        private List<WordToken> Words = new List<WordToken>();
        public Sentence(string plainText)
        {
            foreach (var word in plainText.Split(' '))
            {
                Words.Add(new WordToken(word));
            }
        }

        public WordToken this[int index]
        {
            get
            {
                return Words[index];
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Words[0]);
            for (int i = 1; i < Words.Count; i++)
            {
                sb.Append(" ").Append(Words[i]);
            }
            return sb.ToString();
        }

        public class WordToken
        {
            public string Word;
            public bool Capitalize;

            public WordToken(string word)
            {
                Word = word;
            }

            public override string ToString()
            {
                if (Capitalize == true)
                {
                    return Word.ToUpper();

                }
                return Word;
            }
        }
    }
}
