public IEnumerable GetTestCases()
{
  return from seed in GetSeeds()
         from prob in GetFaultProbabilities()
         from hosts in GetHostCounts()
         from clients in GetClientCounts()
         from steps in GetStepCounts()
         from isMut in GetIsMutated()

         where clients * steps <= MaxPossibleAppCount
         select new TestCaseData(seed, prob, hosts, clients, steps, isMut);
}

private IEnumerable GetSeeds()
{
  yield return 0xE99032B;
  yield return 0x4F009539;
  yield return 0x319140E0;
}
