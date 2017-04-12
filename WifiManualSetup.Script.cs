//--------------------------------------------------------------
// Press F1 to get help about using script.
// To access an object that is not located in the current class, start the call with Globals.
// When using events and timers be cautious not to generate memoryleaks,
// please see the help for more information.
//---------------------------------------------------------------

namespace Neo.ApplicationFramework.Generated
{
	using System.Windows.Forms;
	using System;
	using System.Drawing;
	using Neo.ApplicationFramework.Tools;
	using Neo.ApplicationFramework.Common.Graphics.Logic;
	using Neo.ApplicationFramework.Controls;
	using Neo.ApplicationFramework.Interfaces;
	using System.Net;

	public partial class WifiManualSetup
	{
		int page;
		private Timer tmrWifi;
		private int stage;
		private int timeout_count;
		
		void WifiManualSetup_Opened(System.Object sender, System.EventArgs e)
		{
			page = 0;
			
			ShowContent(page);
			
			tmrWifi = new Timer();
			tmrWifi.Interval = 500;
			tmrWifi.Tick += new EventHandler(tmrWifiElasp);
			tmrWifi.Enabled = true;
			
			stage = 0;
			Globals.Tags.wifiConnectAPProgress.Value = 0;
			
			Globals.Tags.wifiPassword.Value = "";
		}
		
