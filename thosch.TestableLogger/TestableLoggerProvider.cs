using Microsoft.Extensions.Logging;

namespace thosch.TestableLogger
{
  internal class TestableLoggerProvider : ILoggerProvider
  {
    public TestableLoggerProvider(Microsoft.Extensions.Logging.TestableLogger logger) => this.logger = logger;
    public void Dispose() { }
    public ILogger CreateLogger(string categoryName) => logger;

    private readonly Microsoft.Extensions.Logging.TestableLogger logger;
  }
}