#define _CRT_SECURE_NO_WARNINGS
#include<Windows.h>
#include<CommCtrl.h>
#include<cstdio>
#include"resource.h"
#include<string> // Для std::to_string
#include<algorithm> // Для std::max

#pragma comment(lib, "Comctl32.lib")

BOOL CALLBACK DlgProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);

INT WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInst, LPSTR lpCmdLine, INT nCmdShow)
{
	DialogBoxParam(hInstance, MAKEINTRESOURCE(IDD_DIALOG1), NULL, (DLGPROC)DlgProc, 0);
	return 0;
}

DWORD GetMaskFromPrefix(DWORD dwPrefix) 
{
	if (dwPrefix == 0) return 0;
	if (dwPrefix > 32) dwPrefix = 32; // Ограничиваем до 32
	return (0xFFFFFFFF << (32 - dwPrefix));
}

DWORD GetPrefixFromMask(DWORD dwMask) 
{
	if (dwMask == 0) return 0;
	DWORD prefix = 0;
	DWORD tempMask = dwMask;
	// Пересчитываем единицы начиная с самого старшего бита
	while (prefix < 32 && (tempMask & 0x80000000)) 
	{
		prefix++;
		tempMask <<= 1;
	}
	return prefix;
}

DWORD GetPrefixFromEditBox(HWND hEditPrefix) 
{
	CHAR szPrefix[10] = {}; // Достаточный размер для буфера
	GetDlgItemText(hEditPrefix, IDC_EDIT_PREFIX, szPrefix, sizeof(szPrefix));

	if (strlen(szPrefix) == 0) 
	{
		return 0;
	}

	DWORD prefix = atoi(szPrefix); // Преобразуем строку в число

	if (prefix > 32) prefix = 32;

	return prefix;
}

void UpdateNetworkFields(HWND hwnd, HWND hIPaddress, HWND hIPmask, HWND hEditPrefix, 
	HWND hSpinPrefix, DWORD dwIPaddress, DWORD dwNewPrefix) 
{
	CHAR szIPprefix[4] = {};
	sprintf(szIPprefix, "%u", dwNewPrefix);
	SetDlgItemText(hwnd, IDC_EDIT_PREFIX, szIPprefix);
	SendMessage(hSpinPrefix, UDM_SETPOS, 0, MAKELPARAM(dwNewPrefix, 0));

	DWORD dwNewMask = GetMaskFromPrefix(dwNewPrefix);
	SendMessage(hIPmask, IPM_SETADDRESS, 0, dwNewMask);
}


