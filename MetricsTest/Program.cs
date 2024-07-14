// See https://aka.ms/new-console-template for more information

using System.Text;
using App.Metrics;
using App.Metrics.Counter;
using App.Metrics.Scheduling;

Console.WriteLine("Hello, World!");

var metrics = new MetricsBuilder()
    .Report.ToConsole()
    .Build();
    
    
var counter = new CounterOptions { Name = "my_counter" };
metrics.Measure.Counter.Increment(counter);

// var snapshot = metrics.Snapshot.Get();
//
// using (var stream = new MemoryStream())
// {
//     await metrics.DefaultOutputMetricsFormatter.WriteAsync(stream, snapshot);
//     var result = Encoding.UTF8.GetString(stream.ToArray());
//     System.Console.WriteLine(result);
// }

var scheduler = new AppMetricsTaskScheduler(
    TimeSpan.FromSeconds(20),
    async () =>
    {
        await Task.WhenAll(metrics.ReportRunner.RunAllAsync());
    });
scheduler.Start();

for (int i = 0; i < 10; i++)
{
    await Task.Delay(TimeSpan.FromSeconds(3));
}

Console.WriteLine();