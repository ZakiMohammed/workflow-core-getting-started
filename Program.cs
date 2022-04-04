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