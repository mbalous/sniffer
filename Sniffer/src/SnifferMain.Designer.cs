namespace Sniffer
{
    partial class SnifferMain
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
            if (disposing && (components != null))
            {
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
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.start_cap = new System.Windows.Forms.ToolStripButton();
			this.stop_cap = new System.Windows.Forms.ToolStripButton();
			this.clear_cap = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.save_file = new System.Windows.Forms.ToolStripButton();
			this.open_file = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.device_opt = new System.Windows.Forms.ToolStripComboBox();
			this.filter_opt = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.about = new System.Windows.Forms.ToolStripButton();
			this.main_panel = new System.Windows.Forms.TableLayoutPanel();
			this.frames = new System.Windows.Forms.ListView();
			this.f_num = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_src = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_dest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_phy_src = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_phy_dest = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_proto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_len = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.f_details = new System.Windows.Forms.ListView();
			this.d_field = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.d_value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.h_details = new System.Windows.Forms.TextBox();
			this.open_dlg = new System.Windows.Forms.OpenFileDialog();
			this.save_dlg = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip.SuspendLayout();
			this.main_panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip
			// 
			this.toolStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.start_cap,
            this.stop_cap,
            this.clear_cap,
            this.toolStripSeparator1,
            this.save_file,
            this.open_file,
            this.toolStripSeparator2,
            this.device_opt,
            this.filter_opt,
            this.toolStripSeparator3,
            this.about});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(784, 55);
			this.toolStrip.TabIndex = 0;
			this.toolStrip.Text = "toolStrip";
			// 
			// start_cap
			// 
			this.start_cap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.start_cap.Image = global::Sniffer.Properties.Resources.capture;
			this.start_cap.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.start_cap.Name = "start_cap";
			this.start_cap.Size = new System.Drawing.Size(52, 52);
			this.start_cap.Text = "Start";
			this.start_cap.ToolTipText = "Start";
			this.start_cap.Click += new System.EventHandler(this.start_cap_Click);
			// 
			// stop_cap
			// 
			this.stop_cap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.stop_cap.Image = global::Sniffer.Properties.Resources.stop;
			this.stop_cap.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.stop_cap.Name = "stop_cap";
			this.stop_cap.Size = new System.Drawing.Size(52, 52);
			this.stop_cap.Text = "Stop";
			this.stop_cap.Click += new System.EventHandler(this.stop_cap_Click);
			// 
			// clear_cap
			// 
			this.clear_cap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.clear_cap.Image = global::Sniffer.Properties.Resources.clear;
			this.clear_cap.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clear_cap.Name = "clear_cap";
			this.clear_cap.Size = new System.Drawing.Size(52, 52);
			this.clear_cap.Text = "Clear";
			this.clear_cap.Click += new System.EventHandler(this.clear_cap_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
			// 
			// save_file
			// 
			this.save_file.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.save_file.Image = global::Sniffer.Properties.Resources.save;
			this.save_file.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.save_file.Name = "save_file";
			this.save_file.Size = new System.Drawing.Size(52, 52);
			this.save_file.Text = "Save";
			this.save_file.Click += new System.EventHandler(this.save_file_Click);
			// 
			// open_file
			// 
			this.open_file.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.open_file.Image = global::Sniffer.Properties.Resources.open;
			this.open_file.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.open_file.Name = "open_file";
			this.open_file.Size = new System.Drawing.Size(52, 52);
			this.open_file.Text = "Open";
			this.open_file.Click += new System.EventHandler(this.open_file_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
			// 
			// device_opt
			// 
			this.device_opt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.device_opt.DropDownWidth = 200;
			this.device_opt.Name = "device_opt";
			this.device_opt.Size = new System.Drawing.Size(200, 55);
			// 
			// filter_opt
			// 
			this.filter_opt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.filter_opt.Image = global::Sniffer.Properties.Resources.filter;
			this.filter_opt.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.filter_opt.Name = "filter_opt";
			this.filter_opt.Size = new System.Drawing.Size(52, 52);
			this.filter_opt.Text = "Filter";
			this.filter_opt.Click += new System.EventHandler(this.filter_opt_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
			// 
			// about
			// 
			this.about.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.about.Image = global::Sniffer.Properties.Resources.about;
			this.about.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.about.Name = "about";
			this.about.Size = new System.Drawing.Size(52, 52);
			this.about.Text = "About";
			this.about.ToolTipText = "About Sinffer.NET";
			this.about.Click += new System.EventHandler(this.about_Click);
			// 
			// main_panel
			// 
			this.main_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.main_panel.AutoSize = true;
			this.main_panel.ColumnCount = 2;
			this.main_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
			this.main_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
			this.main_panel.Controls.Add(this.frames, 0, 0);
			this.main_panel.Controls.Add(this.f_details, 0, 1);
			this.main_panel.Controls.Add(this.h_details, 1, 1);
			this.main_panel.Location = new System.Drawing.Point(6, 53);
			this.main_panel.Name = "main_panel";
			this.main_panel.RowCount = 2;
			this.main_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.main_panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.main_panel.Size = new System.Drawing.Size(772, 502);
			this.main_panel.TabIndex = 1;
			// 
			// frames
			// 
			this.frames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.frames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.f_num,
            this.f_time,
            this.f_src,
            this.f_dest,
            this.f_phy_src,
            this.f_phy_dest,
            this.f_proto,
            this.f_len});
			this.main_panel.SetColumnSpan(this.frames, 2);
			this.frames.FullRowSelect = true;
			this.frames.HideSelection = false;
			this.frames.Location = new System.Drawing.Point(3, 3);
			this.frames.MultiSelect = false;
			this.frames.Name = "frames";
			this.frames.Size = new System.Drawing.Size(766, 345);
			this.frames.TabIndex = 0;
			this.frames.UseCompatibleStateImageBehavior = false;
			this.frames.View = System.Windows.Forms.View.Details;
			this.frames.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.frames_ItemSelectionChanged);
			// 
			// f_num
			// 
			this.f_num.Text = "Frame Number";
			this.f_num.Width = 85;
			// 
			// f_time
			// 
			this.f_time.Text = "Time of Day";
			this.f_time.Width = 81;
			// 
			// f_src
			// 
			this.f_src.Text = "Source IP";
			this.f_src.Width = 98;
			// 
			// f_dest
			// 
			this.f_dest.Text = "Destination IP";
			this.f_dest.Width = 125;
			// 
			// f_phy_src
			// 
			this.f_phy_src.Text = "Source MAC";
			this.f_phy_src.Width = 94;
			// 
			// f_phy_dest
			// 
			this.f_phy_dest.Text = "Destination MAC";
			this.f_phy_dest.Width = 112;
			// 
			// f_proto
			// 
			this.f_proto.Text = "Protocol Name";
			this.f_proto.Width = 96;
			// 
			// f_len
			// 
			this.f_len.Text = "Length";
			// 
			// f_details
			// 
			this.f_details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.f_details.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.d_field,
            this.d_value});
			this.f_details.FullRowSelect = true;
			this.f_details.GridLines = true;
			this.f_details.Location = new System.Drawing.Point(3, 354);
			this.f_details.MultiSelect = false;
			this.f_details.Name = "f_details";
			this.f_details.ShowItemToolTips = true;
			this.f_details.Size = new System.Drawing.Size(434, 145);
			this.f_details.TabIndex = 1;
			this.f_details.UseCompatibleStateImageBehavior = false;
			this.f_details.View = System.Windows.Forms.View.Details;
			this.f_details.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.f_details_ItemSelectionChanged);
			// 
			// d_field
			// 
			this.d_field.Text = "Field";
			this.d_field.Width = 78;
			// 
			// d_value
			// 
			this.d_value.Text = "Value";
			this.d_value.Width = 312;
			// 
			// h_details
			// 
			this.h_details.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.h_details.Font = new System.Drawing.Font("Consolas", 10F);
			this.h_details.Location = new System.Drawing.Point(443, 354);
			this.h_details.Multiline = true;
			this.h_details.Name = "h_details";
			this.h_details.ReadOnly = true;
			this.h_details.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.h_details.Size = new System.Drawing.Size(326, 145);
			this.h_details.TabIndex = 2;
			this.h_details.WordWrap = false;
			// 
			// open_dlg
			// 
			this.open_dlg.Filter = "\"Sniffer.NET Capture Files|*.cap|All Files|*.*\"";
			this.open_dlg.RestoreDirectory = true;
			// 
			// save_dlg
			// 
			this.save_dlg.Filter = "Sniffer.NET Capture Files|*.cap|All Files|*.*";
			this.save_dlg.RestoreDirectory = true;
			// 
			// SnifferMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Controls.Add(this.main_panel);
			this.Controls.Add(this.toolStrip);
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "SnifferMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sniffer.NET";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SnifferMain_FormClosing);
			this.Load += new System.EventHandler(this.SnifferMain_Load);
			this.Shown += new System.EventHandler(this.SnifferMain_Shown);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.main_panel.ResumeLayout(false);
			this.main_panel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton start_cap;
        private System.Windows.Forms.ToolStripButton stop_cap;
        private System.Windows.Forms.ToolStripButton clear_cap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton save_file;
        private System.Windows.Forms.ToolStripButton open_file;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox device_opt;
        private System.Windows.Forms.ToolStripButton filter_opt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton about;
        private System.Windows.Forms.TableLayoutPanel main_panel;
        private System.Windows.Forms.ListView frames;
        private System.Windows.Forms.ListView f_details;
        private System.Windows.Forms.TextBox h_details;
		private System.Windows.Forms.ColumnHeader f_num;
		private System.Windows.Forms.ColumnHeader f_src;
		private System.Windows.Forms.ColumnHeader f_dest;
		private System.Windows.Forms.ColumnHeader f_proto;
		private System.Windows.Forms.ColumnHeader f_len;
		private System.Windows.Forms.ColumnHeader f_time;
		private System.Windows.Forms.ColumnHeader d_field;
		private System.Windows.Forms.ColumnHeader d_value;
		private System.Windows.Forms.ColumnHeader f_phy_src;
		private System.Windows.Forms.ColumnHeader f_phy_dest;
		private System.Windows.Forms.OpenFileDialog open_dlg;
		private System.Windows.Forms.SaveFileDialog save_dlg;

    }
}

