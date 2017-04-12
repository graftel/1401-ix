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
    
    
    public partial class popCalculator
    {
		
		void btnPass0_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String != "0")
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "0";
			}
			
		}
		
		void btnPass1_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "1";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "1";
			}
		}
		
		void btnPass2_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "2";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "2";
			}
		}
		
		void btnPass3_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "3";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "3";
			}
		}
		
		void btnPass4_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "4";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "4";
			}
		}
		
		void btnPass5_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "5";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "5";
			}
		}
		
		void btnPass6_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "6";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "6";
			}
		}
		
		void btnPass7_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "7";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "7";
			}
		}
		
		void btnPass8_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "8";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "8";
			}
		}
		
		void btnPass9_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String == "0") 
			{
				Globals.Tags.Enter_Value.Value = "9";
			}
			else
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + "9";
			}
		}
		
		void btnPassDel_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value != "")
			{
				string temp = Globals.Tags.Enter_Value.Value;
				temp = temp.Remove(temp.Length - 1, 1);
				
				if (temp == "")
				{
					temp = "0";
				}
				
				Globals.Tags.Enter_Value.Value = temp;
			}
		}
		
		void btnPassClose_Click(System.Object sender, System.EventArgs e)
		{
			Globals.popCalculator.Close();
		}
		
		void btnDot_Click(System.Object sender, System.EventArgs e)
		{
			if (!Globals.Tags.Enter_Value.Value.String.Contains("."))
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value + ".";
			}
		}
		
		void btnToggleNeg_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.Enter_Value.Value.String.StartsWith("-"))
			{
				Globals.Tags.Enter_Value.Value = Globals.Tags.Enter_Value.Value.String.Remove(0,1);
			}
			else
			{
				Globals.Tags.Enter_Value.Value = "-" + Globals.Tags.Enter_Value.Value.String;
			}
		}
		
		void btnPassEnter_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Status_CalculatorScr.Value = false;

			if (Globals.Tags.CalculatorTargetScr.Value.Int == 1)
			{
				if (Globals.Tags.firmware.Value.String == Globals.Tags.Enter_Value.Value.String)
				{
					Globals.Tags.SettingSel.Value = 1;
					Globals.popCalculator.Close();
					Globals.popCalSelect.Show();
				}
				else
				{
					Globals.Tags.GeneralMessage.Value = "Wrong password, please try again!";
					Globals.GeneralMsgBox.Show();
				}
			}
			else if (Globals.Tags.CalculatorTargetScr.Value.Int == 2)
			{
				if (Globals.Tags.firmware.Value.String == Globals.Tags.Enter_Value.Value.String)
				{
					Globals.popCalculator.Close();
					Globals.CalDueDateSetting.Show();
				}
				else
				{
					Globals.Tags.GeneralMessage.Value = "Wrong password, please try again!";
					Globals.GeneralMsgBox.Show();
				}
			}
			else if (Globals.Tags.CalculatorTargetScr.Value.Int == 3)
			{
				if (Globals.Tags.firmware.Value.String == Globals.Tags.Enter_Value.Value.String)
				{
					Globals.popCalculator.Close();
					Globals.NozzleCheckConfig.Show();
					Globals.Tags.SettingSel.Value = 4;
				}
				else
				{
					Globals.Tags.GeneralMessage.Value = "Wrong password, please try again!";
					Globals.GeneralMsgBox.Show();
				}
			}
			else if (Globals.Tags.CalculatorTargetScr.Value.Int == 4)
			{
				if (Globals.Tags.firmware.Value.String == Globals.Tags.Enter_Value.Value.String)
				{
					Globals.Tags.popLRMIDEn.Value = 1;
					Globals.popCalculator.Close();
					
				}
				else
				{
					Globals.Tags.GeneralMessage.Value = "Wrong password, please try again!";
					Globals.GeneralMsgBox.Show();
				}
			}
			else
			{
				Globals.popCalculator.Close();
			}
			
		}
		
		void popCalculator_Opened(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.Status_CalculatorScr.Value = true;
			
			if (Globals.Tags.CalculatorTargetScr.Value.Int == 1
			 || Globals.Tags.CalculatorTargetScr.Value.Int == 2
			 || Globals.Tags.CalculatorTargetScr.Value.Int == 3
			 || Globals.Tags.CalculatorTargetScr.Value.Int == 4)
			{
				lblPwd.Visible = true;
			}
			else
			{
				lblPwd.Visible = false;
			}
		}
		
		
		
    }
}
