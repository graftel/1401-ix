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
    
    
    public partial class AutoCal
    {
		
		


		
		
		void Button12_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.AutoCalStatus.Value.Int == 1)
			{
				Globals.Tags.ConfirmAction.Value = 4;
				Globals.Tags.GeneralConfirmMsg.Value = "Calibration in progress, are you sure you want to exit?";
				Globals.popConfirm.Show();
				
			}
			else
			{
				Globals.SettingScreen.Show();
			}
			
		}
		
		
		
		
    }
}
