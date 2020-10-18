using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace LogoCommunicatorTests.Infrastructure
{

  public class TestableLogger<T> : TestableLogger, ILogger<T> { }
  public class TestableLogger : ILogger
  {
    public List<string> Messages { get; } = new List<string>();

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) => Messages.Add($"{logLevel}: {formatter(state, exception)}");

    public bool IsEnabled(LogLevel logLevel) => true;
    public IDisposable BeginScope<TState>(TState state) => null!;
  }

  public class TestableLoggerProvider : ILoggerProvider
  {
    public TestableLoggerProvider(TestableLogger logger) => this.logger = logger;
    public void Dispose() { }
    public ILogger CreateLogger(string categoryName) => logger;

    private readonly TestableLogger logger;
  }

  public static class TestableLoggerExtensionMethods
  {
    public static void AddTestableLogger(this ILoggingBuilder loggingBuilder, TestableLogger testableLogger)
      => loggingBuilder.AddProvider(new TestableLoggerProvider(testableLogger));

    public static void ConfigureTestableLogger(this ILoggingBuilder c, TestableLogger testableLogger)
    {
      c.AddTestableLogger(testableLogger);
      c.SetMinimumLevel(LogLevel.Debug);
    }
  }
}