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
    
    
    public partial class CalInstruction
    {
		
		void CalInstruction_Opened(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.calInstPrg.Value = 100;
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				Globals.Tags.InstDisp.Value = 0;
			}
			else
			{
				Globals.Tags.InstDisp.Value = 2;
			}
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.calInstPrg.Value = 100;
			if (Globals.Tags.calSelMeter.Value.Int < Globals.Comm.FlowMeters.Count)	
			{
				Globals.Tags.InstDisp.Value = 0;
			}
			else
			{
				Globals.Tags.InstDisp.Value = 2;
			}
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.calInstPrg.Value = 100;
			if (Globals.Tags.calSelMeter.Value.Int < Globals.Comm.FlowMeters.Count)	
			{
				Globals.Tags.InstDisp.Value = 1;
			}
			else
			{
				Globals.Tags.InstDisp.Value = 3;
			}
		}
    }
}
