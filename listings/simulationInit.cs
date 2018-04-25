public void Simulate()
{
  var model = Model.Instance;
  model.InitModel(appCount: _StepCount);
  model.Faults.SuppressActivations();

  var simulator = new SafetySharpSimulator(model);
  ExecuteSimulation(simulator, _StepCount);
}

public static void ExecuteSimulation(SafetySharpSimulator simulator, int steps)
{
  var model = (Model)simulator.Model;
  for(var i = 0; i < steps; i++)
  {
    var stepStartTime = DateTime.Now;

    simulator.SimulateStep();

    var stepTime = DateTime.Now - stepStartTime;
    if(stepTime < _MinStepTime)
      Thread.Sleep(_MinStepTime - stepTime);

    PrintTrace(model);
  }
}
