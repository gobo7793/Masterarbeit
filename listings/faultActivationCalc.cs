var node = Nodes.First(n => n.Name == nodeName);
var nodeUsage = (node.MemoryUsage + node.CpuUsage) / 2;

if(nodeUsage < 0.1) nodeUsage = 0.1;
else if(nodeUsage > 0.9) nodeUsage = 0.9;

NodeUsageOnActivation = nodeUsage; // for using on repairing

var faultUsage = nodeUsage * ActivationProbability * 2;

var probability = 1 - faultUsage;
var randomValue = RandomGen.NextDouble();
Logger.Info($"Activation probability: {probability} < {randomValue}");
return probability < randomValue;