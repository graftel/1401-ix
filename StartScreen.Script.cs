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
	using System.IO;
    
    public partial class StartScreen
	{
		
		void StartScreen_Opened(System.Object sender, System.EventArgs e)
		{
			
			if (Globals.Tags.Initialized.Value == 0)
			{
				Globals.DefaultSettings.LoadRecipe("Default_Setting");
				Globals.InternalSettings.LoadRecipe("Current");
				Globals.PersistentVariables.LoadRecipe("Current");
				
				Globals.DecimalSettings.LoadRecipe("Current");
				
				//Load filter settings
				Globals.FilterSettingLow.LoadRecipe("Current");
				Globals.FilterSettingMid.LoadRecipe("Current");
				Globals.FilterSettingHigh.LoadRecipe("Current");	
				//Load Stability Settings
				Globals.StabSettingLow.LoadRecipe("Current");
				Globals.StabSettingMid.LoadRecipe("Current");
				Globals.StabSettingHigh.LoadRecipe("Current");
				Globals.RecordingSetting.LoadRecipe("Current");
				
				Globals.Comm.Inilialize();
				Globals.Comm.Start();
				Globals.MainTimer.Start();
				Globals.Tags.Initialized.Value = 1;
				Globals.SolenoidValveControl.Initialized();
				
				Globals.Tags.StartBtnEnable.Value = 0;
				
				Globals.Tags.CurrentScreen.Value = 1;
				
				Globals.Tags.DemoModeOnOff.Value = 0;
				
				Globals.Tags.GraphMax.Value = Globals.UnitsAndConversion.FlowConv(Globals.Tags.HighRangeMax.Value.Double,4,1);
				Globals.Tags.GraphMin.Value = 0;
				
				Globals.Tags.GraphLeftMax.Value = 200;
				Globals.Tags.GraphLeftMin.Value = 0;
			
				if (Directory.Exists("\\FlashDrive\\Project\\Project Files\\Recordings\\"))
				{
					System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo("\\FlashDrive\\Project\\Project Files\\Recordings\\");
					foreach (System.IO.FileInfo file in dir.GetFiles())
					{
						try
						{	
							file.Delete();
						}
						catch
						{
						}
					}
					
				}
			
				
			}
		}
		
		void btnStart_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.selMeter.Value = 1;
			Globals.Tags.tmr485_control.Value = 4;
			
		}
		
		void Text5_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.Enter_Value.Value = "";
			Globals.Tags.CalculatorTargetScr.Value = 2;
			Globals.popCalculator.Show();
		}
		
		void Text4_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.Enter_Value.Value = "";
			Globals.Tags.CalculatorTargetScr.Value = 2;
			Globals.popCalculator.Show();
		}
		

    }
}
