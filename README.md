
Medo.X11Clipboard
=================

X11Clipboard library is designed for applications that need to interact with the
X11 clipboard system. This library provides essential functions for getting and
setting UTF-8 text content for both X11's primary selection and clipboard. This
makes it ideal for applications that require straightforward clipboard
interactions without the overhead of more comprehensive libraries.

Features:
* Supports both primary selection and clipboard GetText and SetText operations.
* .NET 8 AOT support

Fork notice
-----------
This repository is a fork of the original Medo.X11Clipboard by Josip Medved. It is maintained by Evgeny Gorbovoy <jinek@msn.com>.

The changes in this fork were implemented by Junie with ChatGPT-5. The main goals of the fork are to improve CA1031 compliance and developer ergonomics.

You can find packaged library at [NuGet][nuget_x11clipboard].


## Usage

To write and read X11 primary selection (aka, middle-click clipboard):
```csharp
using System;
using Medo.X11;

X11Clipboard.Primary.SetText("My text.");
Console.WriteLine(X11Clipboard.Primary.GetText());
```

To write and read normal clipboard:
```csharp
using System;
using Medo.X11;

X11Clipboard.Clipboard.SetText("My text.");
Console.WriteLine(X11Clipboard.Clipboard.GetText());
```

## Exception handling (fork changes)

- Constructors now throw exceptions instead of silently failing:
  - PlatformNotSupportedException on non-Linux platforms.
  - X11ClipboardException for X11/atom/window initialization failures.

- A new UnhandledException event is raised when an exception occurs in the background X11 event loop. You can observe and optionally handle it:

```csharp
using Medo.X11;

// Subscribe once at startup
X11Clipboard.Clipboard.UnhandledException += (sender, e) => {
    // Log the error
    Console.Error.WriteLine($"X11 loop error: {e.Exception}");

    // If you decide you handled it and want to prevent the thread from crashing:
    e.Handled = true; // omit or set to false to let the exception bubble up
};
```

[nuget_x11clipboard]: https://www.nuget.org/packages/Medo.X11Clipboard/
