public class ApplyDiscount : StepBody
{
    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("ApplyDiscount");
        return ExecutionResult.Next();
    }
}