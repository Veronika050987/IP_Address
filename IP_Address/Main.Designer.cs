namespace IP_Address
{
	partial class Main
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
			this.TextBox_IPAddress = new System.Windows.Forms.TextBox();
			this.labelIP = new System.Windows.Forms.Label();
			this.labelSubnetMask = new System.Windows.Forms.Label();
			this.Label_NetworkAddress = new System.Windows.Forms.Label();
			this.Label_BroadcastAddress = new System.Windows.Forms.Label();
			this.Label_TotalIPAddresses = new System.Windows.Forms.Label();
			this.textBox_NetworkAddress = new System.Windows.Forms.TextBox();
			this.textBox_BroadcastAddress = new System.Windows.Forms.TextBox();
			this.textBox_TotalIPAddresses = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_UsableHosts = new System.Windows.Forms.TextBox();
			this.labelMaskPrefix = new System.Windows.Forms.Label();
			this.comboBox_SubnetMask = new System.Windows.Forms.ComboBox();
			this.label_FirstUsableIPAddress = new System.Windows.Forms.Label();
			this.label_LastUsableIPAddress = new System.Windows.Forms.Label();
			this.textBox_FirstIPAddress = new System.Windows.Forms.TextBox();
			this.textBox_LastIPAddress = new System.Windows.Forms.TextBox();
			this.comboBox_MaskPrefix = new System.Windows.Forms.ComboBox();
			this.button_Calculate = new System.Windows.Forms.Button();
			this.textBox_AddressType = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// TextBox_IPAddress
			// 
			this.TextBox_IPAddress.Location = new System.Drawing.Point(218, 42);
			this.TextBox_IPAddress.Name = "TextBox_IPAddress";
			this.TextBox_IPAddress.Size = new System.Drawing.Size(268, 22);
			this.TextBox_IPAddress.TabIndex = 0;
			// 
			// labelIP
			// 
			this.labelIP.AutoSize = true;
			this.labelIP.Location = new System.Drawing.Point(36, 42);
			this.labelIP.Name = "labelIP";
			this.labelIP.Size = new System.Drawing.Size(75, 16);
			this.labelIP.TabIndex = 1;
			this.labelIP.Text = "IP address:";
			// 
			// labelSubnetMask
			// 
			this.labelSubnetMask.AutoSize = true;
			this.labelSubnetMask.Location = new System.Drawing.Point(36, 97);
			this.labelSubnetMask.Name = "labelSubnetMask";
			this.labelSubnetMask.Size = new System.Drawing.Size(88, 16);
			this.labelSubnetMask.TabIndex = 3;
			this.labelSubnetMask.Text = "Subnet mask:";
			// 
			// Label_NetworkAddress
			// 
			this.Label_NetworkAddress.AutoSize = true;
			this.Label_NetworkAddress.Location = new System.Drawing.Point(36, 195);
			this.Label_NetworkAddress.Name = "Label_NetworkAddress";
			this.Label_NetworkAddress.Size = new System.Drawing.Size(112, 16);
			this.Label_NetworkAddress.TabIndex = 5;
			this.Label_NetworkAddress.Text = "Network address:";
			// 
			// Label_BroadcastAddress
			// 
			this.Label_BroadcastAddress.AutoSize = true;
			this.Label_BroadcastAddress.Location = new System.Drawing.Point(36, 237);
			this.Label_BroadcastAddress.Name = "Label_BroadcastAddress";
			this.Label_BroadcastAddress.Size = new System.Drawing.Size(125, 16);
			this.Label_BroadcastAddress.TabIndex = 6;
			this.Label_BroadcastAddress.Text = "Broadcast address:";
			// 
			// Label_TotalIPAddresses
			// 
			this.Label_TotalIPAddresses.AutoSize = true;
			this.Label_TotalIPAddresses.Location = new System.Drawing.Point(36, 279);
			this.Label_TotalIPAddresses.Name = "Label_TotalIPAddresses";
			this.Label_TotalIPAddresses.Size = new System.Drawing.Size(124, 16);
			this.Label_TotalIPAddresses.TabIndex = 7;
			this.Label_TotalIPAddresses.Text = "Total IP addresses:";
			// 
			// textBox_NetworkAddress
			// 
			this.textBox_NetworkAddress.Location = new System.Drawing.Point(218, 198);
			this.textBox_NetworkAddress.Name = "textBox_NetworkAddress";
			this.textBox_NetworkAddress.Size = new System.Drawing.Size(268, 22);
			this.textBox_NetworkAddress.TabIndex = 9;
			// 
			// textBox_BroadcastAddress
			// 
			this.textBox_BroadcastAddress.Location = new System.Drawing.Point(218, 239);
			this.textBox_BroadcastAddress.Name = "textBox_BroadcastAddress";
			this.textBox_BroadcastAddress.Size = new System.Drawing.Size(268, 22);
			this.textBox_BroadcastAddress.TabIndex = 10;
			// 
			// textBox_TotalIPAddresses
			// 
			this.textBox_TotalIPAddresses.Location = new System.Drawing.Point(218, 280);
			this.textBox_TotalIPAddresses.Name = "textBox_TotalIPAddresses";
			this.textBox_TotalIPAddresses.Size = new System.Drawing.Size(268, 22);
			this.textBox_TotalIPAddresses.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 321);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Usable hosts:";
			// 
			// textBox_UsableHosts
			// 
			this.textBox_UsableHosts.Location = new System.Drawing.Point(218, 321);
			this.textBox_UsableHosts.Name = "textBox_UsableHosts";
			this.textBox_UsableHosts.Size = new System.Drawing.Size(268, 22);
			this.textBox_UsableHosts.TabIndex = 14;
			// 
			// labelMaskPrefix
			// 
			this.labelMaskPrefix.AutoSize = true;
			this.labelMaskPrefix.Location = new System.Drawing.Point(616, 97);
			this.labelMaskPrefix.Name = "labelMaskPrefix";
			this.labelMaskPrefix.Size = new System.Drawing.Size(78, 16);
			this.labelMaskPrefix.TabIndex = 16;
			this.labelMaskPrefix.Text = "CIDR mask:";
			// 
			// comboBox_SubnetMask
			// 
			this.comboBox_SubnetMask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_SubnetMask.FormattingEnabled = true;
			this.comboBox_SubnetMask.Items.AddRange(new object[] {
            "255.255.255.255",
            "255.255.255.254",
            "255.255.255.252",
            "255.255.255.248",
            "255.255.255.240",
            "255.255.255.224",
            "255.255.255.192",
            "255.255.255.128",
            "255.255.255.0",
            "255.255.254.0",
            "255.255.252.0",
            "255.255.248.0",
            "255.255.240.0",
            "255.255.224.0",
            "255.255.192.0",
            "255.255.128.0",
            "255.255.0.0",
            "255.254.0.0",
            "255.252.0.0",
            "255.248.0.0",
            "255.240.0.0",
            "255.224.0.0",
            "255.192.0.0",
            "255.128.0.0",
            "255.0.0.0",
            "254.0.0.0",
            "252.0.0.0",
            "248.0.0.0",
            "240.0.0.0",
            "224.0.0.0",
            "192.0.0.0",
            "128.0.0.0"});
			this.comboBox_SubnetMask.Location = new System.Drawing.Point(218, 92);
			this.comboBox_SubnetMask.Name = "comboBox_SubnetMask";
			this.comboBox_SubnetMask.Size = new System.Drawing.Size(268, 24);
			this.comboBox_SubnetMask.TabIndex = 17;
			// 
			// label_FirstUsableIPAddress
			// 
			this.label_FirstUsableIPAddress.AutoSize = true;
			this.label_FirstUsableIPAddress.Location = new System.Drawing.Point(36, 363);
			this.label_FirstUsableIPAddress.Name = "label_FirstUsableIPAddress";
			this.label_FirstUsableIPAddress.Size = new System.Drawing.Size(175, 16);
			this.label_FirstUsableIPAddress.TabIndex = 18;
			this.label_FirstUsableIPAddress.Text = "First host usable IP address:";
			// 
			// label_LastUsableIPAddress
			// 
			this.label_LastUsableIPAddress.AutoSize = true;
			this.label_LastUsableIPAddress.Location = new System.Drawing.Point(36, 405);
			this.label_LastUsableIPAddress.Name = "label_LastUsableIPAddress";
			this.label_LastUsableIPAddress.Size = new System.Drawing.Size(175, 16);
			this.label_LastUsableIPAddress.TabIndex = 19;
			this.label_LastUsableIPAddress.Text = "Last host usable IP address:";
			// 
			// textBox_FirstIPAddress
			// 
			this.textBox_FirstIPAddress.Location = new System.Drawing.Point(218, 362);
			this.textBox_FirstIPAddress.Name = "textBox_FirstIPAddress";
			this.textBox_FirstIPAddress.Size = new System.Drawing.Size(268, 22);
			this.textBox_FirstIPAddress.TabIndex = 20;
			// 
			// textBox_LastIPAddress
			// 
			this.textBox_LastIPAddress.Location = new System.Drawing.Point(218, 403);
			this.textBox_LastIPAddress.Name = "textBox_LastIPAddress";
			this.textBox_LastIPAddress.Size = new System.Drawing.Size(268, 22);
			this.textBox_LastIPAddress.TabIndex = 21;
			// 
			// comboBox_MaskPrefix
			// 
			this.comboBox_MaskPrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_MaskPrefix.FormattingEnabled = true;
			this.comboBox_MaskPrefix.Items.AddRange(new object[] {
            "/32",
            "/31",
            "/30",
            "/29",
            "/28",
            "/27",
            "/26",
            "/25",
            "/24",
            "/23",
            "/22",
            "/21",
            "/20",
            "/19",
            "/18",
            "/17",
            "/16",
            "/15",
            "/14",
            "/13",
            "/12",
            "/11",
            "/10",
            "/9",
            "/8",
            "/7",
            "/6",
            "/5",
            "/4",
            "/3",
            "/2",
            "/1"});
			this.comboBox_MaskPrefix.Location = new System.Drawing.Point(717, 94);
			this.comboBox_MaskPrefix.Name = "comboBox_MaskPrefix";
			this.comboBox_MaskPrefix.Size = new System.Drawing.Size(126, 24);
			this.comboBox_MaskPrefix.TabIndex = 22;
			// 
			// button_Calculate
			// 
			this.button_Calculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.button_Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.button_Calculate.Location = new System.Drawing.Point(218, 142);
			this.button_Calculate.Name = "button_Calculate";
			this.button_Calculate.Size = new System.Drawing.Size(135, 33);
			this.button_Calculate.TabIndex = 23;
			this.button_Calculate.Text = "Calculate";
			this.button_Calculate.UseVisualStyleBackColor = false;
			// 
			// textBox_AddressType
			// 
			this.textBox_AddressType.Location = new System.Drawing.Point(536, 42);
			this.textBox_AddressType.Name = "textBox_AddressType";
			this.textBox_AddressType.Size = new System.Drawing.Size(307, 22);
			this.textBox_AddressType.TabIndex = 24;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(874, 450);
			this.Controls.Add(this.textBox_AddressType);
			this.Controls.Add(this.button_Calculate);
			this.Controls.Add(this.comboBox_MaskPrefix);
			this.Controls.Add(this.textBox_LastIPAddress);
			this.Controls.Add(this.textBox_FirstIPAddress);
			this.Controls.Add(this.label_LastUsableIPAddress);
			this.Controls.Add(this.label_FirstUsableIPAddress);
			this.Controls.Add(this.comboBox_SubnetMask);
			this.Controls.Add(this.labelMaskPrefix);
			this.Controls.Add(this.textBox_UsableHosts);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_TotalIPAddresses);
			this.Controls.Add(this.textBox_BroadcastAddress);
			this.Controls.Add(this.textBox_NetworkAddress);
			this.Controls.Add(this.Label_TotalIPAddresses);
			this.Controls.Add(this.Label_BroadcastAddress);
			this.Controls.Add(this.Label_NetworkAddress);
			this.Controls.Add(this.labelSubnetMask);
			this.Controls.Add(this.labelIP);
			this.Controls.Add(this.TextBox_IPAddress);
			this.Name = "Main";
			this.Text = "IPCalculator";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextBox_IPAddress;
		private System.Windows.Forms.Label labelIP;
		private System.Windows.Forms.Label labelSubnetMask;
		private System.Windows.Forms.Label Label_NetworkAddress;
		private System.Windows.Forms.Label Label_BroadcastAddress;
		private System.Windows.Forms.Label Label_TotalIPAddresses;
		private System.Windows.Forms.TextBox textBox_NetworkAddress;
		private System.Windows.Forms.TextBox textBox_BroadcastAddress;
		private System.Windows.Forms.TextBox textBox_TotalIPAddresses;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_UsableHosts;
		private System.Windows.Forms.Label labelMaskPrefix;
		private System.Windows.Forms.ComboBox comboBox_SubnetMask;
		private System.Windows.Forms.Label label_FirstUsableIPAddress;
		private System.Windows.Forms.Label label_LastUsableIPAddress;
		private System.Windows.Forms.TextBox textBox_FirstIPAddress;
		private System.Windows.Forms.TextBox textBox_LastIPAddress;
		private System.Windows.Forms.ComboBox comboBox_MaskPrefix;
		private System.Windows.Forms.Button button_Calculate;
		private System.Windows.Forms.TextBox textBox_AddressType;
	}
}

