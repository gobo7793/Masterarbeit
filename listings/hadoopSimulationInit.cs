public TimeSpan MinStepTime { get; set; } = new TimeSpan(0, 0, 0, 25);
public int BenchmarkSeed { get; set; } = Environment.TickCount;
public int StepCount { get; set; } = 3;
public bool PrecreatedInputs { get; set; } = true;
public bool RecreatePreInputs { get; set; } = false;
public double FaultActivationProbability { get; set; } = 0.25;
public double FaultRepairProbability { get; set; } = 0.5;
public int HostsCount { get; set; } = 1;
public int NodeBaseCount { get; set; } = 4;
public int ClientCount { get; set; } = 2;

private Model InitModel()
{
  ModelSettings.HostMode = ModelSettings.EHostMode.Multihost;
  ModelSettings.HostsCount = HostsCount;
  ModelSettings.NodeBaseCount = NodeBaseCount;
  ModelSettings.IsPrecreateBenchInputsRecreate = RecreatePreInputs;
  ModelSettings.IsPrecreateBenchInputs = PrecreatedInputs;
  ModelSettings.RandomBaseSeed = BenchmarkSeed;
  
  var model = Model.Instance;
  model.InitModel(appCount: StepCount, clientCount: ClientCount);
  model.Faults.SuppressActivations();
  
  return model;
}
