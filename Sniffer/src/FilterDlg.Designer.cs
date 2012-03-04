namespace Sniffer
{
	partial class FilterDlg
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.filter_protocol = new System.Windows.Forms.GroupBox();
			this.udp_chk = new System.Windows.Forms.CheckBox();
			this.tcp_chk = new System.Windows.Forms.CheckBox();
			this.arp_chk = new System.Windows.Forms.CheckBox();
			this.dest_ip = new IPAddressControlLib.IPAddressControl();
			this.dest_ip_label = new System.Windows.Forms.Label();
			this.dest_port_label = new System.Windows.Forms.Label();
			this.dest_port = new Sniffer.NumTextBox();
			this.dest_ip_chk = new System.Windows.Forms.CheckBox();
			this.filter_ip = new System.Windows.Forms.GroupBox();
			this.src_ip_chk = new System.Windows.Forms.CheckBox();
			this.src_port = new Sniffer.NumTextBox();
			this.src_port_label = new System.Windows.Forms.Label();
			this.src_ip_label = new System.Windows.Forms.Label();
			this.src_ip = new IPAddressControlLib.IPAddressControl();
			this.ok_btn = new System.Windows.Forms.Button();
			this.cancel_btn = new System.Windows.Forms.Button();
			this.filter_protocol.SuspendLayout();
			this.filter_ip.SuspendLayout();
			this.SuspendLayout();
			// 
			// filter_protocol
			// 
			this.filter_protocol.Controls.Add(this.udp_chk);
			this.filter_protocol.Controls.Add(this.tcp_chk);
			this.filter_protocol.Controls.Add(this.arp_chk);
			this.filter_protocol.Location = new System.Drawing.Point(12, 12);
			this.filter_protocol.Name = "filter_protocol";
			this.filter_protocol.Size = new System.Drawing.Size(197, 44);
			this.filter_protocol.TabIndex = 0;
			this.filter_protocol.TabStop = false;
			this.filter_protocol.Text = "Filter Protocol";
			// 
			// udp_chk
			// 
			this.udp_chk.AutoSize = true;
			this.udp_chk.Location = new System.Drawing.Point(116, 20);
			this.udp_chk.Name = "udp_chk";
			this.udp_chk.Size = new System.Drawing.Size(49, 17);
			this.udp_chk.TabIndex = 2;
			this.udp_chk.Text = "UDP";
			this.udp_chk.UseVisualStyleBackColor = true;
			// 
			// tcp_chk
			// 
			this.tcp_chk.AutoSize = true;
			this.tcp_chk.Location = new System.Drawing.Point(62, 20);
			this.tcp_chk.Name = "tcp_chk";
			this.tcp_chk.Size = new System.Drawing.Size(47, 17);
			this.tcp_chk.TabIndex = 1;
			this.tcp_chk.Text = "TCP";
			this.tcp_chk.UseVisualStyleBackColor = true;
			// 
			// arp_chk
			// 
			this.arp_chk.AutoSize = true;
			this.arp_chk.Location = new System.Drawing.Point(7, 20);
			this.arp_chk.Name = "arp_chk";
			this.arp_chk.Size = new System.Drawing.Size(48, 17);
			this.arp_chk.TabIndex = 0;
			this.arp_chk.Text = "ARP";
			this.arp_chk.UseVisualStyleBackColor = true;
			// 
			// dest_ip
			// 
			this.dest_ip.AllowInternalTab = false;
			this.dest_ip.AutoHeight = true;
			this.dest_ip.BackColor = System.Drawing.SystemColors.Window;
			this.dest_ip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dest_ip.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dest_ip.Location = new System.Drawing.Point(58, 43);
			this.dest_ip.MinimumSize = new System.Drawing.Size(87, 20);
			this.dest_ip.Name = "dest_ip";
			this.dest_ip.ReadOnly = false;
			this.dest_ip.Size = new System.Drawing.Size(126, 20);
			this.dest_ip.TabIndex = 2;
			this.dest_ip.Text = "...";
			// 
			// dest_ip_label
			// 
			this.dest_ip_label.AutoSize = true;
			this.dest_ip_label.Location = new System.Drawing.Point(6, 46);
			this.dest_ip_label.Name = "dest_ip_label";
			this.dest_ip_label.Size = new System.Drawing.Size(48, 13);
			this.dest_ip_label.TabIndex = 3;
			this.dest_ip_label.Text = "Address:";
			// 
			// dest_port_label
			// 
			this.dest_port_label.AutoSize = true;
			this.dest_port_label.Location = new System.Drawing.Point(6, 73);
			this.dest_port_label.Name = "dest_port_label";
			this.dest_port_label.Size = new System.Drawing.Size(29, 13);
			this.dest_port_label.TabIndex = 4;
			this.dest_port_label.Text = "Port:";
			// 
			// dest_port
			// 
			this.dest_port.Location = new System.Drawing.Point(58, 70);
			this.dest_port.MaxLength = 5;
			this.dest_port.Name = "dest_port";
			this.dest_port.Size = new System.Drawing.Size(50, 20);
			this.dest_port.TabIndex = 5;
			// 
			// dest_ip_chk
			// 
			this.dest_ip_chk.AutoSize = true;
			this.dest_ip_chk.Location = new System.Drawing.Point(8, 20);
			this.dest_ip_chk.Name = "dest_ip_chk";
			this.dest_ip_chk.Size = new System.Drawing.Size(117, 17);
			this.dest_ip_chk.TabIndex = 6;
			this.dest_ip_chk.Text = "Filter Destination IP";
			this.dest_ip_chk.UseVisualStyleBackColor = true;
			this.dest_ip_chk.CheckedChanged += new System.EventHandler(this.dest_ip_chk_CheckedChanged);
			// 
			// filter_ip
			// 
			this.filter_ip.Controls.Add(this.src_ip_chk);
			this.filter_ip.Controls.Add(this.src_port);
			this.filter_ip.Controls.Add(this.src_port_label);
			this.filter_ip.Controls.Add(this.src_ip_label);
			this.filter_ip.Controls.Add(this.src_ip);
			this.filter_ip.Controls.Add(this.dest_ip_chk);
			this.filter_ip.Controls.Add(this.dest_port);
			this.filter_ip.Controls.Add(this.dest_port_label);
			this.filter_ip.Controls.Add(this.dest_ip_label);
			this.filter_ip.Controls.Add(this.dest_ip);
			this.filter_ip.Location = new System.Drawing.Point(13, 62);
			this.filter_ip.Name = "filter_ip";
			this.filter_ip.Size = new System.Drawing.Size(196, 195);
			this.filter_ip.TabIndex = 1;
			this.filter_ip.TabStop = false;
			this.filter_ip.Text = "Filter IP Address";
			// 
			// src_ip_chk
			// 
			this.src_ip_chk.AutoSize = true;
			this.src_ip_chk.Location = new System.Drawing.Point(9, 114);
			this.src_ip_chk.Name = "src_ip_chk";
			this.src_ip_chk.Size = new System.Drawing.Size(98, 17);
			this.src_ip_chk.TabIndex = 11;
			this.src_ip_chk.Text = "Filter Source IP";
			this.src_ip_chk.UseVisualStyleBackColor = true;
			this.src_ip_chk.CheckedChanged += new System.EventHandler(this.src_ip_chk_CheckedChanged);
			// 
			// src_port
			// 
			this.src_port.Location = new System.Drawing.Point(59, 164);
			this.src_port.MaxLength = 5;
			this.src_port.Name = "src_port";
			this.src_port.Size = new System.Drawing.Size(50, 20);
			this.src_port.TabIndex = 10;
			// 
			// src_port_label
			// 
			this.src_port_label.AutoSize = true;
			this.src_port_label.Location = new System.Drawing.Point(7, 167);
			this.src_port_label.Name = "src_port_label";
			this.src_port_label.Size = new System.Drawing.Size(29, 13);
			this.src_port_label.TabIndex = 9;
			this.src_port_label.Text = "Port:";
			// 
			// src_ip_label
			// 
			this.src_ip_label.AutoSize = true;
			this.src_ip_label.Location = new System.Drawing.Point(7, 140);
			this.src_ip_label.Name = "src_ip_label";
			this.src_ip_label.Size = new System.Drawing.Size(48, 13);
			this.src_ip_label.TabIndex = 8;
			this.src_ip_label.Text = "Address:";
			// 
			// src_ip
			// 
			this.src_ip.AllowInternalTab = false;
			this.src_ip.AutoHeight = true;
			this.src_ip.BackColor = System.Drawing.SystemColors.Window;
			this.src_ip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.src_ip.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.src_ip.Location = new System.Drawing.Point(59, 137);
			this.src_ip.MinimumSize = new System.Drawing.Size(87, 20);
			this.src_ip.Name = "src_ip";
			this.src_ip.ReadOnly = false;
			this.src_ip.Size = new System.Drawing.Size(126, 20);
			this.src_ip.TabIndex = 7;
			this.src_ip.Text = "...";
			// 
			// ok_btn
			// 
			this.ok_btn.Location = new System.Drawing.Point(12, 263);
			this.ok_btn.Name = "ok_btn";
			this.ok_btn.Size = new System.Drawing.Size(75, 23);
			this.ok_btn.TabIndex = 2;
			this.ok_btn.Text = "OK";
			this.ok_btn.UseVisualStyleBackColor = true;
			this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
			// 
			// cancel_btn
			// 
			this.cancel_btn.Location = new System.Drawing.Point(134, 263);
			this.cancel_btn.Name = "cancel_btn";
			this.cancel_btn.Size = new System.Drawing.Size(75, 23);
			this.cancel_btn.TabIndex = 3;
			this.cancel_btn.Text = "Cancel";
			this.cancel_btn.UseVisualStyleBackColor = true;
			this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
			// 
			// FilterDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(221, 297);
			this.Controls.Add(this.cancel_btn);
			this.Controls.Add(this.ok_btn);
			this.Controls.Add(this.filter_ip);
			this.Controls.Add(this.filter_protocol);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(237, 335);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(237, 335);
			this.Name = "FilterDlg";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sinffer.NET Filter";
			this.Activated += new System.EventHandler(this.FilterDlg_Activated);
			this.filter_protocol.ResumeLayout(false);
			this.filter_protocol.PerformLayout();
			this.filter_ip.ResumeLayout(false);
			this.filter_ip.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox filter_protocol;
		private System.Windows.Forms.CheckBox udp_chk;
		private System.Windows.Forms.CheckBox tcp_chk;
		private System.Windows.Forms.CheckBox arp_chk;
		private IPAddressControlLib.IPAddressControl dest_ip;
		private System.Windows.Forms.Label dest_ip_label;
		private System.Windows.Forms.Label dest_port_label;
		private Sniffer.NumTextBox dest_port;
		private System.Windows.Forms.CheckBox dest_ip_chk;
		private System.Windows.Forms.GroupBox filter_ip;
		private System.Windows.Forms.CheckBox src_ip_chk;
		private Sniffer.NumTextBox src_port;
		private System.Windows.Forms.Label src_port_label;
		private System.Windows.Forms.Label src_ip_label;
		private IPAddressControlLib.IPAddressControl src_ip;
		private System.Windows.Forms.Button ok_btn;
		private System.Windows.Forms.Button cancel_btn;
	}
}