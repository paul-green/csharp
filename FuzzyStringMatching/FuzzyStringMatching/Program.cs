using F23.StringSimilarity;
using F23.StringSimilarity.Interfaces;
using System.Security.Cryptography;

var algorithms = new IStringSimilarity[]
{
    new Cosine(),
    new Jaccard(),
    new JaroWinkler(),
    new NormalizedLevenshtein(),
};

var nameGroups = new List<List<string>>
{
    new() {"John", "Jon", "Jonny", "Jonothan" },
    new() {"William", "Will", "Willy", "Bill", "Billy"},
    new() {"Catherine", "Cat", "Cathy", "Cat", "Kat"}
};



for (int g = 0; g < nameGroups.Count; g++)
{
    var group = nameGroups[g];
    Console.WriteLine();
    Console.Write("".PadRight(26));
    foreach (var algorithm in algorithms)
    {
        var name = algorithm.GetType().Name;
        Console.Write($"{name.Substring(0,System.Math.Min(name.Length, 7))}".PadRight(8));
    }
    Console.WriteLine();

    for (int i = 0; i < group.Count; i++)
    {
        for (int j = i + 1; j < group.Count; j++)
        {
            var name1 = group[i];
            var name2 = group[j];
            var comparisonText = $"{name1} vs {name2} :".PadRight(25);
            Console.Write(comparisonText);

            foreach (var algorithm in algorithms)
            {
                //Console.Write($"{algorithm.GetType().Name}");
                var similarity = algorithm.Similarity(name1, name2);
                var simText = $"{similarity:p}".PadLeft(8);
                Console.Write(simText);
            }

            Console.WriteLine();
        }
    }
}
