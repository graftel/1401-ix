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
    
	public partial class wifiSearchSSID
	{

		int searchStatus = 0;
		private int searchTimeCount;
		private const int MaxSearchTime = 3;
		private Timer tmrWifi;
		private int timeout_count;
		void wifiSearchSSID_Opened(System.Object sender, System.EventArgs e)
		{
			
			Globals.Comm.XBee.GetATcmd("NR").dataStatus = DataStatus.NotAvailable;
			Globals.Comm.XBee.GetATcmd("AS").dataStatus = DataStatus.NotAvailable;
			Globals.Comm.XBee.ssidInfo.Clear();
			
			tmrWifi = new Timer();
			tmrWifi.Interval = 500;
			tmrWifi.Tick += new EventHandler(tmrWifiElasp);
			tmrWifi.Enabled = true;
			
			btnOK.Visible = false;
			LinearMeter.Visible = true;
			Text2.Visible = true;	
			searchStatus = 0;
			timeout_count = 0;
			searchTimeCount = 0;
			Globals.Tags.wifiConnectionStatus.Value = "Initializing";
			Globals.Tags.wifiConnectAPProgress.Value = 0;
		}
		
		private void tmrWifiElasp(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Tags.wifiConnectAPProgress.Value == 0)
			{
				if (Globals.Tags.wifiReset.Value == 1)
				{
					Globals.Tags.wifiConnectAPProgress.Value = 12;
				}
				else
				{
					Globals.Comm.XBee.SendReadCmd("NR");
				
					Globals.Tags.wifiConnectionStatus.Value = "Reset";
				
					Globals.Tags.wifiConnectAPProgress.Value++;
				}
		
				
			}
			else if (Globals.Tags.wifiConnectAPProgress.Value >= 1 && Globals.Tags.wifiConnectAPProgress.Value <= 10)
			{
				Globals.Tags.wifiConnectAPProgress.Value++;
				if (Globals.Comm.XBee.GetATcmd("NR").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiConnectAPProgress.Value = 12;
					Globals.Tags.wifiReset.Value = 1;
				}
			}
			else if (Globals.Tags.wifiConnectAPProgress.Value == 11)
			{
				if (Globals.Comm.XBee.GetATcmd("NR").dataStatus == DataStatus.Available)
				{
					Globals.Tags.wifiConnectAPProgress.Value++;
					timeout_count = 0;
				}
				else
				{
					btnOK.Visible = true;
					LinearMeter.Visible = false;
					searchStatus = 2;
					Globals.Tags.wifiConnectionStatus.Value = "Cannot find access point, restart LRM and retry";
					tmrWifi.Enabled = false;
				}
				
			}
			else if (Globals.Tags.wifiConnectAPProgress.Value == 12)
			{
				Globals.Tags.wifiConnectionStatus.Value = "Reset successful, waiting for searching to start";
				Globals.Comm.XBee.SendReadCmd("AI");
				
				if (Globals.Comm.XBee.GetATcmd("AI").dataStatus == DataStatus.Available)
				{
					if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x23)
					{
						searchStatus = 1;
						Globals.Tags.wifiConnectionStatus.Value = "Searching";
						Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 2;
					}
					else
					{
						timeout_count++;
						
						if (timeout_count > 20)
						{
							btnOK.Visible = true;
							LinearMeter.Visible = false;
							searchStatus = 2;
							Globals.Tags.wifiConnectionStatus.Value = "Cannot find access point, click OK to go back and retry";
							tmrWifi.Enabled = false;
						}
						
					}
				}
			}
			else if (Globals.Tags.wifiConnectAPProgress.Value == 14)
			{
				
				
				Globals.Comm.XBee.SendReadCmd("AS");
				
				Globals.Tags.wifiConnectAPProgress.Value++;
				// wait for 5 seconds
			}
			else if (Globals.Tags.wifiConnectAPProgress.Value >= 15 &&
					Globals.Tags.wifiConnectAPProgress.Value <= 45)
			{
				Globals.Tags.wifiConnectAPProgress.Value++;
				if (Globals.Comm.XBee.GetATcmd("AS").dataStatus == DataStatus.Available)
				{
					
					if (searchTimeCount < 4)
					{
						searchTimeCount++;
						Globals.Tags.wifiConnectAPProgress.Value = 14;
					}
					else
					{
						Globals.WifiQuickSetup.Show();
					}
					
				}
			}
			else if (Globals.Tags.wifiConnectAPProgress.Value == 46)
			{
				if (Globals.Comm.XBee.ssidInfo.Count > 0)	
				{
					btnOK.Visible = true;
					LinearMeter.Visible = false;
					Globals.Tags.wifiConnectionStatus.Value = "Found " + Globals.Comm.XBee.ssidInfo.Count.ToString() + " access points";
					tmrWifi.Enabled = false;
				}
				else
				{
					btnOK.Visible = true;
					LinearMeter.Visible = false;
					Globals.Tags.wifiConnectionStatus.Value = "Cannot find access point, click OK to go back and retry";
					tmrWifi.Enabled = false;
					searchStatus = 2;
				}
			}
		   
			

			
		
		}
		
		/*
		
		void update()
		{
			
			int times_out = 0;
			int MAX_COUNT = 5;

			Globals.Comm.XBee.WaitForAtCmd("NR");
			
			Globals.Tags.wifiConnectionStatus.Value = "Reset";
			
			Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 2;
			
			while(searchStatus == 0)
			{		
				if(Globals.Comm.XBee.WaitForAtCmd("AI"))
				{
					if (Globals.Comm.XBee.GetATcmd("AI").mRawData[0] == 0x23)
					{
						searchStatus = 1;
						Globals.Tags.wifiConnectionStatus.Value = "Searching";
					}
				}

				Globals.Tags.wifiConnectAPProgress.Value = Globals.Tags.wifiConnectAPProgress.Value + 2;
				
				times_out++;
				
				Thread.Sleep(500);
				
				if (times_out > MAX_COUNT)
				{
					searchStatus = 2;
					btnOK.Visible = true;
					LinearMeter.Visible = false;
					
					Globals.Tags.wifiConnectionStatus.Value = "Cannot find access point, click OK to go back and retry";
					
				}
			}
			
			
			switch (searchStatus)
			{
				case 1:
					if (Globals.Comm.XBee.WaitForAtCmd("AS"))
					{
						Thread.Sleep(500);
						if (Globals.Comm.XBee.ssidInfo.Count > 0)	
						{
							btnOK.Visible = true;
							LinearMeter.Visible = false;
							Globals.Tags.wifiConnectionStatus.Value = "Found " + Globals.Comm.XBee.ssidInfo.Count.ToString() + " access points";
						}
						else
						{
							Globals.Comm.XBee.WaitForAtCmd("FR");
							
							Globals.Comm.XBee.WaitForAtCmd("NR");
							
							Globals.Comm.XBee.WaitForAtCmd("AS");
							
							if (Globals.Comm.XBee.ssidInfo.Count > 0)	
							{
								btnOK.Visible = true;
								LinearMeter.Visible = false;
								Globals.Tags.wifiConnectionStatus.Value = "Found " + Globals.Comm.XBee.ssidInfo.Count.ToString() + " access points";
							}
							else
							{
								Globals.Tags.wifiConnectionStatus.Value = "Cannot find access point, click OK to go back";
							}
						}
				
						
					}
					break;
				case 2:
					
					btnOK.Visible = true;
					LinearMeter.Visible = false;
					
					Globals.Tags.wifiConnectionStatus.Value = "Cannot find access point, click OK to go back and retry";
					
					break;
				
			}
			
	
		}
*/
		
		void btnOK_Click(System.Object sender, System.EventArgs e)
		{
			switch(searchStatus)
			{
				case 1:
					Globals.WifiQuickSetup.Show();
					break;
				case 2:
					Globals.WifiSetting.Show();
					break;
			}
		}
		
		void wifiSearchSSID_Closed(System.Object sender, System.EventArgs e)
		{
			tmrWifi.Enabled = false;
		}
		
		
	}
}
