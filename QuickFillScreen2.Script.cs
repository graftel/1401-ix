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
    
    
    public partial class QuickFillScreen2
    {
		private Timer tmrPressMonitor;
		void QuickFillScreen2_Opened(System.Object sender, System.EventArgs e)
		{
			
			tmrPressMonitor = new Timer();
			tmrPressMonitor.Interval = 500;
			tmrPressMonitor.Enabled = true;
			tmrPressMonitor.Tick += MONITOR_TICK;
		}
		
		
		private void MONITOR_TICK(Object m, EventArgs e)
		{
			if (Globals.Comm.PressSensors[1].GetDiff() >= 2)
			{
				tmrPressMonitor.Enabled = false;
				Globals.QuickFillScreen3.Show();
			}
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.GeneralConfirmMsg.Value = "Are you sure you want to abort the Quick Fill process?";
			Globals.Tags.ConfirmAction.Value = 1;
			Globals.popConfirm.Show();
		}
		
		void QuickFillScreen2_Closed(System.Object sender, System.EventArgs e)
		{
			tmrPressMonitor.Enabled = false;
		}
		
		
    }
}
