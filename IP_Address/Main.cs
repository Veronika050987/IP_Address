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
		//для сопоставления маски и префикса
		private Dictionary<string, string> subnetMaskToPrefixString = new Dictionary<string, string>();

		private Dictionary<string, string> prefixStringToSubnetMask = new Dictionary<string, string>();

		public Main()
		{
			InitializeComponent();
			InitializeMaskPrefixMappings(); // Инициализация словарей
			PopulateMaskComboBox();          // Заполнение comboBox_SubnetMask
			PopulatePrefixComboBox();        // Заполнение comboBox_MaskPrefix

			TextBox_IPAddress.Text = "192.168.1.10";

			comboBox_SubnetMask.SelectedIndex = 0;

			textBox_AddressType.Text = "";
			textBox_NetworkAddress.Text = "";
			textBox_BroadcastAddress.Text = "";			
			textBox_TotalIPAddresses.Text = "";
			textBox_UsableHosts.Text = "";			
			textBox_FirstIPAddress.Text = "";
			textBox_LastIPAddress.Text = "";

			button_Calculate.Click += button_Calculate_Click;

			TextBox_IPAddress.TextChanged += Control_Changed;
			comboBox_SubnetMask.SelectedIndexChanged += Control_Changed;
			comboBox_MaskPrefix.SelectedIndexChanged += Control_Changed;

			CalculateNetworkInfo();
		}

		private void InitializeMaskPrefixMappings()
		{
			var masks = new List<string>
			{
				"255.255.255.254", "255.255.255.252", "255.255.255.248", "255.255.255.240",
				"255.255.255.224", "255.255.255.192", "255.255.255.128", "255.255.255.0",
				"255.255.254.0", "255.255.252.0", "255.255.248.0", "255.255.240.0",
				"255.255.224.0", "255.255.192.0", "255.255.128.0", "255.255.0.0",
				"255.254.0.0", "255.252.0.0", "255.248.0.0", "255.240.0.0",
				"255.224.0.0", "255.192.0.0", "255.0.0.0", "254.0.0.0",
				"252.0.0.0", "248.0.0.0", "240.0.0.0", "224.0.0.0",
				"192.0.0.0", "128.0.0.0"
			};

			var prefixes = new List<int>
			{
				31, 30, 29, 28, 27, 26, 25, 24,
				23, 22, 21, 20, 19, 18, 17, 16,
				15, 14, 13, 12, 11, 10, 8, 7,
				6, 5, 4, 3, 2, 1
			};

			if (masks.Count != prefixes.Count)
			{
				MessageBox.Show("Ошибка: количество масок и префиксов не совпадает!", "Инициализация", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			for (int i = 0; i < masks.Count; i++)
			{
				string prefixString = "/" + prefixes[i].ToString();
				subnetMaskToPrefixString[masks[i]] = prefixString;
				prefixStringToSubnetMask[prefixString] = masks[i];
			}
		}

		private void PopulateMaskComboBox()
		{
			comboBox_SubnetMask.Items.Clear();

			comboBox_SubnetMask.Items.Add("Выберите маску...");

			foreach (var mask in subnetMaskToPrefixString.Keys.OrderBy
				(m => IPAddress.Parse(m).GetAddressBytes().Aggregate(0L, (acc, b) => (acc << 8) | b)))
			{
				comboBox_SubnetMask.Items.Add(mask);
			}
		}

		private void PopulatePrefixComboBox()
		{
			comboBox_MaskPrefix.Items.Clear();
			foreach (var prefixString in prefixStringToSubnetMask.Keys.OrderBy
				(p => int.Parse(p.Substring(1)))) 
				// Убираем '/' для сортировки
			{
				comboBox_MaskPrefix.Items.Add(prefixString);
			}
		}

		private void Control_Changed(object sender, EventArgs e)
		{
			if (sender == comboBox_SubnetMask)
			{
				string selectedMask = comboBox_SubnetMask.SelectedItem?.ToString();
				if (selectedMask != null && subnetMaskToPrefixString.ContainsKey(selectedMask))
				{
					string prefixString = subnetMaskToPrefixString[selectedMask];
					int prefixIndex = comboBox_MaskPrefix.FindStringExact(prefixString);
					if (prefixIndex != -1 && comboBox_MaskPrefix.SelectedIndex != prefixIndex)
					{
						comboBox_MaskPrefix.SelectedIndex = prefixIndex;
					}
				}
			}
			else if (sender == comboBox_MaskPrefix)
			{
				string selectedPrefixString = comboBox_MaskPrefix.SelectedItem?.ToString();
				if (!string.IsNullOrEmpty(selectedPrefixString) && prefixStringToSubnetMask.ContainsKey
					(selectedPrefixString))
				{
					string mask = prefixStringToSubnetMask[selectedPrefixString];
					int maskIndex = comboBox_SubnetMask.FindStringExact(mask);
					if (maskIndex != -1 && comboBox_SubnetMask.SelectedIndex != maskIndex)
					{
						comboBox_SubnetMask.SelectedIndex = maskIndex;
					}
				}
			}
		}
		private void button_Calculate_Click(object sender, EventArgs e)
		{
			CalculateNetworkInfo();
		}
		private string DetermineAddressType(IPAddress ip)
		{
			if (ip == null) return "Неверный IP";

			byte[] ipBytes = ip.GetAddressBytes();
			if (ipBytes.Length != 4) return "Не IPv4";

			// 0.0.0.0 (Default Gateway / Current Network)
			if (ipBytes[0] == 0 && ipBytes[1] == 0 && ipBytes[2] == 0 && ipBytes[3] == 0)
			{
				return "Зарезервированный адрес";
			}

			// 127.0.0.0/8 (Loopback)
			if (ipBytes[0] == 127)
			{
				return "Петлевой интерфейс (Loopback)";
			}

			// 10.0.0.0/8 (Private)
			if (ipBytes[0] == 10)
			{
				return "Автономная сеть";
			}

			// 172.16.0.0/12 (Private)
			if (ipBytes[0] == 172 && ipBytes[1] >= 16 && ipBytes[1] <= 31)
			{
				return "Приватная сеть (LAN)";
			}

			// 192.168.0.0/16 (Private)
			if (ipBytes[0] == 192 && ipBytes[1] == 168)
			{
				return "Приватная сеть (LAN)";
			}

			return "Общедоступный (Public)";
		}

		private void CalculateNetworkInfo()
		{
			string ipAddressString = TextBox_IPAddress.Text;
			string subnetMaskString = comboBox_SubnetMask.SelectedItem?.ToString();
			string selectedPrefixString = comboBox_MaskPrefix.SelectedItem?.ToString();

			// --- Валидация IP-адреса ---
			IPAddress ipAddress;
			if (!IPAddress.TryParse(ipAddressString, out ipAddress))
			{
				MessageBox.Show("Неверный формат IP-адреса!", "Ошибка!!!", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				textBox_AddressType.Text = "Неверный IP";
				// Очищаем поля результатов при ошибке ввода IP
				textBox_NetworkAddress.Text = "";
				textBox_BroadcastAddress.Text = "";
				textBox_TotalIPAddresses.Text = "";
				textBox_UsableHosts.Text = "";
				textBox_FirstIPAddress.Text = "";
				textBox_LastIPAddress.Text = "";
				return;
			}

			// --- Определение типа IP-адреса ---
			string addressType = DetermineAddressType(ipAddress);
			textBox_AddressType.Text = addressType;

			// --- Дальнейшие расчеты, если IP-адрес корректен ---
			if (string.IsNullOrEmpty(subnetMaskString) || string.IsNullOrEmpty(selectedPrefixString))
			{
				return;
			}

			int prefixLength;
			if (!int.TryParse(selectedPrefixString.Substring(1), out prefixLength) || prefixLength < 0 
				|| prefixLength > 32)
			{
				MessageBox.Show("Неверный префикс сети.", "Ошибка!!!", MessageBoxButtons.OK, 
					MessageBoxIcon.Error);
				return;
			}

			IPAddress subnetMask;
			if (!prefixStringToSubnetMask.ContainsKey(selectedPrefixString))
			{
				MessageBox.Show($"Неизвестный префикс: {selectedPrefixString}", "Ошибка!!!", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			subnetMaskString = prefixStringToSubnetMask[selectedPrefixString];
			if (!IPAddress.TryParse(subnetMaskString, out subnetMask))
			{
				MessageBox.Show("Неверный формат маски подсети (из словаря)!", "Ошибка!!!", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
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

			// --- Вычисление адреса сети ---
			byte[] networkBytes = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
			}
			IPAddress networkAddress = new IPAddress(networkBytes);

			// --- Вычисление широковещательного адреса ---
			byte[] broadcastBytes = new byte[4];
			for (int i = 0; i < 4; i++)
			{
				broadcastBytes[i] = (byte)(networkBytes[i] | (~maskBytes[i] & 0xFF));
			}
			IPAddress broadcastAddress = new IPAddress(broadcastBytes);

			// --- Расчет общего количества IP-адресов ---
			long totalAddresses = (long)Math.Pow(2, 32 - prefixLength);

			// --- Расчет количества доступных узлов ---
			long usableHosts = totalAddresses - 2;
			if (usableHosts < 0) usableHosts = 0;

			// --- Расчет первого и последнего IP-адресов для узлов ---
			IPAddress firstUsableIP = null;
			IPAddress lastUsableIP = null;

			if (totalAddresses > 2)
			{
				byte[] firstUsableBytes = networkAddress.GetAddressBytes();
				firstUsableBytes[3]++;
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

				byte[] lastUsableBytes = broadcastAddress.GetAddressBytes();
				lastUsableBytes[3]--;
				if (lastUsableBytes[3] == 255)
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

			textBox_NetworkAddress.Text = networkAddress.ToString();			
			textBox_BroadcastAddress.Text = broadcastAddress.ToString();
			
			textBox_TotalIPAddresses.Text = totalAddresses.ToString();						
			textBox_UsableHosts.Text = usableHosts.ToString();

			textBox_FirstIPAddress.Text = (firstUsableIP != null) ? firstUsableIP.ToString() : "N/A";
			textBox_LastIPAddress.Text = (lastUsableIP != null) ? lastUsableIP.ToString() : "N/A";
		}
	}
}
