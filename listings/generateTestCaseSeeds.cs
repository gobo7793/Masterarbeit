var ticks = Environment.TickCount;
var ran = new Random(ticks);
var s1 = ran.Next(int.MinValue, int.MaxValue);
var s2 = ran.Next(int.MinValue, int.MaxValue);
var s3 = ran.Next(int.MinValue, int.MaxValue);
Console.WriteLine($"Ticks: {ticks:X} | s1: {s1:X} | s2: {s2:X} | s3: {s3:X}");
// Specific output for generating test case seeds:
// Ticks: 40595187 | s1: 105838460 | s2: -2044864785 | s3: 514633513
