public class Initialize : StepBody
{
    public double BaseAmount { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Initialize");
        return ExecutionResult.Next();
    }
}