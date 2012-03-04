using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using System.Collections.ObjectModel;
using System.Net;
using PcapDotNet.Packets.Ethernet;

namespace Sniffer
{
	class ArpParser
	{
		/// <summary>
		/// Handle ARP packets
		/// </summary>
		/// <param name="packet">The EthernetDatagram</param>
		/// <param name="arp">The ArpDatagram to parse</param>
		public static void HandleARP(Packet packet, ArpDatagram arp, 
			ref UInt64 frame_id, object[] ctrl)
		{
			ListViewItem item = new ListViewItem(frame_id.ToString());
			frame_id++;
			List<string> packet_info = new List<string>();
			ListView frames = (ListView)ctrl[0];
			EthernetDatagram ethernet = packet.Ethernet;

			packet_info.Add(packet.Timestamp.ToString("hh:mm:ss.fff tt"));
			packet_info.Add(arp.SenderProtocolIpV4Address.ToString());
			packet_info.Add(arp.TargetProtocolIpV4Address.ToString());
			packet_info.Add(ethernet.Source.ToString());
			packet_info.Add(ethernet.Destination.ToString());
			packet_info.Add("ARP");
			packet_info.Add(arp.Length.ToString());

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
		/// Format an ARP packet
		/// </summary>
		/// <param name="arp">The ARP packet to be parsed</param>
		/// <param name="ctrl">Contorls to update information with
		/// ctrl[0] is a ListView
		/// ctrl[1] is a TextBox
		/// </param>
		public static void ParseARPPacket(ArpDatagram arp, object[] ctrl)
		{
			if (arp == null || ctrl == null
				|| ctrl[0] == null || ctrl[1] == null) return;

			SnifferMain.datagram = arp;

			List<ListViewItem> items = new List<ListViewItem>();

			ListViewItem item = new ListViewItem("Packet Type");
			item.SubItems.Add("ARP");
			items.Add(item);

			item = new ListViewItem("HardwareLength");
			item.SubItems.Add(arp.HardwareLength.ToString());
			items.Add(item);

			item = new ListViewItem("HardwareType");
			item.SubItems.Add(arp.HardwareType.ToString());
			items.Add(item);

			item = new ListViewItem("HeaderLength");
			item.SubItems.Add(arp.HeaderLength.ToString());
			items.Add(item);

			item = new ListViewItem("Operation");
			item.SubItems.Add(arp.Operation.ToString());
			items.Add(item);

			item = new ListViewItem("ProtocolLength");
			item.SubItems.Add(arp.ProtocolLength.ToString());
			items.Add(item);

			item = new ListViewItem("ProtocolType");
			item.SubItems.Add(arp.ProtocolType.ToString());
			items.Add(item);

			item = new ListViewItem("SenderHardwareAddress");
			ReadOnlyCollection<byte> addr = arp.SenderHardwareAddress;
			string address = String.Join("-", ParserHelper.ByteToHexString(addr.ToArray()));
			item.SubItems.Add(address);
			items.Add(item);

			item = new ListViewItem("SenderProtocolAddress");
			address = new IPAddress(arp.SenderProtocolAddress.ToArray()).ToString();
			item.SubItems.Add(address);
			items.Add(item);

			item = new ListViewItem("TargetHardwareAddress");
			addr = arp.TargetHardwareAddress;
			address = string.Join("-", ParserHelper.ByteToHexString(addr.ToArray()));
			item.SubItems.Add(address);
			items.Add(item);

			item = new ListViewItem("TargetProtocolAddress");
			address = new IPAddress(arp.TargetProtocolAddress.ToArray()).ToString();
			item.SubItems.Add(address);
			items.Add(item);

			ListView f_details = (ListView)ctrl[0];
			object[] param = new object[2];
			param[0] = f_details;
			param[1] = items;
			f_details.BeginInvoke(new ParserHelper.UIHandler(ParserHelper.UpdateDetailsUI), param);

			PacketParser.DumpPacket(arp, ctrl[1]);
		}

	}
}
