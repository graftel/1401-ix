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
    
    
    public partial class StabLow
    {
		Timer pressCount;
		
		private int count = 0;
		
		private int selected = 0;
		
		private double increment;
		
		void StabLow_Opened(System.Object sender, System.EventArgs e)
		{
			
			if (Globals.Tags.bStabEnable.Value.Bool)
			{
				Globals.Tags.StabONOFF.Value = 0;
			}
			else
			{
				Globals.Tags.StabONOFF.Value = 1;
			}
			
			pressCount = new Timer();
			
			pressCount.Tick += pressCountTick;
			
			pressCount.Interval = 200;
			
			pressCount.Enabled = false;
			
			Validate();
			
			
		}
		
		private void pressCountTick(System.Object sender, System.EventArgs e)
		{
			count++;

			if (count >= 0 && count < 30)
			{
				increment = 0.1;
			}
			else if (count >= 30 && count < 50)
			{
				increment = 1;
			}
			else
			{
				increment = 5;
			}
			
			switch(selected)
			{
				case 0:
					Globals.Tags.Stab_low_green.Value = (double)Globals.Tags.Stab_low_green.Value - increment;
					break;
				case 1:
					Globals.Tags.Stab_low_green.Value = (double)Globals.Tags.Stab_low_green.Value + increment;
					break;
				case 2:
					Globals.Tags.Stab_low_orange.Value = (double)Globals.Tags.Stab_low_orange.Value - increment;
					break;
				case 3:
					Globals.Tags.Stab_low_orange.Value = (double)Globals.Tags.Stab_low_orange.Value + increment;
					break;
				case 4:
					Globals.Tags.Stab_low_red.Value = (double)Globals.Tags.Stab_low_red.Value - increment;
					break;
				case 5:
					Globals.Tags.Stab_low_red.Value = (double)Globals.Tags.Stab_low_red.Value + increment;
					break;
			}
			Validate();
						
		}
		
		
		void Button6_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.Stab_low_green.Value = (double)Globals.Tags.Stab_low_green.Value - 0.01;
			Validate();
		}
		
		void Button6_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 0;
		}
		
		void Button6_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void Button5_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.Stab_low_green.Value = (double)Globals.Tags.Stab_low_green.Value + 0.01;
			Validate();
		}
		
		
		void Button5_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 1;
		}
		
		void Button5_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		private void Validate()
		{	
			double tmp;

			if ((double)Globals.Tags.Stab_low_green.Value <= 0.01)
			{
				Globals.Tags.Stab_low_green.Value = 0.01;
			}
			else if ((double)Globals.Tags.Stab_low_green.Value >= 99.96)
			{
				Globals.Tags.Stab_low_green.Value = 99.96;
			}

			
			if ((double)Globals.Tags.Stab_low_orange.Value <= 0.02)
			{
				Globals.Tags.Stab_low_orange.Value = 0.02;
			}
			else if ((double)Globals.Tags.Stab_low_orange.Value >= 99.97)
			{
				Globals.Tags.Stab_low_orange.Value = 99.97;
			}
			
			if ((double)Globals.Tags.Stab_low_red.Value <= 0.03)
			{
				Globals.Tags.Stab_low_red.Value = 0.03;
			}
			else if ((double)Globals.Tags.Stab_low_red.Value >= 99.98)
			{
				Globals.Tags.Stab_low_red.Value = 99.98;
			}

			Globals.Tags.Stab_low_green.Value = Math.Round((double)Globals.Tags.Stab_low_green.Value, 2);
			Globals.Tags.Stab_low_orange.Value = Math.Round((double)Globals.Tags.Stab_low_orange.Value, 2);
			Globals.Tags.Stab_low_red.Value = Math.Round((double)Globals.Tags.Stab_low_red.Value, 2);

			if (selected == 1)
			{
				if ((double)Globals.Tags.Stab_low_green.Value >= (double)Globals.Tags.Stab_low_orange.Value)
				{
					Globals.Tags.Stab_low_orange.Value = (double)Globals.Tags.Stab_low_green.Value + 0.01;
				}
			}
			
			if (selected == 1 || selected == 3)
			{
				if ((double)Globals.Tags.Stab_low_orange.Value >= (double)Globals.Tags.Stab_low_red.Value)
				{
					Globals.Tags.Stab_low_red.Value = (double)Globals.Tags.Stab_low_orange.Value + 0.01;
				}
			}

			if (selected == 4)
			{
				if ((double)Globals.Tags.Stab_low_red.Value <= (double)Globals.Tags.Stab_low_orange.Value)
				{
					Globals.Tags.Stab_low_orange.Value = (double)Globals.Tags.Stab_low_red.Value - 0.01;
				}
			}

			if (selected == 2 || selected == 4)
			{
				if ((double)Globals.Tags.Stab_low_orange.Value <= (double)Globals.Tags.Stab_low_green.Value)
				{
					Globals.Tags.Stab_low_green.Value = (double)Globals.Tags.Stab_low_orange.Value - 0.01;
				}
			}
			
			tmp = (double)Globals.Tags.Stab_low_red.Value + 0.01;
			lblLowDarkred.Text = tmp.ToString("F2") + "-100";
			

			
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.Stab_low_orange.Value = (double)Globals.Tags.Stab_low_orange.Value - 0.01;
			Validate();
		}
		
		void Button1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 2;
		}
		
		void Button1_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.Stab_low_orange.Value = (double)Globals.Tags.Stab_low_orange.Value + 0.01;
			Validate();
		}
		
		void Button_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 3;
		}
		
		void Button_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.Stab_low_red.Value = (double)Globals.Tags.Stab_low_red.Value - 0.01;
			Validate();
		}
		
		void Button3_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 4;
		}
		
		void Button3_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			count = 0;
			Globals.Tags.Stab_low_red.Value = (double)Globals.Tags.Stab_low_red.Value + 0.01;
			Validate();
		}
		
		void Button2_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			count = 0;
			pressCount.Enabled = true;
			selected = 5;
		}
		
		void Button2_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pressCount.Enabled = false;
		}
		
		
		void StabLow_Closed(System.Object sender, System.EventArgs e)
		{
			Globals.StabSettingLow.SaveRecipe("Current",false);
			Globals.PersistentVariables.SaveRecipe("Current",false);
		}
		
		void Button8_Click(System.Object sender, System.EventArgs e)
		{
			Globals.StabSettingLow.LoadRecipe("Default");
			lblLowDarkred.Text = "30.01-100";
		}
		
		

    }
}
