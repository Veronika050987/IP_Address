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
			this.TextBox_SubnetMask = new System.Windows.Forms.TextBox();
			this.labelSubnetMask = new System.Windows.Forms.Label();
			this.Button_Calculate = new System.Windows.Forms.Button();
			this.Label_NetworkAddress = new System.Windows.Forms.Label();
			this.Label_BroadcastAddress = new System.Windows.Forms.Label();
			this.Label_TotalIPAddresses = new System.Windows.Forms.Label();
			this.Label_UsableIPAddresses = new System.Windows.Forms.Label();
			this.textBox_NetworkAddress = new System.Windows.Forms.TextBox();
			this.textBox_BroadcastAddress = new System.Windows.Forms.TextBox();
			this.textBox_TotalIPAddresses = new System.Windows.Forms.TextBox();
			this.textBox_UsableIPAddresses = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox_UsableHosts = new System.Windows.Forms.TextBox();
			this.textBox_MaskPrefix = new System.Windows.Forms.TextBox();
			this.labelMaskPrefix = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// TextBox_IPAddress
			// 
			this.TextBox_IPAddress.Location = new System.Drawing.Point(190, 39);
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
			// TextBox_SubnetMask
			// 
			this.TextBox_SubnetMask.Location = new System.Drawing.Point(190, 94);
			this.TextBox_SubnetMask.Name = "TextBox_SubnetMask";
			this.TextBox_SubnetMask.Size = new System.Drawing.Size(268, 22);
			this.TextBox_SubnetMask.TabIndex = 2;
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
			// Button_Calculate
			// 
			this.Button_Calculate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.Button_Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Button_Calculate.Location = new System.Drawing.Point(152, 146);
			this.Button_Calculate.Name = "Button_Calculate";
			this.Button_Calculate.Size = new System.Drawing.Size(105, 30);
			this.Button_Calculate.TabIndex = 4;
			this.Button_Calculate.Text = "Calculate";
			this.Button_Calculate.UseVisualStyleBackColor = false;
			this.Button_Calculate.Click += new System.EventHandler(this.Button_Calculate_Click);
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
			this.Label_BroadcastAddress.Location = new System.Drawing.Point(36, 238);
			this.Label_BroadcastAddress.Name = "Label_BroadcastAddress";
			this.Label_BroadcastAddress.Size = new System.Drawing.Size(125, 16);
			this.Label_BroadcastAddress.TabIndex = 6;
			this.Label_BroadcastAddress.Text = "Broadcast address:";
			// 
			// Label_TotalIPAddresses
			// 
			this.Label_TotalIPAddresses.AutoSize = true;
			this.Label_TotalIPAddresses.Location = new System.Drawing.Point(36, 280);
			this.Label_TotalIPAddresses.Name = "Label_TotalIPAddresses";
			this.Label_TotalIPAddresses.Size = new System.Drawing.Size(124, 16);
			this.Label_TotalIPAddresses.TabIndex = 7;
			this.Label_TotalIPAddresses.Text = "Total IP addresses:";
			// 
			// Label_UsableIPAddresses
			// 
			this.Label_UsableIPAddresses.AutoSize = true;
			this.Label_UsableIPAddresses.Location = new System.Drawing.Point(36, 322);
			this.Label_UsableIPAddresses.Name = "Label_UsableIPAddresses";
			this.Label_UsableIPAddresses.Size = new System.Drawing.Size(137, 16);
			this.Label_UsableIPAddresses.TabIndex = 8;
			this.Label_UsableIPAddresses.Text = "Usable IP addresses:";
			// 
			// textBox_NetworkAddress
			// 
			this.textBox_NetworkAddress.Location = new System.Drawing.Point(190, 195);
			this.textBox_NetworkAddress.Name = "textBox_NetworkAddress";
			this.textBox_NetworkAddress.Size = new System.Drawing.Size(268, 22);
			this.textBox_NetworkAddress.TabIndex = 9;
			// 
			// textBox_BroadcastAddress
			// 
			this.textBox_BroadcastAddress.Location = new System.Drawing.Point(190, 238);
			this.textBox_BroadcastAddress.Name = "textBox_BroadcastAddress";
			this.textBox_BroadcastAddress.Size = new System.Drawing.Size(268, 22);
			this.textBox_BroadcastAddress.TabIndex = 10;
			// 
			// textBox_TotalIPAddresses
			// 
			this.textBox_TotalIPAddresses.Location = new System.Drawing.Point(190, 277);
			this.textBox_TotalIPAddresses.Name = "textBox_TotalIPAddresses";
			this.textBox_TotalIPAddresses.Size = new System.Drawing.Size(268, 22);
			this.textBox_TotalIPAddresses.TabIndex = 11;
			// 
			// textBox_UsableIPAddresses
			// 
			this.textBox_UsableIPAddresses.Location = new System.Drawing.Point(190, 319);
			this.textBox_UsableIPAddresses.Name = "textBox_UsableIPAddresses";
			this.textBox_UsableIPAddresses.Size = new System.Drawing.Size(268, 22);
			this.textBox_UsableIPAddresses.TabIndex = 12;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(36, 361);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Usable hosts:";
			// 
			// textBox_UsableHosts
			// 
			this.textBox_UsableHosts.Location = new System.Drawing.Point(190, 361);
			this.textBox_UsableHosts.Name = "textBox_UsableHosts";
			this.textBox_UsableHosts.Size = new System.Drawing.Size(268, 22);
			this.textBox_UsableHosts.TabIndex = 14;
			// 
			// textBox_MaskPrefix
			// 
			this.textBox_MaskPrefix.Location = new System.Drawing.Point(668, 94);
			this.textBox_MaskPrefix.Name = "textBox_MaskPrefix";
			this.textBox_MaskPrefix.Size = new System.Drawing.Size(100, 22);
			this.textBox_MaskPrefix.TabIndex = 15;
			// 
			// labelMaskPrefix
			// 
			this.labelMaskPrefix.AutoSize = true;
			this.labelMaskPrefix.Location = new System.Drawing.Point(511, 97);
			this.labelMaskPrefix.Name = "labelMaskPrefix";
			this.labelMaskPrefix.Size = new System.Drawing.Size(123, 16);
			this.labelMaskPrefix.TabIndex = 16;
			this.labelMaskPrefix.Text = "Subnet mask prefix:";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.labelMaskPrefix);
			this.Controls.Add(this.textBox_MaskPrefix);
			this.Controls.Add(this.textBox_UsableHosts);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_UsableIPAddresses);
			this.Controls.Add(this.textBox_TotalIPAddresses);
			this.Controls.Add(this.textBox_BroadcastAddress);
			this.Controls.Add(this.textBox_NetworkAddress);
			this.Controls.Add(this.Label_UsableIPAddresses);
			this.Controls.Add(this.Label_TotalIPAddresses);
			this.Controls.Add(this.Label_BroadcastAddress);
			this.Controls.Add(this.Label_NetworkAddress);
			this.Controls.Add(this.Button_Calculate);
			this.Controls.Add(this.labelSubnetMask);
			this.Controls.Add(this.TextBox_SubnetMask);
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
		private System.Windows.Forms.TextBox TextBox_SubnetMask;
		private System.Windows.Forms.Label labelSubnetMask;
		private System.Windows.Forms.Button Button_Calculate;
		private System.Windows.Forms.Label Label_NetworkAddress;
		private System.Windows.Forms.Label Label_BroadcastAddress;
		private System.Windows.Forms.Label Label_TotalIPAddresses;
		private System.Windows.Forms.Label Label_UsableIPAddresses;
		private System.Windows.Forms.TextBox textBox_NetworkAddress;
		private System.Windows.Forms.TextBox textBox_BroadcastAddress;
		private System.Windows.Forms.TextBox textBox_TotalIPAddresses;
		private System.Windows.Forms.TextBox textBox_UsableIPAddresses;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox_UsableHosts;
		private System.Windows.Forms.TextBox textBox_MaskPrefix;
		private System.Windows.Forms.Label labelMaskPrefix;
	}
}

