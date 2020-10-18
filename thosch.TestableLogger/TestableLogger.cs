using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace

namespace Microsoft.Extensions.Logging
{
  /// <summary>
  /// A logger that stores all logged messages e.g. for asserting on messages in test projects. 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class TestableLogger<T> : TestableLogger, ILogger<T>
  {
    /// <summary>
    /// ctor
    /// </summary>
    public TestableLogger() => BeginScope(typeof(T).FullName);
  }
  
  /// <summary>
  /// A logger that stores all logged messages e.g. for asserting on messages in test projects.
  /// </summary>
  public class TestableLogger : ILogger
  {
    
    /// <summary>
    /// Contains all messages logged with this instance.
    /// </summary>
    // ReSharper disable once CollectionNeverQueried.Global
    public List<string> Messages { get; } = new List<string>();

    /// <summary>
    /// ILogger interface method
    /// </summary>
    /// <param name="logLevel"></param>
    /// <param name="eventId"></param>
    /// <param name="state"></param>
    /// <param name="exception"></param>
    /// <param name="formatter"></param>
    /// <typeparam name="TState"></typeparam>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) 
      => Messages.Add($"{logLevel}: {formatter(state, exception)}");

    /// <summary>
    /// ILogger interface method 
    /// </summary>
    /// <param name="logLevel"></param>
    /// <returns></returns>
    public bool IsEnabled(LogLevel logLevel) => true;
    
    /// <summary>
    /// ILogger interface method
    /// </summary>
    /// <param name="state"></param>
    /// <typeparam name="TState"></typeparam>
    /// <returns></returns>
    public IDisposable BeginScope<TState>(TState state) => null!;
  }
}