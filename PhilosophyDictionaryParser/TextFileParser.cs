using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhilosophyDictionaryParser
{
    public class TextFileParser
    {
        public Dictionary<string, string> DictionaryPhilosophy { get; set; }
        private string pathToFile = @"DictionaryResourse.txt";

        public TextFileParser()
        {
            ParseDictionaryContent();
        }
        private string[] DictionaryContent()
        {
            string[] textInFile = File.ReadAllLines(pathToFile);
            return textInFile;
        }

        private void ParseDictionaryContent()
        {
            string[] dictContent = DictionaryContent();
            string Definition = "";
            string Explanation = "";
            foreach (var newLine in dictContent)
            {
                if (newLine.Contains(" "))
                {
                    var firstWord = newLine.Substring(0, newLine.IndexOf(" "));
                    if (firstWord.All(char.IsUpper) && firstWord.Length > 1)
                    {
                        Definition = newLine.Substring(0, newLine.IndexOf("—")).Trim();
                        Explanation = newLine.Substring(newLine.IndexOf("—") + 2, newLine.Length - 1 - (newLine.IndexOf("—") + 2)).Trim();
                    }
                    else { Explanation = Explanation + newLine; }
                }
                else { Explanation = Explanation + newLine; }
                if (DictionaryPhilosophy.ContainsKey(Definition)) { DictionaryPhilosophy[Definition] = Explanation; }
                else { DictionaryPhilosophy.Add(Definition, Explanation); }
            }
        }
    }
}
