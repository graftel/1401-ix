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
    
    
    public partial class RcrdInterval
    {
		private int mins = 0;
		private int secs = 0;
		
		void RcrdInterval_Opened(System.Object sender, System.EventArgs e)
		{
			

			
			mins = Globals.Tags.RcrdInterval.Value.Int / 60;
			secs = Globals.Tags.RcrdInterval.Value.Int % 60;
			
			lblMin.Value = mins;
			lblSec.Value = secs;
			
		}
		
		void Button23_Click(System.Object sender, System.EventArgs e)
		{
			mins = mins - 1;
			lblMin.Value = mins;
			if (mins <= 0)
			{
				mins = 0;
				lblMin.Value = 0;
			}
			
			if (mins == 0 && secs == 0)
			{
				secs = 2;
				lblSec.Value = 2;
			}
		}
		
		void Button22_Click(System.Object sender, System.EventArgs e)
		{
			mins++;
			lblMin.Value = mins;
			if (mins > 60)
			{
				mins = 60;
				lblMin.Value = 60;
			}
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			secs = secs - 1;
			lblSec.Value = secs;
			
			if (mins == 0)
			{
				if (secs <= 2)
				{
					secs = 2;
					lblSec.Value = 2;
				}
			}
			else
			{
				if (secs <= 0)
				{
					secs = 0;
					lblSec.Value = 0;
				}
			}
			
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			secs = secs + 1;
			lblSec.Value = secs;
			if (secs >= 59)
			{
				secs = 59;
				lblSec.Value = 59;
			}
		}
		
		void RcrdInterval_Closed(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.RcrdInterval.Value = mins * 60 + secs;
			Globals.PersistentVariables.SaveRecipe("Current",false);
			Globals.RecordingSetting.SaveRecipe("Current",false);
		}
		
		void CheckBox_Click(System.Object sender, System.EventArgs e)
		{
			if (CheckBox.Checked)
			{
				Globals.Tags.popRcrdMode.Value = 1;
			}
			else
			{
				Globals.Tags.popRcrdMode.Value = 0;
			}
		}
		
		
    }
}
