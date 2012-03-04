using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.Transport;
using System.IO;

namespace Sniffer
{
	class PacketSniffer
	{
		private static  PacketCommunicator communicator;
		private static PacketDumpFile detailsDumper;
		private static string detailsFile;
		public static string DumpFileName { get; set; }

		public PacketSniffer(int DeviceIndex)
		{
			// Retrieve the device list from the local machine
			IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;
			PacketDevice SelectedDevice = allDevices[DeviceIndex];

			communicator = SelectedDevice.Open(65536,                       // portion of the packet to capture
																			// 65536 guarantees that the whole packet will be captured on all the link layers
									PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
									1000);

			if (detailsDumper == null) {
				detailsFile = Path.GetTempFileName();
				detailsDumper = communicator.OpenDump(detailsFile);
			}

			ResetDumpFile();
		}

		public static void DumpDetailsPacket(Packet packet)
		{
			if (detailsDumper == null) {
				detailsFile = Path.GetTempFileName();
				detailsDumper = communicator.OpenDump(detailsFile);
			}
			detailsDumper.Dump(packet);
		}

		public static void ResetDetailsDumper()
		{
			detailsDumper.Dispose();
			File.Delete(detailsFile);
			detailsFile = Path.GetTempFileName();
			detailsDumper = communicator.OpenDump(detailsFile);
		}


		/// <summary>
		/// Reset DumpFileName to default value
		/// </summary>
		public static void ResetDumpFile()
		{
			try {
				string cwd = Directory.GetCurrentDirectory();
				DumpFileName = cwd + "\\packets.cap";
			}
			catch (Exception) {
				DumpFileName = "packets.cap";
			}
		}

		/// <summary>
		/// Start an off-line capture
		/// </summary>
		/// <param name="file">The dump file name to capture</param>
		/// <param name="callback">Callback to handle packets</param>
		/// <param name="IsBadDumpFile">Flag indicates whether the dump file is invalid</param>
		public static void StartOfflineCapture(string file, HandlePacket callback, ref bool IsBadDumpFile)
		{
			PacketCommunicator pc = communicator;
			try {
				// Create the off-line device
				OfflinePacketDevice selectedDevice = new OfflinePacketDevice(file);

				communicator =
					selectedDevice.Open(65536,                      // portion of the packet to capture
																	// 65536 guarantees that the whole packet will be captured on all the link layers
							PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
							1000);                                  // read timeout
				// Compile the filter
				using (BerkeleyPacketFilter filter =
					communicator.CreateFilter(SnifferConfig.Filter.FilterString)) {
					communicator.SetFilter(filter);
				}

				// Read and dispatch packets until EOF is reached
				communicator.ReceivePackets(0, callback);
			}
			catch (Exception) {
				IsBadDumpFile = true;
			}
			finally {
				if (pc != null)
					communicator = pc;
			}

		}


		/// <summary>
		/// Setup filter and start capture
		/// Return when an error occurs or StopCapture is called
		/// </summary>
		/// <param name="callback">Callback to handle packets</param>
		/// <param name="ErrorMsg">When return contains the error description</param>
		public void StartCapture(HandlePacket callback, out string ErrorMsg)
		{
			// Check the link layer. We support only Ethernet
			if (communicator.DataLink.Kind != DataLinkKind.Ethernet) {
				ErrorMsg = "This program works only on Ethernet networks.";
				return;
			}

			// Compile the filter
			using (BerkeleyPacketFilter filter =
				communicator.CreateFilter(SnifferConfig.Filter.FilterString)) {
				communicator.SetFilter(filter);
			}

			using (PacketDumpFile dumpFile = communicator.OpenDump(DumpFileName))
			{
				try {
					// start the capture
					communicator.ReceivePackets(0,
						delegate(Packet packet)
						{
							dumpFile.Dump(packet);
							callback(packet);
						});
				}
				catch (Exception ex){
					ErrorMsg = ex.Message;
				}

			}

			ErrorMsg = null;
		}

		/// <summary>
		/// Stop capture and return the number of captured packets
		/// </summary>
		/// <returns></returns>
		public uint StopCapture()
		{
			communicator.Break();
			PacketTotalStatistics statistics = communicator.TotalStatistics;
			return statistics.PacketsCaptured;
		}

		/// <summary>
		/// Retrieve details about a packet
		/// </summary>
		/// <param name="index">Index of the packet to retrieve</param>
		/// <param name="ctrl">UI elements</param>
		public static void RetrievePacketDetails(int index, object[] ctrl)
		{
			// Create the off-line device
			OfflinePacketDevice selectedDevice = new OfflinePacketDevice(detailsFile);

			// Open the capture file
			using (PacketCommunicator communicator =
				selectedDevice.Open(65536,                                  // portion of the packet to capture
				// 65536 guarantees that the whole packet will be captured on all the link layers
									PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
									1000))                                  // read timeout
			{
				Packet packet = null;
				try {
					while (index-- > 0)
						communicator.ReceivePacket(out packet);
				}
				catch (Exception) {
					return;
				}


				PacketParser.ParsePacket(packet, ctrl);
			}
		}

	}
}
