using System.Buffers;
using System.Diagnostics;

var values = new[] { "John", "Paul", "George", "Ringo" };
var searchValues = SearchValues.Create(values, StringComparison.OrdinalIgnoreCase);
TimeThis(() => searchValues.Contains("ringo"), "SearchValues.Contains");

var hashSetValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
TimeThis(() => hashSetValues.Contains("ringo"), "HashSet.Contains");

var listValues = values.ToList();
TimeThis(()=> listValues.Any(v=>v.Equals("ringo", StringComparison.OrdinalIgnoreCase)), "List.Any()");





void TimeThis(Action action, string method)
{
    var sw = Stopwatch.StartNew();
    int c = 0;
    while (sw.ElapsedMilliseconds < 100)
    {
        action();
        c++;
    }
    sw.Stop();
    Console.WriteLine($"{method.PadRight(25)} did {c} in {sw.ElapsedMilliseconds}ms");
}