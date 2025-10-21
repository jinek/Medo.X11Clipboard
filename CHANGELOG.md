CHANGELOG

[fork-1.0.0] (2025-10-21)

- Fork: CA1031 compliance and exception handling adjustments.
- Added X11ClipboardException and X11ClipboardLoopExceptionEventArgs; constructor throws precise exceptions.
- Introduced UnhandledException event; exceptions bubble if not handled unless e.Handled = true.
- Updated metadata (Authors, URLs, Description, Version) in multi-framework csproj.
- Added GitHub Actions workflow to pack and publish NuGet on push to main.

[1.0.0] (2024-07-21)

- Initial release release



[unreleased]: https://github.com/jinek/Medo.X11Clipboard
[1.0.0]: https://www.nuget.org/packages/Medo.X11Clipboard/1.0.0
[fork-1.0.0]: https://www.nuget.org/packages/jinek.X11Clipboard.Fork/1.0.0
