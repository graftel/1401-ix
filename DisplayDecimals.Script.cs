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
    using Neo.ApplicationFramework.Tools.MessageLibrary;
    
    public partial class DisplayDecimals
    {
		private int DecimalSelMeter = 0;
		private int DecimalSelUnit = 0;
		
		void DisplayDecimals_Opened(System.Object sender, System.EventArgs e)
		{
			
			UpdateDisplay();
		}
		
		
		void UpdateDisplay()
		{
			if (DecimalSelMeter < 3)
			{
				Button5.Text = Globals.TextLibrary.FlowUnit.Messages[DecimalSelUnit].Message;
				
			}
			else if (DecimalSelMeter == 3)
			{
				Button5.Text = Globals.TextLibrary.PressureUnit.Messages[DecimalSelUnit].Message;
			}
			
			Button2.Text = Globals.TextLibrary.MeterName.Messages[DecimalSelMeter].Message;
			
			if (DecimalSelMeter == 0)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						AnalogNumeric.Value = Globals.Tags.LowsccmDecimal.Value;
						break;
					case 1:
						AnalogNumeric.Value = Globals.Tags.LowslpmDecimal.Value;
						break;
					case 2:
						AnalogNumeric.Value = Globals.Tags.LowscfmDecimal.Value;
						break;
					case 3:
						AnalogNumeric.Value = Globals.Tags.LowscfhDecimal.Value;
						break;
				}
			}
			else if (DecimalSelMeter == 1)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						AnalogNumeric.Value = Globals.Tags.MidsccmDecimal.Value;
						break;
					case 1:
						AnalogNumeric.Value = Globals.Tags.MidslpmDecimal.Value;
						break;
					case 2:
						AnalogNumeric.Value = Globals.Tags.MidscfmDecimal.Value;
						break;
					case 3:
						AnalogNumeric.Value = Globals.Tags.MidscfhDecimal.Value;
						break;
				}
			}
			else if (DecimalSelMeter == 2)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						AnalogNumeric.Value = Globals.Tags.HighsccmDecimal.Value;
						break;
					case 1:
						AnalogNumeric.Value = Globals.Tags.HighslpmDecimal.Value;
						break;
					case 2:
						AnalogNumeric.Value = Globals.Tags.HighscfmDecimal.Value;
						break;
					case 3:
						AnalogNumeric.Value = Globals.Tags.HighscfhDecimal.Value;
						break;
				}
			}
			else if (DecimalSelMeter == 3)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						AnalogNumeric.Value = Globals.Tags.psigDecimal.Value;
						break;
					case 1:
						AnalogNumeric.Value = Globals.Tags.ksiDecimal.Value;
						break;
					case 2:
						AnalogNumeric.Value = Globals.Tags.barDecimal.Value;
						break;
				}
				
			}
			
			
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			DecimalSelUnit = 0;
			
			if (DecimalSelMeter < 3)
			{
				DecimalSelMeter = DecimalSelMeter + 1;
			}
			else if (DecimalSelMeter == 3)
			{
				DecimalSelMeter = 0;
			}
			
			UpdateDisplay();
		}
		
		void Button5_Click(System.Object sender, System.EventArgs e)
		{
			if (DecimalSelMeter < 3)
			{
			
				if (DecimalSelUnit < 3)
				{
					DecimalSelUnit = DecimalSelUnit + 1;
				}
				else if (DecimalSelUnit == 3)
				{
					DecimalSelUnit = 0;
				}
				
			}
			else if (DecimalSelMeter== 3)
			{
				if (DecimalSelUnit < 2)
				{
					DecimalSelUnit = DecimalSelUnit + 1;
				}
				else if (DecimalSelUnit == 2)
				{
					DecimalSelUnit = 0;
				}
				
				
			}
			
			UpdateDisplay();
		}
		
		void Button4_Click(System.Object sender, System.EventArgs e)
		{
			if (DecimalSelMeter == 0)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.LowsccmDecimal.Value.Int > Globals.Tags.MIN_LOW_SCCM_DECIMAL.Value.Int)
						{
							Globals.Tags.LowsccmDecimal.Value --;
						}
							
						AnalogNumeric.Value = Globals.Tags.LowsccmDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.LowslpmDecimal.Value.Int > Globals.Tags.MIN_LOW_SLPM_DECIMAL.Value.Int)
							Globals.Tags.LowslpmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.LowslpmDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.LowscfmDecimal.Value.Int > Globals.Tags.MIN_LOW_SCFM_DECIMAL.Value.Int)
							Globals.Tags.LowscfmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.LowscfmDecimal.Value;
						break;
					case 3:
						if (Globals.Tags.LowscfhDecimal.Value.Int > Globals.Tags.MIN_LOW_SCFH_DECIMAL.Value.Int)
							Globals.Tags.LowscfhDecimal.Value--;
						AnalogNumeric.Value = Globals.Tags.LowscfhDecimal.Value;
						break;
				}
			}
			else if (DecimalSelMeter == 1)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.MidsccmDecimal.Value.Int > Globals.Tags.MIN_MID_SCCM_DECIMAL.Value.Int)
							Globals.Tags.MidsccmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.MidsccmDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.MidslpmDecimal.Value.Int > Globals.Tags.MIN_MID_SLPM_DECIMAL.Value.Int)
							Globals.Tags.MidslpmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.MidslpmDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.MidscfmDecimal.Value.Int > Globals.Tags.MIN_MID_SCFM_DECIMAL.Value.Int)
							Globals.Tags.MidscfmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.MidscfmDecimal.Value;
						break;
					case 3:
						if (Globals.Tags.MidscfhDecimal.Value.Int > Globals.Tags.MIN_MID_SCFH_DECIMAL.Value.Int)
							Globals.Tags.MidscfhDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.MidscfhDecimal.Value;
						break;
				}
			}
			else if (DecimalSelMeter == 2)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.HighsccmDecimal.Value.Int > Globals.Tags.MIN_HI_SCCM_DECIMAL.Value.Int)
							Globals.Tags.HighsccmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.HighsccmDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.HighslpmDecimal.Value.Int > Globals.Tags.MIN_HI_SLPM_DECIMAL.Value.Int)
							Globals.Tags.HighslpmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.HighslpmDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.HighscfmDecimal.Value.Int > Globals.Tags.MIN_HI_SCFM_DECIMAL.Value.Int)
							Globals.Tags.HighscfmDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.HighscfmDecimal.Value;
						break;
					case 3:
						if (Globals.Tags.HighscfhDecimal.Value.Int > Globals.Tags.MIN_HI_SCFH_DECIMAL.Value.Int)
							Globals.Tags.HighscfhDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.HighscfhDecimal.Value;
						break;
				}
				
			}
			else if (DecimalSelMeter == 3)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.psigDecimal.Value.Int > Globals.Tags.MIN_PSIG_DECIMAL.Value.Int)
							Globals.Tags.psigDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.psigDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.ksiDecimal.Value.Int > Globals.Tags.MIN_KSI_DECIMAL.Value.Int)
							Globals.Tags.ksiDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.ksiDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.barDecimal.Value.Int > Globals.Tags.MIN_BAR_DECIMAL.Value.Int)
							Globals.Tags.barDecimal.Value --;
						AnalogNumeric.Value = Globals.Tags.barDecimal.Value;
						break;
				}
				
			}
			
			Globals.DecimalSettings.SaveRecipe("Current",false);
		}
		

		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			if (DecimalSelMeter == 0)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.LowsccmDecimal.Value.Int < Globals.Tags.MAX_LOW_SCCM_DECIMAL.Value.Int)
							Globals.Tags.LowsccmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.LowsccmDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.LowslpmDecimal.Value.Int < Globals.Tags.MAX_LOW_SLPM_DECIMAL.Value.Int)
							Globals.Tags.LowslpmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.LowslpmDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.LowscfmDecimal.Value.Int < Globals.Tags.MAX_LOW_SCFM_DECIMAL.Value.Int)
							Globals.Tags.LowscfmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.LowscfmDecimal.Value;
						break;
					case 3:
						if (Globals.Tags.LowscfhDecimal.Value.Int < Globals.Tags.MAX_LOW_SCFH_DECIMAL.Value.Int)
							Globals.Tags.LowscfhDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.LowscfhDecimal.Value;
						break;
				}
			}
			else if (DecimalSelMeter == 1)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.MidsccmDecimal.Value.Int < Globals.Tags.MAX_MID_SCCM_DECIMAL.Value.Int)
							Globals.Tags.MidsccmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.MidsccmDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.MidslpmDecimal.Value.Int < Globals.Tags.MAX_MID_SLPM_DECIMAL.Value.Int)
							Globals.Tags.MidslpmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.MidslpmDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.MidscfmDecimal.Value.Int < Globals.Tags.MAX_MID_SCFM_DECIMAL.Value.Int)
							Globals.Tags.MidscfmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.MidscfmDecimal.Value;
						break;
					case 3:
						if (Globals.Tags.MidscfhDecimal.Value.Int < Globals.Tags.MAX_MID_SCFH_DECIMAL.Value.Int)
							Globals.Tags.MidscfhDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.MidscfhDecimal.Value;
						break;
				}
			}
			else if (DecimalSelMeter == 2)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.HighsccmDecimal.Value.Int < Globals.Tags.MAX_HI_SCCM_DECIMAL.Value.Int)
							Globals.Tags.HighsccmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.HighsccmDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.HighslpmDecimal.Value.Int < Globals.Tags.MAX_HI_SLPM_DECIMAL.Value.Int)
							Globals.Tags.HighslpmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.HighslpmDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.HighscfmDecimal.Value.Int < Globals.Tags.MAX_HI_SCFM_DECIMAL.Value.Int)
							Globals.Tags.HighscfmDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.HighscfmDecimal.Value;
						break;
					case 3:
						if (Globals.Tags.HighscfhDecimal.Value.Int < Globals.Tags.MAX_HI_SCFH_DECIMAL.Value.Int)
							Globals.Tags.HighscfhDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.HighscfhDecimal.Value;
						break;
				}
				
			}
			else if (DecimalSelMeter == 3)
			{
				switch(DecimalSelUnit)
				{
					case 0:
						if (Globals.Tags.psigDecimal.Value.Int < Globals.Tags.MAX_PSIG_DECIMAL.Value.Int)
							Globals.Tags.psigDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.psigDecimal.Value;
						break;
					case 1:
						if (Globals.Tags.ksiDecimal.Value.Int < Globals.Tags.MAX_KSI_DECIMAL.Value.Int)
							Globals.Tags.ksiDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.ksiDecimal.Value;
						break;
					case 2:
						if (Globals.Tags.barDecimal.Value < Globals.Tags.MAX_BAR_DECIMAL.Value.Int)
							Globals.Tags.barDecimal.Value ++;
						AnalogNumeric.Value = Globals.Tags.barDecimal.Value;
						break;
				}
				
			}
			
			Globals.DecimalSettings.SaveRecipe("Current",false);
		}
		
		void Button8_Click(System.Object sender, System.EventArgs e)
		{
			Globals.DecimalSettings.LoadRecipe("Default");
			UpdateDisplay();
		}
    }
}
