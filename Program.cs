using System;

namespace NameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 10;
            var gen = new SeriesGenerator();

            // A = adjectives,
        // N = nouns,
        // P = pastVerbs
        // V = verbs,
        // D = adverbs
        // M = animal name
        // G = -ing verb

            while (i>0)
            {
                Console.WriteLine(gen.GetRandomPhrase("PAGM"));
                i -= 1;
            }
        }
    }
}
