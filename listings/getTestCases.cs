public IEnumerable GetTestCases()
{
  foreach(var seed in GetSeeds())
  foreach(var prob in GetFaultProbabilities())
  foreach(var hosts in GetHostCounts())
  foreach(var clients in GetClientCounts())
  foreach(var steps in GetStepCounts())
  foreach(var isMut in GetIsMutated())
    yield return new TestCaseData(seed, prob, hosts,
        clients, steps, isMut);
}

private IEnumerable GetSeeds()
{
  yield return 0xE99032B;
  yield return 0x4F009539;
  yield return 0x319140E0;
}
