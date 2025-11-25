using System.Diagnostics;

// ---------------------------------------------------------
// TOP-LEVEL STATEMENTS (The "Main" method is invisible in .NET 8)
// ---------------------------------------------------------

SafeLogger logger = new();

// 'using' declaration ensures cts is Disposed automatically at the end of scope
using CancellationTokenSource cts = new();

Console.WriteLine("--- IoT Sensor Hub (.NET 8 Edition) ---");
Console.WriteLine("Press 'C' to stop all sensors safely.\n");

// NEW: Collection Expressions (C# 12)
// Cleaner way to initialize lists
List<Sensor> sensors = 
[
    new(1), 
    new(2), 
    new(3), 
    new(4)
];

List<Task> sensorTasks = [];

// Start all sensors
foreach (var sensor in sensors)
{
    sensorTasks.Add(sensor.MonitorAsync(logger, cts.Token));
}

// Background Thread for Health Check
Thread healthThread = new(() =>
{
    while (!cts.Token.IsCancellationRequested)
    {
        Thread.Sleep(3000);
        logger.Log("[System] Health Check: OK");
    }
})
{ IsBackground = true };

healthThread.Start();

// Control Loop
while (true)
{
    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.C)
    {
        logger.Log(">>> STOP COMMAND RECEIVED. Cancelling tasks...");
        cts.Cancel();
        break;
    }
    
    // Non-blocking wait
    await Task.Delay(100);
}

// Wait for shutdown
try
{
    await Task.WhenAll(sensorTasks);
}
catch
{
    // Ignore cancellation exceptions during shutdown
}

Console.WriteLine("\n--- Hub Shutdown Complete ---");

// ---------------------------------------------------------
// CLASS DEFINITIONS (Must be at the bottom in Top-Level Statements)
// ---------------------------------------------------------

// NEW: Primary Constructor (C# 12)
// We declare 'id' right in the class definition.
public class Sensor(int id)
{
    public int Id { get; } = id;
    
    // Target-typed new()
    private readonly Random _random = new();

    private async Task<double> ReadTemperatureAsync(CancellationToken token)
    {
        // Simulating network latency
        await Task.Delay(_random.Next(500, 2000), token);
        return 20.0 + (_random.NextDouble() * 10.0);
    }

    public async Task MonitorAsync(SafeLogger logger, CancellationToken token)
    {
        logger.Log($"Sensor {Id} connecting...");

        try
        {
            while (!token.IsCancellationRequested)
            {
                double temp = await ReadTemperatureAsync(token);
                logger.Log($"Sensor {Id} Report: {temp:F2}°C");
                
                // Pass token to allow immediate cancellation during sleep
                await Task.Delay(1000, token);
            }
        }
        catch (OperationCanceledException)
        {
            logger.Log($"Sensor {Id} stopping gracefully.");
        }
        catch (Exception ex)
        {
            logger.Log($"Sensor {Id} Error: {ex.Message}");
        }
    }
}

public class SafeLogger
{
    // In .NET 9, there is a new 'System.Threading.Lock' type, 
    // but in .NET 8, we still use 'object'.
    private readonly object _lock = new();

    public void Log(string message)
    {
        lock (_lock)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            // String interpolation is slightly faster in .NET 8
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {message}");
            Console.ResetColor();
        }
    }
}