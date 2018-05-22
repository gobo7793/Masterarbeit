public void UpdateBenchmark()
{
  var benchChanged = BenchController.ChangeBenchmark();
  
  if(benchChanged)
  {
    StopCurrentBenchmark();
    StartBenchmark(BenchController.CurrentBenchmark);
  }
}