		private void tmrWifiElasp(Object myObject, EventArgs myEventArgs) 
		{
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			if (stage == 0)
			{
				Globals.Comm.XBee.SendReadCmd("AH");
				lblPrg.Text = "Reading Network Type";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 1)
			{
				if (Globals.Comm.XBee.GetATcmd("AH").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiNetworkType.Value = (int)Globals.Comm.XBee.GetATcmd("AH").mRawData[0];
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 2)
			{
				Globals.Comm.XBee.SendReadCmd("CE");
				lblPrg.Text = "Reading Wifi Mode";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 3)
			{
				if (Globals.Comm.XBee.GetATcmd("CE").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiInMode.Value = (int)Globals.Comm.XBee.GetATcmd("CE").mRawData[0];
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 4)
			{
				Globals.Comm.XBee.SendReadCmd("ID");
				lblPrg.Text = "Reading SSID";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 5)
			{
				if (Globals.Comm.XBee.GetATcmd("ID").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiSSID.Value = System.Text.Encoding.ASCII.GetString(Globals.Comm.XBee.GetATcmd("ID").mRawData,0,Globals.Comm.XBee.GetATcmd("ID").mRawDataLen);
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 6)
			{
				Globals.Comm.XBee.SendReadCmd("EE");
				lblPrg.Text = "Reading Encryption";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 7)
			{
				if (Globals.Comm.XBee.GetATcmd("EE").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiEnType.Value = (int)Globals.Comm.XBee.GetATcmd("EE").mRawData[0];	
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 8)
			{
				Globals.Comm.XBee.SendReadCmd("MA");
				lblPrg.Text = "Reading DHCP Setting";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 9)
			{
				if (Globals.Comm.XBee.GetATcmd("MA").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiIPAddrMode.Value = (int)Globals.Comm.XBee.GetATcmd("MA").mRawData[0];	
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 10)
			{
				Globals.Comm.XBee.SendReadCmd("DL");
				lblPrg.Text = "Reading Destination IP";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 11)
			{
				if (Globals.Comm.XBee.GetATcmd("DL").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiDLIP.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("DL").mRawData,Globals.Comm.XBee.GetATcmd("DL").mRawDataLen);
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 12)
			{
				Globals.Comm.XBee.SendReadCmd("DE");
				lblPrg.Text = "Reading Destination Port";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 13)
			{
				if (Globals.Comm.XBee.GetATcmd("DE").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiDP.Value = ConvertPort(Globals.Comm.XBee.GetATcmd("DE").mRawData);
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 14)
			{
				Globals.Comm.XBee.SendReadCmd("C0");
				lblPrg.Text = "Reading Source Port";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 15)
			{
				if (Globals.Comm.XBee.GetATcmd("C0").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiSP.Value = ConvertPort(Globals.Comm.XBee.GetATcmd("C0").mRawData);
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 16)
			{
				Globals.Comm.XBee.SendReadCmd("MK");
				lblPrg.Text = "Reading Mask Address";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 17)
			{
				if (Globals.Comm.XBee.GetATcmd("MK").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiIPAddrMark.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("MK").mRawData,Globals.Comm.XBee.GetATcmd("MK").mRawDataLen);
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 18)
			{
				Globals.Comm.XBee.SendReadCmd("GW");
				lblPrg.Text = "Reading Gateway Address";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 19)
			{
				if (Globals.Comm.XBee.GetATcmd("GW").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiIPGateway.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("GW").mRawData,Globals.Comm.XBee.GetATcmd("GW").mRawDataLen);
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 20)
			{
				Globals.Comm.XBee.SendReadCmd("MY");
				lblPrg.Text = "Reading Device IP Address";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 21)
			{
				if (Globals.Comm.XBee.GetATcmd("MY").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiIPAddr.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("MY").mRawData,Globals.Comm.XBee.GetATcmd("MY").mRawDataLen);
					stage++;
				}
				else
				{
					timeout_count++;	
				}
				
				if (timeout_count > 10)
				{
					stage = 100;
				}	
			}
			else if (stage == 22)
			{
				page = 1;
				ShowContent(page);
				tmrWifi.Enabled = false;
			}
			else if (stage == 100)
			{
				page = 1;
				ShowContent(page);
				tmrWifi.Enabled = false;
			}
			
		}
		
		string ConvertIP(byte[] input, int len)
		{
			string strOut = "";

			for (int i = 0; i < len; i++)
			{
				strOut = strOut + ((int)input[i]).ToString();

				strOut = strOut + ".";
			}

			strOut = strOut.Remove(strOut.Length - 1,1);
			
			return strOut;
		}
		
		string ConvertPort(byte[] input)
		{
			
			byte[] port = new byte[2]; 
			
			port[0] = input[0];
			port[1] = input[1];
			
			if (BitConverter.IsLittleEndian)
				Array.Reverse(port);

			return ((Int32)(BitConverter.ToInt16(port, 0))).ToString();
		
			
		}
		/*
		void update()
		{
			if (Globals.Comm.XBee.WaitForAtCmd("AH"))
			{
				Globals.Tags.wifiNetworkType.Value = (int)Globals.Comm.XBee.GetATcmd("AH").mRawData[0];
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("CE"))
			{
				Globals.Tags.wifiInMode.Value = (int)Globals.Comm.XBee.GetATcmd("CE").mRawData[0];
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("ID"))
			{
				Globals.Tags.wifiSSID.Value = System.Text.Encoding.ASCII.GetString(Globals.Comm.XBee.GetATcmd("ID").mRawData,0,Globals.Comm.XBee.GetATcmd("ID").mRawDataLen);
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("EE"))
			{
				Globals.Tags.wifiEnType.Value = (int)Globals.Comm.XBee.GetATcmd("EE").mRawData[0];	
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			Globals.Tags.wifiPassword.Value = "";
			
			if (Globals.Comm.XBee.WaitForAtCmd("MA"))
			{
				Globals.Tags.wifiIPAddrMode.Value = (int)Globals.Comm.XBee.GetATcmd("MA").mRawData[0];	
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("DL"))
			{
				Globals.Tags.wifiDLIP.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("DL").mRawData,Globals.Comm.XBee.GetATcmd("DL").mRawDataLen);
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("DE"))
			{
				Globals.Tags.wifiDP.Value = ConvertPort(Globals.Comm.XBee.GetATcmd("DE").mRawData);
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("C0"))
			{
				Globals.Tags.wifiSP.Value = ConvertPort(Globals.Comm.XBee.GetATcmd("C0").mRawData);
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("MK"))
			{
				Globals.Tags.wifiIPAddrMark.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("MK").mRawData,Globals.Comm.XBee.GetATcmd("MK").mRawDataLen);
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			

			if (Globals.Comm.XBee.WaitForAtCmd("GW"))
			{
				Globals.Tags.wifiIPGateway.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("GW").mRawData,Globals.Comm.XBee.GetATcmd("GW").mRawDataLen);
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			if (Globals.Comm.XBee.WaitForAtCmd("MY"))
			{
				Globals.Tags.wifiIPAddr.Value = ConvertIP(Globals.Comm.XBee.GetATcmd("MY").mRawData,Globals.Comm.XBee.GetATcmd("MY").mRawDataLen);
				
				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 5;
			}
			
			page = 1;
			
			ShowContent(page);
		}
		*/
		
		void ShowContent(int ipage)
		{
			switch(ipage)
			{
				case 0:
					lblTitle.Text = "Manual Setup";
					
					prgBar.Visible = true;
					lblPrg.Visible = true;
					
					Button1.Visible = false;
					Button2.Visible = false;
					
					lblNetType.Visible = false;
					cbNetType.Visible = false;
					lblInMode.Visible = false;
					cbInMode.Visible = false;
					lblSSID.Visible = false;
					tbSSID.Visible = false;
					lblEnType.Visible = false;
					cbEnType.Visible = false;
			
					lblPass.Visible = false;
					tbPass.Visible = false;
					lblIPMode.Visible = false;
					cbIPMode.Visible = false;
					lblDL.Visible = false;
					tbDL.Visible = false;
					lblDP.Visible = false;
					tbDP.Visible = false;
			
					lblSP.Visible = false;
					tbSP.Visible = false;
					lblIPGateway.Visible = false;
					tbIPGateway.Visible = false;
					lblIPAddrMark.Visible = false;
					tbIPAddrMark.Visible = false;
					lblIPAddr.Visible = false;
					tbIPAddr.Visible = false;
					btnApply.Visible = false;
					break;
				case 1:
					lblTitle.Text = "Manual Setup 1/3";
			
					prgBar.Visible = false;
					lblPrg.Visible = false;
					
					Button1.Visible = true;
					Button2.Visible = true;
					
					lblNetType.Visible = true;
					cbNetType.Visible = true;
					lblInMode.Visible = true;
					cbInMode.Visible = true;
					lblSSID.Visible = true;
					tbSSID.Visible = true;
					lblEnType.Visible = true;
					cbEnType.Visible = true;
			
					lblPass.Visible = false;
					tbPass.Visible = false;
					lblIPMode.Visible = false;
					cbIPMode.Visible = false;
					lblDL.Visible = false;
					tbDL.Visible = false;
					lblDP.Visible = false;
					tbDP.Visible = false;
			
					lblSP.Visible = false;
					tbSP.Visible = false;
					lblIPGateway.Visible = false;
					tbIPGateway.Visible = false;
					lblIPAddrMark.Visible = false;
					tbIPAddrMark.Visible = false;
					lblIPAddr.Visible = false;
					tbIPAddr.Visible = false;
					btnApply.Visible = true;
					break;
				case 2:
					lblTitle.Text = "Manual Setup 2/3";
			
					prgBar.Visible = false;
					lblPrg.Visible = false;
					
					Button1.Visible = true;
					Button2.Visible = true;
					
					lblNetType.Visible = false;
					cbNetType.Visible = false;
					lblInMode.Visible = false;
					cbInMode.Visible = false;
					lblSSID.Visible = false;
					tbSSID.Visible = false;
					lblEnType.Visible = false;
					cbEnType.Visible = false;
			
					lblPass.Visible = true;
					tbPass.Visible = true;
					lblIPMode.Visible = true;
					cbIPMode.Visible = true;
					lblDL.Visible = true;
					tbDL.Visible = true;
					lblDP.Visible = true;
					tbDP.Visible = true;
			
					lblSP.Visible = false;
					tbSP.Visible = false;
					lblIPGateway.Visible = false;
					tbIPGateway.Visible = false;
					lblIPAddrMark.Visible = false;
					tbIPAddrMark.Visible = false;
					lblIPAddr.Visible = false;
					tbIPAddr.Visible = false;
					btnApply.Visible = true;
					break;
				case 3:
					lblTitle.Text = "Manual Setup 3/3";
			
					prgBar.Visible = false;
					lblPrg.Visible = false;
					
					Button1.Visible = true;
					Button2.Visible = true;
					
					lblNetType.Visible = false;
					cbNetType.Visible = false;
					lblInMode.Visible = false;
					cbInMode.Visible = false;
					lblSSID.Visible = false;
					tbSSID.Visible = false;
					lblEnType.Visible = false;
					cbEnType.Visible = false;
			
					lblPass.Visible = false;
					tbPass.Visible = false;
					lblIPMode.Visible = false;
					cbIPMode.Visible = false;
					lblDL.Visible = false;
					tbDL.Visible = false;
					lblDP.Visible = false;
					tbDP.Visible = false;
			
					lblSP.Visible = true;
					tbSP.Visible = true;
					lblIPGateway.Visible = true;
					tbIPGateway.Visible = true;
					lblIPAddrMark.Visible = true;
					tbIPAddrMark.Visible = true;
					lblIPAddr.Visible = true;
					tbIPAddr.Visible = true;
					btnApply.Visible = true;
					break;
			}
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			if (page < 3)
			{
				page++;
				ShowContent(page);
			}
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			if (page > 1)
			{
				page--;
				ShowContent(page);
			}
		}
		
		
		bool VerifySSID(string strSSID)
		{
			if (strSSID.Length < 31)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		bool VerifyPort(string strPort)
		{
			int testPort = 0;
			bool bTest = true;
			
			try
			{
				testPort = Int32.Parse(strPort);	
			}
			catch
			{
				bTest = false;
			}
			if (bTest)
			{
				if (testPort >= 1 && testPort <= 65535)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		
		bool VerifyIP(string strIP)
		{
			IPAddress testIP;
			
			bool bTest = true;
			
			try{
				testIP = IPAddress.Parse(strIP);
			}
			catch
			{
				bTest = false;
			}
		
			if (bTest)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//	  string[] tmpIP = strIP.Split('.');
			
		//		int currentValue = 0;
			
		//		bool CheckResult = true;
			
		//		if (tmpIP.Length == 4)
		//		{
		//			for (int i = 0; i < 4; i++)
		//			{
		//				if (Int32.TryParse(tmpIP[i], out currentValue))
		//				{
		//					if (currentValue
		//				}
		//				else
		//				{
		//					CheckResult = false;
		//				}
		//			}
		//		}
		//		else
		//		{
		//			return false;
		//		}
			
			
		//		return CheckResult;
		
		void WifiManualSetup_Closed(System.Object sender, System.EventArgs e)
		{
			tmrWifi.Enabled = false;
		}
		
		void btnApply_Click(System.Object sender, System.EventArgs e)
		{
			// Check IP addresses and Port
		
			if (!VerifySSID(Globals.Tags.wifiSSID.Value.String))
			{
				Globals.Tags.GeneralMessage.Value = "Please enter valid SSID";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			if (!VerifyPort(Globals.Tags.wifiSP.Value.String))
			{
				Globals.Tags.GeneralMessage.Value = "Please enter valid source port";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			if (!VerifyPort(Globals.Tags.wifiDP.Value.String))
			{
				Globals.Tags.GeneralMessage.Value = "Please enter valid destination port";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			if (!VerifyIP(Globals.Tags.wifiDLIP.Value.String))
			{
				Globals.Tags.GeneralMessage.Value = "Please enter valid destination ip";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			if (!VerifyIP(Globals.Tags.wifiIPAddrMark.Value.String))
			{
				Globals.Tags.GeneralMessage.Value = "Please enter valid network mask";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			if (!VerifyIP(Globals.Tags.wifiIPAddr.Value.String))
			{
				Globals.Tags.GeneralMessage.Value = "Please enter valid device IP address";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			if (!VerifyIP(Globals.Tags.wifiIPGateway.Value.String))
			{
				Globals.Tags.GeneralMessage.Value = "Please enter valid gateway";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			if (Globals.Tags.wifiEnType.Value != 0 && Globals.Tags.wifiPassword.Value == "")
			{
				Globals.Tags.GeneralMessage.Value = "Did you forget to enter password?";
				Globals.GeneralMsgBox.Show();
				return;
			}
			
			Globals.wifiSetupManual.Show();
		}
	}
}
