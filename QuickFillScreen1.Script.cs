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
    
    
    public partial class QuickFillScreen1
    {
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.quickFillTargetPress.Value = Globals.Tags.RawTestPressure.Value;
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.GeneralConfirmMsg.Value = "Are you sure you want to abort the Quick Fill process?";
			Globals.Tags.ConfirmAction.Value = 1;
			Globals.popConfirm.Show();
		}
    }
}
