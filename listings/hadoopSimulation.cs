[Test]
public void SimulateHadoop()
{
  ModelSettings.FaultActivationProbability = 0.0;
  ModelSettings.FaultRepairProbability = 1.0;
  
  var execRes = ExecuteSimulation();
  Assert.IsTrue(execRes, "fatal error occured, see log for details");
}

private bool ExecuteSimulation()
{
  var model = InitModel();
  var isWithFaults = FaultActivationProbability > 0.000001; // prevent inaccuracy
  
  var wasFatalError = false;
  try
  {
    // init simulation
    var simulator = new SafetySharpSimulator(model);
    var simModel = (Model)simulator.Model;
    var faults = CollectYarnNodeFaults(simModel);

    SimulateBenchmarks();

    // do simuluation
    for(var i = 0; i < StepCount; i++)
    {
      OutputUtilities.PrintStepStart();
      var stepStartTime = DateTime.Now;

      if(isWithFaults)
        HandleFaults(faults);
      simulator.SimulateStep();

      var stepTime = DateTime.Now - stepStartTime;
      OutputUtilities.PrintDuration(stepTime);
      if(stepTime < ModelSettings.MinStepTime)
        Thread.Sleep(ModelSettings.MinStepTime - stepTime);

      OutputUtilities.PrintFullTrace(simModel.Controller);
    }

    // collect fault counts and check constraint
  }
  // catch/finally
  
  return !wasFatalError;
}