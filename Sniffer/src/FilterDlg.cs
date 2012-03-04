using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace Sniffer
{
	public partial class FilterDlg : Form
	{
		public FilterDlg()
		{
			InitializeComponent();
		}

		private void FilterDlg_Activated(object sender, EventArgs e)
		{
			// Set control status according to filter settings
			SnifferFilter filter = SnifferConfig.Filter;
			arp_chk.Checked = filter.bARP;
			tcp_chk.Checked = filter.bTCP;
			udp_chk.Checked = filter.bUDP;

			bool bSrc = filter.bSrc;
			src_ip_chk.Checked = bSrc;
			src_ip_label.Enabled = bSrc;
			src_port_label.Enabled = bSrc;
			src_ip.Enabled = bSrc;
			if (filter.srcIP != null)
				src_ip.SetAddressBytes(filter.srcIP.GetAddressBytes());
			src_port.Enabled = bSrc;
			if (filter.srcPort != -1)
				src_port.Text = filter.srcPort.ToString();

			bool bDest = filter.bDest;
			dest_ip_chk.Checked = bDest;
			dest_ip_label.Enabled = bDest;
			dest_ip.Enabled = bDest;
			if (filter.destIP != null)
				dest_ip.SetAddressBytes(filter.destIP.GetAddressBytes());
			dest_port.Enabled = bDest;
			if (filter.destPort != -1)
				dest_port.Text = filter.destPort.ToString();
			dest_port_label.Enabled = bDest;
		}

		private void ok_btn_Click(object sender, EventArgs e)
		{
			int iport;
			bool bOK;
			string port;
			byte[] addr_b;
			byte[] empty = { 0, 0, 0, 0 };

			// Save current config
			SnifferFilter filter = SnifferConfig.Filter;
			filter.bARP = arp_chk.Checked;
			filter.bTCP = tcp_chk.Checked;
			filter.bUDP = udp_chk.Checked;

			if (dest_ip_chk.Checked) {
				addr_b = dest_ip.GetAddressBytes();
				if (!addr_b.SequenceEqual(empty))
					filter.destIP = new IPAddress(addr_b);
				port = dest_port.Text;
				bOK = int.TryParse(port, out iport);
				if (bOK && iport < 0xFFFF && iport >= 0) {
					filter.destPort = iport;
				}
				else {
					filter.destPort = -1;
				}
			}
			else{
				filter.destIP = null;
				filter.destPort = -1;
			}

			if (src_ip_chk.Checked) {
				addr_b = src_ip.GetAddressBytes();
				if (!addr_b.SequenceEqual(empty))
					filter.srcIP = new IPAddress(addr_b);
				port = src_port.Text;
				bOK = int.TryParse(port, out iport);
				if (bOK && iport < 0xFFFF && iport >= 0) {
					filter.srcPort = iport;
				}
				else {
					filter.srcPort = -1;
				}
			}
			else {
				filter.srcIP = null;
				filter.srcPort = -1;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancel_btn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void dest_ip_chk_CheckedChanged(object sender, EventArgs e)
		{
			bool bDest = dest_ip_chk.Checked;
			dest_ip_label.Enabled = bDest;
			dest_ip.Enabled = bDest;
			dest_port.Enabled = bDest;
			dest_port_label.Enabled = bDest;
			
			if (!bDest) {
				dest_ip.Clear();
				dest_port.Text = "";
			}

		}

		private void src_ip_chk_CheckedChanged(object sender, EventArgs e)
		{
			bool bSrc = src_ip_chk.Checked;
			src_ip_label.Enabled = bSrc;
			src_port_label.Enabled = bSrc;
			src_ip.Enabled = bSrc;
			src_port.Enabled = bSrc;

			if (!bSrc) {
				src_ip.Clear();
				src_port.Text = "";
			}
		}
	}
}
