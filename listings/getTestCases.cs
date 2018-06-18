public IEnumerable GetTestCases()
{
  return from seed in GetSeeds()
         from prob in GetFaultProbabilities()
         from hosts in GetHostCounts()
         from clients in GetClientCounts()
         from steps in GetStepCounts()
         from isMut in GetIsMutated()

         where !(hosts == 1 && clients >= 6)
         where !(clients <= 2 && steps >= 10)
         select new TestCaseData(seed, prob, hosts, clients, steps, isMut);
}

private IEnumerable<int> GetSeeds()
{
  yield return 0xAB4FEDD;
  yield return 0x11399D3;
}
