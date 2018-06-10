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
  yield return 123;
  yield return 456;
  yield return 789;
}