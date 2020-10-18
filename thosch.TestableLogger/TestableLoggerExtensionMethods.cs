// ReSharper disable MemberCanBePrivate.Global

using thosch.TestableLogger;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Logging
{
  /// <summary>
  /// 
  /// </summary>
  public static class TestableLoggerExtensionMethods
  {
    /// <summary>
    /// Adds <see cref="TestableLogger{T}"/> to the log factory.
    /// </summary>
    /// <param name="loggingBuilder"></param>
    /// <param name="testableLogger">A <see cref="TestableLogger{T}"/> instance.</param>
    public static void AddTestableLogger(this ILoggingBuilder loggingBuilder, TestableLogger testableLogger)
      => loggingBuilder.AddProvider(new TestableLoggerProvider(testableLogger));

    /// <summary>
    /// Configures logger factory to use a <see cref="TestableLogger{T}"/>.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="testableLogger">A <see cref="TestableLogger{T}"/> instance.</param>
    public static void ConfigureTestableLogger(this ILoggingBuilder c, TestableLogger testableLogger)
    {
      c.AddTestableLogger(testableLogger);
      c.SetMinimumLevel(LogLevel.Debug);
    }
  }
}