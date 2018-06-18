var todayStrShort = DateTime.Today.ToString("yyMMdd");
var mutated = isMutated ? "MT" : "MF";
var faultProbStr = faultProbability.ToString(CultureInfo.InvariantCulture);
var baseFileName = $"0x{benchmarkSeed:X8}-{faultProbStr}F-{hostsCount:D1}H-{clientCount:D1}C-{stepCount:D2}S-{mutated}-{todayStrShort}";
