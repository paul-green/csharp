using F23.StringSimilarity.Interfaces;

namespace FuzzyStringMatching;

internal class FirstCharSimilarity(int count) : IStringSimilarity
{
    public double Similarity(string s1, string s2)
    {
        var s1Short = s1[..Math.Min(count, s1.Length)];  
        var s2Short = s2[..Math.Min(count, s2.Length)];
        return string.Equals(s1Short, s2Short, StringComparison.InvariantCultureIgnoreCase) ? 1 : 0;
    }
}
