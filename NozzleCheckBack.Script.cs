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
    
    
    public partial class NozzleCheckBack
    {
		
		void Group3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (Globals.Tags.CurrentScreen.Value.Int == 61)
			{
				Globals.Tags.CalculatorTargetScr.Value = 3;
				Globals.Tags.Enter_Value.Value = "";
				Globals.popCalculator.Show();
			}
		}
    }
}
