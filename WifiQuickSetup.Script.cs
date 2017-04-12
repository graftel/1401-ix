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
	using System.Collections.Generic;
    
	public partial class WifiQuickSetup
	{
		private int currentPage = 1;
		private int total_pages = 1;
		private int currentStartIndex = 0;

		private List<SSIDInfo> mSSIDInfo; 
		void WifiQuickSetup_Opened(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.listSelected.Value = 0;
			mSSIDInfo = new List<SSIDInfo>();
			
			
			ResetAll();
			
			if (Globals.Comm.XBee.ssidInfo.Count > 0)	
			{

				mSSIDInfo = Globals.Comm.XBee.ssidInfo;

				DisplayItems(currentPage);
			}
			
		}
		
		void ResetAll()
		{
						
			ID1.Text = "";
			ID2.Text = "";
			ID3.Text = "";
			ID4.Text = "";
			ID5.Text = "";
			
			SC1.Text = "";
			SC2.Text = "";
			SC3.Text = "";
			SC4.Text = "";
			SC5.Text = "";
			
			CH1.Text = "";
			CH2.Text = "";
			CH3.Text = "";
			CH4.Text = "";
			CH5.Text = "";
			
			ID1.Visible = false;
			ID2.Visible = false;
			ID3.Visible = false;
			ID4.Visible = false;
			ID5.Visible = false;
			
			SC1.Visible = false;
			SC2.Visible = false;
			SC3.Visible = false;
			SC4.Visible = false;
			SC5.Visible = false;
			
			CH1.Visible = false;
			CH2.Visible = false;
			CH3.Visible = false;
			CH4.Visible = false;
			CH5.Visible = false;
			
			MP1.Visible = false;
			MP2.Visible = false;
			MP3.Visible = false;
			MP4.Visible = false;
			MP5.Visible = false;
		}
		
		
		void DisplayItems(int currentPageNum)
		{
			int start_entry,end_entry,count;

			if (mSSIDInfo.Count % 5 == 0)
			{
				total_pages = (mSSIDInfo.Count / 5);
			}
			else
			{
				total_pages = (mSSIDInfo.Count / 5) + 1;
			}
			
			if (currentPageNum > total_pages)
			{
				currentPageNum = total_pages;
			}
			
			// reset everything
			
			ResetAll();
			
			if (currentPageNum == total_pages)
			{
				btnNextPg.IsEnabled = false;
			}
			else
			{
				btnNextPg.IsEnabled = true;
			}
			
			
			
			if (currentPageNum == 1) 
			{
				btnPrevPg.IsEnabled = false;
			}
			else
			{
				btnPrevPg.IsEnabled = true;
			}



			if (mSSIDInfo.Count > 0)
			{
				start_entry = (currentPageNum - 1) * 5;
				currentStartIndex = start_entry;
				if (mSSIDInfo.Count < start_entry + 5)
				{
					end_entry = mSSIDInfo.Count;
				}
				else
				{
					end_entry = (currentPageNum) * 5;
				}
				
				count = 1;
				
				for (int i = start_entry; i < end_entry; i++)
				{
					switch(count)
					{
						case 1:
							ID1.Text = mSSIDInfo[i].mSSID;
							ID1.Visible = true;
							
							SC1.Text = mSSIDInfo[i].mSecurity;
							SC1.Visible = true;

							CH1.Text = mSSIDInfo[i].mChannel.ToString();
							CH1.Visible = true;
							
							Globals.Tags.wifiQuality1.Value = mSSIDInfo[i].mSignalStrengh;
							MP1.Visible = true;
							break;
						case 2:
							ID2.Text = mSSIDInfo[i].mSSID;
							ID2.Visible = true;

							SC2.Text = mSSIDInfo[i].mSecurity;
							SC2.Visible = true;

							CH2.Text = mSSIDInfo[i].mChannel.ToString();
							CH2.Visible = true;
							
							Globals.Tags.wifiQuality2.Value = mSSIDInfo[i].mSignalStrengh;
							MP2.Visible = true;
							break;
						case 3:
							ID3.Text = mSSIDInfo[i].mSSID;
							ID3.Visible = true;

							SC3.Text = mSSIDInfo[i].mSecurity;
							SC3.Visible = true;

							CH3.Text = mSSIDInfo[i].mChannel.ToString();
							CH3.Visible = true;
							
							Globals.Tags.wifiQuality3.Value = mSSIDInfo[i].mSignalStrengh;
							MP3.Visible = true;
							break;
						case 4:
							ID4.Text = mSSIDInfo[i].mSSID;
							ID4.Visible = true;

							SC4.Text = mSSIDInfo[i].mSecurity;
							SC4.Visible = true;

							CH4.Text = mSSIDInfo[i].mChannel.ToString();
							CH4.Visible = true;
							
							Globals.Tags.wifiQuality4.Value = mSSIDInfo[i].mSignalStrengh;
							MP4.Visible = true;
							break;
						case 5:
							ID5.Text = mSSIDInfo[i].mSSID;
							ID5.Visible = true;

							SC5.Text = mSSIDInfo[i].mSecurity;
							SC5.Visible = true;

							CH5.Text = mSSIDInfo[i].mChannel.ToString();
							CH5.Visible = true;
							
							Globals.Tags.wifiQuality5.Value = mSSIDInfo[i].mSignalStrengh;
							MP5.Visible = true;
							break;
					}
					
					count++;			
				}
				
			}
			
		}
		
		
		void ID1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 1;
		}
		

		
		void ID2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 2;
		}
		
		void ID3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 3;
		}
		
		void ID4_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 4;
		}
		
		void ID5_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 5;
		}
		
		void SC1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 1;
		}
		
		void SC2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 2;
		}
		
		void SC3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 3;
		}
		
		void SC4_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 4;
		}
		
		void SC5_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 5;
		}
		
		void MP1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 1;
		}
		
		void MP2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 2;
		}
		
		void MP3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 3;
		}
		
		void MP4_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 4;
		}
		
		void MP5_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 5;
		}
		
		
		void btnPrevPg_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.listSelected.Value = 0;
			currentPage--;
			DisplayItems(currentPage);
		}
		
		void btnNextPg_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.listSelected.Value = 0;
			currentPage++;
			DisplayItems(currentPage);
		}
		
		void btnNext_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.listSelected.Value == 0)
			{
				Globals.Tags.GeneralMessage.Value = "Please select an access point to connect";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				int pos = (currentPage - 1) * 5 + Globals.Tags.listSelected.Value.Int - 1;
			
				Globals.Tags.wifiSecurity.Value = (int)mSSIDInfo[pos].mbSecurity;
				
				Globals.Tags.wifiSSID.Value = mSSIDInfo[pos].mSSID;
				
				Globals.Tags.wifiTempSignalStrength.Value = mSSIDInfo[pos].mTrueSignalStrengh;
				
				if (mSSIDInfo[pos].mSecurity == "Open")
				{
					Globals.WifiConnectToAP.Show();
				}
				else
				{
					Globals.WifiEnterPassword.Show();
				}
			}
		}
		
		void btnPrev_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.wifiReset.Value = 0;
			Globals.Comm.XBee.SendReadCmd("FR");
		}
		
		void CH1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 1;
		}
		
		void CH2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 2;
		}
		
		void CH3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 3;
		}
		
		void CH4_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 4;
		}
		
		void CH5_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.listSelected.Value = 5;
		}
		
		
		
	}
}
