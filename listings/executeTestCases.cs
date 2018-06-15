[Test]
[TestCase(0x36159C73, 0.3, 2, 4, 5, false)]
// other test cases
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
    ResetInstances();
    MoveCaseStudyLogs(/* test case parameter */);
  }
  Assert.False(isFailed);
}
