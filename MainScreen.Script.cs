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
    
    
    public partial class MainScreen
    {
		private Timer tmrPress;
		private Timer tmrRcrd;
		private Timer tmrCheckZero;
		private int tmrRcrdCount = 0;
		
		void MainScreen_Opened(System.Object sender, System.EventArgs e)
		{	
			Globals.Tags.ValveState.Value = 0;
			Globals.Tags.RemoteDesktopIcon.Value = 0;
			tmrPress = new Timer();
			tmrRcrd = new Timer();
			tmrCheckZero = new Timer();
			tmrPress.Interval = 5000;
			tmrPress.Tick += new EventHandler(pressElasp);
			tmrCheckZero.Interval = 3000;
			tmrCheckZero.Tick += ZeroCheckTimerTick;
			Globals.DrawScreen.DrawMainScreen((int)Globals.Tags.selMeter.Value);
			Globals.CalAndUpdate.UpdateTestPressureTag();
			Globals.CalAndUpdate.UpdateFlowRateTag();
			Button7.Text = Globals.UnitsAndConversion.GetModeName(Globals.Tags.selMode.Value.Int);
			
		}
		
		void Button2_Click(System.Object sender, System.EventArgs e)
		{
			int flowunit;
			int selMeter  = (int)Globals.Tags.selMeter.Value;

			
			
			switch(selMeter)
			{
				case 0:
					flowunit = (int)Globals.Tags.flow_unit_low.Value;
					flowunit++;
					if (flowunit > 3)
					{
						flowunit = 0;
					}
					Globals.Tags.flow_unit_low.Value = flowunit;
					break;
				case 1:
					flowunit = (int)Globals.Tags.flow_unit_mid.Value;
					flowunit++;
					if (flowunit > 3)
					{
						flowunit = 0;
					}
					Globals.Tags.flow_unit_mid.Value = flowunit;
					break;		
				case 2:
					flowunit = (int)Globals.Tags.flow_unit_high.Value;
					flowunit++;
					if (flowunit > 3)
					{
						flowunit = 0;
					}
					Globals.Tags.flow_unit_high.Value = flowunit;
					break;	
			}
			Globals.DefaultSettings.SaveRecipe("Default_Setting",false);
			Globals.DrawScreen.DrawMainScreen(selMeter);
//			Globals.CalAndUpdate.UpdateFlowRateTag();
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
		}
		
		void Button7_Click(System.Object sender, System.EventArgs e)
		{
			int selMode  = (int)Globals.Tags.selMode.Value;
			int flowunit = (int)Globals.Tags.flow_unit_low.Value.Int;
			selMode++;
			if (selMode > 3)
			{
				selMode = 0;
			}
			Globals.Tags.selMode.Value = selMode;
		//	Button7.Text = Globals.UnitsAndConversion.GetModeName(selMode);
			if (selMode != 0)
			{
				Globals.Tags.selMeter.Value = selMode - 1;
				Globals.DrawScreen.DrawMainScreen(selMode-1);
			}
			
	//		ShowZeroButtonText();
			Globals.CalAndUpdate.UpdateFlowRateTag();
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
			
			Globals.Tags.ValveState.Value = 0;
			
		}

		void Button8_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.PressUnit.Value > 1)
			{
				Globals.Tags.PressUnit.Value = 0;
			}
			else
			{
				Globals.Tags.PressUnit.Value = Globals.Tags.PressUnit.Value.Int + 1;
			}
				
			Globals.CalAndUpdate.UpdateTestPressureTag();
			Globals.DefaultSettings.SaveRecipe("Default_Setting",false);
			
			Globals.Tags.QuickFillMessageVisi.Value = 0;
		}
		
		void Button4_Click(System.Object sender, System.EventArgs e)
		{
			if ((int)Globals.Tags.gasType.Value == 0)
			{
				Globals.Tags.gasType.Value = 1;
			}
			else
			{
				Globals.Tags.gasType.Value = 0;
			}
			
			Globals.CalAndUpdate.UpdateFlowRateTag();
			
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
				
		}
		

	
		
		private void pressElasp(Object myObject, EventArgs myEventArgs) 
		{
			btnInPressDown.Visible = false;
			tmrPress.Enabled = false;
			AnalogNumeric1.Fill = new BrushCF(Color.FromArgb(227,227,227));
			Globals.Tags.InletPressIndicator.Value = 0;
			Globals.CalAndUpdate.UpdateTestPressureTag();
			
		}
		
		void Button6_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tmrPress.Enabled = true;
			btnInPressDown.Visible = true;
			AnalogNumeric1.Fill = new BrushCF(Color.FromArgb(218,167,87));
			Globals.Tags.InletPressIndicator.Value = 1;
			Globals.CalAndUpdate.UpdateInletPressureTag();
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
			
		}
		

		

		void Button1_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tmrRcrdCount = 0;
			tmrRcrd.Interval = 1000;
			tmrRcrd.Tick += RcrdTimerTick;
			tmrRcrd.Enabled = true;
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
		}
		
		private void RcrdTimerTick(System.Object sender, System.EventArgs e)
		{
			tmrRcrdCount++;
		}
		
		
		
		private void ZeroCheckTimerTick(System.Object sender, System.EventArgs e)
		{
			switch(Globals.Tags.selMode.Value.Int)
			{
				case 0:
					if (Globals.Comm.PressSensors[1].CheckZeroPass())
					{
						Globals.Tags.MainDisplayMessage.Value = 3;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 6;
					}
					break;
				case 1:
					if (Globals.Comm.FlowMeters[0].CheckZeroPass())
					{
						Globals.Tags.MainDisplayMessage.Value = 1;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 4;
					}
					break;
				case 2:
					if (Globals.Comm.FlowMeters[1].CheckZeroPass())
					{
						Globals.Tags.MainDisplayMessage.Value = 21;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 22;
					}
					break;
				case 3:
					if (Globals.Comm.FlowMeters[2].CheckZeroPass())
					{
						Globals.Tags.MainDisplayMessage.Value = 2;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 5;
					}
					break;
			}
			tmrCheckZero.Enabled = false;
			
		}
		
		void Button1_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tmrRcrd.Tick -= RcrdTimerTick;
			tmrRcrd.Enabled = false;

			if ((int)Globals.Tags.USBStatus.Value == 0)
			{
				tmrRcrdCount = 0;
				Globals.Tags.MainDisplayMessage.Value = 15;
			}
			else
			{
				if (tmrRcrdCount >= 3)
				{
					tmrRcrdCount = 0;
					if (Globals.Tags.popRcrdShow.Value == 0)
					{
						Globals.Recording.CreatNewFile();
						Globals.Tags.RcrdStatus.Value = 1;
					}
					else
					{
						Globals.popRecordOptions.Show();
					}
				}
				else
				{	tmrRcrdCount = 0;
					Globals.Tags.RcrdStatus.Value = 0;
					Globals.Recording.CreatNewFile();
					Globals.Recording.RecordDataPoint();
					Globals.Recording.CloseDataFile();
					Globals.Tags.MainDisplayMessage.Value = 7;
				}
			}
		
			Globals.Tags.QuickFillMessageVisi.Value = 0;
		}
		
		void Button10_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Recording.CloseDataFile();
