In .Net 9 the Stopwatch has improved performance.

Prior to .9 it would use DateTime.UtcNow, which had a good amount of extra code to check for timezones/leap-seconds etc, which reduced its 
performance.

```Stopwatch.StartNew()``` now uses ``` Stopwatch.GetTimestamp()``` which uses the O/S kernal hardware timer - which is usually the case. If not it 
will fallback to ```DateTime.UtcNow```

``` Stopwatch.GetTimestamp()``` is hardware specific and can't be assumed to be consistent across devices - so don't perform calculations assuming
it's ticks for example.

