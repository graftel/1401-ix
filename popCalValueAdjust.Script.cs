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
    
    
    public partial class popCalValueAdjust
    {
		private int reg_num = 0;
		
		private int[] reg_cmd_list;
		private string[] reg_name_list;
		
		private int current_reg_value = 0;
		
		private Timer tmrPoll;
		private Timer tmrValveCtrl;
		private Timer tmrCount;
		private Timer tmrCalculator;
		
		private int ValveState = 0;
		private int CountInt = 0;
		private double currentValue = 0;
		private double setValue = 0;
		private int direction = 0;
		
		private bool sendChange = false;
//		private bool sendZero = false;
		
		void popCalValueAdjust_Opened(System.Object sender, System.EventArgs e)
		{
			ResetGUI();
			switch(Globals.Tags.calRegType.Value.Int)
			{
				case 0:	// Temperature
					lblTitle.Text = "TEMPERATURE";
					lblTitle1.Text = "Pressure";
					lblTitle2.Text = "Vol Flow Rate";
					lblTitle3.Text = "Mass Flow Rate";
					reg_num = 1;
					reg_cmd_list = new int[reg_num];
					reg_cmd_list[0] = 6;
					
					reg_name_list = new string[reg_num];
					reg_name_list[0] = "OFFSET";
					break;
				case 1: // Pressure
					lblTitle.Text = "PRESSURE";
					lblTitle1.Text = "Temperature";
					lblTitle2.Text = "Vol Flow Rate";
					lblTitle3.Text = "Mass Flow Rate";
					reg_num = 2;
					reg_cmd_list = new int[reg_num];
					reg_cmd_list[0] = 8;
					reg_cmd_list[1] = 7;
					
					reg_name_list = new string[reg_num];
					reg_name_list[0] = "SPAN";
					reg_name_list[1] = "OFFSET";
					break;
			}
			
			Update_GUI();
			
			tmrPoll = new Timer();
			tmrPoll.Interval = 500;
			tmrPoll.Enabled = false;
			tmrPoll.Tick += POLL_TICK;
			tmrCount = new Timer();
			tmrCount.Interval = 200;
			tmrCount.Tick += COUNT_TICK;
			tmrCount.Enabled = false;
			tmrCalculator = new Timer();
			tmrCalculator.Enabled = false;
			tmrCalculator.Interval = 500;
			tmrCalculator.Tick += CAL_TICK;
			tmrValveCtrl = new Timer();
			tmrValveCtrl.Interval = 500;
			tmrValveCtrl.Enabled = true;
			tmrValveCtrl.Tick += VALVE_TICK;
			
			
		}
		
		void ResetGUI()
		{
			lblValue.Text = "";
			
			
			
		}
		void Update_GUI()
		{
			double tmpVolFlowRate,tmpMassFlowRate;
			
			btnToggle.Text = reg_name_list[current_reg_value];
			
			if (Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iParaResult[reg_cmd_list[current_reg_value]].para_result != ParaStatus.NotAvailable)
			{
				currentValue = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iParaResult[reg_cmd_list[current_reg_value]].para_value;
				lblValue.Text = currentValue.ToString();
			}
			
			switch(Globals.Tags.calRegType.Value.Int)
			{
				case 0:
					lblRdg.Text = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dTemp.ToString() + " °C";
					lblSubRdg1.Text = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dPressure.ToString() + " psia";
					
					tmpVolFlowRate = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dVolFlowRate * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
					lblSubRdg2.Text = tmpVolFlowRate.ToString() + " " + Globals.UnitsAndConversion.GetVolFlowRateUnits((int)Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iMeterUnit);
					
					tmpMassFlowRate =  Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dMassFlowRate * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
					lblSubRdg3.Text = tmpMassFlowRate.ToString() + " " + Globals.UnitsAndConversion.GetFlowRateUnits((int)Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iMeterUnit);
					break;
				case 1:
					lblRdg.Text = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dPressure.ToString() + " psia";
					lblSubRdg1.Text = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dTemp.ToString() + " °C";
					
					tmpVolFlowRate = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dVolFlowRate * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
					lblSubRdg2.Text = tmpVolFlowRate.ToString() + " " + Globals.UnitsAndConversion.GetVolFlowRateUnits((int)Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iMeterUnit);
					
					tmpMassFlowRate =  Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].dMassFlowRate * Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
					lblSubRdg3.Text = tmpMassFlowRate.ToString() + " " + Globals.UnitsAndConversion.GetFlowRateUnits((int)Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iMeterUnit);
					break;
			}	
		}
		
		private void COUNT_TICK(Object myObject, EventArgs myEventArgs) 
		{

			if (CountInt >= 0 && CountInt <= 10)
			{
				CountInt++;
			}
			else if (CountInt > 10 && CountInt <= 100)
			{
				CountInt += 10;
			}
			else if (CountInt > 100 && CountInt <= 1000)
			{
				CountInt += 100;
			}
			else if (CountInt > 1000 && CountInt <= 10000)
			{
				CountInt += 1000;
			}
			else if (CountInt > 10000)
			{
				CountInt += 10000;
			}
			
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				if (direction == 0)
				{	
					setValue = currentValue + CountInt;
				}
				else
				{
					setValue = currentValue - CountInt;
				}
				lblValue.Text = setValue.ToString();
			}
			else
			{
				if (direction == 0)
				{
					setValue = currentValue + (double)CountInt * 0.01;
				}
				else
				{
					setValue = currentValue - (double)CountInt * 0.01;
				}
				lblValue.Text = setValue.ToString("F5");
			}
			
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
			else if (Globals.Tags.calSelMeter.Value.Int == 3)
			{
				if (ValveState == 0)
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
					if (Globals.Comm.SolenoidValves[0].currentStatus != ValveStatus.Close)
					{
						Globals.Comm.SolenoidValves[0].Close_ASC();
					}
					else
					{
						tmrValveCtrl.Enabled = false;
						tmrPoll.Enabled = true;
					}
				}
			}
			else
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
			if (lblValue.Text == "")
			{
				Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestPara(reg_cmd_list[current_reg_value]);
			}
			else
			{
				if (sendChange)
				{		

					Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestChange(reg_cmd_list[current_reg_value],setValue);
				
					ResetGUI();
					sendChange = false;
				}
				else
				{
					Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestData();
				}
			}
			
			
			Update_GUI();
		}
		
		void btnToggle_Click(System.Object sender, System.EventArgs e)
		{
			ResetGUI();
			current_reg_value++;
			if (current_reg_value >= reg_num)
			{
				current_reg_value = 0;
			}
			Update_GUI();
		}
		
		void Button_Click(System.Object sender, System.EventArgs e)
		{
			Globals.popCalValueAdjust.Close();
		}
		
		private void CAL_TICK(Object myObject, EventArgs myEventArgs) 
		{
			if (Globals.Tags.Status_CalculatorScr.Value.Bool == false)
			{
				try{
					setValue = Double.Parse(Globals.Tags.Enter_Value.Value.String);
				}
				catch
				{
					setValue = 0;
				}
				sendChange = true;
				tmrCalculator.Enabled = false;
			}
		}
		
		
		void btnUp_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CountInt = 1;
			direction = 0;
			Globals.Tags.calCalValueColor.Value = 1;
			tmrPoll.Enabled = false;
			tmrCount.Enabled = true;
		}
		
		void btnUp_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.calCalValueColor.Value = 0;
			setValue = currentValue + CountInt;
			sendChange = true;
			tmrPoll.Enabled = true;
			tmrCount.Enabled = false;
		}
		
		void btnDown_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			CountInt = 1;
			direction = 1;
			Globals.Tags.calCalValueColor.Value = 1;
			tmrPoll.Enabled = false;
			tmrCount.Enabled = true;
		}
		
		void btnDown_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Globals.Tags.calCalValueColor.Value = 0;
			setValue = currentValue - CountInt;
			sendChange = true;
			tmrPoll.Enabled = true;
			tmrCount.Enabled = false;
		}
		
		void OpenCalculator()
		{
			Globals.Tags.CalculatorTargetScr.Value = 0;
			
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				Globals.Tags.Enter_Value.Value = currentValue.ToString();
			}
			else
			{
				Globals.Tags.Enter_Value.Value = currentValue.ToString("F5");
			}
			
			Globals.popCalculator.Show();
			tmrCalculator.Enabled = true;
		}
		
		void btnCal_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			OpenCalculator();
		}
		
		void lblValue_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			OpenCalculator();
		}
		
		void popCalValueAdjust_Closed(System.Object sender, System.EventArgs e)
		{
			tmrPoll.Enabled = false;
			tmrCount.Enabled = false;
			tmrCalculator.Enabled = false;
			tmrValveCtrl.Enabled = false;
		}
    }
}
