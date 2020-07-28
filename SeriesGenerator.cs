using System;
using System.IO;
using System.Text;

namespace NameGenerator
{
    public class SeriesGenerator
    {
        protected string[] adjectives;
        // protected string[] adverbs;
        protected string[] animals;
        protected string[] ingVerbs;
        protected string[] nouns;
        protected string[] pastVerbs;
        // protected string[] verbs;
        protected Random random = new Random();

        private void LoadWords()
        {
            adjectives = File.ReadAllLines(@"adjectives.txt");
            nouns = File.ReadAllLines(@"nouns.txt");
            pastVerbs = File.ReadAllLines(@"past-verbs.txt");
            // verbs = File.ReadAllLines(@"verbs.txt");
            animals = File.ReadAllLines(@"oneWordAnimals.txt");
            ingVerbs = File.ReadAllLines(@"ing-verbs.txt");
            // adverbs = File.ReadAllLines(@"adverbs.txt");
        }

        public SeriesGenerator()
        {
            LoadWords();
        }

        public enum Style
        {
            CamelCase,
            KebabLower,
            Spaced
        }

        // A = adjectives,
        // N = nouns,
        // P = pastVerbs
        // V = verbs,
        // D = adverbs
        // M = animal name
        // G = -ing verb
        public string GetRandomPhrase(string phraseCode, Style style = Style.Spaced)
        {
            var sb = new StringBuilder();
            var upperPhrase = phraseCode.ToUpperInvariant();
            for (int i = 0; i < upperPhrase.Length; i++)
            {
                var code = upperPhrase[i];
                string word = null;
                switch (code)
                {
                    case 'A':
                        word = GetRandom(adjectives);
                        break;
                    case 'N':
                        word = GetRandom(nouns);
                        break;
                    case 'P':
                        word = GetRandom(pastVerbs);
                        break;
                    // case 'V':
                    //     word = GetRandom(verbs);
                    //     break;
                    // case 'D':
                    //     word = GetRandom(adverbs);
                    //     break;
                    case 'M':
                        word = GetRandom(animals);
                        break;
                    case 'G':
                        word = GetRandom(ingVerbs);
                        break;
                    default:
                        throw new Exception($"Invalid phrase code: {code}");
                }
                if (style == Style.CamelCase)
                {
                    word = char.ToUpperInvariant(word[0]) + word.Substring(1);
                }
                else
                {
                    word = word.ToLower();
                }
                sb.Append(word);
                if (i < upperPhrase.Length - 1)
                {
                    if (style == Style.Spaced) sb.Append(" ");
                    if (style == Style.KebabLower) sb.Append("-");
                }
            }
            return sb.ToString();
        }

        private string GetRandom(string[] words)
        {
            return words[random.Next(0, words.Length)];
        }
    }




}
