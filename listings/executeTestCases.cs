[Test]
[TestCase(514633513, 0.3, 2, 1, 15)]
// ...
public void ExecuteCaseStudy(int benchmarkSeed, double faultProbability, int hostsCount, int clientCount,  int stepCount)
{
  // For all test cases
  _MinStepTime = new TimeSpan(0, 0, 0, 25);
  _RecreatePreInputs = true;
  _PrecreatedInputs = true;
  _NodeBaseCount = 4;

  // Specific test cases
  _BenchmarkSeed = benchmarkSeed;
  _FaultActivationProbability = faultProbability;
  _FaultRepairProbability = faultProbability;
  _HostsCount = hostsCount;
  _ClientCount = clientCount;

  _StepCount = stepCount;

  // execute
  SimulateHadoopFaults();

  // move logs
  MoveCaseStudyLogs();
}
