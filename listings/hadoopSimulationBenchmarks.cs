public void SimulateBenchmarks()
{
  for(int i = 1; i <= _ClientCount; i++)
  {
    var seed = _BenchmarkSeed + i;
    var benchController = new BenchmarkController(seed);
    Logger.Info($"Simulating Benchmarks for Client {i} with Seed {seed}:");
    for(int j = 0; j < _StepCount; j++)
    {
      benchController.ChangeBenchmark();
      Logger.Info($"Step {j}: {benchController.CurrentBenchmark.Name}");
    }
  }
}