BOOL CALLBACK DlgProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uMsg)
	{
	case WM_INITDIALOG:
	{
		InitCommonControls();
		HWND hSpinPrefix = GetDlgItem(hwnd, IDC_SPIN_PREFIX);
		SendMessage(hSpinPrefix, UDM_SETRANGE, 0, MAKELPARAM(32, 0));

		HWND hIPaddress = GetDlgItem(hwnd, IDC_IPADDRESS);
		HWND hIPmask = GetDlgItem(hwnd, IDC_IPMASK);
		HWND hEditPrefix = GetDlgItem(hwnd, IDC_EDIT_PREFIX);

		DWORD initialIP = 0xC0A80101; // 192.168.1.1
		SendMessage(hIPaddress, IPM_SETADDRESS, 0, initialIP);

		DWORD initialMask = GetMaskFromPrefix(24);
		SendMessage(hIPmask, IPM_SETADDRESS, 0, initialMask);

		DWORD dwIPprefix = GetPrefixFromMask(initialMask);
		CHAR szIPprefix[4] = {}; // Размер 4 для числа до 32 и нулевого символа
		sprintf(szIPprefix, "%i", dwIPprefix);
		SetDlgItemText(hwnd, IDC_EDIT_PREFIX, szIPprefix);

		// Синхронизируем спин-контрол с начальным префиксом
		SendMessage(hSpinPrefix, UDM_SETPOS, 0, MAKELPARAM(dwIPprefix, 0));
	}
		break;
	case WM_COMMAND:
	{
		HWND hIPaddress = GetDlgItem(hwnd, IDC_IPADDRESS);
		HWND hIPmask = GetDlgItem(hwnd, IDC_IPMASK);
		HWND hEditPrefix = GetDlgItem(hwnd, IDC_EDIT_PREFIX);
		HWND hSpinPrefix = GetDlgItem(hwnd, IDC_SPIN_PREFIX);// Получаем спин-контрол
		
		DWORD dwIPaddress = 0;
		DWORD dwIPmask = UINT_MAX;
		DWORD dwIPprefix = 0;
		
		switch (LOWORD(wParam))
		{
		case IDC_IPADDRESS:
		{
			if (HIWORD(wParam) == EN_CHANGE)
			{
				SendMessage(hIPaddress, IPM_GETADDRESS, 0, (LPARAM)&dwIPaddress);
				DWORD dwFirst = FIRST_IPADDRESS(dwIPaddress);
				if (dwFirst < 128)dwIPprefix = 8;//A
				else if (dwFirst < 192)dwIPprefix = 16;//B
				else if (dwFirst < 224)dwIPprefix = 24;//C
				else dwIPprefix = 32; // Для других (например, multicast)

				UpdateNetworkFields(hwnd, hIPaddress, hIPmask, hEditPrefix, hSpinPrefix, 
					dwIPaddress, dwIPprefix);
			}
		}
			break;
		case IDC_IPMASK:
		{
			if (HIWORD(wParam) == EN_CHANGE)
			{
				SendMessage(hIPmask, IPM_GETADDRESS, 0, (LPARAM)&dwIPmask);

				dwIPprefix = GetPrefixFromMask(dwIPmask);
				UpdateNetworkFields(hwnd, hIPaddress, hIPmask, hEditPrefix, hSpinPrefix, 
					dwIPaddress, dwIPprefix);
			}
		}
			break;
		case IDC_SPIN_PREFIX:
		{
			// UDM_GETPOS возвращает текущую позицию спин-контрола.
			// Low-order word - текущая позиция, High-order word - всегда 0.
			int currentPrefix = LOWORD(SendMessage(hSpinPrefix, UDM_GETPOS, 0, 0));

			// Получаем текущий IP-адрес, чтобы при необходимости его оставить
			SendMessage(hIPaddress, IPM_GETADDRESS, 0, (LPARAM)&dwIPaddress);

			UpdateNetworkFields(hwnd, hIPaddress, hIPmask, hEditPrefix, hSpinPrefix, 
				dwIPaddress, (DWORD)currentPrefix);			
		}
			break;
		case IDC_EDIT_PREFIX:
		{
			// Получаем новый префикс из текстового поля
			DWORD newPrefix = GetPrefixFromEditBox(hEditPrefix);

			// Получаем текущий IP-адрес
			SendMessage(hIPaddress, IPM_GETADDRESS, 0, (LPARAM)&dwIPaddress);

			// Обновляем все поля на основе нового префикса
			UpdateNetworkFields(hwnd, hIPaddress, hIPmask, hEditPrefix, hSpinPrefix, 
				dwIPaddress, newPrefix);
		}
			break;
		case IDOK:
		{
			SendMessage(hIPaddress, IPM_GETADDRESS, 0, (LPARAM)&dwIPaddress);
			SendMessage(hIPmask, IPM_GETADDRESS, 0, (LPARAM)&dwIPmask);

			dwIPprefix = GetPrefixFromEditBox(hEditPrefix);

			CHAR szIPAddrStr[20] = {};
			CHAR szMaskAddrStr[20] = {};
			CHAR szPrefixStr[4] = {};

			sprintf(szIPAddrStr, "%d.%d.%d.%d",
					(dwIPaddress >> 24) & 0xFF,
					(dwIPaddress >> 16) & 0xFF,
					(dwIPaddress >> 8) & 0xFF,
					dwIPaddress & 0xFF);

			sprintf(szMaskAddrStr, "%d.%d.%d.%d",
					(dwIPmask >> 24) & 0xFF,
					(dwIPmask >> 16) & 0xFF,
					(dwIPmask >> 8) & 0xFF,
					dwIPmask & 0xFF);

			GetDlgItemText(hEditPrefix, IDC_EDIT_PREFIX, szPrefixStr, sizeof(szPrefixStr));

			std::string message = "IP Address: " + std::string(szIPAddrStr) + "\n";
			message += "Mask: " + std::string(szMaskAddrStr) + "\n";
			message += "Prefix: /" + std::string(szPrefixStr);

			MessageBox(hwnd, message.c_str(), "Network Info", MB_OK);
		}
			break;
		case IDCANCEL:
			EndDialog(hwnd, 0);
			break;
		}
	}
		break;
	case WM_CLOSE:
		EndDialog(hwnd, 0);
	}
	return FALSE;
}
