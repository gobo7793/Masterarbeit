public class Benchmark
{
  public const string BaseDirHolder = "$DIR";
  public const string OutDirHolder = "$OUT";
  public const string InDirHolder = "$IN";
  
  public Benchmark(int id, string name, string startCmd, string outputDir, string inputDir)
  {
    _StartCmd = startCmd;
    _InDir = inputDir;
    HasInputDir = true;
  }
  
  public string GetStartCmd(string clientDir = "")
  {
    var result = _StartCmd.Replace(OutDirHolder, GetOutputDir(clientDir)).Replace(InDirHolder, GetInputDir(clientDir));
    if(result.Contains(BaseDirHolder))
      result = ReplaceClientDir(result, clientDir);
    return result;
  }
}

using static Benchmark;
public class BenchmarkController
{

  public static Benchmark[] Benchmarks { get; } // benchmarks
  public static int[][] BenchTransitions { get; } // transitions
  
  static BenchmarkController()
  {
    Benchmarks = new[]
    {
      new Benchmark(04, "wordcount", $"example wordcount {InDirHolder} {OutDirHolder}", $"{BaseDirHolder}/wcout", $"{BaseDirHolder}/rantw"),
    };
  }
}

public class Client : Component
{
  public string StartBenchmark(Benchmark benchmark)
  {
    if(benchmark.HasOutputDir)
      SubmittingConnector.RemoveHdfsDir(benchmark.GetOutputDir(ClientDir));
    var appId = SubmittingConnector.StartApplicationAsync(benchmark.GetStartCmd(ClientDir));
  }
}