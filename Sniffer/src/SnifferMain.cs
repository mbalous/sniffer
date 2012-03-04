using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.IpV4;


namespace Sniffer
{
    public partial class SnifferMain : Form
    {
		private CaptureWorker worker;
		private bool IsOffline;
		private string OfflineDumpFile;

		public static Packet packet{get; set;}
		public static Datagram datagram {get; set;}
		public static Datagram payload {get; set;}
		
        public SnifferMain()
        {
            InitializeComponent();
			worker = null;
			IsOffline = false;
			OfflineDumpFile = null;
        }

        private void about_Click(object sender, EventArgs e)
        {
            AboutSniffer about = new AboutSniffer();

            if (about != null) {
                about.ShowDialog();
            }
        }

        private void SnifferMain_Shown(object sender, EventArgs e)
        {
			String max_str = null;

			// Setup initial tool strip status
			stop_cap.Enabled = false;
			clear_cap.Enabled = false;
			save_file.Enabled = false;

            // Update the device list
			IList<String> devices = SnifferConfig.AllDevices;
			if (devices.Count == 0) {
				start_cap.Enabled = false;
				device_opt.Enabled = false;
				open_file.Enabled = false;
				MessageBox.Show("Can not obtain device list\n\nSniffer.NET will exit.", "Sniffer.NET",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			else {
				device_opt.Items.AddRange(devices.ToArray<String>());

				// Find the longest string in device list
				int max_len = devices.Max(device => device.Length);
				foreach (String device in devices) {
					if (device.Length == max_len)
						max_str = device;
				}
				// For padding
				max_str += "WWW";
			}
            
            // Resize control width based on string length in pixel
            using(Graphics graphics = Graphics.FromImage(new Bitmap(1,1))) {
				if (max_str != null) {
					SizeF size = graphics.MeasureString(max_str, device_opt.Font);
					device_opt.DropDownWidth = size.ToSize().Width;
					device_opt.Size = size.ToSize();
					device_opt.SelectedIndex = 0;
				}

				// Setup ListView column width for performance reasons
				string[] values = {"Frame Number W", "99:99:99.999 WWW",
							   "999.999.999.999:99999 WWW", "999.999.999.999:99999 WWW",
							   "FF:FF:FF:FF:FF:FF WWW", "FF:FF:FF:FF:FF:FF WWW",
							  "Protocol Name W", "Length WWW"};

				Font font = frames.Font;
				for (int i = 0; i < values.Length; i++) {
					SizeF size = graphics.MeasureString(values[i], font);
					frames.Columns[i].Width = size.ToSize().Width; 
				}

            }


        }

		private void start_cap_Click(object sender, EventArgs e)
		{
			IsOffline = false;

			int deviceIndex = device_opt.SelectedIndex;
			worker = new CaptureWorker();
			object[] ctrls = new object[2];
			ctrls[0] = frames;
			ctrls[1] = clear_cap;
			worker.StartCapture(deviceIndex, ctrls);

			// Update tool strip status
			stop_cap.Enabled = true;
			start_cap.Enabled = false;
			open_file.Enabled = false;
			save_file.Enabled = true;
			device_opt.Enabled = false;
		}

		private void stop_cap_Click(object sender, EventArgs e)
		{
			if (worker != null) 
				worker.StopCapture();

			// Update tool strip status
			stop_cap.Enabled = false;
			start_cap.Enabled = true;
			open_file.Enabled = true;
			device_opt.Enabled = true;

		}

		private void clear_cap_Click(object sender, EventArgs e)
		{
			frames.Items.Clear();
			f_details.Items.Clear();
			h_details.Clear();

			if (worker != null)
				worker.FrameId = 1;

			PacketSniffer.ResetDetailsDumper();

			clear_cap.Enabled = false;
		}

		private void SnifferMain_Load(object sender, EventArgs e)
		{
			// Initialize capture filter
			SnifferFilter filter = new SnifferFilter(
				true, true, true,
				null, -1, null, -1);
			SnifferConfig.Filter = filter;
		}

		private void filter_opt_Click(object sender, EventArgs e)
		{
			FilterDlg dlg = new FilterDlg();
			DialogResult dr = dlg.ShowDialog();
			if (dr == DialogResult.OK){
				// User changed the filter
				// Restart capture using new filter if we are capturing now
				if (worker != null) {
					object[] ctrls = new object[2];
					ctrls[0] = frames;
					ctrls[1] = clear_cap;

					frames.Items.Clear();

					if (!IsOffline) {
						worker.StopCapture();

						PacketSniffer.ResetDetailsDumper();
						worker.StartOfflineCapture(null, ctrls);

						int deviceIndex = device_opt.SelectedIndex;
						worker.StartCapture(deviceIndex, ctrls);
					}
					else {
						PacketSniffer.ResetDetailsDumper();
						worker.StartOfflineCapture(OfflineDumpFile, ctrls);
					}
				}
			}
		}

		private void SnifferMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (worker != null)
				worker.StopCapture();
		}



		private void save_file_Click(object sender, EventArgs e)
		{
			DialogResult rs = save_dlg.ShowDialog(this);

			if (rs == DialogResult.OK) {
				// Copy the dumping file to new file
				string path = save_dlg.FileName;

				try {
					File.Copy(PacketSniffer.DumpFileName, path, true);
				}
				catch (Exception CopyError) {
					MessageBox.Show(this, CopyError.Message, "Sniffer.NET Error",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

		}

		private void open_file_Click(object sender, EventArgs e)
		{
			// Update tool strip status
			start_cap.Enabled = false;
			stop_cap.Enabled = false;
			filter_opt.Enabled = false;
			open_file.Enabled = false;

			IsOffline = true;

			DialogResult rs = open_dlg.ShowDialog(this);

			OfflineDumpFile = null;
			if (rs == DialogResult.OK) {
				string path = open_dlg.FileName;
				OfflineDumpFile = path;

				if (worker == null) {
					worker = new CaptureWorker();
				}

				frames.Items.Clear();
				f_details.Items.Clear();
				h_details.ResetText();

				object[] ctrls = new object[2];
				ctrls[0] = frames;
				ctrls[1] = clear_cap;

				this.Cursor = Cursors.WaitCursor;
				try {
					PacketSniffer.ResetDetailsDumper();
				}
				catch(Exception){
				}
				bool status = worker.StartOfflineCapture(path, ctrls);

				if (!status) {
					MessageBox.Show(this, "Bad dump file format", "Sniffer.NET",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				this.Cursor = Cursors.Arrow;
			}

			// Update tool strip status
			if (device_opt.Items.Count != 0)
				start_cap.Enabled = true;
			filter_opt.Enabled = true;
			open_file.Enabled = true;
		}

		/// <summary>
		/// Show details about a frame when selected
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frames_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected) {
				int id;
				bool rs = int.TryParse(e.Item.Text, out id);
				if (!rs) return;

				object[] param = new object[2];
				param[0] = f_details;
				param[1] = h_details;

				PacketSniffer.RetrievePacketDetails(id, param);
			}
		}

		private void f_details_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if (e.IsSelected) {
				ListViewItem item = e.Item;

				EthernetDatagram ethernet = packet.Ethernet;
				switch (item.Text) 
				{
					case "Ethernet":
						{
							// Update Ethernet details
							if (ethernet != null)
								PacketParser.DumpPacket(ethernet, h_details);
							break;
						}

					case "IPV4":
						{
							// Update IPV4 details
							if (ethernet != null) {
								IpV4Datagram ip = packet.Ethernet.IpV4;
								PacketParser.DumpPacket(ip, h_details);
							}
							break;
						}

					case "Payload Length":
						{
							PacketParser.DumpPacket(payload, h_details);
							break;
						}

					default: 
						{
							// Otherwise, use the last datagram
							PacketParser.DumpPacket(datagram, h_details);
							break;
						}
				}
			}
		}
    }
}
