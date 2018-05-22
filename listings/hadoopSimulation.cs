public void SimulateHadoop()
{
  ModelSettings.FaultActivationProbability = 0.0;
  ModelSettings.FaultRepairProbability = 1.0;
  
  ExecuteSimulation();
}

private void ExecuteSimulation(bool isWithFaults)
{
  var origModel = InitModel();
  
  var wasFatalError = false;
  try
  {
    var simulator = new SafetySharpSimulator(origModel);
    var simModel = (Model)simulator.Model;
    var faults = CollectYarnNodeFaults(simModel);
    
    SimulateBenchmarks();
    
    for(var i = 0; i < _StepCount; i++)
    {
      OutputUtilities.PrintStepStart();
      var stepStartTime = DateTime.Now;
      
      if(isWithFaults)
        HandleFaults(faults);
      simulator.SimulateStep();
      
      var stepTime = DateTime.Now - stepStartTime;
      OutputUtilities.PrintSteptTime(stepTime);
      if(stepTime < ModelSettings.MinStepTime)
        Thread.Sleep(ModelSettings.MinStepTime - stepTime);
      
      OutputUtilities.PrintFullTrace(simModel.Controller);
    }
    
    OutputUtilities.PrintExecutionFinish();
  }
  // catch/finally
}