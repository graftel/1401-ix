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
    
    
    public partial class QuickFillScreen3
	{	
		private Timer tmrSTDMonitor;
		private Timer tmrPressMonitor;
		private Timer tmrAutoClose;
		private bool IsFinished;
		private int HoldCount;
		private double std_value;
		private int TimeRemain;
		void QuickFillScreen3_Opened(System.Object sender, System.EventArgs e)
		{
		
			IsFinished = false;
			
			HoldCount = 0;
			std_value = 100;
				
			tmrPressMonitor = new Timer();
			tmrPressMonitor.Interval = 1000;
			tmrPressMonitor.Enabled = true;
			tmrPressMonitor.Tick += MONITOR_TICK;
			
			tmrSTDMonitor = new Timer();
			tmrSTDMonitor.Interval = 60000;
			tmrSTDMonitor.Enabled = false;
			tmrSTDMonitor.Tick += STDMonitor_TICK;
			
			
			Globals.Comm.PressSensors[1].ClearPressureData();
			
			tmrAutoClose = new Timer();
			tmrAutoClose.Interval = 10000;
			tmrAutoClose.Tick += AUTOCLOSE_TICK;
			tmrAutoClose.Enabled = false;
			lblStatus.Visible = false;
			Globals.Tags.QuickFillBracketIndicator.Value = 0;
			lblQuickFill.Text = "Quick Filling in Progress";
			Globals.Tags.QuickFillProgressBlink.Value = 1;
		}
		
		private void STDMonitor_TICK(Object myObject, EventArgs myEventArgs) 
		{
			std_value = Globals.Comm.PressSensors[1].GetPressSTD();
			Globals.Comm.PressSensors[1].ClearPressureData();
			if (std_value != -1 && std_value <= Globals.Tags.STDTolerence.Value.Double * Globals.Tags.Test_Press_Max.Value.Double / 100 )
			{
				
				HoldCount ++;
				
				TimeRemain  = Globals.Tags.TargetPressHoldTime.Value.Int - HoldCount;
				lblStatus.Visible = true;
				lblStatus.Text = "Stablization Time Left: " + TimeRemain.ToString() + " min(s)";
			}
			else
			{
				tmrSTDMonitor.Enabled = false;
				HoldCount = 0;
				Globals.Tags.QuickFillBracketIndicator.Value = 0;
				lblStatus.Visible = false;
				
			}
					
			if (HoldCount >= Globals.Tags.TargetPressHoldTime.Value.Int)
			{
				IsFinished = true;
				tmrSTDMonitor.Enabled = false;
				tmrPressMonitor.Enabled = false;
				lblQuickFill.Text = "Quick Fill Finished";
				Globals.Tags.QuickFillProgressBlink.Value = 0;
				tmrAutoClose.Enabled = true;
			}
		}
		
		
		private void MONITOR_TICK(Object m, EventArgs e)
		{
		
			if (Math.Abs(Globals.Tags.quickFillTargetPress.Value - Globals.Tags.RawTestPressure.Value) <= Globals.Tags.TargetPressTolerance.Value.Double * Globals.Tags.Test_Press_Max.Value.Double / 100)
			{
				Globals.Tags.QuickFillBracketIndicator.Value = 1;
				if (Globals.Tags.TargetPressHoldTime.Value.Int == 0)
				{
					IsFinished = true;
					tmrSTDMonitor.Enabled = false;
					tmrPressMonitor.Enabled = false;
					lblQuickFill.Text = "Quick Fill Finished";
					Globals.Tags.QuickFillProgressBlink.Value = 0;
					tmrAutoClose.Enabled = true;
				}
				else
				{
					tmrSTDMonitor.Enabled = true;
					lblStatus.Visible = true;
					if (Globals.Tags.TargetPressHoldTime.Value.Int == 1)
					{lblStatus.Text = "Stablization Time Left: " + Globals.Tags.TargetPressHoldTime.Value.Int.ToString() + " minute";}
					else
					{lblStatus.Text = "Stablization Time Left: " + Globals.Tags.TargetPressHoldTime.Value.Int.ToString() + " minutes";}
					
				}
			}
			else
			{	
				tmrSTDMonitor.Enabled = false;
				HoldCount = 0;
				Globals.Tags.QuickFillBracketIndicator.Value = 0;
				lblStatus.Visible = false;
			}
			

		}
			
		private void AUTOCLOSE_TICK(Object m, EventArgs e)
		{
			Globals.MainScreen.Show();
			tmrAutoClose.Enabled = false;
			Globals.Tags.QuickFillMessage.Value = "Quick Fill reached " + 
				Globals.UnitsAndConversion.PressConv(Globals.Tags.quickFillTargetPress.Value.Double,0,Globals.Tags.PressUnit.Value.Int).ToString("F" + Globals.Tags.MainPressDecimal.Value.Int.ToString()) + " " + Globals.UnitsAndConversion.GetPressureUnits(Globals.Tags.PressUnit.Value.Int) + " at " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
			Globals.Tags.QuickFillMessageVisi.Value = 1;
			
		}
		
		
		void QuickFillScreen3_Closed(System.Object sender, System.EventArgs e)
		{
			  tmrSTDMonitor.Enabled = false;
			  tmrPressMonitor.Enabled = false;
			  tmrAutoClose.Enabled = false;
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			if (IsFinished)
			{
				Globals.MainScreen.Show();
				Globals.Tags.ValveState.Value = 0;
				Globals.Tags.QuickFillMessage.Value =  "Quick Fill reached " + 
					Globals.UnitsAndConversion.PressConv(Globals.Tags.quickFillTargetPress.Value.Double,0,Globals.Tags.PressUnit.Value.Int).ToString("F" + Globals.Tags.MainPressDecimal.Value.Int.ToString()) + " " + Globals.UnitsAndConversion.GetPressureUnits(Globals.Tags.PressUnit.Value.Int) + " at " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
				Globals.Tags.QuickFillMessageVisi.Value = 1;
			}
			else
			{
				Globals.Tags.GeneralConfirmMsg.Value = "Are you sure you want to abort the Quick Fill process?";
				Globals.Tags.ConfirmAction.Value = 1;
				Globals.popConfirm.Show();
			}
		}
		
		
	}
}
