public bool IsReconfPossible()
{
  Logger.Debug("Checking if reconfiguration is possible");
  
  var isReconfPossible = ConnectedNodes.Any(n => n.State == ENodeState.RUNNING);
  if(!isReconfPossible)
  {
    Logger.Error("No reconfiguration possible!");
    throw new Exception("No reconfiguration possible!");
  }
  
  return true;
}