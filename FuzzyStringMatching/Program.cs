using F23.StringSimilarity;
using F23.StringSimilarity.Interfaces;
using FuzzyStringMatching;

var algorithms = new Dictionary<string, IStringSimilarity>()
{
    {"Cosine", new Cosine() },
    {"Jaccard", new Jaccard() },
    {"J-Winkler", new JaroWinkler() },
    {"N-Lev", new NormalizedLevenshtein() },
    {"First4", new FirstCharSimilarity(4) },
    {"First2", new FirstCharSimilarity(2) }
};

var nameGroups = new List<List<string>>
{
    new() {"John", "Jon", "Jonny", "Jonothan" },
    new() {"William", "Will", "Willy", "Bill", "Billy"},
    new() {"Catherine", "Cat", "Cathy", "Kate", "Kat"},
    new() {"Alexander", "Alex", "Xander"},
    new() {"Christine", "Christeen", "Chris" , "Crissy" , "Christie" },
    new() {"James", "Jim", "Jimmy" },
    new() {"Robert", "Rob", "Robby", "Robbie", "Bob" }
};

var defaultColor = Console.ForegroundColor;

for (int g = 0; g < nameGroups.Count; g++)
{
    var group = nameGroups[g];
    Console.WriteLine();
    Console.Write("".PadRight(26));
    foreach (var algorithm in algorithms)
    {
        var name = algorithm.Key;
        Console.Write($"{name[..Math.Min(name.Length, 7)]}".PadRight(8));

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
                var similarity = algorithm.Value.Similarity(name1, name2);
                var simText = $"{similarity:p}".PadLeft(8);

                if (similarity >= .90) 
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (similarity >= .8)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(simText);
                Console.ForegroundColor = defaultColor;
            }

            Console.WriteLine();
        }
    }
}
