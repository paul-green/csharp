using System.Buffers;
using System.Diagnostics;

var TimeFrame = TimeSpan.FromMilliseconds(100);

List<(string mehod, long count)> timings = new();

var values = new[] { "John", "Paul", "George", "Ringo" };
var searchValues = SearchValues.Create(values, StringComparison.OrdinalIgnoreCase);
TimeThis(() => searchValues.Contains("ringo"), "SearchValues.Contains");

var hashSetValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
TimeThis(() => hashSetValues.Contains("ringo"), "HashSet.Contains");

var listValues = values.ToList();
TimeThis(() => listValues.Any(v => v.Equals("ringo", StringComparison.OrdinalIgnoreCase)), "List.Any");

var sortedArray = values.ToList().Order().ToList();
TimeThis(() => sortedArray.BinarySearch("ringo", StringComparer.OrdinalIgnoreCase), "List.BinarySearch");

Console.WriteLine($"Iterations in {TimeFrame.TotalMilliseconds}ms:");
foreach (var time in timings.OrderByDescending(o => o.count))
{
    Console.WriteLine($"{time.mehod.PadRight(25)} : {time.count}");
}



void TimeThis(Action action, string method)
{
    var sw = Stopwatch.StartNew();
    int c = 0;
    while (sw.Elapsed < TimeFrame)
    {
        action();
        c++;
    }
    sw.Stop();
    timings.Add(new (method, c));
}