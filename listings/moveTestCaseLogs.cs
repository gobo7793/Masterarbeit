private void MoveCaseStudyLogs()
{
  var origLogDir = $@"{Environment.CurrentDirectory}\logs";
  var todayStrLong = DateTime.Today.ToString("yyyy-MM-dd");
  var origLogFile = $@"{origLogDir}\{todayStrLong}.log";
  var origSshLog = $@"{origLogDir}\{todayStrLong}-sshout.log";

  var caseStudyLogDir = $@"{Environment.CurrentDirectory}\testingHadoopCaseStudyLogs";
  var todayStrShort = DateTime.Today.ToString("yyMMdd");
  var filename = $"{_BenchmarkSeed:X8}-{_FaultActivationProbability:F1}-{_HostsCount:D1}-{_ClientCount:D1}-{_StepCount:D2}-{todayStrShort}";
  var newLogFile = $@"{caseStudyLogDir}\{filename}.log";
  var newSshLog = $@"{caseStudyLogDir}\{filename}-ssh.log";

  Directory.CreateDirectory(caseStudyLogDir);
  File.Move(origLogFile, newLogFile);
  File.Move(origSshLog, newSshLog);
}
