var todayStrShort = DateTime.Today.ToString("yyMMdd");
var mutatedInt = isMutated ? 1 : 0;
var faultProbStr = faultProbability.ToString(CultureInfo.InvariantCulture);
var filename = $"{benchmarkSeed:X8}-{faultProbStr}-{hostsCount:D1}-{clientCount:D1}-{stepCount:D2}-{mutatedInt:D1}-{todayStrShort}";