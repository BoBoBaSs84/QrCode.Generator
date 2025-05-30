﻿// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.Logging;

using QrCode.Generator.Interfaces.Services;

namespace QrCode.Generator.Services;

/// <summary>
/// The logger service class.
/// </summary>
/// <remarks>
/// Implements the <see cref="ILoggerService{T}"/> interface.
/// </remarks>
/// <typeparam name="T"></typeparam>
[ExcludeFromCodeCoverage(Justification = "Wrapper class.")]
internal sealed class LoggerService<T>(ILogger<T> logger) : ILoggerService<T> where T : class
{
  /// <inheritdoc/>
  public void Log(Action<ILogger, Exception?> del, Exception? exception = null)
    => del?.Invoke(logger, exception);

  /// <inheritdoc/>
  public void Log<T1>(Action<ILogger, T1, Exception?> del, T1 param, Exception? exception = null)
    => del?.Invoke(logger, param, exception);

  /// <inheritdoc/>
  public void Log<T1, T2>(Action<ILogger, T1, T2, Exception?> del, T1 param1, T2 param2,
    Exception? exception = null)
    => del?.Invoke(logger, param1, param2, exception);

  /// <inheritdoc/>
  public void Log<T1, T2, T3>(Action<ILogger, T1, T2, T3, Exception?> del, T1 param1, T2 param2,
    T3 param3, Exception? exception = null)
    => del?.Invoke(logger, param1, param2, param3, exception);

  /// <inheritdoc/>
  public void Log<T1, T2, T3, T4>(Action<ILogger, T1, T2, T3, T4, Exception?> del, T1 param1,
    T2 param2, T3 param3, T4 param4, Exception? exception = null)
    => del?.Invoke(logger, param1, param2, param3, param4, exception);

  /// <inheritdoc/>
  public void Log<T1, T2, T3, T4, T5>(Action<ILogger, T1, T2, T3, T4, T5, Exception?> del, T1 param1,
    T2 param2, T3 param3, T4 param4, T5 param5, Exception? exception = null)
    => del?.Invoke(logger, param1, param2, param3, param4, param5, exception);

  /// <inheritdoc/>
  public void Log<T1, T2, T3, T4, T5, T6>(Action<ILogger, T1, T2, T3, T4, T5, T6, Exception?> del,
    T1 param1, T2 param2, T3 param3, T4 param4, T5 param5, T6 param6, Exception? exception = null)
    => del?.Invoke(logger, param1, param2, param3, param4, param5, param6, exception);
}
