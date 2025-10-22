namespace Tests;

using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using jinek.X11;
using System.Security.Cryptography;

[TestClass]
public class Basic {

    private static readonly object Lock = new();

    [TestMethod]
    public void Primary() {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                var textP = "P-" + RandomNumberGenerator.GetHexString(8);
                var textC = "C-" + RandomNumberGenerator.GetHexString(8);
                X11Clipboard.Clipboard.SetText(textC);
                X11Clipboard.Primary.SetText(textP);
                X11Clipboard.Clipboard.SetText(textC);
                Assert.AreEqual(textP, X11Clipboard.Primary.GetText());
                Assert.AreEqual(textC, X11Clipboard.Clipboard.GetText());
        } else {
            Assert.Inconclusive("Only supported on Linux.");
        }
    }

    [TestMethod]
    public void Clipboard() {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                var textP = "P-" + RandomNumberGenerator.GetHexString(8);
                var textC = "C-" + RandomNumberGenerator.GetHexString(8);
                X11Clipboard.Primary.SetText(textP);
                X11Clipboard.Clipboard.SetText(textC);
                X11Clipboard.Primary.SetText(textP);
                Assert.AreEqual(textP, X11Clipboard.Primary.GetText());
                Assert.AreEqual(textC, X11Clipboard.Clipboard.GetText());
        } else {
            Assert.Inconclusive("Only supported on Linux.");
        }
    }

}
