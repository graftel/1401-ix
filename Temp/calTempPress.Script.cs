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
    
    
    public partial class calTempPress
    {
		private Timer tmrPoll;
		private Timer tmrValveCtrl;
		private int ValveState = 0;
		
		void calTempPress_Opened(System.Object sender, System.EventArgs e)
		{
			tmrPoll = new Timer();
			tmrPoll.Interval = 500;
			tmrPoll.Enabled = false;
			tmrPoll.Tick += POLL_TICK;
			tmrValveCtrl = new Timer();
			tmrValveCtrl.Interval = 500;
			tmrValveCtrl.Enabled = true;
			tmrValveCtrl.Tick += VALVE_TICK;
			
			lblTitle.Text = "Temp/Pressure (" + Globals.TextLibrary.FlowMeterName.Messages[Globals.Tags.calSelMeter.Value.Int].Message + " Range Flow Meter)";
		}
		
		void calTempPress_Closed(System.Object sender, System.EventArgs e)
		{
			tmrValveCtrl.Enabled = false;
			tmrPoll.Enabled = false;
		}
		
		
		private void VALVE_TICK(Object myObject, EventArgs myEventArgs)
		{
			if (Globals.Tags.calSelMeter.Value.Int == 0)
			{
				if (ValveState == 0)
				{
					if (Globals.Comm.SolenoidValves[1].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[1].Close_ASC();
					}
					else
					{
						ValveState++;
					}
				}
				else if (ValveState == 1)
				{
					if (Globals.Comm.SolenoidValves[2].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[2].Close_ASC();
					}
					else
					{
						ValveState++;
					}
				}
				else if (ValveState == 2)
				{
					if (Globals.Comm.SolenoidValves[0].currentStatus != ValveStatus.Open)
					{
						Globals.Comm.SolenoidValves[0].Open_ASC();
					}
					else
					{
						tmrValveCtrl.Enabled = false;
						tmrPoll.Enabled = true;
					}
				}
			}
			else if (Globals.Tags.calSelMeter.Value.Int == 1)
			{
				if (ValveState == 0)
				{
					if (Globals.Comm.SolenoidValves[0].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[0].Close_ASC();
					}
					else
					{
						ValveState++;
					}
				}
				else if (ValveState == 1)
				{
					if (Globals.Comm.SolenoidValves[2].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[2].Close_ASC();
					}
					else
					{
						ValveState++;
					}
				}
				else if (ValveState == 2)
				{
					if (Globals.Comm.SolenoidValves[1].currentStatus != ValveStatus.Open)
					{
						Globals.Comm.SolenoidValves[1].Open_ASC();
					}
					else
					{
						tmrValveCtrl.Enabled = false;
						tmrPoll.Enabled = true;
					}
				}
			}
			else if (Globals.Tags.calSelMeter.Value.Int == 2)
			{
				if (ValveState == 0)
				{
					if (Globals.Comm.SolenoidValves[0].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[0].Close_ASC();
					}
					else
					{
						ValveState++;
					}
				}
				else if (ValveState == 1)
				{
					if (Globals.Comm.SolenoidValves[1].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[1].Close_ASC();
					}
					else
					{
						ValveState++;
					}
				}
				else if (ValveState == 2)
				{
					if (Globals.Comm.SolenoidValves[2].currentStatus != ValveStatus.Open)
					{
						Globals.Comm.SolenoidValves[2].Open_ASC();
					}
					else
					{
						tmrValveCtrl.Enabled = false;
						tmrPoll.Enabled = true;
					}
				}
			}
		}
		
		private void POLL_TICK(Object myObject, EventArgs myEventArgs) 
		{
	
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestData();
					
				Globals.Tags.calRawTemp.Value = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dTemp.ToString() + " °C";
				
				Globals.Tags.calRawPressure.Value = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dPressure.ToString() + " psia";
				
				Globals.Tags.calRawVolFlowRate.Value = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dVolFlowRate.ToString() + " " + Globals.UnitsAndConversion.GetFlowRateUnits((int)Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iMeterUnit);
				
				Globals.Tags.calRawMassFlowRate.Value = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dMassFlowRate.ToString() + " " + Globals.UnitsAndConversion.GetFlowRateUnits((int)Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iMeterUnit);
				
					
			}
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.GeneralConfirmMsg.Value = "Warning: Adjust Temperature of Flow Meter may affect flow rate readings, if you insist to adjust, please record the initial value.";
			
			Globals.Tags.ConfirmAction.Value = 5;
			
			Globals.popConfirm.Show();
		}
		
		void Button1_Click(System.Object sender, System.EventArgs e)
		{
			Globals.Tags.GeneralConfirmMsg.Value = "Warning: Adjust Pressure of Flow Meter may affect flow rate readings, if you insist to adjust, please record the initial value.";
			
			Globals.Tags.ConfirmAction.Value = 6;
			
			Globals.popConfirm.Show();
		}
		
    }
}
