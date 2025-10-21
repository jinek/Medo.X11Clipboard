/* Fork-specific exception types for Medo.X11Clipboard */

namespace Medo.X11;

using System;

/// <summary>
/// Represents an error that occurs while interacting with the X11 clipboard.
/// </summary>
public class X11ClipboardException : Exception {
    public X11ClipboardException() { }
    public X11ClipboardException(string message) : base(message) { }
    public X11ClipboardException(string message, Exception? innerException) : base(message, innerException) { }
}

/// <summary>
/// Event arguments for exceptions raised from the background event loop.
/// Handlers may set Handled = true to prevent the exception from bubbling to the thread top.
/// </summary>
public sealed class X11ClipboardLoopExceptionEventArgs : EventArgs {
    public X11ClipboardLoopExceptionEventArgs(Exception exception, string? context = null) {
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        Context = context;
    }

    /// <summary>
    /// Gets the exception that occurred inside the event loop.
    /// </summary>
    public Exception Exception { get; }

    /// <summary>
    /// Gets optional context description related to the error.
    /// </summary>
    public string? Context { get; }

    /// <summary>
    /// If set to true by an event handler, the exception will be considered handled and will not be rethrown.
    /// </summary>
    public bool Handled { get; set; }
}
