using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sniffer;
using System.Net;

namespace SnifferTest
{
	[TestClass]
	public class FilterTest
	{
		[TestMethod]
		public void TestFilterGenerator()
		{
			SnifferFilter filter = new SnifferFilter(
				true, true, true,
				null, -1, null, -1);

			// Protocol test
			string filter_s = filter.FilterString;
			Assert.AreEqual("(arp or (ip proto \\tcp) or (ip proto \\udp))", filter_s);
			filter.bARP = false;
			filter.bTCP = false;
			filter.bUDP = false;
			filter_s = filter.FilterString;
			Assert.AreEqual("ip", filter_s);
			filter.bUDP = true;
			filter.bARP = true;
			filter_s = filter.FilterString;
			Assert.AreEqual("(arp or (ip proto \\udp))", filter_s);

			// IP address test
			byte[] src = { 192, 168, 1, 1 };
			filter.srcIP = new IPAddress(src);
			filter_s = filter.FilterString;
			Assert.AreEqual("(arp or (ip proto \\udp)) and (src host 192.168.1.1)", filter_s);

			filter.destPort = 80;
			filter_s = filter.FilterString;
			Assert.AreEqual("(arp or (ip proto \\udp)) and (dst port 80) and (src host 192.168.1.1)", filter_s);

			filter.srcPort = 4541;
			filter_s = filter.FilterString;
			Assert.AreEqual("(arp or (ip proto \\udp)) and (dst port 80) and (src host 192.168.1.1) and (src port 4541)", filter_s);

			byte[] dst = { 8, 8, 8, 8 };
			filter.destIP = new IPAddress(dst);
			filter_s = filter.FilterString;
			Assert.AreEqual("(arp or (ip proto \\udp)) and (dst host 8.8.8.8) and (dst port 80) and (src host 192.168.1.1) and (src port 4541)", filter_s);

			filter.srcIP = null;
			filter_s = filter.FilterString;
			Assert.AreEqual("(arp or (ip proto \\udp)) and (dst host 8.8.8.8) and (dst port 80) and (src port 4541)", filter_s);
		}
	}
}
