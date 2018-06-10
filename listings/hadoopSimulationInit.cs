internal TimeSpan MinStepTime = new TimeSpan(0, 0, 0, 25);
internal int BenchmarkSeed = Environment.TickCount;
internal int StepCount = 3;
internal bool RecreatePreInputs = false;
internal bool PrecreatedInputs = true;
internal double FaultActivationProbability = 0.25; // 0.0 -> inactive, 1.0 -> always
internal double FaultRepairProbability = 0.5; // 0.0 -> inactive, 1.0 -> always
internal int HostsCount = 1;
internal int NodeBaseCount = 4;
internal int ClientCount = 2;

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