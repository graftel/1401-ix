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
    
	public partial class WifiSetupSoftAP
	{
		
		private Timer tmrWifi;
		private int stage;
		private int timeout_count;
		void WifiSetupSoftAP_Opened(System.Object sender, System.EventArgs e)
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
				byte[] mode = {0x01}; 
				Globals.Comm.XBee.GetATcmd("CE").dataStatus = DataStatus.NotAvailable;
				Globals.Comm.XBee.SendWriteCmd("CE",mode,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up mode";
				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 1)
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
			else if (stage == 2)
			{
				byte[] ssid = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiSSID.Value.String);
				
				Globals.Comm.XBee.GetATcmd("ID").dataStatus = DataStatus.NotAvailable;
				Globals.Comm.XBee.SendWriteCmd("ID",ssid,ssid.Length);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up SSID";
				timeout_count = 0;
				stage++;
			}
			else if (stage == 3)
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
			else if (stage == 4)
			{
				byte[] dhcp = {0x00}; 
				Globals.Comm.XBee.SendWriteCmd("MA",dhcp,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up DHCP";
				timeout_count = 0;
				stage++;
			}	
			else if (stage == 5)
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
			else if (stage == 6)
			{
				
				
				if (Globals.Tags.wifiPassword.Value == "")
				{
					
					byte[] security = {0x00}; 
					Globals.Comm.XBee.SendWriteCmd("EE",security,1);
					Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
				}	
				else
				{
					byte[] security = {0x02}; 
					Globals.Comm.XBee.SendWriteCmd("EE",security,1);
					Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
				}
					

				timeout_count = 0;
				stage++;
				
			}
			else if (stage == 7)
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
			else if (stage == 8)
			{
				if (Globals.Tags.wifiPassword.Value == "")
				{
					stage = 10;
				}
				else
				{
					byte[] password = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiPassword.Value.String);
					Globals.Comm.XBee.SendWriteCmd("PK",password,password.Length);
					Globals.Tags.wifiConnectionStatus.Value = "Setup up password";
					timeout_count = 0;
					stage++;
				}
			}
			else if (stage == 9)
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
			else if (stage == 10)
			{
				Globals.Comm.XBee.SendReadCmd("WR");
				timeout_count = 0;
				stage++;			
			}
			else if (stage == 11)
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
			else if (stage == 12)
			{
				Globals.Comm.XBee.SendReadCmd("AC");
				timeout_count = 0;
				stage++;			
			}
			else if (stage == 13)
			{
				if (Globals.Comm.XBee.GetATcmd("AC").dataStatus == DataStatus.Available)
				{
					stage++;
					timeout_count = 0;
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
				timeout_count++;
				
				Globals.Comm.XBee.SendReadCmd("AI");
				
				if (Globals.Comm.XBee.GetATcmd("AI").dataStatus == DataStatus.Available)
				{
					if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x00)
					{
						Globals.Tags.wifiConnectionStatus.Value = "Successfully setup up Soft AP as \"" + Globals.Tags.wifiSSID.Value + "\"";
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
			else if (stage == 100)  // Timeout Error Stage
			{
				Globals.Tags.wifiConnectionStatus.Value = "Time out, could not establish connection, please retry or change another access point";
				LinearMeter.Visible = false;
				btnOK.Visible = true;
				tmrWifi.Enabled = false;
			}
		}
		/*
		void update()
		{
			//read everything
			
			byte[] mode = {0x01}; 
			
			Globals.Comm.XBee.WaitForWriteAtCmd("CE",mode,1);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up mode";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			byte[] ssid = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiSSID.Value.String);
			
			Globals.Comm.XBee.WaitForWriteAtCmd("ID",ssid,ssid.Length);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up SSID";
			Globals.Tags.wifiConnectAPProgress.Value++;

			byte[] dhcp = {0x00}; 
			Globals.Comm.XBee.WaitForWriteAtCmd("MA",dhcp,1);
			Globals.Tags.wifiConnectionStatus.Value = "Setup up DHCP";
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			
			if (Globals.Tags.wifiPassword.Value == "")
			{
				byte[] security = {0x00}; 
				Globals.Comm.XBee.WaitForWriteAtCmd("EE",security,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
				Globals.Tags.wifiConnectAPProgress.Value++;
			}
			else
			{
				byte[] password = System.Text.Encoding.ASCII.GetBytes(Globals.Tags.wifiPassword.Value.String);
				Globals.Comm.XBee.WaitForWriteAtCmd("PK",password,password.Length);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up password";
				Globals.Tags.wifiConnectAPProgress.Value++;
				
				byte[] security = {0x02}; 
				Globals.Comm.XBee.WaitForWriteAtCmd("EE",security,1);
				Globals.Tags.wifiConnectionStatus.Value = "Setup up security";
				Globals.Tags.wifiConnectAPProgress.Value++;
			}
			
			Globals.Comm.XBee.WaitForAtCmd("WR");
			Globals.Tags.wifiConnectAPProgress.Value++;
			Globals.Comm.XBee.WaitForAtCmd("AC");
			Globals.Tags.wifiConnectAPProgress.Value++;
			
			
			int retry_count = 0;
			int MAX_RETRY_COUNT = 50;
			
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
		void WifiSetupSoftAP_Closed(System.Object sender, System.EventArgs e)
		{
			tmrWifi.Enabled = false;
		}

	}		
}
