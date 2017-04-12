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
    
    
    public partial class FilterHigh
    {
		Timer pressCount;
		
		private int count = 0;
		
		private int selected = 0;
		
		private double increment;
		
		void FilterHigh_Opened(System.Object sender, System.EventArgs e)
		{
			pressCount = new Timer();
			
			pressCount.Tick += pressCountTick;
			
			pressCount.Interval = 200;
			
			pressCount.Enabled = false;
		}
		
		
		private void pressCountTick(System.Object sender, System.EventArgs e)
		{
			count++;

			if (count >= 0 && count < 30)
			{
				increment = 1;
			}
			else if (count >= 30 && count < 50)
			{
				increment = 5;
			}
			else
			{
				increment = 10;
			}
			
			switch(selected)
			{
				case 0:
					Globals.Tags.FilterUpperLimitHigh.Value = (int)Globals.Tags.FilterUpperLimitHigh.Value - increment;
					break;
				case 1:
					Globals.Tags.FilterUpperLimitHigh.Value = (int)Globals.Tags.FilterUpperLimitHigh.Value + increment;
					break;
			}
			Validate();
						
		}
		
		private void Validate()
		{
			
			if ((int)Globals.Tags.FilterResponseHigh.Value <= 0)
			{
				Globals.Tags.FilterResponseHigh.Value = 0;
			}
			else if ((int)Globals.Tags.FilterResponseHigh.Value >= 9)
			{
				Globals.Tags.FilterResponseHigh.Value = 9;
			}
			
			if ((int)Globals.Tags.FilterUpperLimitHigh.Value <= 0)
			{
				Globals.Tags.FilterUpperLimitHigh.Value = 0;
			}
			else if ((int)Globals.Tags.FilterUpperLimitHigh.Value >= 100)
			{
				Globals.Tags.FilterUpperLimitHigh.Value = 100;
			}
			
			
			
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.FilterResponseHigh.Value = (int)Globals.Tags.FilterResponseHigh.Value - 1;
			Validate();
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.FilterUpperLimitHigh.Value = (int)Globals.Tags.FilterUpperLimitHigh.Value + 1;
			Validate();
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.FilterResponseHigh.Value = (int)Globals.Tags.FilterResponseHigh.Value + 1;
			Validate();
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.FilterUpperLimitHigh.Value = (int)Globals.Tags.FilterUpperLimitHigh.Value - 1;
			Validate();
		}
		
		void Button3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 0;
		}
		
		void Button3_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void Button2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 1;
		}
		
		void Button2_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void Button8_Click(System.Object sender, System.EventArgs e)
		{
			Globals.FilterSettingHigh.LoadRecipe("Default");
		}
		
		void FilterHigh_Closed(System.Object sender, System.EventArgs e)
		{
			Globals.FilterSettingHigh.SaveRecipe("Current",false);
		}
		
		
		
		
    }
}
