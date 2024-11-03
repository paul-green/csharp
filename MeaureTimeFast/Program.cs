using System.Diagnostics;

const int durSecs = 1;

void UsingUtcNow()
{
    var then = DateTime.UtcNow.AddSeconds(durSecs);
    var count = 0;
    while (DateTime.UtcNow < then) count++;
    Console.WriteLine($"DateTime.UtcNow count in : {count:N}");
}

void UsingStopwatchElapsed()
{
    var then = TimeSpan.FromSeconds(durSecs);
    var count = 0;
    Stopwatch.GetTimestamp()
    var sw = Stopwatch.StartNew();
    while (sw.Elapsed < then) count++;
    Console.WriteLine($"Stopwatch.Elapsed count in : {count:N}");
}

UsingUtcNow();
UsingStopwatchElapsed();
