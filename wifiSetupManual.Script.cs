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
    
	public partial class wifiSetupManual
	{
		private Timer tmrWifi;
		private int stage;
		private int timeout_count;
		
		void wifiSetupManual_Opened(System.Object sender, System.EventArgs e)
		{
			tmrWifi = new Timer();
			tmrWifi.Interval = 500;
			tmrWifi.Tick += new EventHandler(tmrWifiElasp);
			tmrWifi.Enabled = true;
			
			btnOK.Visible = false;
			LinearMeter.Visible = true;
			Text2.Visible = true;
			
			Globals.Tags.wifiConnectAPProgress.Value = 0;
			
			stage = 0;
		}
		
		private void tmrWifiElasp(Object myObject, EventArgs myEventArgs) 
		{
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			if (stage == 0)
			{
				byte[] netType = new byte[1];
		
				netType[0] = (byte)Globals.Tags.wifiNetworkType.Value.Int;
			
				Globals.Comm.XBee.SendWriteCmd("AH",netType,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up network type";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 1)
			{
				if (Globals.Comm.XBee.GetATcmd("AH").dataStatus == DataStatus.Available)
				{
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
				byte[] mode = new byte[1];
		
				mode[0] = (byte)Globals.Tags.wifiInMode.Value.Int;
			
				Globals.Comm.XBee.SendWriteCmd("CE",mode,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up mode";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 3)
			{
				if (Globals.Comm.XBee.GetATcmd("CE").dataStatus == DataStatus.Available)
				{
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
				byte[] ssid = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiSSID.Value.String);
			
				Globals.Comm.XBee.SendWriteCmd("ID",ssid,ssid.Length);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up SSID";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 5)
			{
				if (Globals.Comm.XBee.GetATcmd("ID").dataStatus == DataStatus.Available)
				{
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
				byte[] dhcp = new byte[1];
		
				dhcp[0] = (byte)Globals.Tags.wifiIPAddrMode.Value.Int;
			
				Globals.Comm.XBee.SendWriteCmd("MA",dhcp,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up DHCP";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 7)
			{
				if (Globals.Comm.XBee.GetATcmd("MA").dataStatus == DataStatus.Available)
				{
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
				byte[] security = new byte[1];
		
				security[0] = (byte)Globals.Tags.wifiEnType.Value.Int;
			
				Globals.Comm.XBee.SendWriteCmd("EE",security,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 9)
			{
				if (Globals.Comm.XBee.GetATcmd("EE").dataStatus == DataStatus.Available)
				{
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
				byte[] password = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiPassword.Value.String);
				Globals.Comm.XBee.SendWriteCmd("PK",password,password.Length);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up password";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 11)
			{
				if (Globals.Comm.XBee.GetATcmd("PK").dataStatus == DataStatus.Available)
				{
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
				byte[] bDEPort = BitConverter.GetBytes((short)Globals.Tags.wifiDP.Value.Int);
			
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(bDEPort);
				}
			
				Globals.Comm.XBee.SendWriteCmd("DE",bDEPort,2);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up Destination Port";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 13)
			{
				if (Globals.Comm.XBee.GetATcmd("DE").dataStatus == DataStatus.Available)
				{
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
				byte[] bSPPort = BitConverter.GetBytes((short)Globals.Tags.wifiSP.Value.Int);
			
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(bSPPort);
				}
			
				Globals.Comm.XBee.SendWriteCmd("C0",bSPPort,2);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up Source Port";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 15)
			{
				if (Globals.Comm.XBee.GetATcmd("C0").dataStatus == DataStatus.Available)
				{
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
				byte[] convIP = new byte[4];
			
				convIP = GetIPFromStr(Globals.Tags.wifiDLIP.Value.String);
			
				Globals.Comm.XBee.SendWriteCmd("DL",convIP,4);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up destination IP";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 17)
			{
				if (Globals.Comm.XBee.GetATcmd("DL").dataStatus == DataStatus.Available)
				{
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
				
				byte[] convIP = new byte[4];
				convIP = GetIPFromStr(Globals.Tags.wifiIPAddrMark.Value.String);
			
				Globals.Comm.XBee.SendWriteCmd("MK",convIP,4);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up IP mask";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 19)
			{
				if (Globals.Comm.XBee.GetATcmd("MK").dataStatus == DataStatus.Available)
				{
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
				
				byte[] convIP = new byte[4];
				convIP = GetIPFromStr(Globals.Tags.wifiIPGateway.Value.String);
			
				Globals.Comm.XBee.SendWriteCmd("GW",convIP,4);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up Gateway IP";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 21)
			{
				if (Globals.Comm.XBee.GetATcmd("GW").dataStatus == DataStatus.Available)
				{
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
				
				byte[] convIP = new byte[4];
				convIP = GetIPFromStr(Globals.Tags.wifiIPAddr.Value.String);
			
				Globals.Comm.XBee.SendWriteCmd("MY",convIP,4);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up device IP";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 23)
			{
				if (Globals.Comm.XBee.GetATcmd("MY").dataStatus == DataStatus.Available)
				{
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
			else if (stage == 24)
			{
				
				Globals.Comm.XBee.SendReadCmd("WR");
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 25)
			{
				if (Globals.Comm.XBee.GetATcmd("WR").dataStatus == DataStatus.Available)
				{
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
			else if (stage == 26)
			{
				
				Globals.Comm.XBee.SendReadCmd("AC");
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 27)
			{
				if (Globals.Comm.XBee.GetATcmd("AC").dataStatus == DataStatus.Available)
				{
					timeout_count = 0;
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
			else if (stage == 28)
			{
				timeout_count++;
				
				Globals.Comm.XBee.SendReadCmd("AI");
				
				if (Globals.Comm.XBee.GetATcmd("AI").dataStatus == DataStatus.Available)
				{
					if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x00)
					{
						Globals.Tags.wifiConnectionStatus.Value = "Successfully connected to \"" + Globals.Tags.wifiSSID.Value + "\"";
						LinearMeter.Visible = false;
						btnOK.Visible = true;
						Text2.Visible = false;
						tmrWifi.Enabled = false;
					}
					else if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x27 || 
						Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x40)
					{
						Globals.Tags.wifiConnectionStatus.Value = "Wrong Password, please double check and re-enter";
						LinearMeter.Visible = false;
						btnOK.Visible = true;
						Text2.Visible = false;
						tmrWifi.Enabled = false;
					}
					else
					{
						Globals.Tags.wifiConnectionStatus.Value =  Globals.Comm.XBee.GetAIStatus(Globals.Comm.XBee.GetATcmd("AI").mRawData[0]);
					}
				}
				
				if (timeout_count > 20)
				{
					stage = 100;
				}
			}
			else if (stage == 100)
			{
			
				Globals.Tags.wifiConnectionStatus.Value = "Time out, could not establish connection, please retry or change another access point";
				LinearMeter.Visible = false;
				btnOK.Visible = true;
				tmrWifi.Enabled = false;
			}
		}
		
		byte[] GetIPFromStr(string strIP)
		{
			string[] tmpIP = strIP.Split('.');

			byte[] bIP = new byte[4];

			int currentValue;

			if (tmpIP.Length == 4)
			{
				for (int i = 0; i < 4; i++)
				{
					currentValue = Int32.Parse(tmpIP[i]);
					bIP[i] = (byte)currentValue;
				}


			}

			return bIP;
		}
		/*
		void update()
		{
			//read everything
			
			byte[] netType = new byte[1];
		
			netType[0] = (byte)Globals.Tags.wifiNetworkType.Value.Int;
			
			Globals.Comm.XBee.WaitForWriteAtCmd("AH",netType,1);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up network type";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			byte[] mode = new byte[1];
		
			mode[0] = (byte)Globals.Tags.wifiInMode.Value.Int;
			
			Globals.Comm.XBee.WaitForWriteAtCmd("CE",mode,1);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up mode";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			byte[] ssid = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiSSID.Value.String);
			
			Globals.Comm.XBee.WaitForWriteAtCmd("ID",ssid,ssid.Length);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up SSID";
			Globals.Tags.wifiConnectAPProgress.Value++;

			byte[] dhcp = new byte[1];
		
			dhcp[0] = (byte)Globals.Tags.wifiIPAddrMode.Value.Int;
			
			Globals.Comm.XBee.WaitForWriteAtCmd("MA",dhcp,1);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up DHCP";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
		
			
			byte[] security = new byte[1];
		
			security[0] = (byte)Globals.Tags.wifiEnType.Value.Int;
			
			Globals.Comm.XBee.WaitForWriteAtCmd("EE",security,1);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			if (Globals.Tags.wifiPassword.Value != "")
			{
				byte[] password = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiPassword.Value.String);
				Globals.Comm.XBee.WaitForWriteAtCmd("PK",password,password.Length);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up password";
				Globals.Tags.wifiConnectAPProgress.Value++;
			}
			
			
			byte[] bDEPort = BitConverter.GetBytes((short)Globals.Tags.wifiDP.Value.Int);
			
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bDEPort);
			}
			
			Globals.Comm.XBee.WaitForWriteAtCmd("DE",bDEPort,2);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			byte[] bSPPort = BitConverter.GetBytes((short)Globals.Tags.wifiSP.Value.Int);
			
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bSPPort);
			}
			
			Globals.Comm.XBee.WaitForWriteAtCmd("DE",bSPPort,2);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			byte[] convIP = new byte[4];
			
			convIP = GetIPFromStr(Globals.Tags.wifiDLIP.Value.String);
			
			Globals.Comm.XBee.WaitForWriteAtCmd("DL",convIP,4);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up destination IP";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			
			convIP = GetIPFromStr(Globals.Tags.wifiIPAddrMark.Value.String);
			
			Globals.Comm.XBee.WaitForWriteAtCmd("MK",convIP,4);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up IP mask";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			convIP = GetIPFromStr(Globals.Tags.wifiIPGateway.Value.String);
			
			Globals.Comm.XBee.WaitForWriteAtCmd("GW",convIP,4);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up Gateway IP";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			
			convIP = GetIPFromStr(Globals.Tags.wifiIPAddr.Value.String);
			
			Globals.Comm.XBee.WaitForWriteAtCmd("MY",convIP,4);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up device IP";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			
			Globals.Comm.XBee.WaitForAtCmd("WR");
			Globals.Tags.wifiConnectAPProgress.Value++;
			Globals.Comm.XBee.WaitForAtCmd("AC");
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			
			int retry_count = 0;
			int MAX_RETRY_COUNT = 30;
			
			Globals.Comm.XBee.WaitForAtCmd("AI");
			
			while (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] != 0x00)
			{
				Globals.Tags.wifiConnectionStatus.Value =  Globals.Comm.XBee.GetAIStatus(Globals.Comm.XBee.GetATcmd("AI").mRawData[0]);
				Globals.Comm.XBee.WaitForAtCmd("AI");
				retry_count++;
				if (Globals.Tags.wifiConnectAPProgress.Value < 100)
				{
					Globals.Tags.wifiConnectAPProgress.Value+=2;
				}
				if (retry_count > MAX_RETRY_COUNT || Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x40)
				{
					break;
				}
				
				Thread.Sleep(500);
			}
			
			Text2.Visible = false;	
			
			if (retry_count > MAX_RETRY_COUNT)
			{
				
				Globals.Tags.wifiConnectionStatus.Value = "Time out, could not establish connection, please retry or change another access point";
				LinearMeter.Visible = false;
				btnOK.Visible = true;
			}
			else if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x40)
			{
				Globals.Tags.wifiConnectionStatus.Value = "Wrong Wi-Fi password, please try again";
				LinearMeter.Visible = false;
				btnOK.Visible = true;
			}
			else
			{
				Globals.Tags.wifiConnectionStatus.Value = "Successfully connect to \"" + Globals.Tags.wifiSSID.Value + "\"";
				LinearMeter.Visible = false;
				btnOK.Visible = true;
				
			}
		}
		*/
		
		void wifiSetupManual_Closed(System.Object sender, System.EventArgs e)
		{
			tmrWifi.Enabled = false;
		}
		

	}
}
