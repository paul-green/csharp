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

foreach (var algorithm in algorithms)
{
    Console.WriteLine();
    Console.WriteLine($"{algorithm.GetType().Name}");
    Console.WriteLine(new string('-', algorithm.GetType().Name.Length));

    for (int g = 0; g < nameGroups.Count; g++)
    {
        var group = nameGroups[g];
        Console.WriteLine();
        Console.WriteLine($"Testing Group : {group[0]}");

        for (int i = 0; i < group.Count; i++)
        {
            for (int j = i + 1; j < group.Count; j++)
            {
                var name1 = group[i];
                var name2 = group[j];
                var similarity = algorithm.Similarity(name1, name2);

                Console.WriteLine($"   {name1} vs {name2} : {similarity:p}");
                
            }
        }
    }
}