using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Sniffer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Do not send anonymous statistics about the usage of Pcap.Net
            PcapDotNet.Analysis.PcapDotNetAnalysis.OptIn = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SnifferMain());
        }
    }
}
