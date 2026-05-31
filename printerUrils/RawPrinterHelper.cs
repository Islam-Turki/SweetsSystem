using sweetSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;


namespace sweetSystem
{

    public class RawPrinterHelper
    {
        static string printerName="POS-80(copy of 2)";


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            public string pDocName;
            public string pOutputFile;
            public string pDataType;
        }

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA",
            SetLastError = true, CharSet = CharSet.Ansi)]
        static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter",
            SetLastError = true)]
        static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA",
            SetLastError = true, CharSet = CharSet.Ansi)]
        static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter",
            SetLastError = true)]
        static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter",
            SetLastError = true)]
        static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter",
            SetLastError = true)]
        static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter",
            SetLastError = true)]
        static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        public static bool SendStringToPrinter(string printerName, string text)
        {
            IntPtr pBytes = Marshal.StringToCoTaskMemAnsi(text);

            OpenPrinter(printerName, out IntPtr hPrinter, IntPtr.Zero);

            DOCINFOA di = new DOCINFOA();
            di.pDocName = "Test Print";
            di.pDataType = "RAW";

            StartDocPrinter(hPrinter, 1, di);
            StartPagePrinter(hPrinter);

            WritePrinter(hPrinter, pBytes, text.Length, out _);

            EndPagePrinter(hPrinter);
            EndDocPrinter(hPrinter);
            ClosePrinter(hPrinter);

            Marshal.FreeCoTaskMem(pBytes);

            return true;
        }
        public static bool SendBytesToPrinter( byte[] bytes)
        {
            IntPtr pUnmanagedBytes = Marshal.AllocCoTaskMem(bytes.Length);
            Marshal.Copy(bytes, 0, pUnmanagedBytes, bytes.Length);

            OpenPrinter(printerName, out IntPtr hPrinter, IntPtr.Zero);

            DOCINFOA di = new DOCINFOA();
            di.pDocName = "Receipt";
            di.pDataType = "RAW";

            StartDocPrinter(hPrinter, 1, di);
            StartPagePrinter(hPrinter);

            WritePrinter(hPrinter, pUnmanagedBytes, bytes.Length, out _);

            EndPagePrinter(hPrinter);
            EndDocPrinter(hPrinter);
            ClosePrinter(hPrinter);

            Marshal.FreeCoTaskMem(pUnmanagedBytes);

            return true;
        }


        public static void PrintOut(string arabicText)
        {
            byte[] img = ArabicImagePrinter.CreateImageBytes(arabicText);

            File.WriteAllBytes("debug.png", img);

            byte[] escposImage = EscPosImage.ToRaster(img);

            byte[] feed = {
            0x0A,0x0A,0x0A,
            0x0A,0x0A,0x0A,
            0x0A,0x0A,0x0A,
            0x0A,0x0A
            };

            byte[] cut = { 0x1D, 0x56, 0x00 };

            SendBytesToPrinter(escposImage);

            Thread.Sleep(1000);

            SendBytesToPrinter(feed);

            Thread.Sleep(600);

            //SendBytesToPrinter(cut);
        }


    }
}
