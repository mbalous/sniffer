using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using System.Windows.Forms;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Packets.Ethernet;

namespace Sniffer
{
	class IPParser
	{
		/// <summary>
		/// Handle IPV4 packets, including TCP and UDP packets
		/// </summary>
		/// <param name="packet">The IpV4Datagram to parse</param>
		public static void HandleIPV4(Packet packet, IpV4Datagram ip,
			ref UInt64 frame_id, object[] ctrl)
		{
			ListViewItem item = new ListViewItem(frame_id.ToString());
			frame_id++;
			List<string> packet_info = new List<string>();
			ListView frames = (ListView)ctrl[0];
			EthernetDatagram ethernet = packet.Ethernet;

			switch (ip.Protocol) {
				case IpV4Protocol.Udp: {
						UdpDatagram udp = ip.Udp;
						packet_info.Add(packet.Timestamp.ToString("hh:mm:ss.fff tt"));
						packet_info.Add(ip.Source + ":" + udp.SourcePort);
						packet_info.Add(ip.Destination + ":" + udp.DestinationPort);
						packet_info.Add(ethernet.Source.ToString());
						packet_info.Add(ethernet.Destination.ToString());
						packet_info.Add("UDP");
						packet_info.Add(udp.Length.ToString());

						break;
					}
				case IpV4Protocol.Tcp: {
						TcpDatagram tcp = ip.Tcp;
						packet_info.Add(packet.Timestamp.ToString("hh:mm:ss.fff tt"));
						packet_info.Add(ip.Source + ":" + tcp.SourcePort);
						packet_info.Add(ip.Destination + ":" + tcp.DestinationPort);
						packet_info.Add(ethernet.Source.ToString());
						packet_info.Add(ethernet.Destination.ToString());
						packet_info.Add("TCP");
						packet_info.Add(tcp.Length.ToString());

						break;
					}
				default: {
						item = null;
						break;
					}
			}

			// update UI
			if (item != null) {
				item.SubItems.AddRange(packet_info.ToArray());
				object[] param = new object[2];
				param[0] = frames;
				object[] o = new object[3];
				o[0] = item;
				o[1] = ctrl[1];
				o[2] = packet;
				param[1] = o;
 				frames.BeginInvoke(new ParserHelper.UIHandlerEx(ParserHelper.UpdateFrameUI), param);
			}
		}

		/// <summary>
		/// Parse an IP packet
		/// Dispatch TCP and UDP packets
		/// </summary>
		/// <param name="ip">The IP packet to be parsed</param>
		/// <param name="ctrl"></param>
		public static void ParseIPPacket(IpV4Datagram ip, object[] ctrl)
		{
			if (ip == null || ctrl == null
				|| ctrl[0] == null || ctrl[1] == null) return;

			List<ListViewItem> items = new List<ListViewItem>();
			ListViewItem item = new ListViewItem("IPV4");
			string estr = "Destination = " + ip.Destination;
			estr += ", Source = " + ip.Source;
			estr += ", Next Protocol = " + ip.Protocol;
			estr += ", Packet ID = " + ip.Identification;
			estr += ", Total IP length = " + ip.Length;
			item.SubItems.Add(estr);
			items.Add(item);

			ListView f_details = (ListView)ctrl[0];

			object[] param = new object[2];
			param[0] = f_details;
			param[1] = items;
			f_details.BeginInvoke(new ParserHelper.UIHandler(ParserHelper.UpdateDetailsUI), param);

			switch (ip.Protocol)
			{
				case IpV4Protocol.Tcp:
					{
						TcpDatagram tcp = ip.Tcp;
						SnifferMain.datagram = tcp;
						SnifferMain.payload = tcp.Payload;
						ParseTcpPacket(tcp, ctrl[0]);
						PacketParser.DumpPacket(tcp, ctrl[1]);
						break;
					}

				case IpV4Protocol.Udp:
					{
						UdpDatagram udp = ip.Udp;
						SnifferMain.datagram = udp;
						SnifferMain.payload = udp.Payload;
						ParseUdpPacket(udp, ctrl[0]);
						PacketParser.DumpPacket(udp, ctrl[1]);
						break;
					}

				default: break;
			}
		}

