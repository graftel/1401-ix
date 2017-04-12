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
	using System.Text.RegularExpressions;
    
    public partial class WifiSoftAPSetup
    {
		
		void btnNext_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.wifiSSID.Value == "")
			{
				Globals.Tags.GeneralMessage.Value = "Wifi SSID cannot be empty";
				Globals.GeneralMsgBox.Show();
			}
			else
			{
				Globals.WifiSetupSoftAP.Show();
			}
		}
		
		void WifiSoftAPSetup_Opened(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.wifiPassword.Value = "";
			Globals.Tags.wifiSSID.Value = "";
		}
    }
}
