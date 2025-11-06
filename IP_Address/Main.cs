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

			comboBox_SubnetMask.SelectedIndex = 3;
			
			textBox_NetworkAddress.Text = "";
			textBox_BroadcastAddress.Text = "";
			textBox_TotalIPAddresses.Text = "";
			
			textBox_UsableHosts.Text = "";
			textBox_MaskPrefix.Text = "";

			textBox_FirstIPAddress.Text = "";
			textBox_LastIPAddress.Text = "";
		}

		private void Button_Calculate_Click(object sender, EventArgs e)
		{
			string ipAddressString = TextBox_IPAddress.Text;
			string subnetMaskString = comboBox_SubnetMask.SelectedItem?.ToString();

			if (string.IsNullOrEmpty(subnetMaskString))
			{
				MessageBox.Show("Пожалуйста, выберите маску подсети из списка!", "Ошибка!!!", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			IPAddress ipAddress;
			IPAddress subnetMask;

			if (!IPAddress.TryParse(ipAddressString, out ipAddress))
			{
				MessageBox.Show("Неверный формат IP-адреса!", "Ошибка!!!", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			if (!IPAddress.TryParse(subnetMaskString, out subnetMask))
			{
				MessageBox.Show("Неверный формат маски подсети!", "Ошибка!!!", MessageBoxButtons.OK, 
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

			if (prefixLength < 0 || prefixLength > 32)
			{
				MessageBox.Show($"Ошибка: Некорректное вычисление префикса ({prefixLength}).", 
					"Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			long totalAddresses = (long)Math.Pow(2, 32 - prefixLength);

			// Количество узлов = Общее количество адресов - 2 (адрес сети и широковещательный адрес)
			// Если сеть /31 или /32, то узлов 0.
			long usableHosts = totalAddresses - 2;
			if (usableHosts < 0) usableHosts = 0;

			IPAddress firstUsableIP = null;
			IPAddress lastUsableIP = null;

			if (totalAddresses > 2) // Сеть должна содержать как минимум адрес сети и широковещательный
			{
				// Первый используемый IP-адрес = Адрес сети + 1
				byte[] firstUsableBytes = networkAddress.GetAddressBytes();
				firstUsableBytes[3]++; // Прибавляем 1 к последнему байту
									   // Обработка переноса, если последний байт становится 256 (0)
				if (firstUsableBytes[3] == 0)
				{
					firstUsableBytes[2]++;
					if (firstUsableBytes[2] == 0)
					{
						firstUsableBytes[1]++;
						if (firstUsableBytes[1] == 0)
						{
							firstUsableBytes[0]++;
						}
					}
				}
				firstUsableIP = new IPAddress(firstUsableBytes);

				// Последний используемый IP-адрес = Широковещательный адрес - 1
				byte[] lastUsableBytes = broadcastAddress.GetAddressBytes();
				lastUsableBytes[3]--; // Вычитаем 1 из последнего байта
									  // Обработка "заема", если последний байт становится -1 (255)
				if (lastUsableBytes[3] == 255) // Проверяем, стало ли 255 после вычитания 1 (из 0)
				{
					lastUsableBytes[2]--;
					if (lastUsableBytes[2] == 255)
					{
						lastUsableBytes[1]--;
						if (lastUsableBytes[1] == 255)
						{
							lastUsableBytes[0]--;
						}
					}
				}
				lastUsableIP = new IPAddress(lastUsableBytes);
			}
			// Для сетей /31 и /32, где usableAddresses = 0, first/lastUsableIP останутся null.
			// В таком случае мы можем отобразить "N/A" или те же network/broadcast адреса,
			// но с учетом того, что они не используются для узлов.
			// Здесь мы оставим их null, а в Label отобразим соответственно.

			textBox_MaskPrefix.Text = "/" + prefixLength.ToString();
			
			textBox_NetworkAddress.Text = networkAddress.ToString();
			
			textBox_BroadcastAddress.Text = broadcastAddress.ToString();
			
			textBox_TotalIPAddresses.Text = totalAddresses.ToString();			
			
			textBox_UsableHosts.Text = usableHosts.ToString();

			textBox_FirstIPAddress.Text = (firstUsableIP != null) ? firstUsableIP.ToString() : "N/A";
			textBox_LastIPAddress.Text = (lastUsableIP != null) ? lastUsableIP.ToString() : "N/A";
		}
	}
}
