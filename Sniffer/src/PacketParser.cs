using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Arp;
using System.Windows.Forms;
using System.IO;

namespace Sniffer
{
	class PacketParser
	{
		/// <summary>
		/// Update ctrl with packet information
		/// Increment frame_id by one
		/// </summary>
		/// <param name="packet">The packet to handle</param>
		/// <param name="frame_id">The frame id, for UI display</param>
		/// <param name="ctrl">The control to display information</param>
		public static void HandlePacket(Packet packet, ref UInt64 frame_id, object[] ctrl)
		{
			EthernetDatagram ethernet = packet.Ethernet;
			if (ethernet == null) return;

			switch (ethernet.EtherType) {
				case EthernetType.IpV4: {
						IpV4Datagram ip = ethernet.IpV4;
						IPParser.HandleIPV4(packet, ip, ref frame_id, ctrl);
						break;
					}

				case EthernetType.Arp: {
						ArpDatagram arp = ethernet.Arp;
						ArpParser.HandleARP(packet, arp, ref frame_id, ctrl);
						break;
					}

				default:
					break;
			}
		}


		/// <summary>
		/// Packet parser dispatcher
		/// </summary>
		/// <param name="packet">The packet to be parsed</param>
		/// <param name="ctrl">Contorls to update details with</param>
		public static void ParsePacket(Packet packet, object[] ctrl)
		{
			if (packet == null || ctrl == null || 
				ctrl[0] == null || ctrl[1] == null) return;

			EthernetDatagram ethernet = packet.Ethernet;

			List<ListViewItem> items = new List<ListViewItem>();
			ListViewItem item = new ListViewItem("Ethernet");
			string estr = "Etype = " + ethernet.EtherType;
			estr += ", DestinationAddress = " + ethernet.Destination;
			estr += ", SourceAddress = " + ethernet.Source;
			item.SubItems.Add(estr);
			items.Add(item);

			ListView f_details = (ListView)ctrl[0];
			f_details.Items.Clear();

			object[] param = new object[2];
			param[0] = f_details;
			param[1] = items;
			f_details.BeginInvoke(new ParserHelper.UIHandler(ParserHelper.UpdateDetailsUI), param);

			switch (ethernet.EtherType) {
				case EthernetType.IpV4: {
						IpV4Datagram ip = ethernet.IpV4;
						IPParser.ParseIPPacket(ip, ctrl);
						break;
					}

				case EthernetType.Arp: {
						ArpDatagram arp = ethernet.Arp;
						ArpParser.ParseARPPacket(arp, ctrl);
						break;
					}

				default:
					break;
			}


			// Save packet for layed analyze
			SnifferMain.packet = packet;
		}

		/// <summary>
		/// Format a packet, e.g.
		/// Offset		Byte form				ASCII form
		/// 0000		F3 63 78 A7...			abcd...
		/// </summary>
		/// <param name="packet">Packet to dump</param>
		/// <param name="ctrl">UI control to update</param>
		public static void DumpPacket(Datagram packet, object ctrl)
		{
			int len = packet.Length;
			List<string> lines = new List<string>();
			string line = null;
			int offset = 0;
			const int step = 16;
			MemoryStream ms = packet.ToMemoryStream();

			while (len > 0) {
				int num = len >= step ? step : len;
				byte[] bytes = new byte[num];
				ms.Read(bytes, 0, num);

				line = string.Format("{0:X4}  ", offset);
				string[] hex = ParserHelper.ByteToHexString(bytes);
				line += string.Join(" ", hex);

				// Padding, if byte number is fewer than a line
				if (num < 16) {
					int padding = 16 -num;
					while (padding-- > 0)
						line += "   "; 
				}
				line += "  ";

				line += string.Join("", ParserHelper.EncodeBytes(bytes));
				lines.Add(line);

				offset += num;
				len -= num;
			}

			// Update UI
			TextBox text = (TextBox)ctrl;
			object[] param = new object[2];
			param[0] = ctrl;
			param[1] = lines;
 			text.BeginInvoke(new ParserHelper.UIHandler(ParserHelper.UpdateDumpUI), param);

		}
	}
}
