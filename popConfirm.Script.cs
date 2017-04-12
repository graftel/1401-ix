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
    
    
    public partial class popConfirm
	{
		
		void btnYes_Click(System.Object sender, System.EventArgs e)
		{
			switch(Globals.Tags.ConfirmAction.Value.Int)
			{
				case 1:
					Globals.popConfirm.Close();
					Globals.MainScreen.Show();
					break;
				case 2:
					Globals.popConfirm.Close();;
					Globals.wifiSearchSSID.Show();
					break;
				case 3:
					Globals.popConfirm.Close();
					Globals.Tags.wifiStreaming.Value = 0;
					Globals.Tags.RemoteDesktopIcon.Value = 0;
					Globals.Comm.XBee.SendForceCloseConnection();
					break;
				case 4:
					Globals.popConfirm.Close();
					Globals.SettingScreen.Show();
					break;
				case 5:
					Globals.Tags.calRegType.Value = 0;
					Globals.popConfirm.Close();
					Globals.popCalValueAdjust.Show();
					break;
				case 6:
					Globals.Tags.calRegType.Value = 1;
					Globals.popConfirm.Close();
					Globals.popCalValueAdjust.Show();
					break;
			}
		}
		
		void btnNo_Click(System.Object sender, System.EventArgs e)
		{
			Globals.popConfirm.Close();
		}
		
		void popConfirm_Opened(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.SystemTagPowerLedBlinkFrequency.Value = 1;
		}
		
		void popConfirm_Closed(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.SystemTagPowerLedBlinkFrequency.Value = 0;
		}
		
    }
}
