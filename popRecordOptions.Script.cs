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
    
    
    public partial class popRecordOptions
    {
		
		void btnYes_Click(System.Object sender, System.EventArgs e)
		{
			
			SecondPage();
			
			Globals.RecordingSetting.SaveRecipe("Current",false);
		}
		
		void popRecordOptions_Opened(System.Object sender, System.EventArgs e)
		{
			
			FirstPage();
			
			
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Globals.RecordingSetting.SaveRecipe("Current",false);
			FirstPage();
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			Globals.RecordingSetting.SaveRecipe("Current",false);
			Globals.popRecordOptions.Close();
			
		}
		
		void SecondPage()
		{
			TouchComboBox.Visible = false;
			AnalogNumeric.Visible = false;
			AnalogNumeric1.Visible = false;
			AnalogNumeric2.Visible = false;
			AnalogNumeric3.Visible = false;
			
			Text.Visible  = false;
			Text1.Visible  = false;
			Text2.Visible  = false;
			Text3.Visible  = false;
			Text4.Visible  = false;
			btnYes.Visible = false;
			
			Button1.Visible = true;
			Button.Visible = true;
			Button2.Visible = true;
			
			AnalogNumeric4.Visible = true;
			AnalogNumeric5.Visible = true;
			AnalogNumeric6.Visible = true;
			AnalogNumeric7.Visible = true;
			
			Text5.Visible = true;
			
			Picture.Visible = false;
		}
		
		void FirstPage()
		{
			Globals.Tags.popLRMIDEn.Value = 0;
			TouchComboBox.Visible = true;
			AnalogNumeric.Visible = true;
			AnalogNumeric1.Visible = true;
			AnalogNumeric2.Visible = true;
			AnalogNumeric3.Visible = true;
			
			Text.Visible  = true;
			Text1.Visible  = true;
			Text2.Visible  = true;
			Text3.Visible  = true;
			Text4.Visible  = true;
			btnYes.Visible = true;
			
			Button1.Visible = false;
			Button.Visible = false;
			Button2.Visible = false;
			
			AnalogNumeric4.Visible = false;
			AnalogNumeric5.Visible = false;
			AnalogNumeric6.Visible = false;
			AnalogNumeric7.Visible = false;
			
			Text5.Visible = false;
			
			Picture.Visible = true;
			
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			
			Globals.RecordingSetting.SaveRecipe("Current",false);
			Globals.Recording.CreatNewFile();
			Globals.Tags.RcrdStatus.Value = 1;
			Globals.popRecordOptions.Close();
		}
		
		void Picture_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.Enter_Value.Value = "";
			Globals.Tags.CalculatorTargetScr.Value = 4;
			Globals.popCalculator.Show();
		}
    }
}
