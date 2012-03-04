using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcapDotNet.Base;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using System.Net;

namespace Sniffer
{
	/// <summary>
	/// Represents a filter
	/// </summary>
	public class SnifferFilter
	{
		public SnifferFilter(bool bARP, bool bTCP, bool bUDP,
			IPAddress srcIP, int srcPort,
			IPAddress destIP, int destPort)
		{
			this.bARP = bARP;
			this.bTCP = bTCP;
			this.bUDP = bUDP;
			this.srcIP = srcIP;
			this.srcPort = srcPort;
			this.destIP = destIP;
			this.destPort = destPort;
		}

		public bool bARP {get; set;}

		public bool bTCP {get; set;}

		public bool bUDP {get; set;}

		public IPAddress srcIP { get; set; }

		public int srcPort {get; set;}

		public IPAddress destIP {get; set;}

		public int destPort {get; set;}

		public bool bSrc
		{
			get { return srcIP != null || srcPort != -1; }
		}

		public bool bDest
		{
			get { return destIP != null || destPort != -1; }
		}

		/// <summary>
		/// Retrieve the filter string from current filter
		/// </summary>
		public string FilterString
		{
			get
			{
				string filter = "";
				List<string> parts = new List<string>();

				// Protocol filter
				if (bARP)
					parts.Add("arp");
				if (bTCP)
					parts.Add("(ip proto \\tcp)");
				if (bUDP)
					parts.Add("(ip proto \\udp)");
				if (!bARP && !bTCP && !bUDP)
					parts.Add("ip");

				int len = parts.Count;
				string[] arr = parts.ToArray();
				for (int i = 0; i < len; i++) {
					filter += arr[i];
					if (i < len - 1)
						filter += " or ";
				}
				if (len > 1)
					filter = "(" + filter + ")";

				// IP address filter
				if (destIP != null)
					filter = filter + " and (dst host " + destIP + ")";
				if (destPort != -1)
					filter = filter + " and (dst port " + destPort + ")";
				if (srcIP != null)
					filter = filter + " and (src host " + srcIP + ")";
				if (srcPort != -1)
					filter = filter + " and (src port " + srcPort + ")";

				return filter;
			}
		}

	}


    class SnifferConfig
    {
		/// <summary>
		/// Retrieve a device list from OS
		/// </summary>
        public static IList<String> AllDevices
        {
            get
            {
                IList<String> rs = new List<String>();
				IList<LivePacketDevice> allDevices;

				try {
					// Retrieve the device list from the local machine
					allDevices = LivePacketDevice.AllLocalMachine;
				}
				catch (Exception) {
					return rs;
				}

                if (allDevices.Count == 0) {
                    rs.Add("No device found");
                }

                // Traverse the list
                foreach (LivePacketDevice device in allDevices) {
                    // Use device description if any,
                    // otherwise use device name
                    String desc = device.Description;
                    String s = desc;
                    if (desc != null) {
                        // Remove white-spaces inside device description
                        int end = desc.LastIndexOf('\'');
                        if (end != -1 &&
                            string.IsNullOrWhiteSpace(desc.Substring(end - 1, 1))) {
                            int start = end - 1;
                            char[] tmp = desc.ToCharArray();
                            while (tmp[start] == ' ' || tmp[start] == '\t') {
                                start--;
                            }

                            String s1 = desc.Substring(0, start + 1);
                            String s2 = desc.Substring(end);
                            s = String.Concat(s1, s2);
                        }

                        rs.Add(s);
                    }
                    else {
                        rs.Add(device.Name);
                    }
                }

                return rs;
            }
        }

		public static SnifferFilter Filter { get; set;}
	}
}
