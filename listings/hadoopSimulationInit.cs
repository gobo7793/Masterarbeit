private static TimeSpan _MinStepTime = new TimeSpan(0, 0, 0, 20);
private static int _BenchmarkSeed = Environment.TickCount;
private static int _StepCount = 3;
private static bool _PrecreatedInputs = true;
private static double _FaultActivationProbability = 0.25;
private static double _FaultRepairProbability = 0.5;
private static int _HostsCount = 1;
private static int _NodeBaseCount = 4;
private static int _ClientCount = 1;

private Model InitModel()
{
  ModelSettings.HostMode = ModelSettings.EHostMode.Multihost;
  ModelSettings.HostsCount = _HostsCount;
  ModelSettings.NodeBaseCount = _NodeBaseCount;
  ModelSettings.IsPrecreateBenchInputs = _PrecreatedInputs;
  ModelSettings.RandomBaseSeed = _BenchmarkSeed;
  
  var model = Model.Instance;
  model.InitModel(appCount: _StepCount, clientCount: _ClientCount);
  model.Faults.SuppressActivations();
  
  return model;
}

private FaultTuple[] CollectYarnNodeFaults(Model model)
{
  return (from node in model.Nodes
    
    from faultField in node.GetType().GetFields()
    where typeof(Fault).IsAssignableFrom(faultField.FieldType)
    
    let attr = faultField.GetCustomAttribute<NodeFaultAttribute>()
    where attr != null
    
    let fault = (Fault)faultField.GetValue(node)
    
    select Tuple.Create(fault, attr, node)
  ).ToArray();
}
