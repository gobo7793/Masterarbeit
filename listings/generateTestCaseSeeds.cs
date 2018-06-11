public void GenerateCaseStudyBenchSeeds()
{
  var ticks = Environment.TickCount;
  var ran = new Random(ticks);
  var s1 = ran.Next(0, int.MaxValue);
  var s2 = ran.Next(0, int.MaxValue);
  var s3 = ran.Next(0, int.MaxValue);
  Console.WriteLine($"Ticks: 0x{ticks:X}");
  Console.WriteLine($"s1: 0x{s1:X} | s2: 0x{s2:X} | s3: 0x{s3:X}");
  // Specific output for generating test case seeds:
  // Ticks: 0x719E8C
  // s1: 0xE99032B | s2: 0x4F009539 | s3: 0x319140E0
}
