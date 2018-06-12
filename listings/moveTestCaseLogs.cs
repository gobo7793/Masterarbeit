var todayStrShort = DateTime.Today.ToString("yyMMdd");
var mutated = isMutated ? 'T' : 'F';
var faultProbStr = faultProbability.ToString(CultureInfo.InvariantCulture);
var filename = $"{benchmarkSeed:X8}-{faultProbStr}-{hostsCount:D1}-{clientCount:D1}-{stepCount:D2}-{mutated}-{todayStrShort}";
