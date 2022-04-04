public class ApplyShipping : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("ApplyShipping");
        return ExecutionResult.Next();
    }
}