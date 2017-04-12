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
    
	public partial class WifiSetting
	{
		
		private Timer tmrWifi;
		private int initialized;
		
		void WifiSetting_Opened(System.Object sender, System.EventArgs e)
		{

			Globals.Tags.wifiStatus.Value = "";
			Globals.Tags.wifiSignal.Value = 0;
			// Reset all data status
			
			foreach (ATcmd atCmd in Globals.Comm.XBee.atCmdSets)
			{
				atCmd.dataStatus = DataStatus.NotAvailable;
			}
			
			Globals.Tags.wifiStatus.Value = "Searching...";
			
			tmrWifi = new Timer();
			tmrWifi.Interval = 500;
			tmrWifi.Tick += new EventHandler(tmrWifiElasp);
			tmrWifi.Enabled = true;
			Globals.Tags.wifiReset.Value = 0;
			initialized = 0;
		}
		
		private void tmrWifiElasp(Object myObject, EventArgs myEventArgs) 
		{
		
			if (Globals.Comm.XBee.GetATcmd("AI").dataStatus == DataStatus.NotAvailable)
			{
				Globals.Comm.XBee.SendReadCmd("AI");
				
		//		Globals.Tags.wifidebugint.Value = 1;
			}
			else if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x00)
			{
				if (Globals.Comm.XBee.GetATcmd("ID").dataStatus == DataStatus.NotAvailable)
				{
					Globals.Comm.XBee.SendReadCmd("ID");
		//			Globals.Tags.wifidebugint.Value = 2;
				}
				else if (Globals.Comm.XBee.GetATcmd("LM").dataStatus == DataStatus.NotAvailable)
				{
					Globals.Comm.XBee.SendReadCmd("LM");
		//			Globals.Tags.wifidebugint.Value = 3;
				}
				else
				{
					Globals.Comm.XBee.SendReadCmd("AI");
		//			Globals.Tags.wifidebugint.Value = 4;
				}
			}
			else
			{
				Globals.Comm.XBee.SendReadCmd("AI");
		//		Globals.Tags.wifidebugint.Value = 7;
			}			
			
			if (initialized == 0)
			{
				initialized++;	
			}
			else
			{
				Status_Update();
			}
			
			
		}
				
		void Status_Update()
		{
			if (Globals.Comm.XBee.GetATcmd("AI").dataStatus == DataStatus.NotAvailable)
			{
				Globals.Tags.wifiStatus.Value = "Cannot Connect to WiFi Module";
			}
			else
			{
				switch(Globals.Comm.XBee.GetATcmd("AI").mRawData[0])
				{
					case 0x00:	 // Associated, get SSID and signal strength
						if (Globals.Comm.XBee.GetATcmd("ID").dataStatus == DataStatus.Available)
						{
							Globals.Tags.wifiStatus.Value = "Connected to \"" + System.Text.Encoding.ASCII.GetString(Globals.Comm.XBee.GetATcmd("ID").mRawData,0,Globals.Comm.XBee.GetATcmd("ID").mRawDataLen) + "\"";
			//				Globals.Tags.wifidebugint.Value = 5;
						}
						
						if (Globals.Comm.XBee.GetATcmd("LM").dataStatus == DataStatus.Available)
						{
							byte dbValue = Globals.Comm.XBee.GetATcmd("LM").mRawData[0];
							
							int valuedb = (int)dbValue;
							
							if (dbValue == 0xff)
							{
								Globals.Tags.wifiSignal.Value = Globals.Tags.wifiTempSignalStrength.Value;
							}
							else
							{
								Globals.Tags.wifiSignal.Value = (int)dbValue * 2;
							}
								
		//					Globals.Tags.wifidebugint.Value = 6;
						}
						
						
						break;
					default:
						Globals.Tags.wifiStatus.Value = Globals.Comm.XBee.GetAIStatus(Globals.Comm.XBee.GetATcmd("AI").mRawData[0]);
						Globals.Tags.wifiSignal.Value = 0;
						break;				
				}
			}
			
		}
			
		
		
		void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x00)
			{
				Globals.Tags.GeneralConfirmMsg.Value = "WiFi module is currently connected to \"" + System.Text.Encoding.ASCII.GetString(Globals.Comm.XBee.GetATcmd("ID").mRawData,0,Globals.Comm.XBee.GetATcmd("ID").mRawDataLen) + "\", are you sure you want to disconnect it?";
				Globals.Tags.ConfirmAction.Value = 2;
				Globals.popConfirm.Show();
			}
			else
			{
				Globals.wifiSearchSSID.Show();
			}
						
		}
		
		void WifiSetting_Closed(System.Object sender, System.EventArgs e)
		{
			tmrWifi.Enabled = false;
		}
		

	}
}
