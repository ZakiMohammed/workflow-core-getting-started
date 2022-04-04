public class Initialize : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Initialize");
        return ExecutionResult.Next();
    }
}