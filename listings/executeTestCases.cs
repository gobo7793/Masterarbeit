[Test]
[TestCaseSource(nameof(GetTestCases))]
public void ExecuteCaseStudy(int benchmarkSeed, double faultProbability, int hostsCount, int clientCount, int stepCount, bool isMutated)
{
  // write test case parameter to log

  InitInstances();
  var isFailed = false;
  try
  {
    // Setup
    StartCluster(hostsCount, isMutated);
    Thread.Sleep(5000); // wait for startup

    var simTest = new SimulationTests();
    // save test case parameter to simTest

    // Execution
    simTest.SimulateHadoopFaults();
  }
  // catch exceptions and set isFailed=true
  finally
  {
    // Teardown
    StopCluster();
    MoveCaseStudyLogs(/* test case parameter */);
  }
  Assert.False(isFailed);
}