//			Button1.Visible = true;
//			Button10.Visible = false;
			Globals.Tags.RcrdStatus.Value = 0;
			Globals.Tags.MainDisplayMessage.Value = 10;
			
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
		}
		
		void btnInPressDown_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			tmrPress.Enabled = false;
			btnInPressDown.Visible = false;
			AnalogNumeric1.Fill = new BrushCF(Color.FromArgb(227,227,227));
			Globals.Tags.InletPressIndicator.Value = 0;
			Button6.Text = "Test" + Environment.NewLine + "Pressure";
			Globals.CalAndUpdate.UpdateTestPressureTag();
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
		}
		
		void btnZero_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
			switch(Globals.Tags.selMode.Value.Int)
			{
				case 0:
					if (Globals.Comm.PressSensors[1].CheckZero())
					{
						Globals.Tags.tmr485_control.Value = 13;
						tmrCheckZero.Enabled = true;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 13;
					}
					break;
				case 1:
					if (Globals.Comm.FlowMeters[0].CheckZero())
					{
						Globals.Tags.tmr232_control.Value = 3;
						tmrCheckZero.Enabled = true;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 11;
					}
					break;
				case 2:
					if (Globals.Comm.FlowMeters[1].CheckZero())
					{
						Globals.Tags.tmr232_control.Value = 4;
						tmrCheckZero.Enabled = true;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 23;
					}
					break;
				case 3:
					if (Globals.Comm.FlowMeters[2].CheckZero())
					{
						Globals.Tags.tmr232_control.Value = 5;
						tmrCheckZero.Enabled = true;
					}
					else
					{
						Globals.Tags.MainDisplayMessage.Value = 12;
					}
					break;
				
			}
			
			
		}
		
		void Button3_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
			
			if (Globals.Tags.wifiStreaming.Value == 1)
			{
				Globals.Tags.GeneralConfirmMsg.Value = "LRM currently is locked to main screen because remote client connected, do you want to disconnect first?";
				Globals.Tags.ConfirmAction.Value = 3;
				Globals.popConfirm.Show();
			}
			else
			{
				Globals.SettingScreen.Show();
			}
		}
		
		void Button5_Click(System.Object sender, System.EventArgs e)
		{
			if (Globals.Tags.QuickFillMessageVisi.Value.Int != 0)
			{
				Globals.Tags.QuickFillMessageVisi.Value = 0;
			}
			
			if (Globals.Tags.wifiStreaming.Value == 1)
			{
				Globals.Tags.GeneralConfirmMsg.Value = "LRM currently is locked to main screen because remote client connected, do you want to disconnect first?";
				Globals.Tags.ConfirmAction.Value = 3;
				Globals.popConfirm.Show();
			}
			else
			{
				Globals.StartScreen.Show();
			}
		}
		
		void MainScreen_Closed(System.Object sender, System.EventArgs e)
		{
			tmrPress.Enabled = false;
			tmrRcrd.Enabled = false;
			tmrCheckZero.Enabled = false;
		}
		
		


		
		
		
		
		
		
    }
}
