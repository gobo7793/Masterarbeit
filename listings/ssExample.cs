public class YarnNode : Component
{
    // fault definition, also possible: new PermanentFault()
    public readonly Fault NodeConnectionError = new TransientFault();
    
    // interaction logic (Members, Properties, Methods...)
    
    // fault effect
    [FaultEffect(Fault = nameof(NodeConnectionError))]
    internal class NodeConnectionErrorEffect : YarnNode
    {
		// fault effect logic
    }
}