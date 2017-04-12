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
    
    
    public partial class QuickFillSetting
    {
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.TargetPressTolerance.Value < 100)
			{
				Globals.Tags.TargetPressTolerance.Value += 1;
			}
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.TargetPressTolerance.Value > 1)
			{
				Globals.Tags.TargetPressTolerance.Value -= 1;
			}
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.TargetPressHoldTime.Value += 1;
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.TargetPressHoldTime.Value >= 1)
			{
				Globals.Tags.TargetPressHoldTime.Value -= 1;
			}
		}
		
		void Button21_Click(System.Object sender, System.EventArgs e)
		{
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Button4_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.STDTolerence.Value < 100)
			{
				Globals.Tags.STDTolerence.Value += 1;
			}
		}
		
		void Button5_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.STDTolerence.Value > 1)
			{
				Globals.Tags.STDTolerence.Value -= 1;
			}
		}
    }
}
