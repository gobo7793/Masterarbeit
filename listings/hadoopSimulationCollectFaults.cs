private FaultTuple[] CollectYarnNodeFaults(Model model)
{
  return (from node in model.Nodes      
      from faultField in node.GetType().GetFields()
      where typeof(Fault).IsAssignableFrom(faultField.FieldType)
      
      let attribute = faultField.GetCustomAttribute<NodeFaultAttribute>()
      where attribute != null
      
      let fault = (Fault)faultField.GetValue(node)
      
      select Tuple.Create(fault, attribute, node, new IntWrapper(0), new IntWrapper(0))
  ).ToArray();
}