using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PcapDotNet.Packets;

namespace Sniffer
{
	class ParserHelper
	{
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

		private static const int WM_SETREDRAW = 11; 

		/// <summary>
		/// Convert a byte array to hex string array
		/// </summary>
		/// <param name="bytes">The byte array to convert</param>
		/// <returns>Returns a string array of bytes in hex form</returns>
		public static string[] ByteToHexString(byte[] bytes)
		{
			List<string> rs = new List<string>();

			foreach (byte b in bytes) {
				string hex = string.Format("{0:X2}", b);
				rs.Add(hex);
			}

			return rs.ToArray();
		}


		/// <summary>
		/// Encode a byte array to ASCII string array
		/// Escape invisible character to a '.'
		/// </summary>
		/// <param name="bytes">The byte array to encode</param>
		/// <returns>Returns a string array of bytes in ASCII form</returns>
		public static string[] EncodeBytes(byte[] bytes)
		{
			List<string> rs = new List<string>();
			char c;

			foreach (byte b in bytes) {
				if (b < (byte)'!' || b > (byte)'~') {
					c = '.';
				}
				else {
					c = (char)b;
				}
				rs.Add(string.Format("{0}", c));
			}

			return rs.ToArray();
		}

		/// <summary>
		/// We need to update Control content in the owner thread context
		/// We need to call Ctrl.BeginInvoke
		/// </summary>
		/// <param name="ctrl">Control to update</param>
		/// <param name="param">Update parameter</param>
		public delegate void UIHandler(object ctrl, object param);
		public delegate void UIHandlerEx(object ctrl, object[] param);
		public static void UpdateFrameUI(object ctrl, object[] param)
		{
			ListView frames = (ListView)ctrl;
			ListViewItem item = (ListViewItem)param[0];

			frames.Items.Add(item);

			ToolStripButton btn = (ToolStripButton)param[1];
			if (frames.Items.Count != 0)
				btn.Enabled = true;
			else
				btn.Enabled = false;

			Packet packet = (Packet)param[2];
			PacketSniffer.DumpDetailsPacket(packet);
		}

		public static void UpdateDetailsUI(object ctrl, object param)
		{
			ListView f_details = (ListView)ctrl;
			List<ListViewItem> items = (List<ListViewItem>)param;

			//f_details.Items.Clear();
			SendMessage(f_details.Handle, WM_SETREDRAW, false, 0);
			f_details.Items.AddRange(items.ToArray());
			f_details.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			SendMessage(f_details.Handle, WM_SETREDRAW, true, 0);
		}

		public static void UpdateDumpUI(object ctrl, object param)
		{
			TextBox text = (TextBox)ctrl;
			List<string> lines = (List<string>)param;

			text.Clear();
			text.Text = string.Join("\r\n", lines.ToArray());
		}
	}
}
