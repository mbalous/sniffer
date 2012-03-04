using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Core;

namespace Sniffer
{
	class CaptureWorker
	{
		private Thread captureThread;
		private PacketSniffer packetSniffer;
		private UInt64 frame_id;
		private object[] ctrl;
		public UInt64 FrameId
		{
			get
			{
				return frame_id;
			}

			set
			{
				frame_id = value;
			}
		}
		private bool IsBadDumpFile;



		public CaptureWorker()
		{
			captureThread = null;
			packetSniffer = null;
			frame_id = 1;
		}


		/// <summary>
		/// Start the capture in a new thread
		/// </summary>
		/// <param name="deviceIndex">The device index</param>
		/// <param name="ctrl">Control to update information with</param>
		public void StartCapture(int deviceIndex, object[] ctrl)
		{
			this.ctrl = ctrl;

			captureThread = new Thread(DoCapture);
			captureThread.Start(deviceIndex);
		}

		/// <summary>
		/// Run an off-line capture
		/// </summary>
		/// <param name="file">The dump file to read from
		/// </param>
		public bool StartOfflineCapture(string file, object[] ctrl)
		{
			if (file == null) {
				file = PacketSniffer.DumpFileName;
			}

			// Save dump file name
			PacketSniffer.DumpFileName = file;

			this.ctrl = ctrl;
			frame_id = 1;

			// Open the capture file
			try {
				Thread thread = new Thread(DoOfflineCapture);
				thread.Start(file);
				thread.Join();
			}
			catch (Exception) {
				return false;
			}

			return !IsBadDumpFile;
		}


		private void DoOfflineCapture(object param)
		{
			string file = (string)param;
			IsBadDumpFile = false;

			PacketSniffer.StartOfflineCapture(file, UpdateFrames, ref IsBadDumpFile);
		}


		private void DoCapture(object deviceIndex)
		{
			packetSniffer = new PacketSniffer((int)deviceIndex);
			String Error = null;
			packetSniffer.StartCapture(UpdateFrames, out Error);
		}


		/// <summary>
		/// Stop the active capture and wait for working thread termination
		/// </summary>
		public void StopCapture()
		{
			if (packetSniffer != null) {
				packetSniffer.StopCapture();
				captureThread.Join();

				frame_id = 1;
			}
		}


		/// <summary>
		/// Restart capture if there is an active capture
		/// </summary>
		/// <param name="deviceIndex">Device index to capture</param>
		/// <param name="ctrl">Control to update information with</param>
		public void RestartCapture(int deviceIndex, object[] ctrl)
		{
			if (captureThread != null) {
				StopCapture();
				StartCapture(deviceIndex, ctrl);
			}
		}

		/// <summary>
		/// Update packet frames
		/// </summary>
		/// <param name="packet">Packet to parse</param>
		private void UpdateFrames(Packet packet)
		{
			PacketParser.HandlePacket(packet, ref frame_id, ctrl);
		}

	}
}
