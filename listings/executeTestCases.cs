[Test]
[TestCaseSource(nameof(GetTestCases))]
public void ExecuteCaseStudy(int benchmarkSeed,
    double faultProbability, int hostsCount, int clientCount,
    int stepCount, bool isMutated)
{
  // Write test case parameter to log
  
  StartCluster(hostsCount, isMutated);
  Thread.Sleep(7000); // wait for startup
  
  Logger.Info("Setting up test case");
  var simTest = new SimulationTests
  {
      MinStepTime = new TimeSpan(0, 0, 0, 25),
      RecreatePreInputs = true,
      PrecreatedInputs = true,
      NodeBaseCount = 4,
  
      BenchmarkSeed = benchmarkSeed,
      FaultActivationProbability = faultProbability,
      FaultRepairProbability = faultProbability,
      HostsCount = hostsCount,
      ClientCount = clientCount,
  
      StepCount = stepCount,
  };
  
  // execute
  simTest.SimulateHadoopFaults();
  
  StopCluster();
  
  // move logs
  MoveCaseStudyLogs(benchmarkSeed, faultProbability, hostsCount,
      clientCount, stepCount, isMutated);
}