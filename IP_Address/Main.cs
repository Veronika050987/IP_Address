using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_Address
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			TextBox_IPAddress.Text = "192.168.1.10";
			TextBox_SubnetMask.Text = "255.255.255.0";
			textBox_NetworkAddress.Text = "";
			textBox_BroadcastAddress.Text = "";
			textBox_TotalIPAddresses.Text = "";
			textBox_UsableIPAddresses.Text = "";
		}

		private void Button_Calculate_Click(object sender, EventArgs e)
		{
			string ipAddressString = TextBox_IPAddress.Text;
			string subnetMaskString = TextBox_SubnetMask.Text;

			IPAddress ipAddress;
			IPAddress subnetMask;

			if (!IPAddress.TryParse(ipAddressString, out ipAddress))
			{
				MessageBox.Show("Неверный формат IP-адреса!", "Ошибка", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			if (!IPAddress.TryParse(subnetMaskString, out subnetMask))
			{
				MessageBox.Show("Неверный формат маски подсети!", "Ошибка", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			byte[] ipBytes = ipAddress.GetAddressBytes();
			byte[] maskBytes = subnetMask.GetAddressBytes();

			if (ipBytes.Length != 4 || maskBytes.Length != 4)
			{
				MessageBox.Show("Поддерживается только IPv4!", "Ошибка", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			byte[] networkBytes = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
			}
			IPAddress networkAddress = new IPAddress(networkBytes);

			byte[] broadcastBytes = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				// Широковещательный адрес = (IP-адрес ИЛИ (НЕ Маска))
				// Или проще: Адрес сети + обратный битмаск
				broadcastBytes[i] = (byte)(networkBytes[i] | (~maskBytes[i] & 0xFF)); 
				// 0xFF для обрезки до 8 бит
			}
			IPAddress broadcastAddress = new IPAddress(broadcastBytes);

			// Количество IP-адресов = 2^(32 - количество единиц в маске)
			int prefixLength = 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 7; j >= 0; j--)
				{
					if ((maskBytes[i] & (1 << j)) != 0)
					{
						prefixLength++;
					}
				}
			}
			int totalAddresses = (int)Math.Pow(2, 32 - prefixLength);

			// Количество узлов = Общее количество адресов - 2 (адрес сети и широковещательный адрес)
			int usableAddresses = totalAddresses - 2;
			if (usableAddresses < 0) usableAddresses = 0; // Если сеть /31 или /32, то узлов 0.

			textBox_NetworkAddress.Text = networkAddress.ToString();
			textBox_BroadcastAddress.Text = broadcastAddress.ToString();
			textBox_TotalIPAddresses.Text = totalAddresses.ToString();
			textBox_UsableIPAddresses.Text = usableAddresses.ToString();
		}
	}
}
