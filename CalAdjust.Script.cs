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
    
    public partial class CalAdjust
    {
		private int calType = 0;
		private int selectedUnit = 0;
		private Timer tmrPoll;
		private Timer tmrValveCtrl;
		private string Alicat25 = "SPAN 25%";
		private string Alicat100 = "SPAN 100%";
		private string PressSpan = "SPAN";
		private string PressOffset = "OFFSET";
		private bool sendChange = false;
		private bool sendZero = false;
		private Timer tmrCount;
		private int CountInt = 0;
		private double currentValue = 0;
		private double setValue = 0;
		private Timer tmrCalculator;
		private int ValveState = 0;
		private int direction = 0;
		
		void CalAdjust_Opened(System.Object sender, System.EventArgs e)
		{
			selectedUnit = 0;
			ValveState = 0;
			
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				btnToggle.Text = "TOGGLE" + Environment.NewLine + "25% / 100%";
				btnGasType.Visible = true;
				lblPara.Text = Alicat25;
				calType = 0;
				btnUnit.Text = Globals.TextLibrary.FlowUnit.Messages[selectedUnit].Message;
				
				lblTitle.Text = "Adjust " + Globals.TextLibrary.FlowMeterName.Messages[Globals.Tags.calSelMeter.Value.Int].Message + " Range Flow Meter";
			}
			else
			{
				btnToggle.Text = "TOGGLE SPAN/OFFSET";
				btnGasType.Visible = false;
				lblPara.Text = PressSpan;
				calType = 0;
				btnUnit.Text = Globals.TextLibrary.PressureUnit.Messages[selectedUnit].Message;
				
				
				lblTitle.Text = "Adjust " + Globals.TextLibrary.PressSensorName.Messages[Globals.Tags.calSelMeter.Value.Int - Globals.Comm.FlowMeters.Count].Message + " Pressure Sensor";
			}
			
			btnGasType.Text = Globals.TextLibrary.GasType.Messages[Globals.Tags.gasType.Value.Int].Message;
			lblValue.Text = "";
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
		
		
		private void COUNT_TICK(Object myObject, EventArgs myEventArgs) 
		{

			if (CountInt >= 0 && CountInt <= 10)
			{
				CountInt++;
			}
			if (CountInt > 10 && CountInt <= 100)
			{
				CountInt += 10;
			}
			else if (CountInt > 100)
			{
				CountInt += 100;
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
		
			private void POLL_TICK(Object myObject, EventArgs myEventArgs) 
			{
			if (lblValue.Text == "")
			{
				if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
				{
					if (calType == 0)
					{
						Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestPara(4);
					}
					else
					{
						Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestPara(5);
					}
				}
				else
				{

					if (calType == 0)
					{
						Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].RequestPara_ASC(2);
					}
					else
					{
						Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].RequestPara_ASC(3);
					}
				}
				
				Display();
			}
			else
			{
				if (sendZero)
				{
					if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
					{
						Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].Zero();
					}
					else
					{
						Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].Zero_ASC();
					}
					sendZero = false;
				}
				else if (sendChange)
				{		
					if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
					{
						Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestChange(calType + 4,setValue);
					}
					else
					{
						Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].RequestChange_ASC(calType + 2,setValue);
					}
					
					ResetCal();
					sendChange = false;
				}
				else
				{
					if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
					{
						Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].RequestData();
					
						double reading = Globals.UnitsAndConversion.FlowConv(Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].GetFlowRate(),(int)Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iMeterUnit, selectedUnit)
							* Globals.UnitsAndConversion.GetGasCoeff(Globals.Tags.gasType.Value.Int);
					
						lblReading.Text = Globals.CalAndUpdate.ConvertNumberToStr(reading, Globals.UnitsAndConversion.GetFlowMaxDecimal(Globals.Tags.calSelMeter.Value, selectedUnit));		
					
					}
					else
					{
						Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].SendToPort(PressRequestType.Read, PressDataType.Pressure);
					
						double reading = Globals.UnitsAndConversion.PressConv(Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].GetPress(),(int)Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].iUnit, selectedUnit);
					
					//	lblReading.Text = reading.ToString("F" + Globals.UnitsAndConversion.GetPressMaxDecimal(selectedUnit).ToString());
						
						lblReading.Text = Globals.CalAndUpdate.ConvertNumberToStr(reading, Globals.UnitsAndConversion.GetPressMaxDecimal(selectedUnit));		
					}
				}
			}
			
			
			}
		
			void Display()
			{	
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				if (calType == 0)
				{
					lblPara.Text = Alicat25;
					if (Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iParaResult[4].para_result != ParaStatus.NotAvailable)
					{
						currentValue = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iParaResult[4].para_value;
						lblValue.Text = currentValue.ToString();
					}
				}
				else
				{
					lblPara.Text = Alicat100;
					if (Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iParaResult[5].para_result != ParaStatus.NotAvailable)
					{
						currentValue = Globals.Comm.FlowMeters[Globals.Tags.calSelMeter.Value].iParaResult[5].para_value;
						lblValue.Text = currentValue.ToString();
					}
				}
				
				btnUnit.Text = Globals.TextLibrary.FlowUnit.Messages[selectedUnit].Message;
				
			}
			else
			{
				if (calType == 0)
				{
					lblPara.Text = PressSpan;
					if (Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].pResult[2].para_result != ParaStatus.NotAvailable)
					{
						currentValue = Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].pResult[2].para_value;
						lblValue.Text = currentValue.ToString("F5");
					}
				}
				else
				{
					lblPara.Text = PressOffset;
					if (Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].pResult[3].para_result != ParaStatus.NotAvailable)
					{
						currentValue = Globals.Comm.PressSensors[Globals.Tags.calSelMeter.Value - Globals.Comm.FlowMeters.Count].pResult[3].para_value;
						lblValue.Text = currentValue.ToString("F5");
					}
				}
				
				btnUnit.Text = Globals.TextLibrary.PressureUnit.Messages[selectedUnit].Message;
			}
			
			btnGasType.Text = Globals.TextLibrary.GasType.Messages[Globals.Tags.gasType.Value.Int].Message;
			}
		
		void ResetCal()
		{
			Globals.Comm.PressSensors[0].pResult[2].Reset();
			Globals.Comm.PressSensors[0].pResult[3].Reset();
			Globals.Comm.PressSensors[1].pResult[2].Reset();
			Globals.Comm.PressSensors[1].pResult[3].Reset();
			Globals.Comm.FlowMeters[0].iParaResult[4].Reset();
			Globals.Comm.FlowMeters[0].iParaResult[5].Reset();
			Globals.Comm.FlowMeters[1].iParaResult[4].Reset();
			Globals.Comm.FlowMeters[1].iParaResult[5].Reset();
			Globals.Comm.FlowMeters[2].iParaResult[4].Reset();
			Globals.Comm.FlowMeters[2].iParaResult[5].Reset();
			lblValue.Text = "";
		}
		
			void btnToggle_Click(System.Object sender, System.EventArgs e)
			{
				ResetCal();
				

				if (calType == 0)
				{
					calType = 1;
				}
				else
				{
					calType = 0;
				}
			Display();
			}
		
			void btnGasType_Click(System.Object sender, System.EventArgs e)
			{
				if (Globals.Tags.gasType.Value == 0)
				{
					Globals.Tags.gasType.Value = 1;
				}
				else
				{
					Globals.Tags.gasType.Value = 0;
				}
					
				Display();
			}
		
			void btnUnit_Click(System.Object sender, System.EventArgs e)
			{
			selectedUnit ++;
			
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				if (selectedUnit == Globals.TextLibrary.FlowUnit.Messages.Count)
				{
					selectedUnit = 0;
				}
			}
			else
			{
				if (selectedUnit == Globals.TextLibrary.PressureUnit.Messages.Count)
				{
					selectedUnit = 0;
				}
			}
			
			Display();
			}
		
			void btnZero_Click(System.Object sender, System.EventArgs e)
			{
			sendZero = true;
			
			}
		
			void btnUp_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
			CountInt = 1;
			direction = 0;
			Globals.Tags.calCalValueColor.Value = 1;
			tmrCount.Enabled = true;
			}
		
			void btnUp_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
			Globals.Tags.calCalValueColor.Value = 0;
			
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				setValue = currentValue + CountInt;
			}
			else
			{
				setValue = currentValue + (double)CountInt * 0.01;
			}
			sendChange = true;
			tmrCount.Enabled = false;
			
			}

		
			void btnDown_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
			CountInt = 1;
			direction = 1;
			Globals.Tags.calCalValueColor.Value = 1;
			tmrCount.Enabled = true;
			}
		
			void btnDown_MouseUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
			Globals.Tags.calCalValueColor.Value = 0;
			
			if (Globals.Tags.calSelMeter.Value < Globals.Comm.FlowMeters.Count)
			{
				setValue = currentValue - CountInt;
			}
			else
			{
				setValue = currentValue - (double)CountInt * 0.01;
			}
			
			sendChange = true;
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
		
			void lblPara_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
				OpenCalculator();
			}
		
			void Picture_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
				OpenCalculator();
			}
		
			void lblValue_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
				OpenCalculator();
			}
		
		void CalAdjust_Closed(System.Object sender, System.EventArgs e)
		{
			tmrPoll.Enabled = false;
			tmrCount.Enabled = false;
			tmrCalculator.Enabled = false;
			tmrValveCtrl.Enabled = false;
		}

		
		
	
		}
}
