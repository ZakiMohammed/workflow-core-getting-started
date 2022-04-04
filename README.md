# Workflow Core Getting Started

The WorkflowCore package required .NET Core 2.0 framework.

#### Initial Setup
```
dotnet new console -o workflow-start
dotnet run
```

#### Nuget Packages
```
dotnet add package WorkflowCore
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.DependencyInjection.Abstractions
dotnet add package Microsoft.Extensions.Logging
```

#### Staring Up
One have to create the steps first then the workflow and then finally register the workflow to the host on the main file:

1. Create Steps
2. Create Workflow
3. Register and start the Workflow from the main program file

#### 1. Create Steps
Create steps folder and start adding step files: 
```
public class Initialize : StepBody
{
    public double BaseAmount { get; set; }

    public override ExecutionResult Run(IStepExecutionContext context)
    {
        Console.WriteLine("Initialize");
        return ExecutionResult.Next();
    }
}
```

#### 2. Create Workflow
```
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
```

#### 3. Register and start the Workflow from the main program file
```
var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddWorkflow()
    .BuildServiceProvider();

var host = serviceProvider.GetService<IWorkflowHost>();
if (host == null)
    throw new Exception("Host not initialized");

host.RegisterWorkflow<ProcessPaymentWorkflow>();

host.Start();

host.StartWorkflow("ProcessPaymentWorkflow");

Console.ReadLine();
host.Stop();
```