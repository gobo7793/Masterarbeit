public Func<bool>[] Constraints => new Func<bool>[]
{
  () =>
  {
    if(FinalStatus != EFinalStatus.FAILED) return true;
    if(!String.IsNullOrWhiteSpace(Name) && Name.ToLower().Contains("fail job")) return true;
    return false;
  },
  () =>
  {
    if(State == EAppState.RUNNING)
      return AmHost?.State == ENodeState.RUNNING;
    return true;
  },
};