		private static void ParseUdpPacket(UdpDatagram udp, object ctrl)
		{
			if (udp == null || ctrl == null) return;
			ListView f_details = (ListView)ctrl;

			List<ListViewItem> items = new List<ListViewItem>();

			ListViewItem item = new ListViewItem("Packet Type");
			item.SubItems.Add("UDP");
			items.Add(item);

			item = new ListViewItem("SrcPort");
			item.SubItems.Add(udp.SourcePort.ToString());
			items.Add(item);

			item = new ListViewItem("DstPort");
			item.SubItems.Add(udp.DestinationPort.ToString());
			items.Add(item);

			item = new ListViewItem("Checksum");
			string checksum = string.Format("0x{0:X}", udp.Checksum);
			item.SubItems.Add(checksum);
			items.Add(item);

			item = new ListViewItem("Payload Length");
			item.SubItems.Add(string.Format("{0} ({1:x})", udp.Payload.Length, udp.Payload.Length));
			items.Add(item);

			item = new ListViewItem("TotalLength");
			ushort len = udp.TotalLength;
			string len_str = string.Format("{0} (0x{1:X})", len, len);
			item.SubItems.Add(len_str);
			items.Add(item);

			object[] param = new object[2];
			param[0] = f_details;
			param[1] = items;
			f_details.BeginInvoke(new ParserHelper.UIHandler(ParserHelper.UpdateDetailsUI), param);
		}

		private static void ParseTcpPacket(TcpDatagram tcp, object ctrl)
		{
			if (tcp == null || ctrl == null) return;
			ListView f_details = (ListView)ctrl;

			List<ListViewItem> items = new List<ListViewItem>();

			ListViewItem item = new ListViewItem("Packet Type");
			item.SubItems.Add("TCP");
			items.Add(item);

			item = new ListViewItem("SrcPort");
			item.SubItems.Add(tcp.SourcePort.ToString());
			items.Add(item);

			item = new ListViewItem("DstPort");
			item.SubItems.Add(tcp.DestinationPort.ToString());
			items.Add(item);
			
			item = new ListViewItem("AcknowledgmentNumber");
			uint ack = tcp.AcknowledgmentNumber;
			string ack_str = string.Format("{0} (0x{1:X})", ack, ack);
			item.SubItems.Add(ack_str);
			items.Add(item);

			item = new ListViewItem("Checksum");
			string checksum = string.Format("0x{0:X}", tcp.Checksum);
			item.SubItems.Add(checksum);
			items.Add(item);

			item = new ListViewItem("ControlBits");
			item.SubItems.Add(tcp.ControlBits.ToString());
			items.Add(item);

			item = new ListViewItem("HeaderLength");
			item.SubItems.Add(tcp.HeaderLength.ToString());
			items.Add(item);

			item = new ListViewItem("NextSequenceNumber");
			uint next = tcp.NextSequenceNumber;
			string next_str = string.Format("{0} (0x{1:X})", next, next);
			item.SubItems.Add(next_str);
			items.Add(item);

			item = new ListViewItem("Options");
			string opt = tcp.Options.ToString();
			int start = opt.IndexOf("{");
			int end = opt.LastIndexOf("}");
			opt = opt.Substring(start + 1, end - start - 1);
			item.SubItems.Add(opt);
			items.Add(item);

			item = new ListViewItem("Payload Length");
			item.SubItems.Add(string.Format("{0} ({1:x})", tcp.Payload.Length, tcp.Payload.Length));
			items.Add(item);

			item = new ListViewItem("RealHeaderLength");
			item.SubItems.Add(tcp.RealHeaderLength.ToString());
			items.Add(item);

			item = new ListViewItem("SequenceNumber");
			uint sn = tcp.NextSequenceNumber;
			string sn_str = string.Format("{0} (0x{1:X})", sn, sn);
			item.SubItems.Add(sn_str);
			items.Add(item);

			item = new ListViewItem("UrgentPointer");
			item.SubItems.Add(tcp.UrgentPointer.ToString());
			items.Add(item);

			item = new ListViewItem("Window");
			item.SubItems.Add(tcp.Window.ToString());
			items.Add(item);

			object[] param = new object[2];
			param[0] = f_details;
			param[1] = items;
			f_details.BeginInvoke(new ParserHelper.UIHandler(ParserHelper.UpdateDetailsUI), param);
		}
	}
}
