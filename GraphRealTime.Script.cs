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
    
    
    public partial class GraphRealTime
    {
		
		void GraphRealTime_Opened(System.Object sender, System.EventArgs e)
		{
		
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{	
			int selMode  = (int)Globals.Tags.selMode.Value;
			int flowunit = (int)Globals.Tags.flow_unit_low.Value.Int;
			selMode++;
			if (selMode > 3)
			{
				selMode = 0;
			}
			Globals.Tags.selMode.Value = selMode;
			//	Button7.Text = Globals.UnitsAndConversion.GetModeName(selMode);
			if (selMode != 0)
			{
				Globals.Tags.selMeter.Value = selMode - 1;
				Globals.DrawScreen.DrawMainScreen(selMode-1);
			}
			
			//		ShowZeroButtonText();
			Globals.CalAndUpdate.UpdateFlowRateTag();
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
			
			Globals.Tags.ValveState.Value = 0;
		}
    }
}
