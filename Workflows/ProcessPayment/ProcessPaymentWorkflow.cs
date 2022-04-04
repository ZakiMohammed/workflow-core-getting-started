public class ProcessPaymentWorkflow : IWorkflow
{
    public string Id => "ProcessPaymentWorkflow";

    public int Version => 1;

    public void Build(IWorkflowBuilder<object> builder)
    {
        builder
            .UseDefaultErrorBehavior(WorkflowErrorHandling.Suspend)
            .StartWith<Initialize>()
            .Then<ApplyDiscount>()
            .Then<ApplyShipping>()
            .Then<Finalize>();
    }
}